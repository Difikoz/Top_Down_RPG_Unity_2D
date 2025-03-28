using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Restore Health Over Time", menuName = "Winter Universe/Effect/New Restore Health Over Time")]
    public class RestoreHealthOverTimeEffectConfig : EffectConfig
    {
        public override Effect CreateEffect(PawnController target, PawnController source, float value, float duration)
        {
            return new RestoreHealthOverTimeEffect(this, target, source, value, duration);
        }
    }
}