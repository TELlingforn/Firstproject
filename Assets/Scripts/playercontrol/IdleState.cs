using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IdleState : FSMState
{
    public IdleState(int stateID, MonoBehaviour mono, FSMManger manger) : base(stateID, mono, manger)
    {
        
    }

    public override void OnEnter()
    {
        //播放idle
        Mono.GetComponent<Animator>().SetBool("ISWalking",false);
    }

    public override void OnUpdate()
    {
        //监听是否变为跑步
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 m_Moverment = new Vector3(horizontal, 0, vertical);
        m_Moverment.Serialize();

        if (m_Moverment != Vector3.zero)
        {
            FsmManger.ChangeState((int)PlayerState.run);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            FsmManger.ChangeState((int)PlayerState.roll);
        }
    }
}
