using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    //当前状态id
    public int StateID;
    //状态拥有者
    public MonoBehaviour Mono;
    //状态所属管理器
    public FSMManger FsmManger;
    

    public FSMState(int stateID, MonoBehaviour mono, FSMManger manger)
    {
        StateID = stateID;
        Mono = mono;
        FsmManger = manger;
    }
    
    //进入状态,调用一次该方法
    public abstract void OnEnter();
    //在状态中,每帧调用
    public abstract void OnUpdate();
}
