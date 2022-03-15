using UnityEngine;

public class PlayerScript : PlayerStateMachine
{
    public static PlayerScript current;
    public float rotationSpeed;
    private void Start()
    {
        current = this;
        SetState(new PlayerRoomState(this));
    }

    private void Update()
    {
        state.Update();
    }
}
