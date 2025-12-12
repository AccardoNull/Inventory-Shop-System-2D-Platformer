using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class UpgradeUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Text priceText;
    public Button buyButton;
    public Text boughtText;

    private Item upgrade;
    private ShopUpgradeManager shop;
    private Inventory inventory;

/// <summary>
/// Initializes the UI row for an upgrade option in the shop.
/// </summary>
/// <param name="item">The upgrade item.</param>
/// <param name="shopManager">The manager responsible for applying upgrades.</param>
/// <param name="inv">The player's inventory.</param>
    public void Setup(Item item, ShopUpgradeManager shopManager, Inventory inv)
    {
        this.upgrade = item;
        this.shop = shopManager;
        this.inventory = inv;

        icon.sprite = item.icon;
        nameText.text = item.itemName;
        priceText.text = item.buyPrice.ToString();

        if (item.oneTimePurchase && inventory.items.Contains(item))
        {
            buyButton.interactable = false;
            boughtText.text = "Owned";
        }
        buyButton.onClick.AddListener(Buy);
    }
/// <summary>
/// Attempts to purchase the upgrade when the Buy button is pressed.
/// </summary>
    void Buy()
    {
        bool hadBefore = inventory.items.Contains(upgrade);
        shop.BuyUpgrade(upgrade);
        bool hasAfter = inventory.items.Contains(upgrade);
        //Check whether purchase succeed and update trade menu.
        if (!hadBefore && hasAfter)
        {
            buyButton.interactable = false;
            boughtText.text = "Owned";
        }
    }
}
