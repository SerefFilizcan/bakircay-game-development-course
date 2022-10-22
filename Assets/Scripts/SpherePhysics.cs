using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePhysics : MonoBehaviour
{
    public Color collisionColor;

    public Rigidbody sphereRB;
    public Vector3 ForceValue;

    // Start is called before the first frame update
    void Start()
    {
        //sphereRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {

            sphereRB.AddForce(ForceValue, ForceMode.VelocityChange);

        }

    }

    private void OnCollisionEnter(Collision collision)
    {


        if (collision.collider.CompareTag("Wall"))
        {
            Renderer sphereRenderer = GetComponent<Renderer>();
            sphereRenderer.material.color = collisionColor;
        }

    }

}
