using UnityEngine;

namespace WinterUniverse
{
    public class BootsEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        private BootsEquipmentItemConfig _config;

        public BootsEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(BootsEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                foreach (SpriteRenderer sr in _spriteRenderers)
                {
                    sr.sprite = _config.BootsSprite;
                }
            }
            else
            {
                foreach (SpriteRenderer sr in _spriteRenderers)
                {
                    sr.sprite = null;
                }
            }
        }
    }
}