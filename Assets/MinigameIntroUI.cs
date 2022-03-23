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
        if(GameSystem.gameMode.GetType() == typeof(PlaneMinigame))
        {
            GameNameText.text = GameSystem.planeMinigameParameter.minigameName;
            GameGuideText.text = GameSystem.planeMinigameParameter.minigameGuide;
        }
        else if (GameSystem.gameMode.GetType() == typeof(CarMinigame))
        {
            GameNameText.text = GameSystem.carMinigameParameter.miniGameName;
            GameGuideText.text = GameSystem.carMinigameParameter.miniGameGuide;
        }
    }

    void CloseUI()
    {
        EventSystem.current.CloseUI(ID);
    }

    public void OnButtonClick()
    {
        EventSystem.current.StartCarMiniGame();
        EventSystem.current.StartPlaneMiniGame();
    }
}
