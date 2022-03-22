using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMinigame : MiniGameGameMode
{
    GameSystem gameSystem;
    public static CarMinigame current;
    string nextSceneName;
    public int collisionCount;
    public int timer;

    public CarMinigame(string NextSceneName)
    {
        nextSceneName = NextSceneName;
    }

    // Start is called before the first frame update
    public override void Start()
    {
        current = this;
        gameSystem = GameSystem.current;
        EventSystem.current.OnStartCarMiniGame += StartMiniGame;
        EventSystem.current.OnCarCollision += IncreaseCollision;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    void StartMiniGame()
    {
        gameSystem.StartCoroutine(Timer());
    }

    void IncreaseCollision()
    {
        collisionCount++;
    }

    IEnumerator Timer()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
    }
}
