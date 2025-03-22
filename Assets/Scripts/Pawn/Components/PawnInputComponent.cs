using UnityEngine;

namespace WinterUniverse
{
    public class PawnInputComponent : PawnComponent
    {
        public Vector2 MoveDirection;
        public Vector2 LookDirection;
        public Vector3 LookPoint;

        private bool _isFacingRight;

        public bool IsFacingRight => _isFacingRight;

        public override void Initialize()
        {
            base.Initialize();
            _isFacingRight = true;
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            LookPoint.z = 0f;
            LookDirection = (LookPoint - _pawn.Animator.BodyPoint.position).normalized;
            if (_isFacingRight && LookDirection.x < 0f)
            {
                FlipLeft();
            }
            else if (!_isFacingRight && LookDirection.x > 0f)
            {
                FlipRight();
            }
        }

        private void FlipRight()
        {
            _isFacingRight = true;
            transform.localScale = new(1f, 1f, 1f);
        }

        private void FlipLeft()
        {
            _isFacingRight = false;
            transform.localScale = new(-1f, 1f, 1f);
        }
    }
}