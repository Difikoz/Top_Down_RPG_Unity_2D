using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Belt", menuName = "Winter Universe/Item/Equipment/New Belt")]
    public class BeltEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _beltSprite;

        public Sprite BeltSprite => _beltSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Belt;
        }
    }
}