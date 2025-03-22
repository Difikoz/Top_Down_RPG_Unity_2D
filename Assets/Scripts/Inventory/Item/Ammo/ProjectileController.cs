using Lean.Pool;
using System.Collections;
using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private WeaponDamageCollider _collider;

        private PawnController _owner;
        private RangedWeaponItemConfig _weaponConfig;
        private AmmoItemConfig _ammoConfig;
        private int _pierceCount;

        public void Initialize(PawnController owner, RangedWeaponItemConfig weapon, AmmoItemConfig ammo)
        {
            _collider.Initialize();
            _collider.Initialize(owner, weapon.DamageTypes, ammo.DamageEffects, ammo.DamageMultiplier);
            _collider.Enable();
            _owner = owner;
            _weaponConfig = weapon;
            _ammoConfig = ammo;
            _pierceCount = 0;
            _spriteRenderer.sprite = _ammoConfig.ProjectileSprite;
            _rb.linearVelocity = transform.right * _weaponConfig.Force * _ammoConfig.ForceMultiplier;
            StartCoroutine(DespawnCoroutine());
            _collider.OnHit += OnHit;
        }

        private IEnumerator DespawnCoroutine()
        {
            yield return new WaitForSeconds(_weaponConfig.Range / _weaponConfig.Force * _ammoConfig.ForceMultiplier * 1.1f);
            Despawn();
        }

        private void OnHit()
        {
            _pierceCount++;
            if (_pierceCount > _weaponConfig.PierceCount + _ammoConfig.PierceCount)
            {
                Despawn();
            }
        }

        private void Despawn()
        {
            _collider.OnHit -= OnHit;
            _rb.linearVelocity = Vector2.zero;
            _collider.Disable();
            _collider.ClearDamagedTargets();
            LeanPool.Despawn(gameObject);
        }
    }
}