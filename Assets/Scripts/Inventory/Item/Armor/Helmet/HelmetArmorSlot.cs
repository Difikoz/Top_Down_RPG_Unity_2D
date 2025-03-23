using UnityEngine;

namespace WinterUniverse
{
    public class HelmetArmorSlot : ArmorSlot
    {
        private HelmetArmorItemConfig _config;

        public HelmetArmorItemConfig Config => _config;

        public override void Initialize()
        {
            base.Initialize();
            ChangeConfig(null);
        }

        public void ChangeConfig(HelmetArmorItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _spriteRenderer.sprite = _config.VisualSprite;
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }
    }
}