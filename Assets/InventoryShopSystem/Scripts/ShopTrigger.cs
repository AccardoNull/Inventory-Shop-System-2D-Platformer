using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ShopTrigger : MonoBehaviour
{
    public GameObject shopUI;
    private bool playerInRange = false;
/// <summary>
/// Detects when the player enters the shop trigger area.
/// </summary>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
/// <summary>
/// Detects when the player leaves the shop area and closes the shop UI.
/// </summary>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            if (shopUI != null)
            {
                shopUI.SetActive(false);   // Shop menu auto-close when walk away
            }
            
        }
    }
    
/// <summary>
/// Toggles the shop UI when the player presses the interaction key.
/// </summary>
    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Z))
        {
            shopUI.SetActive(!shopUI.activeSelf);
        }
    }
}
