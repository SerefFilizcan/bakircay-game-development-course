using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Stash))]
public class Collector : MonoBehaviour
{ 
    private Stash _stash;

    private void Awake()
    {
        _stash = GetComponent<Stash>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {             
            if (other.TryGetComponent(out Collectable collected))
            {
                _stash.AddStash(collected); 
            }   
        } 
    }
     
}
