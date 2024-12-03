using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class NJumpState : NMovementBaseState
{
    public override void EnterState(NMovementStateManager movement)
    {
        if(movement.previousState == movement.idle) movement.anim.SetTrigger("IdleJump");
        else if(movement.previousState == movement.walk || movement.previousState == movement.run) movement.anim.SetTrigger("RunJump");   
    }
    public override void UpdateState(NMovementStateManager movement)
    {
        
    }
}
