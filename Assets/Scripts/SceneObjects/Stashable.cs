using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stashable : MonoBehaviour
{
    public void CollectStashable(Transform stashParent, float yLocalPosition, Action onCompleteCollect)
    {
        var completionRadius = .5f;
        var speed = 150f;
        var targetPos = stashParent.position + Vector3.up * yLocalPosition;
        Tweener tweener = transform.DOMove(targetPos, speed).SetSpeedBased(true);
        tweener.OnUpdate(delegate () {
            transform.LookAt(stashParent, Vector3.up);

            // if the tween isn't close enough to the target, set the end position to the target again
            if (Vector3.Distance(transform.position, targetPos) > completionRadius)
            {
                targetPos = stashParent.position + Vector3.up * yLocalPosition; 
                tweener.ChangeEndValue(targetPos, true);
            }

        }).OnComplete(() => {
            transform.parent = stashParent;
            transform.localPosition = Vector3.up * yLocalPosition;
            transform.localRotation = Quaternion.identity;
            onCompleteCollect?.Invoke();
        });
        //StartCoroutine(CollectCoroutine(stashParent, yLocalPosition, onCompleteCollect));
    }
    //private IEnumerator CollectCoroutine(Transform stashParent, float yLocalPosition, Action onCompleteCollect)
    //{   
    //    yield return null; 
    //    //float currentTime = 0;
    //    //float completeTime = 1f;

    //    //Vector3 startPos = transform.position;

    //    //while (currentTime < completeTime)
    //    //{
    //    //    currentTime += Time.deltaTime;

    //    //    var targetPos = stashParent.position + Vector3.up * yLocalPosition;

    //    //    targetPos += Vector3.Lerp(Vector3.up * 7f, Vector3.zero, currentTime / completeTime);

    //    //    transform.position = Vector3.Lerp(startPos, targetPos, currentTime / completeTime);

    //    //    yield return null;
    //    //}  
    //}

    public void PayStashable(Transform target, Action onCompletePay)
    {
        transform.parent = null;

        Vector3 targetPos = target.position;
        Vector3 direction = targetPos - transform.position;
        direction.y = 0;

        var middlePos = transform.position + direction / 2f;
        middlePos.y = transform.position.y + 2f;
        var duration = 0.3f;

        transform.DOPath(new Vector3[] { middlePos, targetPos }, duration, PathType.CatmullRom)
                    .OnComplete(() =>
                    {
                        onCompletePay?.Invoke();
                        Destroy(gameObject);
                    }); 

    }

}
