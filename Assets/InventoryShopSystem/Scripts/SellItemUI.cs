using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class SellItemUI : MonoBehaviour
{
    public Image icon;
    public Text nameText;
    public Text quantityText;

    public Button sellOneButton;
    public Button sellAllButton;

    private Item item;
    private Inventory inventory;
    private CurrencyManager currency;

/// <summary>
/// Sets up the UI row for a sellable item.
/// </summary>
/// <param name="item">The item being displayed.</param>
/// <param name="quantity">The quantity currently owned.</param>
/// <param name="inv">Reference to the player's inventory.</param>
/// <param name="money">Reference to the currency system.</param>
    public void Setup(Item item, int quantity, Inventory inv, CurrencyManager money)
    {
        this.item = item;
        this.inventory = inv;
        this.currency = money;

        icon.sprite = item.icon;
        nameText.text = item.itemName;
        quantityText.text = quantity.ToString();

        sellOneButton.onClick.AddListener(SellOne);
        sellAllButton.onClick.AddListener(SellAll);

    }
/// <summary>
/// Sells a single instance of the item.
/// </summary>
    void SellOne()
    {
        inventory.Remove(item);
        currency.AddCoins(item.sellValue);
        int remaining = inventory.items.FindAll(i => i == item).Count;
        if (remaining > 0)
        {
            quantityText.text = remaining.ToString();
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
/// <summary>
/// Sells all instances of the item owned.
/// </summary>
    void SellAll()
    {
        int count = inventory.items.FindAll(i => i == item).Count;
        for (int i=0; i< count; i++)
        {
            inventory.Remove(item);
        }
        currency.AddCoins(item.sellValue * count);
        Destroy(gameObject);

    }
}
