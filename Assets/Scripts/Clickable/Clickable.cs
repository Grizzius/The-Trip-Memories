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
        EventSystem.current.OnRaycastHitItem += CheckIfGotHit;
        EventSystem.current.OnRaycastNoHitItem += RaycastDidNotHit;
    }

    void CheckIfGotHit(RaycastHit hit)
    {
        if (hit.transform == transform)
        {
            RaycastDidHit();
        }
        else
        {
            RaycastDidNotHit();
        }
    }

    protected void RaycastDidHit()
    {
        if (StateCondictionCheck())
        {
            canBeClicked = true;
            ToggleOutline(3.5f);
        }
        
    }

    protected void RaycastDidNotHit()
    {
        canBeClicked = false;
        ToggleOutline(0f);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && canBeClicked)
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
            outline.OutlineColor = Color.yellow;
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
