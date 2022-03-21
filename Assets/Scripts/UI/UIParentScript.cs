using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParentScript : MonoBehaviour
{
    public int ID;
    public Canvas canvas;

    protected virtual void Start()
    {
        canvas = GetComponent<Canvas>();

        EventSystem.current.OnOpenUI += UIOpenEventListener;
        EventSystem.current.OnOpenUI += ConfirmReceiveMessage;
        EventSystem.current.OnCloseUI += UICloseEventListener;
    }

    void ConfirmReceiveMessage(int ID)
    {
        print("Message reçu");
    }

    protected void UIOpenEventListener(int id)
    {
        if (id == ID)
        {
            canvas.enabled = true;
            OnOpenTab();
        }
    }
    protected void UICloseEventListener(int id)
    {
        if (id == ID)
        {
            canvas.enabled = false;
            OnCloseTab();
        }
    }

    protected virtual void OnOpenTab()
    {

    }

    protected virtual void OnCloseTab()
    {

    }
}
