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
        EventSystem.current.OnAdvanceDate += CheckIfGoToWork;
    }

    public override void Update()
    {

    }

    void CheckIfGoToWork()
    {
        if(GameSystem.playerJob != null)
        {
            switch (GameSystem.date.weekDay)
            {
                case Day.Lundi:
                    if (GameSystem.playerJob.openLundi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Mardi:
                    if (GameSystem.playerJob.openMardi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Mercredi:
                    if (GameSystem.playerJob.openMercredi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Jeudi:
                    if (GameSystem.playerJob.openJeudi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Vendredi:
                    if (GameSystem.playerJob.openVendredi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Samedi:
                    if (GameSystem.playerJob.openSamedi)
                    {
                        GoToWork();
                    }
                    break;
                case Day.Dimanche:
                    if (GameSystem.playerJob.openDimanche)
                    {
                        GoToWork();
                    }
                    break;
            }
        }
    }

    void GoToWork()
    {
        GameSystem.playerMoney += GameSystem.playerJob.Pay;
        GameSystem.AddDay(1);
    }
}
