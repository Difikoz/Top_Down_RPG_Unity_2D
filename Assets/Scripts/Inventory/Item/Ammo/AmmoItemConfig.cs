using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ammo", menuName = "Winter Universe/Item/Ammo/New Ammo")]
    public class AmmoItemConfig : ItemConfig
    {
        [SerializeField] private Sprite _projectileSprite;
        [SerializeField] private float _damageMultiplier = 1f;
        [SerializeField] private float _forceMultiplier = 1f;
        [SerializeField] private int _pierceCount = 1;
        [SerializeField] private List<EffectCreator> _damageEffects = new();

        public Sprite ProjectileSprite => _projectileSprite;
        public float DamageMultiplier => _damageMultiplier;
        public float ForceMultiplier => _forceMultiplier;
        public int PierceCount => _pierceCount;
        public List<EffectCreator> DamageEffects => _damageEffects;

        private void OnValidate()
        {
            _itemType = ItemType.Ammo;
        }
    }
}