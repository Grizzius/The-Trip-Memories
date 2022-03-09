using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    BoatController boat;
    Vector3 currentVelocity = Vector3.zero;

    private void Start()
    {
        boat = FindObjectOfType<BoatController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, boat.transform.position, ref currentVelocity, 1f);
    }
}
