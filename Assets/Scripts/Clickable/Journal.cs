using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Journal : Clickable
{
    protected override void ClickedEvent()
    {
        GameSystem.ChangeScene(1, new BoatMiniGameMode());
    }
}
