using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class InventorySlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private Image _iconImage;
        [SerializeField] private TMP_Text _amountText;
        [SerializeField] private Image _deselectedFrame;
        [SerializeField] private Image _selectedFrame;
        [SerializeField] private Image _pressedFrame;

        private ItemStack _stack;

        public ItemStack Stack => _stack;

        public void Initialize(ItemStack stack)
        {
            _stack = stack;
            _iconImage.sprite = _stack.Item.Icon;
            _amountText.text = $"{(_stack.Amount > 1 ? _stack.Amount : "")}";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _thisButton.Select();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _thisButton.OnDeselect(eventData);
        }

        public void OnSelect(BaseEventData eventData)
        {
            _deselectedFrame.gameObject.SetActive(false);
            _selectedFrame.gameObject.SetActive(true);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _deselectedFrame.gameObject.SetActive(true);
            _selectedFrame.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                //show drop and drop all?
            }
            else
            {
                OnSubmit(eventData);
            }
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (_pressedFrame.gameObject.activeSelf)
            {
                _stack.Item.OnUse(GameManager.StaticInstance.ControllersManager.Player);
            }
            else
            {
                GameManager.StaticInstance.UIManager.StatusBar.InventoryPage.ShowFullInformation(this);
            }
        }

        public void TogglePressedFrame(bool visible)
        {
            _pressedFrame.gameObject.SetActive(visible);
        }
    }
}