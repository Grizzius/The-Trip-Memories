using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobToggle : Clickable
{
    public Jobs job;

    protected override void Start()
    {
        base.Start();
    }
    protected override void ClickedEvent()
    {
        ToggleOutline(0f);
        EventSystem.current.ActivateJobOfferUI(ID, job);
    }
}
