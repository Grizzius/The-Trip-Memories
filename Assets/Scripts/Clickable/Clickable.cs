using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    public string outlineID;
    MeshRenderer meshRenderer;
    bool canBeClicked;

    protected virtual void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
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
        if(Input.GetButtonDown("Fire1") && canBeClicked && PlayerStateMachine.state.GetType() == typeof(PlayerRoomState))
        {
            ClickedEvent();
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
