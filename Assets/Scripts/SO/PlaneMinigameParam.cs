﻿using UnityEngine;

[CreateAssetMenu(fileName = "new parameter", menuName = "Plane minigame parameter")]
public class PlaneMinigameParam : ScriptableObject
{
    public string minigameName;
    [TextArea]
    public string minigameGuide;

    public EnemyPlane planeTemplate;
    public Montgolfière montgolfièreTemplate;

    public int duration;

    public float initialSpawnDelay;
}
