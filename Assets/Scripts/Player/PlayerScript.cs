using UnityEngine;

public class PlayerScript : PlayerStateMachine
{
    public static PlayerScript current;
    public float rotationSpeed;
    private void Start()
    {
        current = this;
        SetState(new PlayerRoomState(this));

        EventSystem.current.OnEndVisitMode += ResetPosition;
    }

    private void Update()
    {
        state.Update();
    }

    void ResetPosition()
    {
        GetComponentInChildren<Camera>().transform.rotation = new Quaternion(0, 0, 0, 1);
        SetState(new PlayerRoomState(this));
        PlayerPositions.current.MovePlayer(0);
    }
}
