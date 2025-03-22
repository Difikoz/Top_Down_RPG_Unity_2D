using System;
using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class WeaponDamageCollider : DamageCollider
    {
        public Action OnHit;

        [SerializeField] private CapsuleCollider2D _collider;

        private PawnController _owner;
        private float _damageMultiplier;

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

        public void Initialize(PawnController owner, List<DamageType> damageTypes, List<EffectCreator> damageEffects, float damageMultiplier = 1f)
        {
            _owner = owner;
            _damageTypes = new(damageTypes);
            _damageEffects = new(damageEffects);
            _damageMultiplier = damageMultiplier;
        }

        public void ChangeCollider(Vector2 size, Vector2 offset)
        {
            _collider.size = size;
            _collider.offset = offset;
        }

        public override bool CanHitTarget(PawnController target)
        {
            return _owner != target && !_damagedTargets.Contains(target);
        }

        public override void OnHitTarget(Collider2D collider, PawnController target)
        {
            if (UnityEngine.Random.value < target.Status.StatHolder.GetStat("EVADE").CurrentValue / 100f)
            {
                return;
            }
            foreach (DamageType dt in _damageTypes)
            {
                target.Status.ReduceHealthCurrent(dt.Damage * _damageMultiplier, dt.Type, _owner);
            }
            target.Status.EffectHolder.ApplyEffects(_damageEffects, _owner);
            OnHit?.Invoke();
        }
    }
}