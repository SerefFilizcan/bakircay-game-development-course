using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float Speed = 5f;

    public Vector3 startPosition;
    public Vector3 startScale;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 position = transform.position;

            position.z += Speed * Time.deltaTime;

            transform.position = position;

        }

    }
}
