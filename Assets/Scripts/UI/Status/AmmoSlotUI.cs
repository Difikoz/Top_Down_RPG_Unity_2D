using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class AmmoSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _emptySprite;

        private AmmoItemConfig _ammo;

        public void Initialize(AmmoItemConfig ammo)
        {
            _ammo = ammo;
            if (_ammo != null)
            {
                _iconImage.sprite = _ammo.Icon;
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

        public void OnSelect(BaseEventData eventData)
        {
            GameManager.StaticInstance.UIManager.StatusBar.EquipmentBar.ShowFullInformation(_ammo);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_ammo == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipAmmo();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (_ammo == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipAmmo();
        }
    }
}