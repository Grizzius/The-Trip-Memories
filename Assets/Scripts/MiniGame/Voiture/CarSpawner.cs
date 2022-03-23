using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public Vector3[] spawnPositions = new Vector3[3];
    public EnemyCar car;

    public Material[] carMaterials;

    int previousSpawnIndex = 0;

    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.OnStartCarMiniGame += StartSpawnCars;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartSpawnCars()
    {
        StartCoroutine(SpawnCarLoop());
    }

    IEnumerator SpawnCarLoop()
    {
        while (true)
        {
            CarMinigame carMinigame = (CarMinigame)GameSystem.gameMode;
            yield return new WaitForSeconds(Random.Range(0.2f, 0.2f + curve.Evaluate(1f - carMinigame.timer / 90f)));
            SpawnCar();
        }
    }

    void SpawnCar()
    {
        Material material = carMaterials[Random.Range(0, carMaterials.Length)];
        EnemyCar newCar = Instantiate(car);

        MeshRenderer meshRenderer = newCar.GetComponentInChildren<MeshRenderer>();
        meshRenderer.material = material;

        int spawnIndex = GetSpawnIndex();
        newCar.transform.position = transform.position + spawnPositions[spawnIndex];

        newCar.speed = 150;
    }

    int GetSpawnIndex()
    {
        int spawnIndex = Random.Range(0, spawnPositions.Length);

        while(spawnIndex == previousSpawnIndex)
        {
            spawnIndex = Random.Range(0, spawnPositions.Length);
        }

        previousSpawnIndex = spawnIndex;

        return spawnIndex;
    }

    private void OnDrawGizmos()
    {
        foreach(Vector3 vector3 in spawnPositions)
        {
            Gizmos.DrawWireSphere(transform.position + vector3, 1);
        }
    }

}

[System.Serializable]
public class SpawnPatern
{
    public SpawnRow[] spawnRows;

    [System.Serializable]
    public class SpawnRow
    {
        public bool SpawnLeft;
        public bool SpawnMidle;
        public bool SpawnRight;
    }
}
