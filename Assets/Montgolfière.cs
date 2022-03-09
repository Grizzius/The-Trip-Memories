using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Montgolfière : MonoBehaviour
{
    public float speed;
    public float movementIntensity;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
