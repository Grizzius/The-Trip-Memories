using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TransportOptionUI : UIParentScript
{
    Date arrivalDate;
    public TextMeshProUGUI transportNameText;
    public TextMeshProUGUI destinationNameText;
    public TextMeshProUGUI arrivalDateText;
    public TextMeshProUGUI priceText;
    [Space]
    public Voyage voyage;

    public static TransportOptionUI current;

    protected override void Start()
    {
        base.Start();
        current = this;

        UpdateUI();
    }

    void UpdateUI()
    {
        arrivalDate = CalculateArrivalDate();
        if(arrivalDate != null)
        {
            arrivalDateText.text = "Arrivée : " + arrivalDate.monthDay + " " + arrivalDate.month;
        }
        destinationNameText.text = "Destination : " + voyage.destinationName;
        priceText.text = "$ : " + voyage.cost;
        transportNameText.text = voyage.transportType.ToString();
    }

    Date CalculateArrivalDate()
    {
        Date currentDate = new Date();

        if(GameSystem.date != null)
        {
            currentDate.monthDay = GameSystem.date.monthDay;
            currentDate.month = GameSystem.date.month;
            currentDate.weekDay = GameSystem.date.weekDay;
            currentDate.AddDay(voyage.travelTime);
            return currentDate;
        }
        else
        {
            return null;
        }

    }

    public void OnConfirmButton()
    {
        if(GameSystem.playerMoney >= voyage.cost)
        {
            GameSystem.AddDay(voyage.travelTime);
            GameSystem.playerMoney -= voyage.cost;
            switch (voyage.transportType)
            {
                case TransportType.avion:
                    GameSystem.ChangeScene("PlaneMinigame", new PlaneMinigame(voyage.destinationSceneName));
                    break;
                case TransportType.voiture:
                    GameSystem.ChangeScene("CarMiniGame", new CarMinigame(voyage.destinationSceneName));
                    break;
            }
        }
        
        
    }
}
