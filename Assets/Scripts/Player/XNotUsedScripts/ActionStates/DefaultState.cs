using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class DefaultState : ActionBaseState
{
   public override void EnterState(ActionStateManager actions)
    {
        actions.RightHandAim.weight = 1;
        actions.LeftHandIK.weight = 1;
        
    }

    public override void UpdateState(ActionStateManager actions)
    {
        actions.RightHandAim.weight = Mathf.Lerp(actions.RightHandAim.weight, 1, Time.deltaTime * 10);
        actions.LeftHandIK.weight = Mathf.Lerp(actions.LeftHandIK.weight, 1, Time.deltaTime * 10);

        if(Input.GetKeyDown(KeyCode.R) && CanReload(actions))
        {
            actions.SwitchState(actions.Reload);
        }
        
    }

    bool CanReload(ActionStateManager action)
    {
        if(action.ammo.currentAmmo == action.ammo.clipSize) return false;
        else if(action.ammo.extraAmmo == 0) return false;
        else return true;
    }
}*/
