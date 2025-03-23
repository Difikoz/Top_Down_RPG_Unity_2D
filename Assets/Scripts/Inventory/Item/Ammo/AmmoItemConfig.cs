using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ammo", menuName = "Winter Universe/Item/Ammo/New Ammo")]
    public class AmmoItemConfig : ItemConfig
    {
        [SerializeField] private GameObject _ammoPrefab;
        [SerializeField] private int _pierceCount = 1;
        [SerializeField] private List<EffectCreator> _damageEffects = new();

        public GameObject AmmoPrefab => _ammoPrefab;
        public int PierceCount => _pierceCount;
        public List<EffectCreator> DamageEffects => _damageEffects;

        private void OnValidate()
        {
            _itemType = ItemType.Ammo;
        }
    }
}