using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisitSelectScript : UIParentScript
{
    public Button closeButton;
    public VerticalLayoutGroup VisitListDisplay;

    public Canvas visitOptionUI;

    LevelData levelData;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        levelData = FindObjectOfType<LevelData>();
    }

    public void OpenTab()
    {
        for(int i = 0; i < VisitListDisplay.transform.childCount; i++)
        {
            Transform child = VisitListDisplay.transform.GetChild(i);
            Destroy(child.gameObject);
        }
        Initialize();
    }

    public void Initialize()
    {
        foreach(VisitPlace visitPlace in levelData.visitPlaces)
        {
            print("add visit place");
            Canvas newVisitOptionUI = Instantiate(visitOptionUI);
            VisitOptionScript visitOptionScript = newVisitOptionUI.GetComponent<VisitOptionScript>();
            visitOptionScript.visit = visitPlace;
            newVisitOptionUI.transform.SetParent(VisitListDisplay.transform);
        }
    }

    public void CloseTab()
    {
        EventSystem.current.CloseUI(ID);
        //UIManager.ToggleUI(self, false, new PlayerStateZoom(PlayerScript.current));
    }
}
