using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class outlineScript : MonoBehaviour
{
    public Material outlineMat;

    GameObject outlineObject;
    // Start is called before the first frame update
    void Start()
    {
        outlineObject = new GameObject();
        outlineObject.transform.parent = transform;

        outlineObject.transform.position = new Vector3(0, 0, 0);
        outlineObject.transform.rotation = new Quaternion(0, 0, 0, 0);

        MeshFilter outlineMesh = outlineObject.AddComponent<MeshFilter>();
        MeshRenderer outlineRenderer = outlineObject.AddComponent<MeshRenderer>();

        outlineMesh.mesh = GetComponent<MeshFilter>().mesh;
        outlineRenderer.material = outlineMat;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
