using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneMinigameUI : MonoBehaviour
{
    public TextMeshProUGUI chronoText;
    public TextMeshProUGUI CollisionsCountText;

    [Header("Result Screen")]
    public Image resultPanel;
    public TextMeshProUGUI collisionCount;
    public TextMeshProUGUI lostTimeCount;
    public TextMeshProUGUI lostMoneyCount;

    public static PlaneMinigameUI current;

    PlaneMinigame planeMinigame;
    // Start is called before the first frame update
    void Start()
    {
        current = this;

        resultPanel.gameObject.SetActive(false);

        planeMinigame = (PlaneMinigame)GameSystem.gameMode;

        chronoText.text = planeMinigame.timer.ToString();

        EventSystem.current.OnPlaneCollision += UpdateCollision;
        EventSystem.current.OnStartPlaneMiniGame += StartTimer;
        EventSystem.current.OnEndPlaneMinigame += DisplayResult;

        UpdateCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DisplayResult()
    {
        resultPanel.gameObject.SetActive(true);
        collisionCount.text = "Collisions : " + planeMinigame.collisionCount.ToString();
        lostTimeCount.text = "Lost time : " + planeMinigame.lostDays.ToString() + " days";
        lostMoneyCount.text = "Lost money : " + planeMinigame.lostMoney.ToString() + " $";
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
