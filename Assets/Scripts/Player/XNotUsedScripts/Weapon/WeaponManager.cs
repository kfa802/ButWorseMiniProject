using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float firerate;
    [SerializeField] bool SemiAuto;
    float fireRateTimer;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletPerShot;
    NAimStateManager aim;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;
    WeaponAmmo ammo;
    WeaponBloom bloom;
    //ActionStateManager actions;
    WeaponRecoil recoil;

    Light muzzleFlashLight;
    ParticleSystem muzzleFlashParticles;
    float lightIntensity;
    [SerializeField] float lightReturnSpeed = 20f;


   
    // Start is called before the first frame update
    void Start()
    {
        recoil = GetComponent<WeaponRecoil>();
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<NAimStateManager>();
        ammo = GetComponent<WeaponAmmo>();
        bloom = GetComponent<WeaponBloom>();
        //actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        fireRateTimer = firerate;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldFire()) Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, Time.deltaTime * lightReturnSpeed);
        Debug.Log(ammo.currentAmmo);
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if(fireRateTimer < firerate) return false;
        if(ammo.currentAmmo == 0) return false;
        //if(actions.currentState == actions.Reload) return false;
        if(SemiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if(!SemiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;

    }
    void Fire()
    {
        fireRateTimer = 0;
        ammo.currentAmmo--;

        barrelPos.LookAt(aim.aimPos);
        barrelPos.localEulerAngles = bloom.BloomAngle(barrelPos);

        audioSource.PlayOneShot(gunShot);
        recoil.TriggerRecoil();
        TriggerMuzzleFlash();
       
        for(int i = 0; i < bulletPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
        
    }
    void TriggerMuzzleFlash()
    {
        muzzleFlashParticles.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}
