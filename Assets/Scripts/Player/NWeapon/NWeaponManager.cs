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
    NAimStateManager aim;

    [SerializeField] AudioClip gunShot;
    AudioSource audioSource;
    NWeaponAmmo ammo;
    NActionStateManager actions;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<NAimStateManager>();
        ammo = GetComponent<NWeaponAmmo>();
        actions = GetComponentInParent<NActionStateManager>();
        fireRateTimer = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(ShouldfFire()) Fire();
        Debug.Log(ammo.currentAmmo);
        
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
        audioSource.PlayOneShot(gunShot);
        ammo.currentAmmo--;
        for(int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
        
    }


}
