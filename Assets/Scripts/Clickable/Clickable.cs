using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class Clickable : MonoBehaviour
{
    [Tooltip("Le numéro d'ID doit être le même que l'objet activé par le clic")]
    public int ID;
    public StateCondition stateCondition;

    bool canBeClicked;

    Outline outline;

    protected virtual void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    protected void OnMouseEnter()
    {
        if (StateCondictionCheck())
        {
            canBeClicked = true;
            ToggleOutline(5f);
        }
        
    }

    protected void OnMouseExit()
    {
        canBeClicked = false;
        ToggleOutline(0f);
    }

    protected void Update()
    {
        if(Input.GetButtonDown("Fire1") && canBeClicked)
        {
            if (StateCondictionCheck())
            {
                ClickedEvent();
            }
            
        }
    }

    bool StateCondictionCheck()
    {
        switch (stateCondition)
        {
            case StateCondition.PlayerRoomState:
                if (PlayerScript.state.GetType() == typeof(PlayerRoomState))
                {
                    return true;
                }
                break;

            case StateCondition.ZoomInState:
                if (PlayerScript.state.GetType() == typeof(PlayerStateZoom))
                {
                    return true;
                }
                break;
        }
        return false;
    }

    protected virtual void ClickedEvent()
    {
        ToggleOutline(0f);
    }

    protected void ToggleOutline(float value)
    {
        if(value != 0)
        {
            outline.enabled = true;
            outline.OutlineWidth = value;
        }
        else
        {
            outline.enabled = false;
        }
    }
}

public enum StateCondition
{
    PlayerRoomState,
    ZoomInState,
    UIState
}
