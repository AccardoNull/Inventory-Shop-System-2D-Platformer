using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    public Transform slotParent;  // Adding Horizontal layout group
    public GameObject slotPrefab; // Add Icon Image to UI objects.

     private void Start()
     {
        inventory.onInventoryChangedCallback += UpdateUI;
        UpdateUI();
     }
    public void UpdateUI()
    {
        // Clear out the old icons when items leave the inventory
        foreach (Transform child in slotParent)
        {
            Destroy(child.gameObject);
        }
        // Add new icons when picking up items or buying upgrades.
        foreach (Item item in inventory.items)
        {
            GameObject slot = Instantiate(slotPrefab, slotParent);
            Image img = slot.GetComponent<Image>();
            img.sprite = item.icon;
        }
    }

}
