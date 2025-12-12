using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShopUIManager : MonoBehaviour
{
    public Inventory inventory;
    public CurrencyManager currency;
    public ShopUpgradeManager upgradeManager;

    public Transform sellListParent;
    public GameObject sellItemUIPrefab;

    public Transform upgradeListParent;
    public GameObject upgradeUIPrefab;

    public Item[] upgradeItems;

    void OnEnable()
    {
        RefreshSellList();
        RefreshUpgradeList();
    }

    void RefreshSellList()
    {
        foreach (Transform child in sellListParent)
        {
            Destroy(child.gameObject);
        }
        var groups = inventory.items
        .Where(i => i.itemType == ItemType.NormalItem)
        .GroupBy(i => i)
        .ToList();

        foreach (var group in groups)
        {
            GameObject row = Instantiate(sellItemUIPrefab, sellListParent);
            row.GetComponent<SellItemUI>()
            .Setup(group.Key, group.Count(), inventory, currency);
        }
    }
    void RefreshUpgradeList()
    {
        foreach (Transform child in upgradeListParent)
        {
            Destroy(child.gameObject);
        }
        foreach (var item in upgradeItems)
        {
            GameObject row = Instantiate(upgradeUIPrefab, upgradeListParent);
            row.GetComponent<UpgradeUI>()
            .Setup(item, upgradeManager, inventory);

        }
    }
}
