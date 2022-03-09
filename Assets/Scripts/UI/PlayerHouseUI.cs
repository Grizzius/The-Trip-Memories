using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHouseUI : MonoBehaviour
{
    public TextMeshProUGUI PlayerMoneyText;
    public TextMeshProUGUI DateText;
    public TextMeshProUGUI WeekDayText;
    
    // Update is called once per frame
    void Update()
    {
        PlayerMoneyText.text = GameSystem.playerMoney.ToString();
        UpdateDate();

        if (Input.GetButtonDown("Jump"))
        {
            GameSystem.AddDay(4);
        }
    }

    void UpdateDate()
    {
        DateText.text = (GameSystem.date.weekDay + " " + GameSystem.date.monthDay + " " + (GameSystem.date.month) + " 20XX");
    }
}
