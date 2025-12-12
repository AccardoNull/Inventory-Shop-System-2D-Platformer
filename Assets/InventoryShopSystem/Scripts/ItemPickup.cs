using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemPickup : MonoBehaviour
{
    public Item item;
    private bool playerInRange = false;
    private Inventory playerInventory;

    // playerInRange = true when player and item's collider interact.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory inv = collision.GetComponent<Inventory>();
        if (inv != null)
        {
            playerInRange = true;
            playerInventory = inv;
        }
    }
    // playerInRange = false when player exits item's collider.
    private void OnTriggerExit2D(Collider2D collision)
    {
        Inventory inv = collision.GetComponent<Inventory>();
        if (inv != null)
        {
            playerInRange = false;
            playerInventory = null;
        }
    }
    // When player is in range, press 'Z' to pick up the item.
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            bool pickedUp = playerInventory.Add(item);
            if (pickedUp)
            {
                Destroy(gameObject);
            }
        }
    }
}
