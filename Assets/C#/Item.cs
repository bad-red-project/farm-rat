using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Assets/Item")]
public class Item: ScriptableObject
{
    [Serializable]
    public struct ItemStats
    {
        public int attackPover;
        public int defence;
    }

    public string id;
    public string title;
    [TextArea]
    public string description;
    public Sprite icon;
    public ItemStats stats;

    public Item(Item item)
    {
        id = item.id;
        title = item.title;
        description = item.description;
        icon = item.icon;
        stats = item.stats;
    }
}
