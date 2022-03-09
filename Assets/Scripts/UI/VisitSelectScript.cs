using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisitSelectScript : MonoBehaviour
{
    public Button closeButton;
    public VerticalLayoutGroup VisitListDisplay;

    public Canvas visitOptionUI;

    Canvas self;

    UIManager UIManager;

    LevelData levelData;

    // Start is called before the first frame update
    void Start()
    {
        levelData = FindObjectOfType<LevelData>();

        self = GetComponentInParent<Canvas>();

        UIManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        UIManager.ToggleUI(self, false);
    }
}
