using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        private PawnController _owner;
        private RangedWeaponItemConfig _weaponConfig;
        private GameObject _model;
        private WeaponDamageCollider _damageCollider;
        private int _pierceCount;

        public void Initialize(PawnController owner, RangedWeaponItemConfig weapon)
        {
            _damageCollider.Initialize(owner, weapon.DamageTypes, weapon.UsingAmmo.DamageEffects);
            _damageCollider.Enable();
            _owner = owner;
            _weaponConfig = weapon;
            _pierceCount = 0;
            _model = LeanPool.Spawn(_weaponConfig.UsingAmmo.AmmoPrefab, transform);
            _damageCollider = GetComponentInChildren<WeaponDamageCollider>();
            _damageCollider.Initialize(_owner, _weaponConfig.DamageTypes, _weaponConfig.UsingAmmo.DamageEffects);
            _rb.linearVelocity = transform.right * _weaponConfig.Force;
            StartCoroutine(DespawnCoroutine());
            _damageCollider.OnHit += OnHit;
            _damageCollider.Enable();
        }

        private IEnumerator DespawnCoroutine()
        {
            yield return new WaitForSeconds(_weaponConfig.Range / _weaponConfig.Force * 1.1f);
            Despawn();
        }

        private void OnHit()
        {
            _pierceCount++;
            if (_pierceCount > _weaponConfig.PierceCount + _weaponConfig.UsingAmmo.PierceCount)
            {
                Despawn();
            }
        }

        private void Despawn()
        {
            _damageCollider.Disable();
            _damageCollider.ClearDamagedTargets();
            _damageCollider.OnHit -= OnHit;
            _rb.linearVelocity = Vector2.zero;
            LeanPool.Despawn(_model);
            LeanPool.Despawn(gameObject);
        }
    }
}