using UnityEngine;

namespace WinterUniverse
{
    public class HelmetEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        private HelmetEquipmentItemConfig _config;

        public HelmetEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(HelmetEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _spriteRenderer.sprite = _config.HelmetSprite;
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }
    }
}