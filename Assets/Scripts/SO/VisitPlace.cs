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
    public RandomEventData[] randomEventDatas;
    public VisitType visitType;
    public Sprite paint;

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

public enum VisitType
{
    Hiking,
    Monument,
}
