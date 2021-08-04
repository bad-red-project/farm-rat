using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Database : MonoBehaviour
{
    public ItemDatabase itemDatabase;

    public Item getItemById(string itemId)
    {
        return itemDatabase.allItems.FirstOrDefault(item => item.id == itemId);
    }
}
