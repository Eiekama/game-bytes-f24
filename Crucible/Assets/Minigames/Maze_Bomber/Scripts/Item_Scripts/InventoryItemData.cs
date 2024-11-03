using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory System/Inventory Item")]

public class InventoryItemData : ScriptableObject
{
    public Sprite Icon;
    public int MaxStackSize;
    public int ID;
    public string DisplayName;
    [TextArea(4, 4)]
    public string Description;

    public GameObject ItemPrefab; // The 3D model or prefab to instantiate when dropping
}