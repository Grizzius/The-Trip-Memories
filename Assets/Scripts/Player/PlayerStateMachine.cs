using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public static PlayerState state;

    public static void SetState(PlayerState newState)
    {
        state = newState;
        state.Start();
    }
}
