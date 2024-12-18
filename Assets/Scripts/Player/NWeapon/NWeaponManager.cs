using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]    
    [SerializeField] float fireRate;
    [SerializeField] bool semiAuto;
    float fireRateTimer;

    [Header("Bullet Properties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    public float damage = 20;
    NAimStateManager aim;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;
    NWeaponAmmo ammo;
    NWeaponBloom bloom;
    NActionStateManager actions;
    NWeaponRecoil recoil;

    Light muzzleFlashLight;
    ParticleSystem muzzleFlashParticles;
    float lightIntensity;
    [SerializeField] float lightReturnSpeed = 20;

    public float enemyKickbackForce = 100;

    // Start is called before the first frame update
    void Start()
    {
        recoil = GetComponent<NWeaponRecoil>();
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<NAimStateManager>();
        ammo = GetComponent<NWeaponAmmo>();
        bloom = GetComponent<NWeaponBloom>();
        actions = GetComponentInParent<NActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldfFire()) Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightReturnSpeed * Time.deltaTime);
        
    }

    bool ShouldfFire()
    {
        fireRateTimer += Time.deltaTime;
        if(fireRateTimer < fireRate) return false;
        if(ammo.currentAmmo == 0) return false;
        if(actions.currentState == actions.Reload) return false;
        if(semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if(!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
        barrelPos.localEulerAngles = bloom.BloomAngle(barrelPos);
        audioSource.PlayOneShot(gunShot);
        recoil.TriggerRecoil();
        TriggerMuzzleFlash();
        ammo.currentAmmo--;
        for(int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            NBullet bulletScript = currentBullet.GetComponent<NBullet>();
            bulletScript.weapon = this;

            bulletScript.dir = barrelPos.transform.forward;

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
