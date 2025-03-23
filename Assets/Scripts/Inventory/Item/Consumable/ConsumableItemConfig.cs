using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Winter Universe/Item/Consumable/New Consumable")]
    public class ConsumableItemConfig : ItemConfig
    {
        [SerializeField] private ConsumableTypeConfig _consumableType;
        [SerializeField] private List<EffectCreator> _effects = new();

        public ConsumableTypeConfig ConsumableType => _consumableType;
        public List<EffectCreator> Effects => _effects;

        private void OnValidate()
        {
            _itemType = ItemType.Consumable;
        }
    }
}