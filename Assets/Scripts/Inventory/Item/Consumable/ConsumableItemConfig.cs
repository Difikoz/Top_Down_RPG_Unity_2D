using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class ConsumableItemConfig : ItemConfig
    {
        [SerializeField] protected ConsumableType _consumableType;
        [SerializeField] protected List<EffectCreator> _effects = new();

        public ConsumableType ConsumableType => _consumableType;
        public List<EffectCreator> Effects => _effects;
    }
}