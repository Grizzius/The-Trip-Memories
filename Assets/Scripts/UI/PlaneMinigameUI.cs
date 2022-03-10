using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneMinigameUI : MonoBehaviour
{
    public TextMeshProUGUI chronoText;
    PlaneMinigame planeMinigame;
    // Start is called before the first frame update
    void Start()
    {
        planeMinigame = (PlaneMinigame)GameSystem.gameMode;

        StartCoroutine(Timer());
        chronoText.text = planeMinigame.timer.ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            planeMinigame.timer -= 1;
            chronoText.text = planeMinigame.timer.ToString();
        }
    }
}
