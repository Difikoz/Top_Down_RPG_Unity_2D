using UnityEngine;

namespace WinterUniverse
{
    public class GlovesEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        private GlovesEquipmentItemConfig _config;

        public GlovesEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(GlovesEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                foreach (SpriteRenderer sr in _spriteRenderers)
                {
                    sr.sprite = _config.GlovesSprite;
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