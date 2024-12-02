using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NRunState : NMovementBaseState
{
    public override void EnterState(NMovementStateManager movement)
    {
        movement.anim.SetBool("Running",true);
    
    }

    public override void UpdateState(NMovementStateManager movement)
    {
        if(Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement,movement.walk);
        else if(movement.dir.magnitude < 0.1f) ExitState(movement,movement.idle);

        if(movement.vInput <0) movement.currentMoveSpeed = movement.runBackSpeed;
        else movement.currentMoveSpeed = movement.runSpeed;
    }

    void ExitState(NMovementStateManager movement, NMovementBaseState state)
    {
        movement.anim.SetBool("Running",false);
        movement.SwitchState(state);
    }
}
