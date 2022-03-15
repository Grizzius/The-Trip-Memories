using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Clickable
{
    public int position1ID;
    public int position2ID;

    PlayerScript player;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerScript>();
    }

    protected override void ClickedEvent()
    {
        if (DefaultMode.playerPositionID == position1ID)
        {
            PlayerPositions.current.MovePlayer(position2ID);
        }
        else if (DefaultMode.playerPositionID == position2ID)
        {
            PlayerPositions.current.MovePlayer(position1ID);
        }
    }
}
