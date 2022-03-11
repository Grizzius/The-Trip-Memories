using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitDoor : Clickable
{
    public VisitPlace visit;

    protected override void Start()
    {
        base.Start();
    }
    protected override void ClickedEvent()
    {
        EventSystem.current.ActivateVisitOptionUI(ID, visit);
    }
}
