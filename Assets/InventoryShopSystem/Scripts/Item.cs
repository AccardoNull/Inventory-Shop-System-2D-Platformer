using UnityEngine;

public enum ItemType
{
    NormalItem,
    Upgrade
}
[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;

    public ItemType itemType = ItemType.NormalItem;
    public int sellValue;
    public int buyPrice;
    public bool oneTimePurchase = false; // Ensure upgrade can only be purchased one time.

    // upgrade effects
    public float jumpIncrease;
    public float speedIncrease;
    public int inventoryIncrease;

}

