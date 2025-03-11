using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;              // 현재 상태
    public float maxValue;              // 최대 상태
    public float startValue;            // 시간이 지남에 따라 상태변화
    public float passiveValue;          // 가만히 있을시 상태 변경
    public Image uiBar;

    void Start()
    {
        curValue = startValue;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    // 수치 증가
    public void Add(float amount)
    {
        curValue = Mathf.Min(curValue + amount, maxValue);
    }

    // 수치 감소
    public void Decrease(float amount)
    {
        curValue = Mathf.Max(curValue - amount, 0.0f);
    }

    public float GetPercentage()
    {
        return curValue / maxValue;
    }
}
