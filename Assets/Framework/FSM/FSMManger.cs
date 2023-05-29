using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMManger
//是一个管理类,但是可以有多个,所以不是单例了
//状态机
{
    //状态列表
    public List<FSMState> StateList = new List<FSMState>();
    //当前状态
    public int CurrentIndex = -1;
    
    //改变状态
    public void ChangeState(int StateID)
    {
        CurrentIndex = StateID;
        //执行一次该状态的进入方法
        StateList[CurrentIndex].OnEnter();
    }
    
    //更新
    public void Update()
    {
        if (CurrentIndex != -1)
        {
            StateList[CurrentIndex].OnUpdate();
        }
    }
    
}
