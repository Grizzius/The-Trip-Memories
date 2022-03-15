using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomClickable : Clickable
{
    int originPositionID;
    public int positionID;
    public Quaternion camRotation;

    protected override void Start()
    {
        base.Start();
    }


    protected override void ClickedEvent()
    {
        originPositionID = DefaultMode.playerPositionID;

        PlayerPositions.current.MovePlayer(positionID);
        PlayerStateZoom.playerCamRotation = camRotation;

        ZoomInUI.zoomClickableScript = this;
        UIManager.current.ToggleUI(ZoomInUI.current.GetComponent<Canvas>(), true, new PlayerStateZoom(PlayerScript.current));
       
    }

    public void ReturnToOrigin()
    {
        PlayerPositions.current.MovePlayer(originPositionID);
        PlayerScript.current.GetComponentInChildren<Camera>().transform.rotation = new Quaternion(0, 0, 0, 1);
        UIManager.current.ToggleUI(ZoomInUI.current.GetComponent<Canvas>(), false, new PlayerRoomState(PlayerScript.current));
    }
}
