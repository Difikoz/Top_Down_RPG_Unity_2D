using System;

namespace WinterUniverse
{
    public class PawnEquipmentComponent : PawnComponent
    {
        public Action OnEquipmentChanged;

        private MeleeWeaponSlot _meleeWeaponSlot;
        private RangedWeaponSlot _rangedWeaponSlot;
        private HelmetEquipmentSlot _helmetSlot;
        private ChestEquipmentSlot _chestSlot;
        private GlovesEquipmentSlot _glovesSlot;
        private PantsEquipmentSlot _pantsSlot;
        private BootsEquipmentSlot _bootsSlot;
        private BeltEquipmentSlot _backpackSlot;
        private AmmoSlot _ammoSlot;
        private WeaponType _currentWeaponType;

        public MeleeWeaponSlot MeleeWeaponSlot => _meleeWeaponSlot;
        public RangedWeaponSlot RangedWeaponSlot => _rangedWeaponSlot;
        public HelmetEquipmentSlot HelmetSlot => _helmetSlot;
        public ChestEquipmentSlot ChestSlot => _chestSlot;
        public GlovesEquipmentSlot GlovesSlot => _glovesSlot;
        public PantsEquipmentSlot PantsSlot => _pantsSlot;
        public BootsEquipmentSlot BootsSlot => _bootsSlot;
        public BeltEquipmentSlot BackpackSlot => _backpackSlot;
        public AmmoSlot AmmoSlot => _ammoSlot;
        public WeaponType CurrentWeaponType => _currentWeaponType;

        public override void Initialize()
        {
            base.Initialize();
            _meleeWeaponSlot = GetComponentInChildren<MeleeWeaponSlot>();
            _rangedWeaponSlot = GetComponentInChildren<RangedWeaponSlot>();
            _helmetSlot = GetComponentInChildren<HelmetEquipmentSlot>();
            _chestSlot = GetComponentInChildren<ChestEquipmentSlot>();
            _glovesSlot = GetComponentInChildren<GlovesEquipmentSlot>();
            _pantsSlot = GetComponentInChildren<PantsEquipmentSlot>();
            _bootsSlot = GetComponentInChildren<BootsEquipmentSlot>();
            _backpackSlot = GetComponentInChildren<BeltEquipmentSlot>();
            _ammoSlot = GetComponentInChildren<AmmoSlot>();
            _meleeWeaponSlot.Initialize();
            _rangedWeaponSlot.Initialize();
            _helmetSlot.Initialize();
            _chestSlot.Initialize();
            _glovesSlot.Initialize();
            _pantsSlot.Initialize();
            _bootsSlot.Initialize();
            _backpackSlot.Initialize();
            _ammoSlot.Initialize();
            ToggleWeaponSlot(WeaponType.Melee);
        }

        public void EquipMeleeWeapon(MeleeWeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_meleeWeaponSlot.IsPerfomingAction || _rangedWeaponSlot.IsPerfomingAction)
            {
                return;
            }
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
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
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
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

        public void EquipHelmet(HelmetEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipHelmet(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _helmetSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_helmetSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipChest(ChestEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipChest(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _chestSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_chestSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipGloves(GlovesEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipGloves(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _glovesSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_glovesSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipPants(PantsEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipPants(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _pantsSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_pantsSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipBoots(BootsEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipBoots(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _bootsSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_bootsSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipBackpack(BeltEquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            UnequipBackpack(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _backpackSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(_backpackSlot.Config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipAmmo(AmmoItemConfig config)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
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

        public void UnequipHelmet(bool addOldToInventory = true)
        {
            if (_helmetSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_helmetSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_helmetSlot.Config);
            }
            _helmetSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipChest(bool addOldToInventory = true)
        {
            if (_chestSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_chestSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_chestSlot.Config);
            }
            _chestSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipGloves(bool addOldToInventory = true)
        {
            if (_glovesSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_glovesSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_glovesSlot.Config);
            }
            _glovesSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipPants(bool addOldToInventory = true)
        {
            if (_pantsSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_pantsSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_pantsSlot.Config);
            }
            _pantsSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipBoots(bool addOldToInventory = true)
        {
            if (_bootsSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_bootsSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_bootsSlot.Config);
            }
            _bootsSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipBackpack(bool addOldToInventory = true)
        {
            if (_backpackSlot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_backpackSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_backpackSlot.Config);
            }
            _backpackSlot.ChangeConfig(null);
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
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
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
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
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