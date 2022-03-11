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

    public event Action<int> OnActivateUI;
    
    public void ActivateUI(int ID)
    {
        OnActivateUI?.Invoke(ID);
    }

    public event Action<int, VisitPlace> OnActivateVisitOptionUI;

    public void ActivateVisitOptionUI(int ID, VisitPlace visitPlace)
    {
        OnActivateVisitOptionUI?.Invoke(ID, visitPlace);
    }
}
