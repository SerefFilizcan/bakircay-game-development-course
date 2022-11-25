using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    public Vector3 rotateAxis = Vector3.up;
    public float speed = 10f;

    public bool startRandomRotation = false;

    private void Start()
    {
        if (startRandomRotation)
        { 
            transform.Rotate(rotateAxis * speed * Random.Range(0f,100f));
        }
    }

    private void Update()
    {
        transform.Rotate(rotateAxis * speed * Time.deltaTime);
    }

}
