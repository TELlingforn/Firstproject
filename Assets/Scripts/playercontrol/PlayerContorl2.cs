using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    run,
    roll
}
public class PlayerContorl2 : MonoBehaviour
{
    private FSMManger FsmManger;

    public int turnspeed=20;
    

    public int moveSpeed=1;

    private IdleState Idle;

    private RunState run;

    private RollState roll;
    // Start is called before the first frame update
    void Start()
    {
        FsmManger = new FSMManger();
         Idle = new IdleState(0, this, FsmManger);
         run = new RunState(1, this, FsmManger);
         roll = new RollState(2, this, FsmManger);
        run.turnSpeed = turnspeed;
        run.moveSpeed = moveSpeed;
        FsmManger.StateList.Add(Idle);
        FsmManger.StateList.Add(run);
        FsmManger.StateList.Add(roll);
        
        FsmManger.ChangeState((int)PlayerState.idle);
    }

    // Update is called once per frame
    void Update()
    {
        FsmManger.Update();
    }

    private void OnAnimatorMove()
    {
       run.onanimove();
    }
}
