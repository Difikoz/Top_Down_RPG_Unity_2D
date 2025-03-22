using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Drink", menuName = "Winter Universe/Item/Consumable/New Drink")]
    public class DrinkConsumableItemConfig : ConsumableItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Consumable;
            _consumableType = ConsumableType.Drink;
        }
    }
}