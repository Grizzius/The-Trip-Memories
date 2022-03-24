using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHouseUI : UIParentScript
{
    [Header("UI Elements")]
    public TextMeshProUGUI PlayerMoneyText;
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI WeekDayText;

    public static PlayerHouseUI current;

    protected override void Start()
    {
        base.Start();
        current = this;
        UpdateDate();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDate();
        PlayerMoneyText.text = GameSystem.playerMoney.ToString();
    }

    public void UpdateDate()
    {
        if (GameSystem.date != null)
        {
            DateText.text = (GameSystem.date.weekDay + " " + GameSystem.date.monthDay + " " + (GameSystem.date.month) + " 20XX");
        }
    }
}
