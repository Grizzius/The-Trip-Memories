using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMinigame : MiniGameGameMode
{
    GameSystem gameSystem;
    PlaneMinigameParam parameter;

    PlaneController player;
    
    EnemyPlane newPlane;
    Montgolfière newMontgolfière;

    int spawnIndexthreshold = 8;

    float initialDelay = 2;

    public int timer;

    public int collisionCount = 0;

    string nextSceneName;

    public static PlaneMinigame current;

    //Results variables
    public int lostDays;
    public int lostMoney;

    public PlaneMinigame(string NextSceneName)
    {
        nextSceneName = NextSceneName;
    }

    public override void Start()
    {
        current = this;
        timer = GameSystem.planeMinigameParameter.duration;
        initialDelay = GameSystem.planeMinigameParameter.initialSpawnDelay;

        EventSystem.current.OnPlaneCollision += IncreaseCollisionCount;
        EventSystem.current.OnStartPlaneMiniGame += StartSpawnPlane;

        gameSystem = Object.FindObjectOfType<GameSystem>();
        parameter = GameSystem.planeMinigameParameter;

        player = Object.FindObjectOfType<PlaneController>();
    }

    public override void Update()
    {
        if (player == null)
        {
            player = Object.FindObjectOfType<PlaneController>();
        }
        if(timer == -5)
        {
            EventSystem.current.EndPlaneMinigame();
        }
        if(timer == -15)
        {
            GameSystem.ChangeScene(nextSceneName, new DefaultMode());
        }
    }

    public void CalculateResults()
    {
        int resultValue = 5;
        if(collisionCount < 5)
        {
            resultValue = collisionCount;
        }

        lostMoney = collisionCount * 10;
        lostDays = collisionCount;
    }

    public void IncreaseCollisionCount()
    {
        Debug.Log("Collision");
        collisionCount++;
        PlaneMinigameUI.current.UpdateCollision();
    }

    void StartSpawnPlane()
    {
        timer = 90;
        gameSystem?.StartCoroutine(SpawnPlane());
    }

    IEnumerator SpawnPlane()
    {
        while (timer > 0)
        {
            if (parameter != null)
            {
                //Choisi de spawn un avion ou une montgolfière
                int spawnIndex = Random.Range(0, 10);
                
                if (spawnIndex < spawnIndexthreshold)
                {
                    //Spawn un avion
                    newPlane = Object.Instantiate(parameter.planeTemplate);

                    newPlane.transform.position = new Vector3(20, Random.Range(-6, 6), 0);

                    newPlane.direction = (player.transform.position - newPlane.transform.position);

                    newPlane.speed = Random.Range(3f, 8f);
                }
                else
                {
                    //Spawn une montgolfière
                    newMontgolfière = Object.Instantiate(parameter.montgolfièreTemplate);

                    newMontgolfière.transform.position = new Vector3(20, Random.Range(-3,3), 0);

                    newMontgolfière.movementIntensity = Random.Range(1f + (4f/timer), 5f);

                    newMontgolfière.speed = Random.Range(3f, 8f);
                }
            }

            yield return new WaitForSeconds(initialDelay / 100 * (timer + 10));
        }
    }
}
