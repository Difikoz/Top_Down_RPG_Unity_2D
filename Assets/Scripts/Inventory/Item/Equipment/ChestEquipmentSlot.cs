using UnityEngine;

namespace WinterUniverse
{
    public class ChestEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _bodySpriteRenderer;
        [SerializeField] private SpriteRenderer[] _upperArmSpriteRenderers;
        [SerializeField] private SpriteRenderer[] _lowerArmSpriteRenderers;
        private ChestEquipmentItemConfig _config;

        public ChestEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(ChestEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _bodySpriteRenderer.sprite = _config.BodyVisualSprite;
                foreach (SpriteRenderer sr in _upperArmSpriteRenderers)
                {
                    sr.sprite = _config.UpperArmVisualSprite;
                }
                foreach (SpriteRenderer sr in _lowerArmSpriteRenderers)
                {
                    sr.sprite = _config.LowerArmVisualSprite;
                }
            }
            else
            {
                _bodySpriteRenderer.sprite = null;
                foreach (SpriteRenderer sr in _upperArmSpriteRenderers)
                {
                    sr.sprite = null;
                }
                foreach (SpriteRenderer sr in _lowerArmSpriteRenderers)
                {
                    sr.sprite = null;
                }
            }
        }
    }
}