using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VagonMovement : MonoBehaviour
{
    public LocomotiveMovement locomotive;
    public float offset = -0.035f;
  
    // Update is called once per frame
    void Update()
    {
        if (locomotive == null)
            return;

        var timeTravelled = locomotive.GetCurrentTimeTravelled() + offset;
        transform.position = locomotive.pathCreator.path.GetPointAtTime(timeTravelled, locomotive.endOfPathInstruction);
        transform.rotation = locomotive.pathCreator.path.GetRotation(timeTravelled, locomotive.endOfPathInstruction);

    }
}
