using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Reduce Stamina Over Time", menuName = "Winter Universe/Effect/New Reduce Stamina Over Time")]
    public class ReduceStaminaOverTimeEffectConfig : EffectConfig
    {
        public override Effect CreateEffect(PawnController target, PawnController source, float value, float duration)
        {
            return new ReduceStaminaOverTimeEffect(this, target, source, value, duration);
        }
    }
}