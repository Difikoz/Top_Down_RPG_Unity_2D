using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class WeaponSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Image _deselectedFrame;
        [SerializeField] private Image _selectedFrame;
        [SerializeField] private Sprite _emptySprite;

        private WeaponItemConfig _config;

        public void Initialize(WeaponItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _iconImage.sprite = _config.Icon;
            }
            else
            {
                _iconImage.sprite = _emptySprite;
            }
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
            GameManager.StaticInstance.UIManager.StatusBar.EquipmentPage.ShowFullInformation(_config);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            _deselectedFrame.gameObject.SetActive(true);
            _selectedFrame.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_config == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipWeapon();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (_config == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipWeapon();
        }
    }
}