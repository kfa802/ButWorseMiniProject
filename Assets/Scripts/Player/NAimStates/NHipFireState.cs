using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NHipFireState : NAimBaseState
{
    public override void EnterState(NAimStateManager aim)
    {
        aim.anim.SetBool("Aiming", false);
        aim.currentFov = aim.hipFov;

    }

    public override void UpdateState(NAimStateManager aim)
    {
        if(Input.GetKey(KeyCode.Mouse1)) aim.SwitchState(aim.Aim);
    }
}
