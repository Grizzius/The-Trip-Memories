using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, moveSpeed * Time.deltaTime);

        
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, (Mathf.Sin(Time.fixedTime) * 0.01f), 0);
    }
}
