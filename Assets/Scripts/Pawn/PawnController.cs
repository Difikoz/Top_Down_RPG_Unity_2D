using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(PawnAnimatorComponent))]
    [RequireComponent(typeof(PawnEquipmentComponent))]
    [RequireComponent(typeof(PawnInputComponent))]
    [RequireComponent(typeof(PawnInventoryComponent))]
    [RequireComponent(typeof(PawnLocomotionComponent))]
    [RequireComponent(typeof(PawnStatusComponent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PawnController : BasicComponent
    {
        protected PawnAnimatorComponent _animator;
        protected PawnEquipmentComponent _equipment;
        protected PawnInputComponent _input;
        protected PawnInventoryComponent _inventory;
        protected PawnLocomotionComponent _locomotion;
        protected PawnStatusComponent _status;

        public PawnAnimatorComponent Animator => _animator;
        public PawnEquipmentComponent Equipment => _equipment;
        public PawnInputComponent Input => _input;
        public PawnInventoryComponent Inventory => _inventory;
        public PawnLocomotionComponent Locomotion => _locomotion;
        public PawnStatusComponent Status => _status;

        public override void Initialize()
        {
            base.Initialize();
            _animator = GetComponent<PawnAnimatorComponent>();
            _equipment = GetComponent<PawnEquipmentComponent>();
            _input = GetComponent<PawnInputComponent>();
            _inventory = GetComponent<PawnInventoryComponent>();
            _locomotion = GetComponent<PawnLocomotionComponent>();
            _status = GetComponent<PawnStatusComponent>();
            _animator.Initialize();
            _equipment.Initialize();
            _input.Initialize();
            _inventory.Initialize();
            _locomotion.Initialize();
            _status.Initialize();
        }

        public override void Enable()
        {
            base.Enable();
            _animator.Enable();
            _equipment.Enable();
            _input.Enable();
            _inventory.Enable();
            _locomotion.Enable();
            _status.Enable();
        }

        public override void Disable()
        {
            _animator.Disable();
            _equipment.Disable();
            _input.Disable();
            _inventory.Disable();
            _locomotion.Disable();
            _status.Disable();
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            _animator.OnFixedUpdate();
            _equipment.OnFixedUpdate();
            _input.OnFixedUpdate();
            _inventory.OnFixedUpdate();
            _locomotion.OnFixedUpdate();
            _status.OnFixedUpdate();
        }
    }
}