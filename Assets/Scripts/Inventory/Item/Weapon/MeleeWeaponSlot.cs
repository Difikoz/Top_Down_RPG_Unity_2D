using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    public class MeleeWeaponSlot : MonoBehaviour
    {
        private PawnController _pawn;
        private MeleeWeaponItemConfig _config;
        private Coroutine _attackCoroutine;

        public MeleeWeaponItemConfig Config => _config;
        public bool IsPerfomingAction => _attackCoroutine != null;

        public void Initialize()
        {
            _pawn = GetComponentInParent<PawnController>();
        }

        public void ChangeConfig(MeleeWeaponItemConfig config)
        {
            if (_config != null)
            {
                //_pawn.StatHolder.RemoveStatModifiers(_config.Modifiers);
            }
            _config = config;
            if (_config != null)
            {
                //_pawn.StatHolder.AddStatModifiers(_config.Modifiers);
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
            _pawn.Animator.SetFloat("Attack Speed", _config.AttackSpeed);
            _pawn.Animator.PlayAction("Attack");
            yield return new WaitForSeconds(1f / _config.AttackSpeed + _config.AttackCooldown);
            _attackCoroutine = null;
        }
    }
}