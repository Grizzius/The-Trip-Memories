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

    public event Action<VisitPlace> onStartVisitMode;
    public void StartVisitMode(VisitPlace visitPlace)
    {
        if(onStartVisitMode != null)
        {
            onStartVisitMode(visitPlace);
        }
    }

    public event Action onEndVisitMode;

    public void EndVisitMode()
    {
        if(onEndVisitMode != null)
        {
            onEndVisitMode();
        }
    }
}
