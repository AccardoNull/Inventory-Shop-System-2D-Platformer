using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUpgradeManager : MonoBehaviour
{
    public Player player;
    public Inventory inventory;
    public CurrencyManager currency;
/// <summary>
/// Attempts to buy the specified upgrade, applying its effects if successful.
/// </summary>
/// <param name="upgrade">The upgrade item.</param>
/// <returns>
/// If not enough coins or already owned.
/// </returns>
    public void BuyUpgrade(Item upgrade)
    {
        if (upgrade.oneTimePurchase && inventory.items.Contains(upgrade))
        {
            Debug.Log("Already owned.");
            return;
        }

        if (currency.SpendCoins(upgrade.buyPrice))
        {
            // Apply upgrades. Customizable condtions for adding upgrades.
            if (upgrade.jumpIncrease != 0)
            {
                player.jumpForce += upgrade.jumpIncrease;
            }
            if (upgrade.speedIncrease != 0)
            {
                player.moveSpeed += upgrade.speedIncrease;
            }
            if (upgrade.inventoryIncrease != 0)
            {
                inventory.capacity += upgrade.inventoryIncrease;
            }
            // Add upgrade item to the inventory.
            inventory.Add(upgrade);
            Debug.Log("Upgrade purchased: " + upgrade.name);
        }
        else
        {
            Debug.Log("Not enough coins.");
            return;
        }
    }
}
