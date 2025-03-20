using UnityEngine;

namespace WinterUniverse
{
    public class AmmoSlot : MonoBehaviour
    {
        private PawnController _pawn;
        private AmmoItemConfig _config;

        public AmmoItemConfig Config => _config;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
        }

        public void ChangeConfig(AmmoItemConfig config)
        {
            if (_config != null)
            {

            }
            _config = config;
            if (_config != null)
            {

            }
        }
    }
}