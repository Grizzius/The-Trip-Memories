using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MinigameIntroUI : UIParentScript
{
    public static MinigameIntroUI current;

    public TextMeshProUGUI GameNameText;
    public TextMeshProUGUI GameGuideText;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        current = this;
        EventSystem.current.OnStartPlaneMiniGame += CloseUI;
        EventSystem.current.OnStartCarMiniGame += CloseUI;

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateText()
    {
    }

    void CloseUI()
    {
        EventSystem.current.CloseUI(ID);
    }

    public void OnButtonClick()
    {
        
    }
}
