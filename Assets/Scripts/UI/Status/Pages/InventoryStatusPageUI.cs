using Lean.Pool;
using TMPro;
using UnityEngine;

namespace WinterUniverse
{
    public class InventoryStatusPageUI : StatusPageUI
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private TMP_Text _infoBarNameText;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        public override void Enable()
        {
            base.Enable();
            GameManager.StaticInstance.ControllersManager.Player.Inventory.OnInventoryChanged += OnInventoryChanged;
            OnInventoryChanged();
        }

        public override void Disable()
        {
            GameManager.StaticInstance.ControllersManager.Player.Inventory.OnInventoryChanged -= OnInventoryChanged;
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
                ShowFullInformation(stack.Item);
                LeanPool.Spawn(_slotPrefab, _contentRoot).GetComponent<InventorySlotUI>().Initialize(stack);
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