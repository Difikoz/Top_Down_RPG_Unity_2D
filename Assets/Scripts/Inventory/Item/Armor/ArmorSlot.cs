using UnityEngine;

namespace WinterUniverse
{
    public class ArmorSlot : MonoBehaviour
    {
        private PawnController _pawn;
        private ArmorItemConfig _config;

        public ArmorItemConfig Config => _config;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
        }

        public void ChangeConfig(ArmorItemConfig config)
        {
            if (_config != null)
            {
                //_pawn.StatHolder.RemoveStatModifiers(_config.Modifiers);
            }
            _config = config;
            if (_config != null)
            {
                //_pawn.StatHolder.AddStatModifiers(_config.Modifiers);
            }
        }
    }
}