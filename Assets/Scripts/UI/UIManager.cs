using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public PlayerHouseUI roomUI;
    public VisitOptionScript[] visitOptionScripts;
    public ZoomInUI zoomInUI;
    public Canvas VisitUI;
    public RandomEventUI randomEventUI;
    public JobOfferUIScript JobOfferUI;

    public static UIManager current;

    private void Start()
    {
        current = this;

        roomUI.canvas.enabled = true;
        foreach (VisitOptionScript option in visitOptionScripts)
        {
            option.canvas.enabled = false;
        }
        zoomInUI.canvas.enabled = false;
        randomEventUI.canvas.enabled = false;
        JobOfferUI.canvas.enabled = false;

        EventSystem.current.OnStartVisitMode += BeginVisitUI;
    }

    private void Update()
    {
        
    }

    public void ToggleUI()
    {
        
    }

    public void BeginVisitUI(VisitPlace visit)
    {

    }
}
