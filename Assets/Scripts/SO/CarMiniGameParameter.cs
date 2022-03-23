using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new car param", menuName = "Create new car minigame parameter")]
public class CarMiniGameParameter : ScriptableObject
{
    public string miniGameName;
    [TextArea]
    public string miniGameGuide;
}
