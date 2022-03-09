using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    
    public int nextSceneID;

    private void Start()
    {

    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            GameSystem.ChangeScene(nextSceneID, new DefaultMode());
        }
    }
}
