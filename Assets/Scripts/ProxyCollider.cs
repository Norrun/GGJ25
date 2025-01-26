using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProxyCollider : MonoBehaviour
{
    public Dictionary<Rigidbody,Vector3> rigidbodies = new Dictionary<Rigidbody, Vector3>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rigidbody ))
        {
            ;
            rigidbodies.Add(rigidbody, other.ClosestPointOnBounds(transform.position));
            Debug.Log(rigidbody);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rigidbody))
        {
            rigidbodies.Remove(rigidbody);
        }
    }

    
        
    
    

}
