using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class MeleeWeaponSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _emptySprite;

        private MeleeWeaponItemConfig _weapon;

        public void Initialize(MeleeWeaponItemConfig weapon)
        {
            _weapon = weapon;
            if (_weapon != null)
            {
                _iconImage.sprite = _weapon.Icon;
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
            GameManager.StaticInstance.UIManager.StatusBar.EquipmentPage.ShowFullInformation(_weapon);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_weapon == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipMeleeWeapon();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (_weapon == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipMeleeWeapon();
        }
    }
}