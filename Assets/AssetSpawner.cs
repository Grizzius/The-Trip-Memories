using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetSpawner : MonoBehaviour
{
    public List<GameObject> assetList;
    public Vector3 spawnOffset;
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

    GameObject RandomAsset()
    {
        int i = Random.Range(0, assetList.Count - 1);
        return assetList[i];
    }

    IEnumerator SpawnItemLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            GameObject asset = Instantiate(RandomAsset());
            asset.transform.position = transform.position + spawnOffset;
        }
    }
}
