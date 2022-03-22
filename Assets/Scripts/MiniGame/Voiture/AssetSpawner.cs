using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawner : MonoBehaviour
{
    public List<AssetSpawnData> assetList;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnItemLoop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    AssetSpawnData RandomAsset()
    {
        int i = Random.Range(0, assetList.Count - 1);
        return assetList[i];
    }

    IEnumerator SpawnItemLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            AssetSpawnData spawnData = RandomAsset();
            GameObject asset = Instantiate(spawnData.asset);
            asset.transform.position = transform.position + spawnData.spawnOffset;
        }
    }
}

[System.Serializable]
public class AssetSpawnData
{
    public GameObject asset;
    public Vector3 spawnOffset;
}
