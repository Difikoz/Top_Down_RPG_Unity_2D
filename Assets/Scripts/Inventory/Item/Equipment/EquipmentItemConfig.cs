using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Equipment", menuName = "Winter Universe/Item/Equipment/New Equipment")]
    public class EquipmentItemConfig : ItemConfig
    {
        [SerializeField] private Sprite _equipmentSprite;
        [SerializeField] private EquipmentTypeConfig _equipmentType;
        [SerializeField] private List<StatModifierCreator> _modifiers = new();
        [SerializeField] private List<EffectCreator> _effects = new();

        public Sprite EquipmentSprite => _equipmentSprite;
        public EquipmentTypeConfig EquipmentType => _equipmentType;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<EffectCreator> Effects => _effects;

        private void OnValidate()
        {
            _itemType = ItemType.Equipment;
        }
    }
}