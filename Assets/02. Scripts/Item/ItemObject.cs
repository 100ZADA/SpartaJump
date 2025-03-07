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
            foreach(ItemDataConsumable consumable in data.consumables)      // 아이템효과가 체력, 스태미나 회복이 둘다 잇을 경우 순차적으로 적용
            {
                switch (consumable.type)
                {
                    case ConsumableType.Health:
                        playerCondition.Heal(consumable.value);             // 체력회복
                        break;
                    case ConsumableType.Stamina:
                        playerCondition.Statmina(consumable.value);         // 스태미나회복
                        break;
                }
            }
        }

        CharacterManager.Instance.Player.itemData = data;

        Destroy(gameObject);                // 아이템 사용후 필드에서 사라짐
    }
}
