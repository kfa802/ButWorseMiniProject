using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NActionStateManager : MonoBehaviour
{
    [HideInInspector] public NActionBaseState currentState;
    public NReloadState Reload = new NReloadState();
    public NDefualtState Default = new NDefualtState();
    public GameObject currentWeapon;
    [HideInInspector] public NWeaponAmmo ammo;
    AudioSource audioSource;

    [HideInInspector] public Animator anim;

    public MultiAimConstraint rHandAim;
    public TwoBoneIKConstraint lHandIK;

    // Start is called before the first frame update
    void Start()
    {
        SwitchState(Default);
        ammo = currentWeapon.GetComponent<NWeaponAmmo>();
        audioSource = currentWeapon.GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        
    }

    public void SwitchState(NActionBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    public void WeaponReloaded()
    {
        ammo.Reload();
        SwitchState(Default);
    }
    public void MagOut()
    {
        audioSource.PlayOneShot(ammo.magOutSound);

    }
    public void MagIn()
    {
        audioSource.PlayOneShot(ammo.magInSound);

    }
    public void ReleaseSlide()
    {
        audioSource.PlayOneShot(ammo.releaseSlideSound);
    }
}
