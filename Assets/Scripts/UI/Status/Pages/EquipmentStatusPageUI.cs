using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class EquipmentStatusPageUI : StatusPageUI
    {
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        private MeleeWeaponSlotUI _meleeWeaponSlot;
        private RangedWeaponSlotUI _rangedWeaponSlot;
        private HelmetSlotUI _helmetSlot;
        private ChestSlotUI _chestSlot;
        private BeltSlotUI _beltSlot;
        private PantsSlotUI _pantsSlot;
        private GlovesSlotUI _glovesSlot;
        private BootsSlotUI _bootsSlot;
        private AmmoSlotUI _ammoSlot;

        public override void Initialize()
        {
            base.Initialize();
            _meleeWeaponSlot = GetComponentInChildren<MeleeWeaponSlotUI>();
            _rangedWeaponSlot = GetComponentInChildren<RangedWeaponSlotUI>();
            _helmetSlot = GetComponentInChildren<HelmetSlotUI>();
            _chestSlot = GetComponentInChildren<ChestSlotUI>();
            _beltSlot = GetComponentInChildren<BeltSlotUI>();
            _pantsSlot = GetComponentInChildren<PantsSlotUI>();
            _glovesSlot = GetComponentInChildren<GlovesSlotUI>();
            _bootsSlot = GetComponentInChildren<BootsSlotUI>();
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
            _helmetSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.HelmetSlot.Config);
            _chestSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.ChestSlot.Config);
            _beltSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.BackpackSlot.Config);
            _pantsSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.PantsSlot.Config);
            _glovesSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.GlovesSlot.Config);
            _bootsSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.BootsSlot.Config);
            _ammoSlot.Initialize(GameManager.StaticInstance.ControllersManager.Player.Equipment.AmmoSlot.Config);
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