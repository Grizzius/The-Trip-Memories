using UnityEngine;

[CreateAssetMenu(fileName = "Random Event data", menuName = "Create new random event data")]
public class RandomEventData : ScriptableObject
{
    public string eventTitle;
    [TextArea]
    public string eventText;

    public int moneyModifier;
}
