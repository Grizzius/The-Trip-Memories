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
        arrivalDateText.text = "Arrivée : " + arrivalDate.monthDay + " " + arrivalDate.month;
        destinationNameText.text = "Destination : " + voyage.destinationName;
        priceText.text = "$ : " + voyage.cost;
        transportNameText.text = voyage.transportType.ToString();
    }

    private void Update()
    {
        UpdateUI();
    }

    Date CalculateArrivalDate()
    {
        Date currentDate = new Date();

        currentDate.monthDay = GameSystem.date.monthDay;
        currentDate.month = GameSystem.date.month;
        currentDate.weekDay = GameSystem.date.weekDay;

        currentDate.AddDay(voyage.travelTime);
        return currentDate;
    }

    public void OnConfirmButton()
    {
        GameSystem.ChangeScene("PlaneMinigame", new PlaneMinigame(voyage.destinationSceneName));
    }
}
