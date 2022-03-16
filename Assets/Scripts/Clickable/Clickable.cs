using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public int ID;
    public string outlineID;
    public StateCondition stateCondition;

    bool canBeClicked;

    protected virtual void Start()
    {

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

    }

    private void ToggleOutline(float value)
    {

    }
}

public enum StateCondition
{
    PlayerRoomState,
    ZoomInState,
    UIState
}
