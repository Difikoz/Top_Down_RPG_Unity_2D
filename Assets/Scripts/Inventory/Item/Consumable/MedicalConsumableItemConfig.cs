using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Medical", menuName = "Winter Universe/Item/Consumable/New Medical")]
    public class MedicalConsumableItemConfig : ConsumableItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Consumable;
            _consumableType = ConsumableType.Medical;
        }
    }
}