using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public Transform stashParent;

    public List<GameObject> CollectedObjects = new List<GameObject>();
     
    public float collectionHeight = 1;
    public int MaxCollectableCount = 5;

    public int CollectedCount => CollectedObjects.Count;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            if (CollectedCount >= MaxCollectableCount)
                return;
             
            if (other.TryGetComponent(out Collectable collected))
            {
                StartCoroutine(CollectCoroutine(collected)); 

            } 
        }



    }

    private IEnumerator CollectCoroutine(Collectable collected)
    {
        var stashable = Instantiate(collected.stashablePrefab, null);
        stashable.transform.position = collected.transform.position + Vector3.up * 1.5f;

        Destroy(collected.gameObject);

        var yLocalPosition = CollectedCount * collectionHeight;

        CollectedObjects.Add(stashable);

        yield return null;
         
        float currentTime = 0;
        float completeTime = 1f;

        Vector3 startPos = stashable.transform.position;

        while (currentTime < completeTime)
        {
            currentTime += Time.deltaTime;

            var targetPos = stashParent.position + Vector3.up * yLocalPosition;

            targetPos += Vector3.Lerp(Vector3.up * 7f, Vector3.zero, currentTime / completeTime);

            stashable.transform.position = Vector3.Lerp(startPos, targetPos, currentTime / completeTime);

            yield return null;
        }

        stashable.transform.parent = stashParent;
        stashable.transform.localPosition = Vector3.up * yLocalPosition;
        stashable.transform.localRotation = Quaternion.identity;




    }
}
