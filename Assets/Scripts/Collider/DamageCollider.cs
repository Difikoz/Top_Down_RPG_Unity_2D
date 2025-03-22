using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class DamageCollider : MonoBehaviour
    {
        [SerializeField] protected List<DamageType> _damageTypes;
        [SerializeField] protected List<EffectCreator> _damageEffects;

        protected List<PawnController> _damagedTargets = new();

        public virtual void Initialize()
        {
            //_damagedTargets = new();
        }

        public virtual void Enable()
        {

        }

        public virtual void Disable()
        {

        }

        public void ClearDamagedTargets()
        {
            _damagedTargets.Clear();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PawnController target = collision.GetComponentInParent<PawnController>();
            if (CanHitTarget(target))
            {
                _damagedTargets.Add(target);
                OnHitTarget(collision, target);
            }
        }

        public abstract bool CanHitTarget(PawnController target);
        public abstract void OnHitTarget(Collider2D collider, PawnController target);
    }
}