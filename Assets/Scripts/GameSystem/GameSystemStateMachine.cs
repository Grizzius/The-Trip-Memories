using UnityEngine;

public class GameSystemStateMachine : MonoBehaviour
{
    public static GameMode gameMode;

    public static void SetMode(GameMode newGameMode)
    {
        gameMode = newGameMode;
        gameMode.Start();
    }
}
