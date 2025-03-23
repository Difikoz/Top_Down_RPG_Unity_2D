using UnityEngine;

namespace WinterUniverse
{
    public abstract class WeaponController : BasicComponent
    {
        [SerializeField] protected WeaponItemConfig _config;

        protected PawnController _pawn;

        public WeaponItemConfig Config => _config;

        public override void Initialize()
        {
            base.Initialize();
            _pawn = GetComponentInParent<PawnController>();
        }

        public virtual bool CanUnequip()
        {
            return true;
        }

        public virtual bool CanAttack()
        {
            return true;
        }

        public abstract void OnAttack();

        public virtual bool CanReload()
        {
            return true;
        }

        public virtual void Reload()
        {

        }

        public virtual void Discharge()
        {

        }
    }
}