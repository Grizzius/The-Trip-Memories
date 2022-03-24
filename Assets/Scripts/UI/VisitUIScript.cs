using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisitUIScript : UIParentScript
{
    Animator animator;
    public int randomEventUI_ID;
    public static VisitPlace visit;
    public static VisitUIScript current;
    public static int price;
    public Image paint; 

    protected override void Start()
    {
        base.Start();
        current = this;

        animator = GetComponent<Animator>();
        canvas = GetComponent<Canvas>();
        EventSystem.current.OnStartVisitMode += StartVisit;
        EventSystem.current.OnCloseRandomEventTab += EndVisit;
    }

    public void TriggerAnim(string trigger)
    {
        Debug.Log("Start Animation " + trigger);
        animator.SetTrigger(trigger);
    }

    void StartVisit(VisitPlace visit)
    {
        TriggerAnim("FadeIn");
        Debug.Log("Start visit");
        ZoomInUI.current.CloseTab();
        canvas.enabled = true;
        paint.sprite = visit.paint;

        StartCoroutine(VisitCoroutine());
    }

    IEnumerator VisitCoroutine()
    {
        RandomEventData randomEvent = ChooseRandomEvent();
        if(randomEvent != null)
        {
            Debug.Log(randomEvent.eventTitle);

            RandomEventUI.current.randomEvent = randomEvent;

            //Apply random event modifiers
            GameSystem.playerMoney += randomEvent.moneyModifier;
            GameSystem.playerLuck += randomEvent.luckModifier;
            GameSystem.playerKnowledge += randomEvent.knowledgeModifier;

            foreach(TriggerModifier modifier in randomEvent.triggerModifiers)
            {
                GameSystem.EventTriggers[modifier.ID] = modifier.value;
            }

            yield return new WaitForSeconds(2f);
            PlayerScript.SetState(new PlayerRoomState(PlayerScript.current));
            print("Ca marche jusque là");
            OpenRandomEventUI();
        }
        else
        {
            yield return new WaitForSeconds(2f);
            EndVisit();
        }
        
    }

    void OpenRandomEventUI()
    {
        print("Open Random Event UI");
        EventSystem.current.OpenUI(randomEventUI_ID);
    }

    void EndVisit()
    {
        Debug.Log("End Visit");

        GameSystem.AddDay(1);

        StartCoroutine(EndVisitCoroutine());
    }

    IEnumerator EndVisitCoroutine()
    {
        EventSystem.current.EndVisitMode();
        TriggerAnim("FadeOut");
        yield return new WaitForSeconds(1f);
        canvas.enabled = false;
    }

    RandomEventData ChooseRandomEvent()
    {
        //Crée une liste des random events qui peuvent arriver
        List<RandomEventData> randomEventList = new List<RandomEventData>();

        print(visit);
        foreach(RandomEventData randomEvent in visit.randomEventDatas)
        {
            //Ajoute le random event à la liste s'il est disponible
            if (IsRandomEventAvailable(randomEvent))
            {
                randomEventList.Add(randomEvent);
            }
        }

        //Somme des probabilités de random event
        float maxValue = 0f;
        foreach (RandomEventData randomEvent in randomEventList)
        {
            maxValue += GetEventProbabilityWeight(randomEvent);
        }

        //Choisi un event au hasard

        float randomIndex = Random.Range(0f, maxValue);
        float f = 0;

        foreach (RandomEventData randomEvent in randomEventList)
        {
            if( f + GetEventProbabilityWeight(randomEvent) > randomIndex)
            {
                return randomEvent;
            }
            else
            {
                f += GetEventProbabilityWeight(randomEvent);
            }
        }
        return null;
    }

    bool IsRandomEventAvailable(RandomEventData randomEvent)
    {
        //Vérifie les conditions de trigger
        foreach(Trigger trigger in randomEvent.triggers)
        {
            if (GameSystem.EventTriggers[trigger.triggerID])
            {
                switch (trigger.triggerType)
                {
                    case EventTriggerType.Cancels:
                        return false;
                    case EventTriggerType.Necessary:
                        break;
                }
            }
            
        }
        //Vérifie condition d'argent
        if(price < randomEvent.moneyCondition)
        {
            
            return false;
        }

        //Vérifie jour d'ouverture
        foreach(Day day in randomEvent.openDays)
        {
            if (day == GameSystem.date.weekDay)
            {
                return true;
            }
        }
        return false;
    }

    float GetEventProbabilityWeight(RandomEventData randomEvent)
    {
        switch (randomEvent.probabilityType)
        {
            case ProbabilityType.Default:
                return randomEvent.curve.Evaluate(0.5f);
            case ProbabilityType.Knowledge:
                return randomEvent.curve.Evaluate(GameSystem.playerKnowledge/100);
            case ProbabilityType.Luck:
                return randomEvent.curve.Evaluate(GameSystem.playerLuck/100);
        }
        return 0f;
    }
}
