using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitUIScript : UIParentScript
{
    Animator animator;
    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        EventSystem.current.OnStartVisitMode += StartVisit;
    }

    public void TriggerAnim(string trigger)
    {
        animator.SetTrigger(trigger);
    }

    void StartVisit(VisitPlace visit)
    {
        TriggerAnim("FadeIn");
    }
}
