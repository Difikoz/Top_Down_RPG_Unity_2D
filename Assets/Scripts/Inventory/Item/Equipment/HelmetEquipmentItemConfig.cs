using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Helmet", menuName = "Winter Universe/Item/Equipment/New Helmet")]
    public class HelmetEquipmentItemConfig : EquipmentItemConfig
    {
        [SerializeField] private Sprite _helmetSprite;

        public Sprite HelmetSprite => _helmetSprite;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
            _equipmentType = EquipmentType.Helmet;
        }
    }
}