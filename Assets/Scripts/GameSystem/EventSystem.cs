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

    //======Appart Events======//
    public event Action OnAdvanceDate;

    public void AdvanceDate()
    {
        OnAdvanceDate?.Invoke();
    }

    //======Minigames Event======//

    public event Action OnPlaneCollision;

    public void PlaneCollision()
    {
        OnPlaneCollision?.Invoke();
    }
}
