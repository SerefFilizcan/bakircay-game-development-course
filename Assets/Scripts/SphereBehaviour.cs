using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{
    public Transform targetCubeTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cubePosition = targetCubeTransform.position;
        cubePosition.y -= 1f;

        transform.position = cubePosition;

    }
}
