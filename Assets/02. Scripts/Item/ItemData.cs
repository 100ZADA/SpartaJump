﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum ItemType
{
    Consumable
}

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
