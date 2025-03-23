using System;

namespace WinterUniverse
{
    public class PawnEquipmentComponent : PawnComponent
    {
        public Action OnEquipmentChanged;

        private WeaponSlot _weaponSlot;
        private EquipmentSlot[] _equipmentSlots;

        public WeaponSlot WeaponSlot => _weaponSlot;
        public EquipmentSlot[] EquipmentSlots => _equipmentSlots;

        public override void Initialize()
        {
            base.Initialize();
            _weaponSlot = GetComponentInChildren<WeaponSlot>();
            _equipmentSlots = GetComponentsInChildren<EquipmentSlot>();
            _weaponSlot.Initialize();
            foreach (EquipmentSlot slot in _equipmentSlots)
            {
                slot.Initialize();
            }
        }

        public void Equip(WeaponItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            if (_weaponSlot.WeaponController != null && !_weaponSlot.WeaponController.CanAttack())
            {
                return;
            }
            UnequipWeapon(addOldToInventory);
            if (removeNewFromInventory)
            {
                _pawn.Inventory.RemoveItem(config);
            }
            _weaponSlot.ChangeConfig(config);
            _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
            _pawn.Animator.ChangeController(config.Controller);
            OnEquipmentChanged?.Invoke();
        }

        public void Equip(EquipmentItemConfig config, bool removeNewFromInventory = true, bool addOldToInventory = true)
        {
            if (_pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", true))
            {
                return;
            }
            foreach (EquipmentSlot slot in _equipmentSlots)
            {
                if (slot.Type.ID == config.EquipmentType.ID)
                {
                    UnequipEquipment(slot, addOldToInventory);
                    if (removeNewFromInventory)
                    {
                        _pawn.Inventory.RemoveItem(config);
                    }
                    slot.ChangeConfig(config);
                    _pawn.Status.StatHolder.AddStatModifiers(config.Modifiers);
                    OnEquipmentChanged?.Invoke();
                    break;
                }
            }
        }

        public void UnequipWeapon(bool addOldToInventory = true)
        {
            if (_weaponSlot.Config == null || _weaponSlot.WeaponController == null)
            {
                return;
            }
            if (!_weaponSlot.WeaponController.CanUnequip())
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(_weaponSlot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(_weaponSlot.Config);
            }
            _weaponSlot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public void UnequipEquipment(string type, bool addOldToInventory = true)
        {
            foreach (EquipmentSlot slot in _equipmentSlots)
            {
                if (slot.Type.ID == type)
                {
                    UnequipEquipment(slot, addOldToInventory);
                    break;
                }
            }
        }

        public void UnequipEquipment(EquipmentSlot slot, bool addOldToInventory = true)
        {
            if (slot.Config == null)
            {
                return;
            }
            _pawn.Status.StatHolder.RemoveStatModifiers(slot.Config.Modifiers);
            if (addOldToInventory)
            {
                _pawn.Inventory.AddItem(slot.Config);
            }
            slot.ChangeConfig(null);
            OnEquipmentChanged?.Invoke();
        }

        public EquipmentSlot GetSlot(string id)
        {
            foreach (EquipmentSlot slot in _equipmentSlots)
            {
                if (slot.Type.ID == id)
                {
                    return slot;
                }
            }
            return null;
        }
    }
}