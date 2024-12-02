using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NIdleState : NMovementBaseState
{
   public override void EnterState(NMovementStateManager movement)
    {
    
    }

  public override void UpdateState(NMovementStateManager movement)
    {
        if(movement.dir.magnitude > 0.1f)
        {
            if(Input.GetKey(KeyCode.LeftShift))movement.SwitchState(movement.run);
            else movement.SwitchState(movement.walk);
        }
        if(Input.GetKeyDown(KeyCode.C))movement.SwitchState(movement.crouch);
    
    }
}
