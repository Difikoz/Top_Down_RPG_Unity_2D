using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class EquipmentStatusPageUI : StatusPageUI
    {
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        private WeaponSlotUI _weaponSlot;
        private EquipmentSlotUI[] _equipmentSlots;

        public override void Initialize()
        {
            base.Initialize();
            _weaponSlot = GetComponentInChildren<WeaponSlotUI>();
            _equipmentSlots = GetComponentsInChildren<EquipmentSlotUI>();
        }

        public override void Enable()
        {
            base.Enable();
            GameManager.StaticInstance.ControllersManager.Player.Equipment.OnEquipmentChanged += OnEquipmentChanged;
            OnEquipmentChanged();
        }

        public override void Disable()
        {
            GameManager.StaticInstance.ControllersManager.Player.Equipment.OnEquipmentChanged -= OnEquipmentChanged;
            base.Disable();
        }

        private void OnEquipmentChanged()
        {
            ShowFullInformation(null);
            _weaponSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.WeaponSlot.Config);
            foreach (EquipmentSlotUI slot in _equipmentSlots)
            {
                slot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.GetSlot(slot.Type.ID).Config);
            }
        }

        public void ShowFullInformation(ItemConfig config)
        {
            if (config != null)
            {
                _infoBarNameText.text = config.DisplayName.GetLocalizedString();
                _infoBarDescriptionText.text = config.Description.GetLocalizedString();
            }
            else
            {
                _infoBarNameText.text = string.Empty;
                _infoBarDescriptionText.text = string.Empty;
            }
        }
    }
}