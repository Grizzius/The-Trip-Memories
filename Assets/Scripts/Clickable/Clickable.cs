using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public int ID;
    public string outlineID;
    MeshRenderer meshRenderer;
    bool canBeClicked;
    public StateCondition stateCondition;

    protected virtual void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }
    protected void OnMouseEnter()
    {
        canBeClicked = true;
        ToggleOutline(1f);
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
            switch (stateCondition)
            {
                case StateCondition.PlayerRoomState:
                    Debug.Log("Default State");
                    if(PlayerScript.state.GetType() == typeof(PlayerRoomState))
                    {
                        ClickedEvent();
                    }
                    break;

                case StateCondition.ZoomInState:
                    Debug.Log("ZoomIn State");
                    if (PlayerScript.state.GetType() == typeof(PlayerStateZoom))
                    {
                        ClickedEvent();
                    }
                    break;
            }
            
        }
    }

    protected virtual void ClickedEvent()
    {

    }

    private void ToggleOutline(float value)
    {
        meshRenderer?.material.SetFloat(outlineID, value);
    }
}

public enum StateCondition
{
    PlayerRoomState,
    ZoomInState,
    UIState
}
