using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnEquipmentComponent : PawnComponent
    {
        public Action OnEquipmentChanged;

        private MeleeWeaponSlot _meleeWeaponSlot;
        private RangedWeaponSlot _rangedWeaponSlot;
        private HelmetArmorSlot _helmetSlot;
        private ChestArmorSlot _chestSlot;

        public MeleeWeaponSlot MeleeWeaponSlot => _meleeWeaponSlot;
        public RangedWeaponSlot RangedWeaponSlot => _rangedWeaponSlot;
        public HelmetArmorSlot HelmetSlot => _helmetSlot;
        public ChestArmorSlot ChestSlot => _chestSlot;

        public override void Initialize()
        {
            base.Initialize();
            _meleeWeaponSlot = GetComponentInChildren<MeleeWeaponSlot>();
            _rangedWeaponSlot = GetComponentInChildren<RangedWeaponSlot>();
            _helmetSlot = GetComponentInChildren<HelmetArmorSlot>();
            _chestSlot = GetComponentInChildren<ChestArmorSlot>();
            _meleeWeaponSlot.Initialize();
            _rangedWeaponSlot.Initialize();
            _helmetSlot.Initialize();
            _chestSlot.Initialize();
        }

        public void EquipMeleeWeapon(MeleeWeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_meleeWeaponSlot.WeaponController != null && _meleeWeaponSlot.WeaponController.IsPerfomingAction)
            {
                return;
            }
            UnequipMeleeWeapon(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _meleeWeaponSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
            _pawn.Animator.ChangeController(config.Controller);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipRangedWeapon(RangedWeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_rangedWeaponSlot.WeaponController != null && _rangedWeaponSlot.WeaponController.IsPerfomingAction)
            {
                return;
            }
            UnequipRangedWeapon(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _rangedWeaponSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
            _pawn.Animator.ChangeController(config.Controller);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipHelmet(HelmetArmorItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
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
            _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void EquipChest(ChestArmorItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
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
            _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipMeleeWeapon(bool addOldToInventory = true)
        {
            if (_meleeWeaponSlot.Config == null || _meleeWeaponSlot.WeaponController == null)
            {
                return;
            }
            if (_meleeWeaponSlot.WeaponController.IsPerfomingAction)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_meleeWeaponSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_meleeWeaponSlot.Config);
            }
            _meleeWeaponSlot.ChangeConfig(null);
            _pawn.Animator.ChangeController(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipRangedWeapon(bool addOldToInventory = true)
        {
            if (_rangedWeaponSlot.Config == null || _rangedWeaponSlot.WeaponController == null)
            {
                return;
            }
            if (_rangedWeaponSlot.WeaponController.IsPerfomingAction)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_rangedWeaponSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_rangedWeaponSlot.Config);
            }
            _rangedWeaponSlot.ChangeConfig(null);
            _pawn.Animator.ChangeController(null);
            OnEquipmentChanged?.Invoke();
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
    }
}