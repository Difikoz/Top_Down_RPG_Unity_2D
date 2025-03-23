using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class RangedWeaponController : WeaponController
    {
        private ShootPoint _shootPoint;
        private int _ammoInMag;
        private Coroutine _fireCoroutine;
        private Coroutine _reloadCoroutine;
        private float _spread;

        public int AmmoInMag => _ammoInMag;

        public override void Initialize()
        {
            base.Initialize();
            _shootPoint = GetComponentInChildren<ShootPoint>();
            Reload();
        }

        public override bool CanUnequip()
        {
            if (_fireCoroutine != null || _reloadCoroutine != null)
            {
                return false;
            }
            return base.CanUnequip();
        }

        public override bool CanAttack()
        {
            if (_fireCoroutine != null || _reloadCoroutine != null || _ammoInMag < 1)
            {
                return false;
            }
            return base.CanAttack();
        }

        public override void OnAttack()
        {
            _ammoInMag--;
            _fireCoroutine = StartCoroutine(FireCoroutine());
        }

        private IEnumerator FireCoroutine()
        {
            yield return new WaitForSeconds(60f / _config.FireRate);
            _fireCoroutine = null;
            if (_ammoInMag == 0)
            {
                Reload();
            }
        }

        public override void Reload()
        {
            if (_fireCoroutine != null || _reloadCoroutine != null || _ammoInMag == _config.MagSize || _pawn.Inventory.AmountOfItem(_config.UsingAmmo) == 0)
            {
                return;
            }
            _reloadCoroutine = StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator ReloadCoroutine()
        {
            yield return new WaitForSeconds(_config.ReloadTime / _pawn.Status.StatHolder.GetStat("RLDSPD").CurrentValue / 100f);
            int ammoDif = _config.MagSize - _ammoInMag;
            int amountInInventory = _pawn.Inventory.AmountOfItem(_config.UsingAmmo);
            if (ammoDif > amountInInventory)
            {
                ammoDif = amountInInventory;
            }
            if (_pawn.Inventory.RemoveItem(_config.UsingAmmo, ammoDif))
            {
                _ammoInMag += ammoDif;
            }
            _reloadCoroutine = null;
        }

        public override void Discharge()
        {
            if (_ammoInMag > 0)
            {
                _pawn.Inventory.AddItem(_config.UsingAmmo, _ammoInMag);
            }
            _ammoInMag = 0;
        }

        public void SpawnProjectiles()
        {
            for (int i = 0; i < _config.ProjectilesPerShot; i++)
            {
                _spread = Random.Range(-_config.Spread, _config.Spread);
                _spread += _shootPoint.transform.eulerAngles.z;
                GameManager.StaticInstance.PrefabsManager.GetProjectile(_shootPoint.transform.position, Quaternion.Euler(0f, 0f, _spread)).Initialize(_pawn, _config);
            }
        }
    }
}