using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameSystem.ChangeScene("Test Scene", new MiniGameGameMode());
        }
    }
}
