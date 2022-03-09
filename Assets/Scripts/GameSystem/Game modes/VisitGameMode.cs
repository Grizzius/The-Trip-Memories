using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitGameMode : GameMode
{
    VisitUIScript visitUI;
    GameSystem gameSystem;
    VisitPlace visit;

    public VisitGameMode(VisitPlace Visit)
    {
        visit = Visit;
    }

    public override void Start()
    {
        visitUI = Object.FindObjectOfType<VisitUIScript>();
        visitUI.TriggerAnim("FadeIn");

        gameSystem = Object.FindObjectOfType<GameSystem>();

        gameSystem.StartCoroutine(StartVisit(visit));
    }

    public override void Update()
    {

    }

    IEnumerator StartVisit(VisitPlace visit)
    {
        yield return new WaitForSeconds(1);
        Debug.Log("RandomEvent");
        yield return new WaitForSeconds(1);

        GameSystem.AddDay(1);

        EventSystem.current.EndVisitMode();

        GameSystem.SetMode(new DefaultMode());
    }
}
