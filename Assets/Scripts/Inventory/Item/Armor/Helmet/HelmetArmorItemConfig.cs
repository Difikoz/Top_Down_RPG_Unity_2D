using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Helmet", menuName = "Winter Universe/Item/Armor/New Helmet")]
    public class HelmetArmorItemConfig : ArmorItemConfig
    {
        private void OnValidate()
        {
            _itemType = ItemType.Helmet;
        }
    }
}