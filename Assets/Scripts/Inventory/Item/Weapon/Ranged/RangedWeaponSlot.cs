using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class RangedWeaponSlot : WeaponSlot
    {
        private RangedWeaponItemConfig _config;
        private RangedWeaponController _weaponController;

        public RangedWeaponItemConfig Config => _config;
        public RangedWeaponController WeaponController => _weaponController;

        public override void Initialize()
        {
            base.Initialize();
            ChangeConfig(null);
        }

        public void ChangeConfig(RangedWeaponItemConfig config)
        {
            if (_weaponController != null)
            {
                _weaponController.Discharge();
                LeanPool.Despawn(_weaponController.gameObject);
                _weaponController = null;
            }
            _config = config;
            if (_config != null)
            {
                _weaponController = LeanPool.Spawn(_config.WeaponController, _weaponRoot).GetComponent<RangedWeaponController>();
                _weaponController.Initialize();
            }
        }

        public void PerformFire()
        {
            if (_config == null || _pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_weaponController.CanFire())
            {
                _weaponController.Fire();
            }
        }

        public void ReloadWeapon()
        {
            if (_config == null || _pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_weaponController.CanReload())
            {
                _weaponController.Reload();
            }
        }
    }
}