using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Ranged Weapon", menuName = "Winter Universe/Item/Weapon/New Ranged Weapon")]
    public class RangedWeaponItemConfig : WeaponItemConfig
    {
        [SerializeField] private List<EffectCreator> _onFireEffects = new();
        [SerializeField] private List<EffectCreator> _onReloadEffects = new();
        [SerializeField] private float _fireStaminaCost = 2f;
        [SerializeField] private float _fireRate = 300f;
        [SerializeField] private float _range = 10f;
        [SerializeField] private float _force = 25f;
        [SerializeField] private float _spread = 5f;
        [SerializeField] private float _reloadTime = 1f;
        [SerializeField] private int _magSize = 30;
        [SerializeField] private int _projectilesPerShot = 1;
        [SerializeField] private int _pierceCount = 1;
        [SerializeField] private bool _consumeAmmoOnFire = true;
        [SerializeField] private bool _consumeAmmoOnReload = true;
        [SerializeField] private AmmoItemConfig _usingAmmo;

        public List<EffectCreator> OnFireEffects => _onFireEffects;
        public List<EffectCreator> OnReloadEffects => _onReloadEffects;
        public float FireStaminaCost => _fireStaminaCost;
        public float FireRate => _fireRate;
        public float Range => _range;
        public float Force => _force;
        public float Spread => _spread;
        public float ReloadTime => _reloadTime;
        public int MagSize => _magSize;
        public int ProjectilesPerShot => _projectilesPerShot;
        public int PierceCount => _pierceCount;
        public bool ConsumeAmmoOnFire => _consumeAmmoOnFire;
        public bool ConsumeAmmoOnReload => _consumeAmmoOnReload;
        public AmmoItemConfig UsingAmmo => _usingAmmo;

        private void OnValidate()
        {
            _itemType = ItemType.RangedWeapon;
        }
    }
}