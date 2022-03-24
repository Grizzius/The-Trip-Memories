using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMinigame : MiniGameGameMode
{
    GameSystem gameSystem;
    public static CarMinigame current;
    string nextSceneName;
    public int collisionCount;
    public int timer = 90;

    public int LostDays;
    public int LostMoney;

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
        Debug.Log("Start minigame");
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

        yield return new WaitForSeconds(3);
        CalculateResult();
        EventSystem.current.EndCarMinigame();

        GameSystem.AddDay(LostDays);
        GameSystem.playerMoney -= LostMoney;

        yield return new WaitForSeconds(10);

        GameSystem.ChangeScene(nextSceneName, new DefaultMode());
    }

    void CalculateResult()
    {
        int malusRate = collisionCount;

        if(malusRate > 5)
        {
            malusRate = 5;
        }

        for(int i = 0; i < malusRate; i++)
        {
            LostDays++;
            LostMoney += 10;
        }
    }
}
