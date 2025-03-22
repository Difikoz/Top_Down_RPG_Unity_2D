using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private WeaponDamageCollider _collider;

        private PawnController _pawn;
        private MeleeWeaponItemConfig _config;
        private Coroutine _attackCoroutine;
        private float _attackSpeed;

        public MeleeWeaponItemConfig Config => _config;
        public bool IsPerfomingAction => _attackCoroutine != null;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
            ChangeConfig(null);
        }

        public void ChangeConfig(MeleeWeaponItemConfig config)
        {
            _config = config;
            if (_config != null)
            {
                _spriteRenderer.sprite = _config.WeaponSprite;
                _collider.Initialize(_pawn, _config.DamageTypes, _config.DamageEffects);
                _collider.ChangeCollider(_config.ColliderSize, _config.ColliderOffset);
            }
            else
            {
                _spriteRenderer.sprite = null;
            }
        }

        public bool CanAttack()
        {
            return _config != null && !IsPerfomingAction;
        }

        public void Attack()
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
            _collider.Enable();
        }

        public void DisableDamageCollider()
        {
            _collider.Disable();
            _collider.ClearDamagedTargets();
        }
    }
}