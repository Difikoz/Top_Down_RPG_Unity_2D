using UnityEngine;

namespace WinterUniverse
{
    public class ChestArmorSlot : ArmorSlot
    {
        private ChestArmorItemConfig _config;

        public ChestArmorItemConfig Config => _config;

        public override void Initialize()
        {
            base.Initialize();
            ChangeConfig(null);
        }

        public void ChangeConfig(ChestArmorItemConfig config)
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