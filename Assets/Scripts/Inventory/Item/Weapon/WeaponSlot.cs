using UnityEngine;

namespace WinterUniverse
{
    public abstract class WeaponSlot : BasicComponent
    {
        [SerializeField] protected Transform _weaponRoot;

        protected PawnController _pawn;

        public override void Initialize()
        {
            base.Initialize();
            _pawn = GetComponentInParent<PawnController>();
        }
    }
}