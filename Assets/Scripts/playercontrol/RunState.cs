using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RunState : FSMState
{ 
    Quaternion m_Quaternion=Quaternion.identity;
    private Vector3 m_Moverment;
    public int turnSpeed;
    public int moveSpeed;
    public RunState(int stateID, MonoBehaviour mono, FSMManger manger) : base(stateID, mono, manger)
    {
       
    }

    public override void OnEnter()
    {
        Mono.GetComponent<Animator>().SetBool("ISWalking",true);
    }

    public override void OnUpdate()
    {
        //监听是否变为跑步
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
         m_Moverment = new Vector3(horizontal, 0, vertical);
        m_Moverment.Serialize();

        if (m_Moverment != Vector3.zero)
        {
            Vector3 desirForward = Vector3.RotateTowards(Mono.transform.forward, m_Moverment, turnSpeed * Time.deltaTime, 0f);
             m_Quaternion = Quaternion.LookRotation((desirForward));
        }
        else
        {
            FsmManger.ChangeState((int)PlayerState.idle);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FsmManger.ChangeState((int)PlayerState.roll);
        }
    }

    public void onanimove()
    {
        Rigidbody m_rigidbody = Mono.GetComponent<Rigidbody>();
        m_rigidbody.MovePosition(m_rigidbody.position+m_Moverment*Mono.GetComponent<Animator>().deltaPosition.magnitude*moveSpeed);
        m_rigidbody.MoveRotation(m_Quaternion);
    }
}
