using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 리스폰 요청
    public void RespawnItem(ItemObject item, float respawnTime)
    {
        StartCoroutine(RespawnCoroutine(item, respawnTime));
    }

    // 코루틴을 사용해 아이템 불러오기
    private IEnumerator RespawnCoroutine(ItemObject item, float respawnTime)
    {
        item.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        item.ResetItme();
        item.gameObject.SetActive(true);
    }
}
