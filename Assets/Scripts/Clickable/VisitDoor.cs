using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisitDoor : Clickable
{
    UIManager uiManager;
    public Canvas triggeredCanvas;

    protected override void Start()
    {
        base.Start();
        uiManager = FindObjectOfType<UIManager>();
    }
    protected override void ClickedEvent()
    {
        uiManager.ToggleUI(triggeredCanvas, true);
    }
}
