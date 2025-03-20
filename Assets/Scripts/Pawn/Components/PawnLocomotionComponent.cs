using UnityEngine;

namespace WinterUniverse
{
    public class PawnLocomotionComponent : PawnComponent
    {
        private Rigidbody2D _rb;

        public override void Initialize()
        {
            base.Initialize();
            _rb = GetComponent<Rigidbody2D>();
        }
    }
}