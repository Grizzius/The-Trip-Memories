using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateZoom : PlayerState
{
    public static Quaternion playerCamRotation;
    Camera playerCam;
    public PlayerStateZoom(PlayerScript playerScript) : base(playerScript)
    {

    }

    public override void Start()
    {
        player.transform.rotation = new Quaternion(0, 0, 0, 1);
        playerCam = PlayerScript.current.GetComponentInChildren<Camera>();

        playerCam.transform.localRotation = playerCamRotation;
    }

    // Update is called once per frame
    public override void Update()
    {

    }
}
