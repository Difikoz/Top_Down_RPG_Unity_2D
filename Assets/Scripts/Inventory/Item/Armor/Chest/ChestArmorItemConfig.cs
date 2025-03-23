using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Chest", menuName = "Winter Universe/Item/Armor/New Chest")]
    public class ChestArmorItemConfig : ArmorItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Chest;
        }
    }
}