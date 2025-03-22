using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class RangedWeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _shootPoint;

        private PawnController _pawn;
        private RangedWeaponItemConfig _config;
        private int _ammoInMag;
        private Coroutine _fireCoroutine;
        private Coroutine _reloadCoroutine;
        private float _spread;

        public RangedWeaponItemConfig Config => _config;
        public int AmmoInMag => _ammoInMag;
        public bool IsPerfomingAction => _fireCoroutine != null || _reloadCoroutine != null;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            ChangeConfig(null);
        }

        public void ChangeConfig(RangedWeaponItemConfig config)
        {
            if (_config != null)
            {
                _pawn.Status.StatHolder.RemoveStatModifiers(_config.Modifiers);
            }
            _config = config;
            if (_config != null)
            {
                _pawn.Status.StatHolder.AddStatModifiers(_config.Modifiers);
                _spriteRenderer.sprite = _config.WeaponSprite;
                _shootPoint.localPosition = _config.ShootPointOffset;
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }

        public bool CanFire()
        {
            return _config != null && _pawn.Equipment.AmmoSlot.Config != null && !IsPerfomingAction && _ammoInMag > 0;
        }

        public void Fire()
        {
            _ammoInMag--;
            _fireCoroutine = StartCoroutine(FireCoroutine());
        }

        public void ChangeAmmoType()
        {
            if (_config == null || IsPerfomingAction)
            {
                return;
            }
            if (_pawn.Equipment.AmmoSlot.Config == null)
            {
                if (_pawn.Inventory.GetAmmo(_config, out AmmoItemConfig ammo))
                {
                    _pawn.Equipment.EquipAmmo(ammo);
                }
            }
            else if (_config.UsingAmmo.Count > 1)
            {
                int currentAmmoIndex = _config.UsingAmmo.IndexOf(_pawn.Equipment.AmmoSlot.Config);
                if (currentAmmoIndex < _config.UsingAmmo.Count - 1)
                {
                    for (int i = currentAmmoIndex + 1; i < _config.UsingAmmo.Count; i++)
                    {
                        if (_pawn.Inventory.AmountOfItem(_config.UsingAmmo[i]) > 0)
                        {
                            _pawn.Equipment.EquipAmmo(_config.UsingAmmo[i]);
                            break;
                        }
                    }
                }
                if (currentAmmoIndex > 1)
                {
                    for (int i = 0; i < currentAmmoIndex - 1; i++)
                    {
                        if (_pawn.Inventory.AmountOfItem(_config.UsingAmmo[i]) > 0)
                        {
                            _pawn.Equipment.EquipAmmo(_config.UsingAmmo[i]);
                            break;
                        }
                    }
                }
            }
        }

        public void ReloadWeapon()
        {
            if (_config == null || IsPerfomingAction || _ammoInMag == _config.MagSize)
            {
                return;
            }
            if (_pawn.Equipment.AmmoSlot.Config == null || _pawn.Inventory.AmountOfItem(_pawn.Equipment.AmmoSlot.Config) == 0)
            {
                if (_pawn.Inventory.GetAmmo(_config, out AmmoItemConfig ammo))
                {
                    _pawn.Equipment.EquipAmmo(ammo);
                }
            }
            else
            {
                _reloadCoroutine = StartCoroutine(ReloadCoroutine());
            }
        }

        public void ClearAmmoInMag()
        {
            _ammoInMag = 0;
        }

        private IEnumerator FireCoroutine()
        {
            for (int i = 0; i < _config.ProjectilesPerShot; i++)
            {
                _spread = Random.Range(-_config.Spread, _config.Spread);
                _spread += _shootPoint.transform.eulerAngles.z;
                GameManager.StaticInstance.PrefabsManager.GetProjectile(_shootPoint.transform.position, Quaternion.Euler(0f, 0f, _spread)).Initialize(_pawn, _config, _pawn.Equipment.AmmoSlot.Config);
            }
            yield return new WaitForSeconds(60f / _config.FireRate);
            _fireCoroutine = null;
            if (_config != null)
            {
                if (_ammoInMag == 0)
                {
                    ReloadWeapon();
                }
            }
        }

        private IEnumerator ReloadCoroutine()
        {
            yield return new WaitForSeconds(_config.ReloadTime / _pawn.Status.StatHolder.GetStat("RLDSPD").CurrentValue / 100f);
            if (_config != null && _pawn.Equipment.AmmoSlot.Config != null)
            {
                int ammoDif = _config.MagSize - _ammoInMag;
                int amountInInventory = _pawn.Inventory.AmountOfItem(_pawn.Equipment.AmmoSlot.Config);
                if (ammoDif > amountInInventory)
                {
                    ammoDif = amountInInventory;
                }
                if (_pawn.Inventory.RemoveItem(_pawn.Equipment.AmmoSlot.Config, ammoDif))
                {
                    _ammoInMag += ammoDif;
                }
            }
            _reloadCoroutine = null;
        }
    }
}