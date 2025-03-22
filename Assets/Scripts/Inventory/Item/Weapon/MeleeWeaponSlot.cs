using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponSlot : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private CapsuleCollider2D _collider;//create damage collider!!!

        private PawnController _pawn;
        private MeleeWeaponItemConfig _config;
        private Coroutine _attackCoroutine;
        private List<PawnController> _damagedTargets;

        public MeleeWeaponItemConfig Config => _config;
        public bool IsPerfomingAction => _attackCoroutine != null;

        public void Initialize()
        {
            _damagedTargets = new();
            _pawn = GetComponentInParent<PawnController>();
            _collider = GetComponentInChildren<CapsuleCollider2D>();
            ChangeConfig(null);
        }

        public void ChangeConfig(MeleeWeaponItemConfig config)
        {
            if (_config != null)
            {
                _pawn.Status.StatHolder.RemoveStatModifiers(_config.Modifiers);
            }
            _config = config;
            if (_config != null)
            {
                _pawn.Status.StatHolder.AddStatModifiers(_config.Modifiers);
                _spriteRenderer.sprite = _config.WeaponSprite;
                _collider.size = _config.ColliderSize;
                _collider.offset = _config.ColliderOffset;
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
            _pawn.Animator.SetFloat("Attack Speed", _config.AttackSpeed);
            _pawn.Animator.PlayAction("Attack");
            yield return new WaitForSeconds(1f / _config.AttackSpeed + _config.AttackCooldown);
            _attackCoroutine = null;
            _damagedTargets.Clear();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_config == null || _attackCoroutine == null)
            {
                return;
            }
            PawnController target = collision.GetComponentInParent<PawnController>();
            if (target != null && target != _pawn && !_damagedTargets.Contains(target))
            {
                _damagedTargets.Add(target);
                foreach (DamageType dt in _config.DamageTypes)
                {
                    target.Status.ReduceHealthCurrent(dt.Damage, dt.Type, _pawn);
                }
                target.Status.EffectHolder.ApplyEffects(_config.DamageEffects, _pawn);
            }
        }
    }
}