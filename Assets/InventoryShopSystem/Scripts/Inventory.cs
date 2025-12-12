using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int capacity = 5; // Max amount of items player can carry
    public List<Item> items = new List<Item>(); // Current list of items

    public delegate void OnInventoryChanged();
    public OnInventoryChanged onInventoryChangedCallback;

/// <summary>
/// Attempts to add an item to the inventory.
/// </summary>
/// <param name="item">The item being added.</param>
/// <returns>
/// True if the item was added successfully. 
/// False if the inventory is full.
/// </returns>
    public bool Add(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Inventory Full!");
            return false;
        }
        items.Add(item);
        if (onInventoryChangedCallback != null)
        {
             onInventoryChangedCallback.Invoke();
        }
        return true;
    }
/// <summary>
/// Removes one instance of the specified item from the inventory.
/// </summary>
/// <param name="item">The item to remove.</param>
    public void Remove(Item item)
    {
        items.Remove(item);
        if (onInventoryChangedCallback != null)
        {
            onInventoryChangedCallback.Invoke();
        }
    }

}
