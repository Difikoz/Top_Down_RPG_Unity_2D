using UnityEngine;

namespace WinterUniverse
{
    public class PantsEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _bodySpriteRenderer;
        [SerializeField] private SpriteRenderer[] _upperLegSpriteRenderers;
        [SerializeField] private SpriteRenderer[] _lowerLegSpriteRenderers;
        private PantsEquipmentItemConfig _config;

        public PantsEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(PantsEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _bodySpriteRenderer.sprite = _config.BodyVisualSprite;
                foreach (SpriteRenderer sr in _upperLegSpriteRenderers)
                {
                    sr.sprite = _config.UpperLegVisualSprite;
                }
                foreach (SpriteRenderer sr in _lowerLegSpriteRenderers)
                {
                    sr.sprite = _config.LowerLegVisualSprite;
                }
            }
            else
            {
                _bodySpriteRenderer.sprite = null;
                foreach (SpriteRenderer sr in _upperLegSpriteRenderers)
                {
                    sr.sprite = null;
                }
                foreach (SpriteRenderer sr in _lowerLegSpriteRenderers)
                {
                    sr.sprite = null;
                }
            }
        }
    }
}