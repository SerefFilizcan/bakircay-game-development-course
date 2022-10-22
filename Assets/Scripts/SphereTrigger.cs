using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTrigger : MonoBehaviour
{
    public GameObject WallObject;
    private float ClosedYValue = 3;
    private float OpenedYValue = 10;

    private bool isInside = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("BallStay");
            //WallObject.SetActive(false);
             
            isInside = true;


        }
    }
    private void FixedUpdate()
    {
        if (isInside == true)
        {
            isInside = false;


            Vector3 wallPosition = WallObject.transform.position;
            wallPosition.y = OpenedYValue;
            WallObject.transform.position = wallPosition;
        }
        else
        {
            Vector3 wallPosition = WallObject.transform.position;
            wallPosition.y = ClosedYValue;
            WallObject.transform.position = wallPosition;
        }
    }

     

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Ball"))
    //    {
    //        Debug.Log("BallEnter");
    //        //WallObject.SetActive(false);

    //        Vector3 wallPosition = WallObject.transform.position;
    //        wallPosition.y = OpenedYValue;
    //        WallObject.transform.position = wallPosition; 
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Ball"))
    //    {
    //        Debug.Log("BallExit");
    //        //WallObject.SetActive(false);

    //        Vector3 wallPosition = WallObject.transform.position;
    //        wallPosition.y = ClosedYValue;
    //        WallObject.transform.position = wallPosition;
    //    }

    //}


}
