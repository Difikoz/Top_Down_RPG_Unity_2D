using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Chest", menuName = "Winter Universe/Item/Equipment/New Chest")]
    public class ChestEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _bodyVisualSprite;
        [SerializeField] private Sprite _upperArmVisualSprite;
        [SerializeField] private Sprite _lowerArmVisualSprite;

        public Sprite BodyVisualSprite => _bodyVisualSprite;
        public Sprite UpperArmVisualSprite => _upperArmVisualSprite;
        public Sprite LowerArmVisualSprite => _lowerArmVisualSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Chest;
        }
    }
}