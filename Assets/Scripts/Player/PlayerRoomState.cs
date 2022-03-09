using UnityEngine;

public class PlayerRoomState : PlayerState
{
    public PlayerRoomState(PlayerScript playerScript) : base(playerScript)
    {
    }

    public override void Start()
    {
        Debug.Log("Player room state");

    }

    public override void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        if (mousePos.x < Screen.width * .2f)
        {
            player.transform.Rotate(0, -player.rotationSpeed * Time.deltaTime, 0);
        } 
        else if (mousePos.x > Screen.width * .8f)
        {
            player.transform.Rotate(0, player.rotationSpeed * Time.deltaTime, 0);
        }


    }
}
