using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class EquipmentItemConfig : ItemConfig
    {
        [SerializeField] protected EquipmentType _equipmentType;
        [SerializeField] protected List<StatModifierCreator> _modifiers = new();
        [SerializeField] protected List<EffectCreator> _effects = new();

        public EquipmentType EquipmentType => _equipmentType;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<EffectCreator> Effects => _effects;
    }
}