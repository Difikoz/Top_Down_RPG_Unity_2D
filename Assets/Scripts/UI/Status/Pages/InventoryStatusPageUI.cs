using Lean.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class InventoryStatusPageUI : StatusPageUI
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;
        [SerializeField] private Button _buttonUseItem;
        [SerializeField] private Button _buttonDropItem;
        [SerializeField] private Button _buttonDropStack;
        [SerializeField] private Button _buttonSortInventory;

        private InventorySlotUI _selectedSlot;

        public override void Enable()
        {
            base.Enable();
            _buttonUseItem.onClick.AddListener(OnButtonUseItemPressed);
            _buttonDropItem.onClick.AddListener(OnButtonDropItemPressed);
            _buttonDropStack.onClick.AddListener(OnButtonDropStackPressed);
            _buttonSortInventory.onClick.AddListener(OnButtonSortInventoryPressed);
            GameManager.StaticInstance.ControllersManager.Player.Inventory.OnInventoryChanged += OnInventoryChanged;
            OnInventoryChanged();
        }

        public override void Disable()
        {
            GameManager.StaticInstance.ControllersManager.Player.Inventory.OnInventoryChanged -= OnInventoryChanged;
            _buttonUseItem.onClick.RemoveListener(OnButtonUseItemPressed);
            _buttonDropItem.onClick.RemoveListener(OnButtonDropItemPressed);
            _buttonDropStack.onClick.RemoveListener(OnButtonDropStackPressed);
            _buttonSortInventory.onClick.RemoveListener(OnButtonSortInventoryPressed);
            base.Disable();
        }

        private void OnInventoryChanged()
        {
            ShowFullInformation(null);
            while (_contentRoot.childCount > 0)
            {
                LeanPool.Despawn(_contentRoot.GetChild(0).gameObject);
            }
            foreach (ItemStack stack in GameManager.StaticInstance.ControllersManager.Player.Inventory.Stacks)
            {
                LeanPool.Spawn(_slotPrefab, _contentRoot).GetComponent<InventorySlotUI>().Initialize(stack);
            }
        }

        public void ShowFullInformation(InventorySlotUI slot = null)
        {
            if (_selectedSlot != null)
            {
                _selectedSlot.TogglePressedFrame(false);
            }
            _selectedSlot = slot;
            if (slot != null)
            {
                _infoBarNameText.text = _selectedSlot.Stack.Item.DisplayName.GetLocalizedString();
                _infoBarDescriptionText.text = _selectedSlot.Stack.Item.Description.GetLocalizedString();
                _selectedSlot.TogglePressedFrame(true);
            }
            else
            {
                _infoBarNameText.text = string.Empty;
                _infoBarDescriptionText.text = string.Empty;
            }
        }

        private void OnButtonUseItemPressed()
        {
            if (_selectedSlot == null)
            {
                return;
            }
            _selectedSlot.Stack.Item.OnUse(GameManager.StaticInstance.ControllersManager.Player);
        }

        private void OnButtonDropItemPressed()
        {
            if (_selectedSlot == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Inventory.DropItem(_selectedSlot.Stack.Item);
        }

        private void OnButtonDropStackPressed()
        {
            if (_selectedSlot == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Inventory.DropItem(_selectedSlot.Stack);
        }

        private void OnButtonSortInventoryPressed()
        {

        }
    }
}