using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class EquipmentBarUI : BasicComponent
    {
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        private MeleeWeaponSlotUI _meleeWeaponSlot;
        private RangedWeaponSlotUI _rangedWeaponSlot;
        private ArmorSlotUI _armorSlot;
        private AmmoSlotUI _ammoSlot;

        public override void Initialize()
        {
            base.Initialize();
            _meleeWeaponSlot = GetComponentInChildren<MeleeWeaponSlotUI>();
            _rangedWeaponSlot = GetComponentInChildren<RangedWeaponSlotUI>();
            _armorSlot = GetComponentInChildren<ArmorSlotUI>();
            _ammoSlot = GetComponentInChildren<AmmoSlotUI>();
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
            _meleeWeaponSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.MeleeWeaponSlot.Config);
            _rangedWeaponSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.RangedWeaponSlot.Config);
            _armorSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.ArmorSlot.Config);
            _ammoSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.AmmoSlot.Config);
        }

        public void ShowFullInformation(ItemConfig config)
        {
            if (config != null)
            {
                _infoBarNameText.text = config.DisplayName;
                _infoBarDescriptionText.text = config.Description;
            }
            else
            {
                _infoBarNameText.text = string.Empty;
                _infoBarDescriptionText.text = string.Empty;
            }
        }
    }
}