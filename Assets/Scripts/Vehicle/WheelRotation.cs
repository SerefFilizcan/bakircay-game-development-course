using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotation : MonoBehaviour
{
    public Vector3 axis = Vector3.up; 

    private float _movementSpeed = 1f;
    public void SetSpeed(float movementSpeed)
    {
        _movementSpeed = movementSpeed; 
    } 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * _movementSpeed * axis);
    }
}
