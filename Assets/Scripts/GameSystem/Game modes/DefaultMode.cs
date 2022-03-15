using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultMode : GameMode
{
    public static int playerPositionID;
    public override void Start()
    {
        Debug.Log("Default game mode");

        PlayerPositions.current.MovePlayer(GameSystem.current.playerStartPositionID);
    }

    public override void Update()
    {

    }
}
