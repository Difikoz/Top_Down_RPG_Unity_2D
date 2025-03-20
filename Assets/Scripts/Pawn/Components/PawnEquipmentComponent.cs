using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnEquipmentComponent : PawnComponent
    {
        public Action OnEquipmentChanged;

        private MeleeWeaponSlot _meleeWeaponSlot;
        private RangedWeaponSlot _rangedWeaponSlot;
        private ArmorSlot _armorSlot;
        private AmmoSlot _ammoSlot;
        private WeaponType _currentWeaponType;

        public MeleeWeaponSlot MeleeWeaponSlot => _meleeWeaponSlot;
        public RangedWeaponSlot RangedWeaponSlot => _rangedWeaponSlot;
        public ArmorSlot ArmorSlot => _armorSlot;
        public AmmoSlot AmmoSlot => _ammoSlot;
        public WeaponType CurrentWeaponType => _currentWeaponType;

        public override void Initialize()
        {
            base.Initialize();
            _meleeWeaponSlot = GetComponentInChildren<MeleeWeaponSlot>();
            _rangedWeaponSlot = GetComponentInChildren<RangedWeaponSlot>();
            _armorSlot = GetComponentInChildren<ArmorSlot>();
            _ammoSlot = GetComponentInChildren<AmmoSlot>();
            _meleeWeaponSlot.Initialize();
            _rangedWeaponSlot.Initialize();
            _armorSlot.Initialize();
            _ammoSlot.Initialize();
            ToggleWeaponSlot(WeaponType.Melee);
        }

        public void EquipMeleeWeapon(MeleeWeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (_meleeWeaponSlot.Config != null && addOldToInventory)
            {
                _pawn.Inventory.AddItem(_meleeWeaponSlot.Config);
            }
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _meleeWeaponSlot.ChangeConfig(config);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipRangedWeapon(RangedWeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (_rangedWeaponSlot.Config != null && addOldToInventory)
            {
                _pawn.Inventory.AddItem(_rangedWeaponSlot.Config);
            }
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _rangedWeaponSlot.ChangeConfig(config);
            OnEquipmentChanged?.Invoke();
            EquipAmmo(config.UsingAmmo[0]);
        }

        public void EquipArmor(ArmorItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_armorSlot.Config != null && addOldToInventory)
            {
                _pawn.Inventory.AddItem(_armorSlot.Config);
            }
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _armorSlot.ChangeConfig(config);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipAmmo(AmmoItemConfig config)
        {
            if (_rangedWeaponSlot.Config == null || !_rangedWeaponSlot.Config.UsingAmmo.Contains(config))
            {
                return;
            }
            if (_ammoSlot.Config != null && _rangedWeaponSlot.AmmoInMag > 0)
            {
                _pawn.Inventory.AddItem(_ammoSlot.Config, _rangedWeaponSlot.AmmoInMag);
            }
            _rangedWeaponSlot.ClearAmmoInMag();
            _ammoSlot.ChangeConfig(config);
            _rangedWeaponSlot.ReloadWeapon();
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipMeleeWeapon(bool addOldToInventory = true)
        {
            if (_meleeWeaponSlot.Config == null)
            {
                return;
            }
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_meleeWeaponSlot.Config);
            }
            _meleeWeaponSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipRangedWeapon(bool addOldToInventory = true)
        {
            if (_rangedWeaponSlot.Config == null)
            {
                return;
            }
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_rangedWeaponSlot.Config);
            }
            _rangedWeaponSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
            UnequipAmmo();
        }

        public void UnequipArmor(bool addOldToInventory = true)
        {
            if (_armorSlot.Config == null)
            {
                return;
            }
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_armorSlot.Config);
            }
            _armorSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipAmmo()
        {
            if (_ammoSlot.Config == null)
            {
                return;
            }
            if (_rangedWeaponSlot.AmmoInMag > 0)
            {
                _pawn.Inventory.AddItem(_ammoSlot.Config, _rangedWeaponSlot.AmmoInMag);
            }
            _rangedWeaponSlot.ClearAmmoInMag();
            _ammoSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void ToggleWeaponSlot(WeaponType type)
        {
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            _currentWeaponType = type;
            if (_currentWeaponType == WeaponType.Melee)
            {
                _meleeWeaponSlot.gameObject.SetActive(true);
                _rangedWeaponSlot.gameObject.SetActive(false);
            }
            else if (_currentWeaponType == WeaponType.Ranged)
            {
                _meleeWeaponSlot.gameObject.SetActive(false);
                _rangedWeaponSlot.gameObject.SetActive(true);
            }
        }

        public void PerformWeaponAction()
        {
            if (!_meleeWeaponSlot.CanAttack() || !_rangedWeaponSlot.CanFire())
            {
                return;
            }
            if (_currentWeaponType == WeaponType.Melee)
            {
                _meleeWeaponSlot.Attack();
            }
            else if (_currentWeaponType == WeaponType.Ranged)
            {
                _rangedWeaponSlot.Fire();
            }
        }
    }
}