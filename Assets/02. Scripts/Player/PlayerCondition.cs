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

    // PlayerController를 참조하여 증가 관련 변수 작성
    private PlayerController playerController;
    private float jumpBoostAmount;
    private float speedBoostAmount;
    private float originalMoveSpeed;
    private float originalJumpPower;

    // playerController에서 받아와 초기화 진행
    private void Awake()
    {
        playerController = GetComponent<PlayerController>();

        if(playerController != null )
        {
            originalMoveSpeed = playerController.moveSpeed;
            originalJumpPower = playerController.jumpPower;
        }
    }

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

    // 점프력 증가 효과 적용
    public void ApplyJumpBoost(float amount, float duration)
    {
        jumpBoostAmount = amount;
        playerController.jumpPower = originalJumpPower + jumpBoostAmount;
        StartCoroutine(RemoveJumpBoost(duration));
    }

    // 점프력 증가 효과 제거
    private IEnumerator RemoveJumpBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        jumpBoostAmount = 0f;
        playerController.jumpPower = originalJumpPower;
    }

    // 스피드 증가 효과 적용
    public void ApplySpeedBoost(float amount, float duration)
    {
        speedBoostAmount = amount;
        playerController.moveSpeed = originalMoveSpeed + speedBoostAmount;
        StartCoroutine(RemoveSpeedBoost(duration));
    }

    // 스피드 증가 효과 제거
    private IEnumerator RemoveSpeedBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        speedBoostAmount = 0f;
        playerController.moveSpeed = originalMoveSpeed;
    }
}
