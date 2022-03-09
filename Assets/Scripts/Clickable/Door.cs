using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Clickable
{
    public GameObject position1;
    public GameObject position2;

    GameObject currentPlayerPosition;

    PlayerScript player;

    protected override void Start()
    {
        base.Start();
        player = FindObjectOfType<PlayerScript>();
        currentPlayerPosition = position1;
    }

    protected override void ClickedEvent()
    {
        if (currentPlayerPosition == position1)
        {
            player.transform.position = position2.transform.position;
            currentPlayerPosition = position2;
        }
        else if (currentPlayerPosition == position2)
        {
            player.transform.position = position1.transform.position;
            currentPlayerPosition = position1;
        }
    }
}
