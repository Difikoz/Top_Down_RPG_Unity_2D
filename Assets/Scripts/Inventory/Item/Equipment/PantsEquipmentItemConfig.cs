using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Pants", menuName = "Winter Universe/Item/Equipment/New Pants")]
    public class PantsEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _bodyVisualSprite;
        [SerializeField] private Sprite _upperLegVisualSprite;
        [SerializeField] private Sprite _lowerLegVisualSprite;

        public Sprite BodyVisualSprite => _bodyVisualSprite;
        public Sprite UpperLegVisualSprite => _upperLegVisualSprite;
        public Sprite LowerLegVisualSprite => _lowerLegVisualSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Pants;
        }
    }
}