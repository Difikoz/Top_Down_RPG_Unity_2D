using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ammo", menuName = "Winter Universe/Item/New Ammo")]
    public class AmmoItemConfig : ItemConfig
    {
        [SerializeField] private Sprite _projectileSprite;
        [SerializeField] private float _damageMultiplier = 1f;
        [SerializeField] private float _rangeMultiplier = 1f;
        [SerializeField] private float _forceMultiplier = 1f;
        [SerializeField] private float _knockbackMultiplier = 1f;
        [SerializeField] private int _pierceCount = 1;
        //[SerializeField] private List<EffectCreator> _effects = new();

        public Sprite ProjectileSprite => _projectileSprite;
        public float DamageMultiplier => _damageMultiplier;
        public float RangeMultiplier => _rangeMultiplier;
        public float ForceMultiplier => _forceMultiplier;
        public float KnockbackMultiplier => _knockbackMultiplier;
        public int PierceCount => _pierceCount;
        //public List<EffectCreator> Effects => _effects;

        private void OnValidate()
        {
            _itemType = ItemType.Ammo;
        }
    }
}