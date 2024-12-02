using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCrouchState : NMovementBaseState
{
    public override void EnterState(NMovementStateManager movement)
    {
        movement.anim.SetBool("Crouching",true);
    
    }

    public override void UpdateState(NMovementStateManager movement)
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) ExitState(movement,movement.run);
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(movement.dir.magnitude < 0.1f) ExitState(movement,movement.idle);
            else ExitState(movement,movement.walk);
        }

        if(movement.vInput <0) movement.currentMoveSpeed = movement.crouchBackSpeed;
        else movement.currentMoveSpeed = movement.crouchSpeed;
    
    }
    void ExitState(NMovementStateManager movement, NMovementBaseState state)
    {
        movement.anim.SetBool("Crouching",false);
        movement.SwitchState(state);
    }
}
