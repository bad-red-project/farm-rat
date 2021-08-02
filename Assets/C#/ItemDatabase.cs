using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Assets/Database/Item Database")]
public class ItemDatabase : ScriptableObject
{
    public List<Item> allItems;
}
