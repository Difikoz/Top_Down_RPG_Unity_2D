using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponSlot : BasicComponent
    {
        [SerializeField] private Transform _weaponRoot;

        private PawnController _pawn;
        private WeaponItemConfig _config;
        private WeaponController _weaponController;

        public WeaponItemConfig Config => _config;
        public WeaponController WeaponController => _weaponController;

        public override void Initialize()
        {
            base.Initialize();
            _pawn = GetComponentInParent<PawnController>();
            ChangeConfig(null);
        }

        public void ChangeConfig(WeaponItemConfig config)
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
                _weaponController = LeanPool.Spawn(_config.WeaponController, _weaponRoot).GetComponent<WeaponController>();
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
                _weaponController.OnAttack();
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