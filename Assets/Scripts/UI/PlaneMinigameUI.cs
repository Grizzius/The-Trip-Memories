using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneMinigameUI : MonoBehaviour
{
    public TextMeshProUGUI chronoText;
    public TextMeshProUGUI CollisionsCountText;

    public static PlaneMinigameUI current;

    PlaneMinigame planeMinigame;
    // Start is called before the first frame update
    void Start()
    {
        current = this;

        planeMinigame = (PlaneMinigame)GameSystem.gameMode;

        chronoText.text = planeMinigame.timer.ToString();

        EventSystem.current.OnPlaneCollision += UpdateCollision;
        EventSystem.current.OnStartPlaneMiniGame += StartTimer;

        UpdateCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartTimer()
    {
        StartCoroutine(Timer());
    }

    public void UpdateCollision()
    {
        CollisionsCountText.text = ("Collisions : " + planeMinigame.collisionCount);
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            planeMinigame.timer -= 1;

            if(planeMinigame.timer > 0)
            {
                chronoText.text = planeMinigame.timer.ToString();
            }
            else
            {
                chronoText.text = "0";
            }
            
        }
    }
}
