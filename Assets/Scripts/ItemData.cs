using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName ="Items/New Item" )]
public class ItemData : ScriptableObject
{
    public string itemname;
    public string description;
    public Sprite visual;
    public GameObject prefab;

    public ItemType itemType;
    public EquipmentType equipmentType;

}
public enum ItemType
{
    Ressource,
    Equipment,
    Comsumable
}

public enum EquipmentType
{
    Head,
    Chest,
    Hands,
    Legs,
    Feet
}