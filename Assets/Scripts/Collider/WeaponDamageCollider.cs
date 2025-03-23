using System;
using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponDamageCollider : DamageCollider
    {
        public Action OnHit;

        [SerializeField] private Collider2D _collider;

        private PawnController _owner;

        public override void Enable()
        {
            base.Enable();
            _collider.enabled = true;
        }

        public override void Disable()
        {
            _collider.enabled = false;
            base.Disable();
        }

        public void Initialize(PawnController owner, List<DamageType> damageTypes, List<EffectCreator> damageEffects)
        {
            Initialize();
            _owner = owner;
            _damageTypes = new(damageTypes);
            _damageEffects = new(damageEffects);
        }

        public override bool CanHitTarget(PawnController target)
        {
            return _owner != target && !_damagedTargets.Contains(target);
        }

        public override void OnHitTarget(Collider2D collider, PawnController target)
        {
            target.Status.ApplyDamage(_damageTypes, _owner);
            target.Status.EffectHolder.ApplyEffects(_damageEffects, _owner);
            OnHit?.Invoke();
        }
    }
}