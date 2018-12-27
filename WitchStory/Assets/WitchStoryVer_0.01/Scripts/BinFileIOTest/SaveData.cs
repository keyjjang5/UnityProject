using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ItemTypeIO
{
    SwordAndShiled,
    TwoHandSword,
    Knife,
    Potion,
    Helmet,
    Top,
    Pants
}
[System.Serializable]
public struct ItemDataIO
{
    public string name;
    public string discription;
    public ItemType itemType;
    public string spritePath;
    public Vector3 position;
}
[System.Serializable]
public struct InventoryDataIO
{
    public float weight;
    public List<ItemDataIO> items;
}
