using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWalkState : NMovementBaseState
{
    public override void EnterState(NMovementStateManager movement)
    {
        movement.anim.SetBool("Walking",true);
    }

    public override void UpdateState(NMovementStateManager movement)
    {
        if(Input.GetKey(KeyCode.LeftShift)) ExitState(movement,movement.run);
        else if(Input.GetKeyDown(KeyCode.C)) ExitState(movement,movement.crouch);
        else if(movement.dir.magnitude < 0.1f) ExitState(movement,movement.idle);

        if(movement.vInput <0) movement.currentMoveSpeed = movement.walkBackSpeed;
        else movement.currentMoveSpeed = movement.walkSpeed;
        if(Input.GetKeyDown(KeyCode.Space))
        {
            movement.previousState = this;
            ExitState(movement,movement.jump);
        }
        
    }

    void ExitState(NMovementStateManager movement, NMovementBaseState state)
    {
        movement.anim.SetBool("Walking",false);
        movement.SwitchState(state);
    }
}
