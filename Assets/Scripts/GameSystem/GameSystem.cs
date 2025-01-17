using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : GameSystemStateMachine
{
    public static bool[] EventTriggers = new bool[256];
    public static int playerMoney = 50000;
    public static int playerLuck = 50;
    public static int playerKnowledge;
    public static int playerMemories;

    public static bool FirstLaunch = true;
    public static Date date;
    public static Jobs playerJob;

    public static GameSystem current;

    [Header("Minigame parameters")]
    public PlaneMinigameParam defaultPlaneMinigameParameter;
    public CarMiniGameParameter defaultCarMinigameParameter;

    public static PlaneMinigameParam planeMinigameParameter;
    public static CarMiniGameParameter carMinigameParameter;

    private void Start()
    {
        current = this;
        if (FirstLaunch)
        {
            SetMode(new DefaultMode());
            print("First launch");
            date = new Date
            {
                weekDay = Day.Lundi,
                monthDay = 7,
                month = Month.Mars
            };
            planeMinigameParameter = defaultPlaneMinigameParameter;
            carMinigameParameter = defaultCarMinigameParameter;

            for(int i = 0; i < EventTriggers.Length; i++)
            {
                EventTriggers[i] = false;
            }

            FirstLaunch = false;
        }
        gameMode.Start();
    }

    private void Update()
    {
        if(gameMode != null)
        {
            gameMode.Update();
        }
        else
        {
            Debug.LogError("no gamemode found");
            SetMode(new DefaultMode());
        }
        
    }

    public static void ChangeScene(string SceneName, GameMode gameMode)
    {
        SetMode(gameMode);
        SceneManager.LoadScene(SceneName);
    }

    public static void AddDay(int dayNumber)
    {
        date.AddDay(dayNumber);
        PlayerHouseUI.current.UpdateDate();
        EventSystem.current.AdvanceDate();
    }

    public void UpdateJob(Jobs newJob)
    {
        playerJob = newJob;
    }
}

[System.Serializable]
public class Date
{
    public Day weekDay;
    [Range(1,31)]
    public int monthDay;
    public Month month;

    public void AddDay(int dayNumber)
    {
        for (int i = 0; i < dayNumber; i++)
        {
            switch (weekDay)
            {
                case Day.Dimanche:
                    weekDay = Day.Lundi;
                    break;
                default:
                    weekDay++;
                    break;
            }

            monthDay++;
            switch (monthDay)
            {
                case 32:
                    if (month == Month.Janvier || month == Month.Mars || month == Month.Mai || month == Month.Juillet || month == Month.Aout || month == Month.Octobre || month == Month.Decembre)
                    {
                        if (month != Month.Decembre)
                        {
                            month++;
                        }
                        else
                        {
                            month = Month.Janvier;
                        }
                        monthDay = 1;
                    }
                    break;
                case 31:
                    if (month == Month.Avril || month == Month.Juin || month == Month.Septembre || month == Month.Novembre)
                    {
                        month++;
                        monthDay = 1;
                    }
                    break;
                case 29:
                    if (month == Month.F�vrier)
                    {
                        month++;
                        monthDay = 1;
                    }
                    break;
            }
        }
    }
}

public enum Day
{
    Lundi,
    Mardi,
    Mercredi,
    Jeudi,
    Vendredi,
    Samedi,
    Dimanche
}

public enum Month
{
    Janvier,
    F�vrier,
    Mars,
    Avril,
    Mai,
    Juin,
    Juillet,
    Aout,
    Septembre,
    Octobre,
    Novembre,
    Decembre
}
