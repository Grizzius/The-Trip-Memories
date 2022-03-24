using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem current;

    // Start is called before the first frame update
    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //======Visit Events======//
    public event Action<VisitPlace> OnStartVisitMode;
    public void StartVisitMode(VisitPlace visitPlace)
    {
        OnStartVisitMode?.Invoke(visitPlace);
    }

    public event Action OnEndVisitMode;

    public void EndVisitMode()
    {
        OnEndVisitMode?.Invoke();
    }

    //======UI Events======//

    public event Action<int> OnOpenUI;
    public void OpenUI(int ID)
    {
        print(PlayerScript.state.GetType());
        if(PlayerScript.state.GetType() != typeof(PlayerUIState))
        {
            print("Ouvre l'UI d'ID " + ID.ToString());
            OnOpenUI?.Invoke(ID);
        }
    }

    public event Action<int> OnCloseUI;
    public void CloseUI(int ID)
    {
        OnCloseUI?.Invoke(ID);
    }

    public event Action<int, VisitPlace> OnActivateVisitOptionUI;
    public void ActivateVisitOptionUI(int ID, VisitPlace visitPlace)
    {
        OnActivateVisitOptionUI?.Invoke(ID, visitPlace);
    }

    public event Action<int, Jobs> OnActivateJobOfferUI;

    public void ActivateJobOfferUI(int ID, Jobs job)
    {
        OnActivateJobOfferUI?.Invoke(ID, job);
    }

    public event Action OnCloseRandomEventTab;

    public void CloseRandomEventTab()
    {
        OnCloseRandomEventTab?.Invoke();
    }

    public event Action<RaycastHit> OnRaycastHitItem;

    public void RaycastHitItem(RaycastHit hit)
    {
        OnRaycastHitItem?.Invoke(hit);
    }

    public event Action OnRaycastNoHitItem;

    public void RaycastNoHitItem()
    {
        OnRaycastNoHitItem?.Invoke();
    }

    //======Appart Events======//
    public event Action OnAdvanceDate;

    public void AdvanceDate()
    {
        OnAdvanceDate?.Invoke();
    }

    //======Minigames Event======//

    //Avion//

    public event Action OnPlaneCollision;

    public void PlaneCollision()
    {
        OnPlaneCollision?.Invoke();
    }

    public event Action OnStartPlaneMiniGame;

    public void StartPlaneMiniGame()
    {
        OnStartPlaneMiniGame?.Invoke();
    }

    //Voiture//

    public event Action OnStartCarMiniGame;

    public void StartCarMiniGame()
    {
        OnStartCarMiniGame?.Invoke();
    }

    public event Action OnCarCollision;

    public void CarCollision()
    {
        OnCarCollision?.Invoke();
    }

    public event Action OnEndCarMinigame;

    public void EndCarMinigame()
    {
        OnEndCarMinigame?.Invoke();
    }
}
