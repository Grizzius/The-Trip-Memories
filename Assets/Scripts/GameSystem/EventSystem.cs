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
        OnOpenUI?.Invoke(ID);
    }

    public event Action<int> OnCloseUI;
    public void CloseUI(int ID)
    {
        OnCloseUI?.Invoke(ID);
    }

    public event Action<int, VisitPlace> OnActivateVisitOptionUI;
    public void ActivateVisitOptionUI(int ID, VisitPlace visitPlace)
    {
        Debug.Log("VisitOptionUI Event");
        OnActivateVisitOptionUI?.Invoke(ID, visitPlace);
    }

    //======Minigames Event======//

    public event Action OnPlaneCollision;

    public void PlaneCollision()
    {
        OnPlaneCollision?.Invoke();
    }
}
