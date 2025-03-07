using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISObject
{
    void TakePhysicalDamage(int damageAmount);
    void TakePhysicalJump(int jumpAmount);
    void TakePhysicalPush(int pushAmount);
}

public class PlayerCondition : MonoBehaviour, ISObject
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina { get { return uiCondition.stamina; } }

    public event Action OnTakeDamage;               // 데미지 받을 시 호출

    void Update()
    {
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (health.curValue == 0f)
        {
            Die();
        }
    }

    // 체력 회복
    public void Heal(float amount)
    {
        health.Add(amount);
    }

    // 스테미나 회복
    public void Statmina(float amount)
    {
        stamina.Add(amount);
    }

    // 플레이어 사망 시 게임 종료
    public void Die()
    {
        GameEnd();
    }

    public void GameEnd()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


    // 스테미나 사용
    public bool UseStamina(float amount)
    {
        if(stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Decrease(amount);
        return true;
    }

    // 데미지 받을시 행동
    public void TakePhysicalDamage(int damageAmount)
    {
        health.Decrease(damageAmount);
        OnTakeDamage?.Invoke();
    }

    // 점프 받을시 행동
    public void TakePhysicalJump(int jumpAmount)
    {
        Vector3 force = new Vector3(0, jumpAmount, 0);
        Rigidbody rb = GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.AddForce(force, ForceMode.Impulse);
        }
    }

    // 밀릴시 행동
    public void TakePhysicalPush(int pushAmount)
    {
        Vector3 force = -transform.forward * pushAmount;         // 반대방향으로 힘을 작용
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(force, ForceMode.Force);
        }
    }
}
