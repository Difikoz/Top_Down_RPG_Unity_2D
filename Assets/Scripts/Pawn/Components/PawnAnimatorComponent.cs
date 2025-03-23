using UnityEngine;

namespace WinterUniverse
{
    public class PawnAnimatorComponent : PawnComponent
    {
        [SerializeField] private AnimatorOverrideController _controller;
        [SerializeField] private Transform _bodyPoint;
        [SerializeField] private Transform _headPoint;

        private Animator _animator;

        public Transform BodyPoint => _bodyPoint;
        public Transform HeadPoint => _headPoint;

        public override void Initialize()
        {
            base.Initialize();
            _animator = GetComponent<Animator>();
        }

        public void PlayAction(string name, float fadeTime = 0.1f, bool isPerfomingAction = true)
        {
            _pawn.Status.StateHolder.SetStateValue("Is Perfoming Action", isPerfomingAction);
            _animator.CrossFade(name, fadeTime);
        }

        public void SetFloat(string name, float value)
        {
            _animator.SetFloat(name, value);
        }

        public void ChangeController(AnimatorOverrideController controller)
        {
            if (controller != null)
            {
                _animator.runtimeAnimatorController = controller;
            }
            else
            {
                _animator.runtimeAnimatorController = _controller;
            }
        }

        //public void SpawnRangedProjectiles()
        //{
        //    _pawn.Equipment.WeaponSlot.WeaponController.SpawnProjectiles();
        //}

        //public void EnableMeleeCollider()
        //{
        //    _pawn.Equipment.WeaponSlot.WeaponController.EnableDamageCollider();
        //}

        //public void DisableMeleeCollider()
        //{
        //    _pawn.Equipment.WeaponSlot.WeaponController.DisableDamageCollider();
        //}
    }
}