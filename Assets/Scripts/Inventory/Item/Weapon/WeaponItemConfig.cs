using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class WeaponItemConfig : ItemConfig
    {
        [SerializeField] private Sprite _weaponSprite;
        [SerializeField] protected WeaponType _weaponType;
        [SerializeField] protected List<DamageType> _damageTypes = new();
        [SerializeField] protected float _knockback = 1f;
        [SerializeField] private List<StatModifierCreator> _modifiers = new();
        [SerializeField] private List<EffectCreator> _attackEffects = new();

        public Sprite WeaponSprite => _weaponSprite;
        public WeaponType WeaponType => _weaponType;
        public List<DamageType> DamageTypes => _damageTypes;
        public float Knockback => _knockback;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<EffectCreator> AttackEffects => _attackEffects;
    }
}