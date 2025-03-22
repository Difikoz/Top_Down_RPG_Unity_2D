using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class ChestSlotUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, ISelectHandler, ISubmitHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private Image _iconImage;
        [SerializeField] private Sprite _emptySprite;

        private ChestEquipmentItemConfig _config;

        public void Initialize(ChestEquipmentItemConfig config)
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

        public void OnSelect(BaseEventData eventData)
        {
            GameManager.StaticInstance.UIManager.StatusBar.EquipmentPage.ShowFullInformation(_config);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (_config == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipChest();
        }

        public void OnSubmit(BaseEventData eventData)
        {
            if (_config == null)
            {
                return;
            }
            GameManager.StaticInstance.ControllersManager.Player.Equipment.UnequipChest();
        }
    }
}