using UnityEngine;

namespace WinterUniverse
{
    public class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] private EquipmentTypeConfig _type;
        [SerializeField] private SpriteRenderer[] _spriteRenderers;
        private EquipmentItemConfig _config;

        public EquipmentItemConfig Config => _config;
        public EquipmentTypeConfig Type => _type;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(EquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                foreach (SpriteRenderer sr in _spriteRenderers)
                {
                    sr.sprite = _config.EquipmentSprite;
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