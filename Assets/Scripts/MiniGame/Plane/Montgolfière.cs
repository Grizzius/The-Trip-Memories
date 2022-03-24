using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montgolfière : MonoBehaviour
{
    public float speed;
    public float movementIntensity;
    public Material[] materials;
    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer[] meshRenderers = GetComponentsInChildren<MeshRenderer>();
        int materialID = Random.Range(0, materials.Length);
        foreach (MeshRenderer meshRenderer in meshRenderers)
        {
            meshRenderer.material = materials[materialID];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-speed, Mathf.Cos(Time.time) * movementIntensity, 0) * Time.deltaTime;

        if(transform.position.x < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlaneController player = other.transform.GetComponent<PlaneController>();
        player.TakeDamage();
    }
}
