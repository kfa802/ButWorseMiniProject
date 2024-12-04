using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public NWeaponManager weapon;
 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(weapon.damage);
        }
        Destroy(this.gameObject);
    }
}
