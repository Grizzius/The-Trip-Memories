using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomClickable : Clickable
{
    int originPositionID;
    public int positionID;
    public int UI_ID;
    public Quaternion camRotation;

    protected override void Start()
    {
        base.Start();
    }


    protected override void ClickedEvent()
    {
        base.ClickedEvent();
        originPositionID = DefaultMode.playerPositionID;

        PlayerPositions.current.MovePlayer(positionID);
        PlayerStateZoom.playerCamRotation = camRotation;

        ZoomInUI.zoomClickableScript = this;
        EventSystem.current.OpenUI(UI_ID);
        PlayerScript.SetState(new PlayerStateZoom(PlayerScript.current));
       
    }

    public void ReturnToOrigin()
    {
        PlayerPositions.current.MovePlayer(originPositionID);
        PlayerScript.current.GetComponentInChildren<Camera>().transform.rotation = new Quaternion(0, 0, 0, 1);

        PlayerScript.SetState(new PlayerRoomState(PlayerScript.current));
    }
}
