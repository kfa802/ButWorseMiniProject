using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NBullet : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    [HideInInspector] public NWeaponManager weapon;
    [HideInInspector] public Vector3 dir;
 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        Debug.DrawLine(transform.position, collision.contacts[0].point, Color.red, 2f);

        if(collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage(weapon.damage);

            if(enemyHealth.health <= 0 && enemyHealth.isDead == false)
            {
                Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
                rb.AddForce(dir * weapon.enemyKickbackForce, ForceMode.Impulse);
                enemyHealth.isDead = true;
            }
        }
        Destroy(this.gameObject);
    }

    
}
