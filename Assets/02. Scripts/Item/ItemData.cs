using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// 아이템 타입
public enum ItemType
{
    Consumable
}

// 회복 타입
public enum ConsumableType
{
    Health,
    Stamina,
    Jump,
    Speed
}

[System.Serializable]
public class ItemDataConsumable
{
    public ConsumableType type;
    public float value;
}

// 아이템 스크랩트오브젝트화
[CreateAssetMenu(fileName = "Food", menuName = "New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string displayName;
    public string info;
    public ItemType type;

    [Header("Consumable")]
    public ItemDataConsumable[] consumables;
}
