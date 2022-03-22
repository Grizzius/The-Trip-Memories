using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarMiniGameUI : MonoBehaviour
{
    Animator animator;
    public string damageTriggerName;
    public TextMeshProUGUI chrono;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.OnCarCollision += TriggerDamageAnim;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CarMinigame carMinigame = (CarMinigame)GameSystem.gameMode;
        chrono.text = carMinigame.timer.ToString() + " s";
    }

    void TriggerDamageAnim()
    {
        animator.SetTrigger(damageTriggerName);
    }
}
