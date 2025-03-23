using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Melee Weapon", menuName = "Winter Universe/Item/Weapon/New Melee Weapon")]
    public class MeleeWeaponItemConfig : WeaponItemConfig
    {
        [SerializeField] private List<EffectCreator> _damageEffects = new();
        [SerializeField] private List<EffectCreator> _onAttackEffects = new();
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _attackCooldown = 0.5f;
        [SerializeField] private float _attackStaminaCost = 10f;

        public List<EffectCreator> DamageEffects => _damageEffects;
        public List<EffectCreator> OnAttackEffects => _onAttackEffects;
        public float AttackRange => _attackRange;
        public float AttackSpeed => _attackSpeed;
        public float AttackCooldown => _attackCooldown;
        public float AttackStaminaCost => _attackStaminaCost;

        private void OnValidate()
        {
            _itemType = ItemType.MeleeWeapon;
        }
    }
}