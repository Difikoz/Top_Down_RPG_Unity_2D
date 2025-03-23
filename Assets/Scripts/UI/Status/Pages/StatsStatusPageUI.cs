using Lean.Pool;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace WinterUniverse
{
    public class StatsStatusPageUI : StatusPageUI
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;
        [SerializeField] private Image _infoBarIconImage;
        [SerializeField] private TMP_Text _infoBarDescriptionText;

        public override void Enable()
        {
            base.Enable();
            GameManager.StaticInstance.ControllersManager.Player.Status.StatHolder.OnStatsChanged += OnStatsChanged;
            OnStatsChanged();
        }

        public override void Disable()
        {
            GameManager.StaticInstance.ControllersManager.Player.Status.StatHolder.OnStatsChanged -= OnStatsChanged;
            base.Disable();
        }

        private void OnStatsChanged()
        {
            ShowFullInformation(null);
            while (_contentRoot.childCount > 0)
            {
                LeanPool.Despawn(_contentRoot.GetChild(0).gameObject);
            }
            foreach (KeyValuePair<string, Stat> kvp in GameManager.StaticInstance.ControllersManager.Player.Status.StatHolder.Stats)
            {
                ShowFullInformation(kvp.Value.Config);
                LeanPool.Spawn(_slotPrefab, _contentRoot).GetComponent<StatSlotUI>().Initialize(kvp.Value);
            }
        }

        public void ShowFullInformation(StatConfig config)
        {
            if (config != null)
            {
                _infoBarIconImage.sprite = config.Icon;
                _infoBarDescriptionText.text = config.Description.GetLocalizedString();
            }
        }
    }
}