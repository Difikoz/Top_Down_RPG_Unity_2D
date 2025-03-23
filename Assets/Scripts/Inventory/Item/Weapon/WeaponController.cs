using UnityEngine;

namespace WinterUniverse
{
    public abstract class WeaponController : BasicComponent
    {
        protected PawnController _pawn;

        public override void Initialize()
        {
            base.Initialize();
            _pawn = GetComponentInParent<PawnController>();
        }
    }
}