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
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoneyText.text = GameSystem.playerMoney.ToString();
        

        if (Input.GetButtonDown("Jump"))
        {
            GameSystem.AddDay(4);
            UpdateDate();
        }
    }

    public void UpdateDate()
    {
        DateText.text = (GameSystem.date.weekDay + " " + GameSystem.date.monthDay + " " + (GameSystem.date.month) + " 20XX");
    }
}
