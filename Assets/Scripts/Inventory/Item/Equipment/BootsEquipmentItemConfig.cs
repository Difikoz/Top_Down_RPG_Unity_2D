using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Boots", menuName = "Winter Universe/Item/Equipment/New Boots")]
    public class BootsEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _bootsSprite;

        public Sprite BootsSprite => _bootsSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Boots;
        }
    }
}