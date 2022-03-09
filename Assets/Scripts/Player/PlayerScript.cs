using UnityEngine;

public class PlayerScript : PlayerStateMachine
{
    public float rotationSpeed;
    private void Start()
    {
        SetState(new PlayerRoomState(this));
    }

    private void Update()
    {
        state.Update();
    }
}
