using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class WeaponItemConfig : ItemConfig
    {
        [SerializeField] protected GameObject _weaponController;
        [SerializeField] protected AnimatorOverrideController _controller;
        [SerializeField] protected List<StatModifierCreator> _modifiers = new();
        [SerializeField] protected List<DamageType> _damageTypes = new();

        public GameObject WeaponController => _weaponController;
        public AnimatorOverrideController Controller => _controller;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<DamageType> DamageTypes => _damageTypes;
    }
}