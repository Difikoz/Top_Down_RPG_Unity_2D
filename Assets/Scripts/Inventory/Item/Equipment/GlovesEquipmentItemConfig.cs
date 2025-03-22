using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Gloves", menuName = "Winter Universe/Item/Equipment/New Gloves")]
    public class GlovesEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _glovesSprite;

        public Sprite GlovesSprite => _glovesSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Gloves;
        }
    }
}