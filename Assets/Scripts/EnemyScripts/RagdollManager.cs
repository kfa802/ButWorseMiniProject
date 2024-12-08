using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    Rigidbody[] rigidbodies;
    // Start is called before the first frame update
    void Start()
    {
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = true;
        }
    }

    public void TriggerRagdoll()
    {
        foreach(Rigidbody rb in rigidbodies)
        {
            rb.isKinematic = false;
        }
    }
}
