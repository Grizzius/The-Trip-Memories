using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    
    public string nextSceneName;

    private void Start()
    {

    }

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            GameSystem.ChangeScene(nextSceneName, new DefaultMode());
        }
    }
}
