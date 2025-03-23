using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponSlot : WeaponSlot
    {
        private MeleeWeaponItemConfig _config;
        private MeleeWeaponController _weaponController;

        public MeleeWeaponItemConfig Config => _config;
        public MeleeWeaponController WeaponController => _weaponController;

        public override void Initialize()
        {
            base.Initialize();
            ChangeConfig(null);
        }

        public void ChangeConfig(MeleeWeaponItemConfig config)
        {
            if (_weaponController != null)
            {
                LeanPool.Despawn(_weaponController.gameObject);
                _weaponController = null;
            }
            _config = config;
            if (_config != null)
            {
                _weaponController = LeanPool.Spawn(_config.WeaponController, _weaponRoot).GetComponent<MeleeWeaponController>();
                _weaponController.Initialize();
            }
        }

        public void PerformAttack()
        {
            if (_config == null || _pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_weaponController.CanAttack())
            {
                _weaponController.Attack();
            }
        }
    }
}