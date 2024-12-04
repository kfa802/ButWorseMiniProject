using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NWeaponBloom : MonoBehaviour
{
    [SerializeField] float defaultBloomAngle = 3;
    [SerializeField] float walkBloomMultiplier = 1.5f;
    [SerializeField] float crouchBloomMultiplier = 0.5f;
    [SerializeField] float sprintBloomMultiplier = 2f;
    [SerializeField] float adsBloomMultiplier = 0.5f;

    NMovementStateManager movement;
    NAimStateManager aiming;

    float currentBloom;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<NMovementStateManager>();
        aiming = GetComponentInParent<NAimStateManager>();
        
    }

    public Vector3 BloomAngle(Transform barrelPos)
    {
        if(movement.currentState == movement.idle) currentBloom = defaultBloomAngle;
        else if (movement.currentState == movement.walk) currentBloom = defaultBloomAngle * walkBloomMultiplier;
        else if (movement.currentState == movement.run) currentBloom = defaultBloomAngle * sprintBloomMultiplier;
        else if (movement.currentState == movement.crouch)
        {
            if(movement.dir.magnitude == 0) currentBloom = defaultBloomAngle * crouchBloomMultiplier;
            else currentBloom = defaultBloomAngle * crouchBloomMultiplier * walkBloomMultiplier;
        }

        if(aiming.currentState == aiming.Aim) currentBloom *= adsBloomMultiplier;     

        float randX = Random.Range(-currentBloom, currentBloom);
        float randY = Random.Range(-currentBloom, currentBloom);
        float randZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randX, randY, randZ);
        return barrelPos.localEulerAngles + randomRotation;
    }

    
}
