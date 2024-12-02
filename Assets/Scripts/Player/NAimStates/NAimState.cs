using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NAimState : NAimBaseState
{
   public override void EnterState(NAimStateManager aim)
    {
        aim.anim.SetBool("Aiming", true);
        aim.currentFov = aim.adsFov;
    }

    public override void UpdateState(NAimStateManager aim)
    {
        if(Input.GetKeyUp(KeyCode.Mouse1)) aim.SwitchState(aim.Hip);
    }
}
