using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action OnTakeDamage;               // 데미지 받을 시 호출

    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (health.curValue < 0f)
        {
            Die();
        }
    }

    // 체력 회복
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    // 플레이어 사망 시 게임 종료
    public void Die()
    {
        Application.Quit();
    }

    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Decrease(amount);
        return true;
    }
}
