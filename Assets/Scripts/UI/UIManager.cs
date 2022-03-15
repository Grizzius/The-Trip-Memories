using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerHouseUI roomUI;
    public VisitOptionScript[] visitOptionScripts;
    public ZoomInUI zoomInUI;
    public Canvas VisitUI;

    public static UIManager current;
    

    private void Start()
    {
        current = this;

        roomUI.gameObject.SetActive(true);
        foreach(VisitOptionScript option in visitOptionScripts)
        {
            option.gameObject.SetActive(false);
        }
        zoomInUI.gameObject.SetActive(false);

        EventSystem.current.OnStartVisitMode += BeginVisitUI;
    }

    public void ToggleUI(Canvas UI, bool enabled, PlayerState newState)
    {
        UI.gameObject.SetActive(enabled);

        switch (enabled)
        {
            case true:
                PlayerScript.SetState(newState);
                break;
            case false:
                PlayerScript.SetState(newState);
                break;
        }
    }

    public void BeginVisitUI(VisitPlace visit)
    {

    }
}
