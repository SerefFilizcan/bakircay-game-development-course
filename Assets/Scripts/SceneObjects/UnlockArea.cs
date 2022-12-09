using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UnlockArea : MonoBehaviour
{
    public UnlockData unlockableData;
    public TextMeshPro NameText;
    public TextMeshPro PriceText;
    public List<GameObject> ObjectsToUnlock = new List<GameObject>();
    

    private void OnEnable()
    {
        CheckUnlocked();
    }

    // Start is called before the first frame update
    void Start()
    { 
        ObjectsToUnlock.ForEach((x) => x.SetActive(false));
        //ObjectToUnlock.SetActive(false);
        NameText.text = "UNLOCK " + unlockableData.unlockableName.ToUpper();
        PriceText.text = unlockableData.RemainingPrice.ToString();  
    }

    public void Pay(Stashable stashable)
    {
        if (unlockableData.RemainingPrice <= 0)
            return;

        unlockableData.CollectedPrice++;
        stashable.PayStashable(transform, PaymentCompleted);
         
    }

    private void PaymentCompleted()
    {
        PriceText.text = unlockableData.RemainingPrice.ToString();

        CheckUnlocked();
    }

    private void CheckUnlocked()
    {
        if (unlockableData.RemainingPrice <= 0)
        {
            ObjectsToUnlock.ForEach((x) =>
            {
                x.transform.parent = null;
                x.SetActive(true);
            });

            gameObject.SetActive(false);
        }
    }
}
