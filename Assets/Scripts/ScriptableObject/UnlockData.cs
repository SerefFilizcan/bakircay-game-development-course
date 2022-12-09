using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Unlock Data", menuName = "ScriptableObjects/UnlockData", order = 1)]
public class UnlockData : ScriptableObject
{
    private const string UNLOCK_PLAYERPREF_KEY = "UNLOCK_PLAYERPREF_KEY:";
    public string unlockableName;

    public int price;
    public int RemainingPrice => price - CollectedPrice;
    public int CollectedPrice
    {
        get => PlayerPrefs.GetInt(UNLOCK_PLAYERPREF_KEY + unlockableName, 0);
        set => PlayerPrefs.SetInt(UNLOCK_PLAYERPREF_KEY + unlockableName, value);
    }

}
