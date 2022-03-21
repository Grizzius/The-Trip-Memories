using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Travel", menuName = "Create new travel")]
public class Voyage : ScriptableObject
{
    public string destinationName;
    public TransportType transportType;
    public int travelTime;
    public int cost;
    [Space]
    public string destinationSceneName;
}

public enum TransportType
{
    voiture,
    avion
}
