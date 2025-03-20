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

        private PawnController _owner;
        private RangedWeaponItemConfig _weaponConfig;
        private AmmoItemConfig _ammoConfig;
        private int _pierceCount;

        public void Initialize(PawnController owner, RangedWeaponItemConfig weapon, AmmoItemConfig ammo)
        {
            _owner = owner;
            _weaponConfig = weapon;
            _ammoConfig = ammo;
            _pierceCount = 0;
            _spriteRenderer.sprite = _ammoConfig.ProjectileSprite;
            _rb.linearVelocity = transform.right * _weaponConfig.Force * _ammoConfig.ForceMultiplier;
            StartCoroutine(DespawnCoroutine());
        }

        private IEnumerator DespawnCoroutine()
        {
            yield return new WaitForSeconds(_weaponConfig.Range * _ammoConfig.RangeMultiplier / _weaponConfig.Force * _ammoConfig.ForceMultiplier);
            Despawn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            PawnController target = other.GetComponentInParent<PawnController>();
            if (target != null)
            {
                // apply damage with source as player
                // read damage from weapon and ammo multiplier
                // add knockback to target
                _pierceCount++;
                if (_pierceCount > _weaponConfig.PierceCount + _ammoConfig.PierceCount)
                {
                    Despawn();
                }
            }
        }

        private void Despawn()
        {
            _rb.linearVelocity = Vector2.zero;
            LeanPool.Despawn(gameObject);
        }
    }
}