using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycast : MonoBehaviour
{
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Debug.Log("Hit " + hit.transform.name);
            EventSystem.current.RaycastHitItem(hit);
        }
        else
        {
            Debug.Log("Didn't hit");
            EventSystem.current.RaycastNoHitItem();
        }
    }
}
