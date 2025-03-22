using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Melee Weapon", menuName = "Winter Universe/Item/Weapon/New Melee Weapon")]
    public class MeleeWeaponItemConfig : WeaponItemConfig
    {
        [SerializeField] private List<EffectCreator> _damageEffects = new();
        [SerializeField] private Vector2 _colliderSize = Vector2.one;
        [SerializeField] private Vector2 _colliderOffset = Vector2.up;
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _attackCooldown = 0.5f;

        public List<EffectCreator> DamageEffects => _damageEffects;
        public Vector2 ColliderSize => _colliderSize;
        public Vector2 ColliderOffset => _colliderOffset;
        public float AttackRange => _attackRange;
        public float AttackSpeed => _attackSpeed;
        public float AttackCooldown => _attackCooldown;

        private void OnValidate()
        {
            _itemType = ItemType.Weapon;
            _weaponType = WeaponType.Melee;
        }
    }
}