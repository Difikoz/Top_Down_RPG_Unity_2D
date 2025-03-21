using UnityEngine;

namespace WinterUniverse
{
    public class PlayerVitalityUI : BasicComponent
    {
        [SerializeField] private VitalityBarUI _healthBar;
        [SerializeField] private VitalityBarUI _staminaBar;

        public override void Enable()
        {
            base.Enable();
            GameManager.StaticInstance.ControllersManager.Player.Status.OnHealthChanged += _healthBar.SetValues;
            GameManager.StaticInstance.ControllersManager.Player.Status.OnStaminaChanged += _staminaBar.SetValues;
            //GameManager.StaticInstance.ControllersManager.Player.Status.RecalculateVitality();
        }

        public override void Disable()
        {
            GameManager.StaticInstance.ControllersManager.Player.Status.OnHealthChanged -= _healthBar.SetValues;
            GameManager.StaticInstance.ControllersManager.Player.Status.OnStaminaChanged -= _staminaBar.SetValues;
            base.Disable();
        }
    }
}