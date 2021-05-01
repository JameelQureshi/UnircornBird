using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockItem : MonoBehaviour
{
    Collider[] colliders;
    Rigidbody[] rigidbodies;

    // Start is called before the first frame update
    void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        //Invoke(nameof(EnableCollision), 3);
    }

    public void EnableCollision()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.useGravity = true;
        }
        //Invoke(nameof(DestroyRock), 5);
    }

    void DestroyRock()
    {
        Destroy(gameObject);
    }
}
