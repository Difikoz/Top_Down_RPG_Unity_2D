using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Winter Universe/Item/Weapon/New Weapon")]
    public class WeaponItemConfig : ItemConfig
    {
        [SerializeField] private GameObject _weaponController;
        [SerializeField] private WeaponTypeConfig _weaponType;
        [SerializeField] private AnimatorOverrideController _controller;
        [SerializeField] private List<StatModifierCreator> _modifiers = new();
        [SerializeField] private List<DamageType> _damageTypes = new();
        [SerializeField] private List<EffectCreator> _attackEffects = new();
        [SerializeField] private List<EffectCreator> _damageEffects = new();
        [Header("Melee Info")]
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _attackCooldown = 0.5f;
        [Header("Ranged Info")]
        [SerializeField] private float _fireRate = 300f;
        [SerializeField] private float _range = 10f;
        [SerializeField] private float _force = 25f;
        [SerializeField] private float _spread = 5f;
        [SerializeField] private float _reloadTime = 1f;
        [SerializeField] private int _magSize = 30;
        [SerializeField] private int _projectilesPerShot = 1;
        [SerializeField] private int _pierceCount = 1;
        [SerializeField] private AmmoItemConfig _usingAmmo;

        public GameObject WeaponController => _weaponController;
        public WeaponTypeConfig WeaponType => _weaponType;
        public AnimatorOverrideController Controller => _controller;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<DamageType> DamageTypes => _damageTypes;
        public List<EffectCreator> AttackEffects => _attackEffects;
        public List<EffectCreator> DamageEffects => _damageEffects;
        public float AttackRange => _attackRange;
        public float AttackSpeed => _attackSpeed;
        public float AttackCooldown => _attackCooldown;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float Force => _force;
        public float Spread => _spread;
        public float ReloadTime => _reloadTime;
        public int MagSize => _magSize;
        public int ProjectilesPerShot => _projectilesPerShot;
        public int PierceCount => _pierceCount;
        public AmmoItemConfig UsingAmmo => _usingAmmo;

        private void OnValidate()
        {
            _itemType = ItemType.Weapon;
        }
    }
}