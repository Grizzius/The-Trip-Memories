using UnityEngine;

[CreateAssetMenu(fileName = "new parameter", menuName = "Plane minigame parameter")]
public class PlaneMinigameParam : ScriptableObject
{
    public EnemyPlane planeTemplate;
    public Montgolfière montgolfièreTemplate;

    public int duration;
}
