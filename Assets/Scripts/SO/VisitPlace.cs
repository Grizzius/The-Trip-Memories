using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Visit", menuName = "Create new visit")]
public class VisitPlace : ScriptableObject
{
    public string visitName;
    [TextArea]
    public string VisitDescription;
    [Min(0)]
    public int minPrice;
    public int maxPrice;
    public int DefaultFunValue;
    public RandomEvent[] randomEvents;

    public void OnValidate()
    {
        if(maxPrice < minPrice)
        {
            maxPrice = minPrice;
        }
        else if(minPrice > maxPrice)
        {
            maxPrice = minPrice;
        }
    }
}

[System.Serializable]
public class RandomEvent
{
    public RandomEventData randomEventData;
    [Range(1,100)]
    public int probability = 50;
}
