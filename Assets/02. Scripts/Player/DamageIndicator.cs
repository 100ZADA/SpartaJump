using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;

    private Coroutine coroutine;

    void Start()
    {
        CharacterManager.Instance.Player.condition.OnTakeDamage += Flash;    // 데미지 받을 때 효과
    }

    public void Flash()
    {
        // 코루틴이 실행 중이면 중지
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        // 시작 전 초기 값 세팅
        image.enabled = true;
        image.color = new Color(1f, 105f / 255f, 105f/255f);
        coroutine = StartCoroutine(FadeAway());
    }

    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while (a > 0.0f)
        {
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            image.color = new Color(1f, 105f / 255f, 105f / 255f, a);
            yield return null;
        }

        image.enabled = false;
    }
}
