using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponController : WeaponController
    {
        [SerializeField] private MeleeWeaponItemConfig _config;

        private WeaponDamageCollider _damageCollider;
        private Coroutine _attackCoroutine;
        private float _attackSpeed;

        public MeleeWeaponItemConfig Config => _config;
        public bool IsPerfomingAction => _attackCoroutine != null;

        public override void Initialize()
        {
            base.Initialize();
            _damageCollider = GetComponentInChildren<WeaponDamageCollider>();
            _damageCollider.Initialize(_pawn, _config.DamageTypes, _config.DamageEffects);
            _damageCollider.Disable();
        }

        public bool CanAttack()
        {
            if (IsPerfomingAction)
            {
                return false;
            }
            return _pawn.Status.EnoughStamina(_config.AttackStaminaCost);
        }

        public void Attack()
        {
            _attackCoroutine = StartCoroutine(AttackCoroutine());
        }

        private IEnumerator AttackCoroutine()
        {
            _pawn.Status.ReduceStaminaCurrent(_config.AttackStaminaCost);
            _pawn.Status.EffectHolder.ApplyEffects(_config.OnAttackEffects, _pawn);
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