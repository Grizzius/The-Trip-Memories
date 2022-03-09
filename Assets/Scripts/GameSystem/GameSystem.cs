using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : GameSystemStateMachine
{
    public int playerStartMoney;
    public Date startingDate;
    public static int playerMoney;
    public static bool FirstLaunch = true;
    public static Date date;

    private void Start()
    {
        if (FirstLaunch)
        {
            date = startingDate;
            playerMoney = playerStartMoney;
            SetMode(new DefaultMode());
            FirstLaunch = false;
        }
        
    }

    

    private void Update()
    {
        gameMode.Update();
    }

    public static void ChangeScene(int sceneID, GameMode gameMode)
    {
        SetMode(gameMode);
        SceneManager.LoadScene(sceneID);
    }

    public static void AddDay(int dayNumber)
    {
        for(int i = 0; i < dayNumber; i++)
        {
            switch (date.weekDay)
            {
                case Day.Dimanche:
                    date.weekDay = Day.Lundi;
                    break;
                default :
                    date.weekDay++;
                    break;
            }

            date.monthDay++;
            switch (date.monthDay)
            {
                case 32:
                    if (date.month == Month.Janvier || date.month == Month.Mars || date.month == Month.Mai || date.month == Month.Juillet || date.month == Month.Aout || date.month == Month.Octobre || date.month == Month.Decembre)
                    {
                        if(date.month != Month.Decembre)
                        {
                            date.month++;
                        }
                        else
                        {
                            date.month = Month.Janvier;
                        }
                        date.monthDay = 1;
                    }
                    break;
                case 31:
                    if (date.month == Month.Avril || date.month == Month.Juin || date.month == Month.Septembre || date.month == Month.Novembre)
                    {
                        date.month++;
                        date.monthDay = 1;
                    }
                    break;
                case 29:
                    if(date.month == Month.Février)
                    {
                        date.month++;
                        date.monthDay = 1;
                    }
                    break;
            }
        }
    }
}

[System.Serializable]
public class Date
{
    public Day weekDay;
    [Range(1,31)]
    public int monthDay;
    public Month month;
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
    Février,
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
