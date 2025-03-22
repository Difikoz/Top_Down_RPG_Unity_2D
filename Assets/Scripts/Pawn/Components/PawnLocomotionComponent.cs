using UnityEngine;

namespace WinterUniverse
{
    public class PawnLocomotionComponent : PawnComponent
    {
        private Rigidbody2D _rb;
        private Vector2 _moveVelocity;
        private float _moveSpeed;

        public override void Initialize()
        {
            base.Initialize();
            _rb = GetComponent<Rigidbody2D>();
        }

        public override void Enable()
        {
            base.Enable();
            _pawn.Status.StatHolder.OnStatsChanged += OnStatsChanged;
        }

        public override void Disable()
        {
            _pawn.Status.StatHolder.OnStatsChanged -= OnStatsChanged;
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            CalculateMoveVelocity();
            _rb.linearVelocity = _moveVelocity * _moveSpeed;
        }

        private void CalculateMoveVelocity()
        {
            if (_pawn.Input.MoveDirection != Vector2.zero && _pawn.Status.StateHolder.CompareStateValue("Is Perfoming Action", false))
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, _pawn.Input.MoveDirection, 2f * Time.fixedDeltaTime);
            }
            else
            {
                _moveVelocity = Vector2.MoveTowards(_moveVelocity, Vector2.zero, 4f * Time.fixedDeltaTime);
            }
            _pawn.Animator.SetFloat("Move Direction", _pawn.Input.IsFacingRight ? _moveVelocity.x : -_moveVelocity.x);
        }

        private void OnStatsChanged()
        {
            _moveSpeed = _pawn.Status.StatHolder.GetStat("MSPD").CurrentValue;
        }
    }
}