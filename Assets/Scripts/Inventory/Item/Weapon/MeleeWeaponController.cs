using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponController : WeaponController
    {
        private WeaponDamageCollider _damageCollider;
        private Coroutine _attackCoroutine;
        private float _attackSpeed;

        public override void Initialize()
        {
            base.Initialize();
            _damageCollider = GetComponentInChildren<WeaponDamageCollider>();
            _damageCollider.Initialize(_pawn, _config.DamageTypes, _config.DamageEffects);
        }

        public override bool CanUnequip()
        {
            if (_attackCoroutine != null)
            {
                return false;
            }
            return base.CanUnequip();
        }

        public override bool CanAttack()
        {
            if (_attackCoroutine != null)
            {
                return false;
            }
            return base.CanAttack();
        }

        public override void OnAttack()
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            _pawn.Status.EffectHolder.ApplyEffects(_config.AttackEffects, _pawn);
            _attackSpeed = _config.AttackSpeed * _pawn.Status.StatHolder.GetStat("ASPD").CurrentValue / 100f;
            _pawn.Animator.SetFloat("Attack Speed", _attackSpeed);
            _pawn.Animator.PlayAction("Attack");
            yield return new WaitForSeconds(1f / _attackSpeed + _config.AttackCooldown);
            _attackCoroutine = null;
        }

        public void EnableDamageCollider()
        {
            _damageCollider.Enable();
        }

        public void DisableDamageCollider()
        {
            _damageCollider.Disable();
            _damageCollider.ClearDamagedTargets();
        }
    }
}