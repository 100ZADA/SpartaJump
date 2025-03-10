using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;
    public float respawnTime;               // 리스폰 시간 설정

    private Vector3 firstposition;          // 처음 위치 저장용
    private Quaternion firstrotation;       // 처음 회전 저장용

    void Start()
    {
        // 초기 위치와 회전값 저장
        firstposition = transform.position;
        firstrotation = transform.rotation;

    }

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.info}";
        return str;
    }

    public void OnInteract()
    {
        PlayerCondition playerCondition = CharacterManager.Instance.Player.GetComponent<PlayerCondition>();

        if(playerCondition != null && data.type == ItemType.Consumable)
        {
            foreach(ItemDataConsumable consumable in data.consumables)      // 아이템효과가 여러개인 경우 순차적으로 적용
            {
                switch (consumable.type)
                {
                    case ConsumableType.Health:
                        playerCondition.Heal(consumable.value);             // 체력회복
                        break;
                    case ConsumableType.Stamina:
                        playerCondition.Statmina(consumable.value);         // 스태미나회복
                        break;
                    case ConsumableType.Jump:                               // 점프력 증가
                        playerCondition.ApplyJumpBoost(consumable.value, 10f);
                        break;
                    case ConsumableType.Speed:                              // 스피드 증가
                        playerCondition.ApplySpeedBoost(consumable.value, 10f);
                        break;
                }
            }
        }

        CharacterManager.Instance.Player.itemData = data;

        // Destory로 소멸하지 않고 비활성화 진행
        RespawnManager.instance.RespawnItem(this, respawnTime);
    }

    public void ResetItme()
    {
        transform.position = firstposition;
        transform.rotation = firstrotation;
    }
}
