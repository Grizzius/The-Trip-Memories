using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomEventUI : UIParentScript
{
    public static RandomEventUI current;
    public RandomEventData randomEvent;

    public TextMeshProUGUI TitleText;
    public TextMeshProUGUI EventText;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        current = this;
    }

    protected override void OnOpenTab()
    {
        base.OnOpenTab();
        UpdateText();
    }

    protected override void OnCloseTab()
    {
        base.OnCloseTab();
    }

    public void UpdateText()
    {
        TitleText.text = randomEvent.eventTitle;
        EventText.text = randomEvent.eventText;
    }

    public void OnButtonClick()
    {
        EventSystem.current.CloseRandomEventTab();
        EventSystem.current.CloseUI(ID);
    }
}
