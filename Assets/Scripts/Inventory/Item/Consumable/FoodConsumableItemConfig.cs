using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Food", menuName = "Winter Universe/Item/Consumable/New Food")]
    public class FoodConsumableItemConfig : ConsumableItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Consumable;
            _consumableType = ConsumableType.Food;
        }
    }
}