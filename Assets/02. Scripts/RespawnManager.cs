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

    // ������ ��û
    public void RespawnItem(ItemObject item, float respawnTime)
    {
        StartCoroutine(RespawnCoroutine(item, respawnTime));
    }

    private IEnumerator RespawnCoroutine(ItemObject item, float respawnTime)
    {
        item.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnTime);

        item.ResetItme();
        item.gameObject.SetActive(true);
    }
}
