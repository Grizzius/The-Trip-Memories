using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMinigame : MiniGameGameMode
{
    private const bool V = true;
    GameSystem gameSystem;
    PlaneMinigameParam parameter;
    bool canSpawnPlane = V;

    PlaneController player;
    
    EnemyPlane newPlane;
    Montgolfière newMontgolfière;

    int spawnIndexthreshold = 8;

    float initialDelay = 2;

    public int timer;

    public override void Start()
    {
        timer = GameSystem.planeMinigameParameter.duration;
        initialDelay = GameSystem.planeMinigameParameter.initialSpawnDelay;

        gameSystem = Object.FindObjectOfType<GameSystem>();
        parameter = GameSystem.planeMinigameParameter;

        player = Object.FindObjectOfType<PlaneController>();

        StartSpawnPlane();
    }

    public override void Update()
    {
        if (player == null)
        {
            player = Object.FindObjectOfType<PlaneController>();
        }

        if (gameSystem == null)
        {
            gameSystem = Object.FindObjectOfType<GameSystem>();
            StartSpawnPlane();
        }

        Debug.Log(canSpawnPlane);

        if(timer == 0)
        {
            GameSystem.ChangeScene(0, new DefaultMode());
        }
    }

    void StartSpawnPlane()
    {
        gameSystem?.StartCoroutine(SpawnPlane());
    }

    IEnumerator SpawnPlane()
    {
        while (true)
        {
            if (parameter != null)
            {
                //Choisi de spawn un avion ou une montgolfière
                int spawnIndex = Random.Range(0, 10);

                if (spawnIndex < spawnIndexthreshold)
                {
                    newPlane = Object.Instantiate(parameter.planeTemplate);

                    newPlane.transform.position = new Vector3(20, Random.Range(-6, 6), 0);

                    newPlane.direction = (player.transform.position - newPlane.transform.position);

                    newPlane.speed = Random.Range(3f, 8f);
                }
                else
                {
                    newMontgolfière = Object.Instantiate(parameter.montgolfièreTemplate);

                    newMontgolfière.transform.position = new Vector3(20, Random.Range(-3,3), 0);

                    newMontgolfière.movementIntensity = Random.Range(1f, 5f);

                    newMontgolfière.speed = Random.Range(1f, 8f);
                }
            }

            yield return new WaitForSeconds(initialDelay / 100 * (timer + 10));
        }
    }
}
