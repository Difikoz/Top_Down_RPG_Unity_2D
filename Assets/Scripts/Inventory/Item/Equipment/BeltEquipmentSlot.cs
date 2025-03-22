using UnityEngine;

namespace WinterUniverse
{
    public class BeltEquipmentSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private BeltEquipmentItemConfig _config;

        public BeltEquipmentItemConfig Config => _config;

        public void Initialize()
        {
            ChangeConfig(null);
        }

        public void ChangeConfig(BeltEquipmentItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _spriteRenderer.sprite = _config.BeltSprite;
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }
    }
}