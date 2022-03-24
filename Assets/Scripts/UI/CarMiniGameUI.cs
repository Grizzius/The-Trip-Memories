using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CarMiniGameUI : MonoBehaviour
{
    Animator animator;
    public string damageTriggerName;
    public TextMeshProUGUI chrono;


    public Image resultPanel;
    public TextMeshProUGUI collisionCount;
    public TextMeshProUGUI lostTimeCount;
    public TextMeshProUGUI lostMoneyCount;

    CarMinigame carMinigame;

    // Start is called before the first frame update
    void Start()
    {
        carMinigame = (CarMinigame)GameSystem.gameMode;
        animator = GetComponent<Animator>();

        EventSystem.current.OnCarCollision += TriggerDamageAnim;
        EventSystem.current.OnEndCarMinigame += DisplayResult;

        resultPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        chrono.text = carMinigame.timer.ToString() + " s";
    }

    void TriggerDamageAnim()
    {
        animator.SetTrigger(damageTriggerName);
    }

    void DisplayResult()
    {
        resultPanel.gameObject.SetActive(true);
        collisionCount.text = "Collisions : " + carMinigame.collisionCount.ToString();
        lostTimeCount.text = "Lost time : " + carMinigame.LostDays.ToString();
        lostMoneyCount.text = "Lost money : " + carMinigame.LostMoney.ToString() + "$";
    }
}
