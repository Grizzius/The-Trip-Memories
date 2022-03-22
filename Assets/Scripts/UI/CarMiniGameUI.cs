using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMiniGameUI : MonoBehaviour
{
    Animator animator;
    public string damageTriggerName;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.current.OnCarCollision += TriggerDamageAnim;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TriggerDamageAnim()
    {
        animator.SetTrigger(damageTriggerName);
    }
}
