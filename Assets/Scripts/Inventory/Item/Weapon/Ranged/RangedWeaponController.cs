using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class RangedWeaponController : WeaponController
    {
        [SerializeField] private RangedWeaponItemConfig _config;

        private ShootPoint _shootPoint;
        private Coroutine _fireCoroutine;
        private Coroutine _reloadCoroutine;
        private int _ammoInMag;
        private float _spread;
        private float _reloadSpeed;

        public RangedWeaponItemConfig Config => _config;
        public bool IsPerfomingAction =>  _fireCoroutine != null || _reloadCoroutine != null;
        public int AmmoInMag => _ammoInMag;

        public override void Initialize()
        {
            base.Initialize();
            _shootPoint = GetComponentInChildren<ShootPoint>();
            if (CanReload())
            {
                Reload();
            }
        }

        public bool CanFire()
        {
            if (IsPerfomingAction)
            {
                return false;
            }
            if (_config.UsingAmmo != null && _ammoInMag < 1)
            {
                return false;
            }
            return _pawn.Status.EnoughStamina(_config.FireStaminaCost);
        }

        public bool CanReload()
        {
            if (IsPerfomingAction)
            {
                return false;
            }
            if (_config.UsingAmmo == null)
            {
                return false;
            }
            if (_ammoInMag == _config.MagSize)
            {
                return false;
            }
            if (_config.ConsumeAmmoOnReload && _pawn.Inventory.AmountOfItem(_config.UsingAmmo) == 0)
            {
                return false;
            }
            return true;
        }

        public void Fire()
        {
            if (_config.ConsumeAmmoOnFire)
            {
                _ammoInMag--;
            }
            _fireCoroutine = StartCoroutine(FireCoroutine());
        }

        public void Reload()
        {
            _reloadCoroutine = StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator FireCoroutine()
        {
            _pawn.Status.ReduceStaminaCurrent(_config.FireStaminaCost);
            _pawn.Status.EffectHolder.ApplyEffects(_config.OnFireEffects, _pawn);
            _pawn.Animator.PlayAction("Fire");
            yield return new WaitForSeconds(60f / _config.FireRate);
            _fireCoroutine = null;
            if (_ammoInMag == 0 && CanReload())
            {
                Reload();
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            _pawn.Status.EffectHolder.ApplyEffects(_config.OnReloadEffects, _pawn);
            _reloadSpeed = _pawn.Status.StatHolder.GetStat("RLDSPD").CurrentValue / 100f;
            _pawn.Animator.SetFloat("Reload Speed", _reloadSpeed / _config.ReloadTime);
            _pawn.Animator.PlayAction("Reload");
            yield return new WaitForSeconds(_config.ReloadTime / _reloadSpeed);
            int ammoDif = _config.MagSize - _ammoInMag;
            if (_config.ConsumeAmmoOnReload)
            {
                int amountInInventory = _pawn.Inventory.AmountOfItem(_config.UsingAmmo);
                if (ammoDif > amountInInventory)
                {
                    ammoDif = amountInInventory;
                }
                if (_pawn.Inventory.RemoveItem(_config.UsingAmmo, ammoDif))
                {
                    _ammoInMag += ammoDif;
                }
            }
            else
            {
                _ammoInMag += ammoDif;
            }
            _reloadCoroutine = null;
        }

        public void Discharge()
        {
            if (_config.UsingAmmo != null && _ammoInMag > 0 && _config.ConsumeAmmoOnReload)
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