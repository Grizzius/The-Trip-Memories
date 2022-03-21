using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Random Event data", menuName = "Create new random event data")]
public class RandomEventData : ScriptableObject
{
    public string eventTitle;
    [TextArea]
    public string eventText;

    public int moneyModifier;
    public int luckModifier;
    public int knowledgeModifier;
    public int memoryModifier;

    public TriggerModifier[] triggerModifiers;

    [Header("Conditions")]
    public int moneyCondition;
    public Day[] openDays;
    public List<Trigger> triggers;

    public ProbabilityType probabilityType;
    public AnimationCurve curve;
}

public enum ProbabilityType
{
    Default,
    Luck,
    Knowledge
}

public enum EventTriggerType
{
    Cancels,
    Necessary
}

[System.Serializable]
public class Trigger
{
    public EventTriggerType triggerType;
    public int triggerID;
}

[System.Serializable]
public class TriggerModifier
{
    public bool value;
    public int ID;
}