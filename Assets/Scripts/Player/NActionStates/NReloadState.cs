using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NReloadState : NActionBaseState
{
    public override void EnterState(NActionStateManager actions)
    {
        actions.rHandAim.weight = 0;
        actions.lHandIK.weight = 0;
        actions.anim.SetTrigger("Reload");

    }

    public override void UpdateState(NActionStateManager actions)
    {

       
    }
   
}
