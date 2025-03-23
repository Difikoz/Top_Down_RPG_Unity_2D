using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class StatSlotUI : MonoBehaviour, IPointerEnterHandler, ISelectHandler
    {
        [SerializeField] private Button _thisButton;
        [SerializeField] private TMP_Text _infoText;

        private Stat _stat;

        public void Initialize(Stat stat)
        {
            _stat = stat;
            _infoText.text = $"{stat.Config.DisplayName.GetLocalizedString()}: {stat.CurrentValue:0.##}{(stat.Config.IsPercent ? "%" : "")}";
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _thisButton.Select();
        }

        public void OnSelect(BaseEventData eventData)
        {
            GameManager.StaticInstance.UIManager.StatusBar.StatsPage.ShowFullInformation(_stat.Config);
        }
    }
}