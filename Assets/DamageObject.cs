using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlayDamageObject : MonoBehaviour
{
    public int damageAmount = 10;

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); // or Heal for heal objects
        }
    }
}
