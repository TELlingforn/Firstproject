using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollState : FSMState
{
    public RollState(int stateID, MonoBehaviour mono, FSMManger manger) : base(stateID, mono, manger)
    {
    }

    public override void OnEnter()
    {
        Mono.GetComponent<Animator>().SetTrigger("RollTrigger");
    }

    public override void OnUpdate()
    {
        if (!Mono.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Roll"))
        {
            //切换回来站立
            FsmManger.ChangeState((int)PlayerState.idle);
        }
    }
}
