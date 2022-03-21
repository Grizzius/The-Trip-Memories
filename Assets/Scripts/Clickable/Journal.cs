using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : Clickable
{
    protected override void ClickedEvent()
    {
        base.ClickedEvent();
        EventSystem.current.OpenUI(ID);
    }
}
