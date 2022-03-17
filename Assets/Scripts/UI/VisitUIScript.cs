using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitUIScript : UIParentScript
{
    Animator animator;
    public static VisitPlace visit;
    public static VisitUIScript current;
    public static int price;

    protected override void Start()
    {
        base.Start();
        current = this;

        animator = GetComponent<Animator>();
        canvas = GetComponent<Canvas>();
        EventSystem.current.OnStartVisitMode += StartVisit;
        EventSystem.current.OnEndVisitMode += EndVisit;
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

        StartCoroutine(VisitCoroutine());
    }

    IEnumerator VisitCoroutine()
    {
        RandomEventData randomEvent = ChooseRandomEvent();

        Debug.Log(randomEvent.eventText);

        canvas.enabled = true;
        Debug.Log("Visit Coroutine");


        yield return new WaitForSeconds(5f);
        EventSystem.current.EndVisitMode();
    }

    void EndVisit()
    {
        Debug.Log("End Visit");

        GameSystem.AddDay(1);
        GameSystem.playerMoney -= price;

        StartCoroutine(EndVisitCoroutine());
    }

    IEnumerator EndVisitCoroutine()
    {
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
        //Vérifie condition d'argent
        if(price <= randomEvent.moneyCondition)
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
