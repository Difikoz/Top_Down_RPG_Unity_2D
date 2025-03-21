using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(PawnAnimatorComponent))]
    [RequireComponent(typeof(PawnEquipmentComponent))]
    [RequireComponent(typeof(PawnInventoryComponent))]
    [RequireComponent(typeof(PawnLocomotionComponent))]
    [RequireComponent(typeof(PawnStatusComponent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnController : MonoBehaviour
    {
        private PawnAnimatorComponent _animator;
        private PawnEquipmentComponent _equipment;
        private PawnInventoryComponent _inventory;
        private PawnLocomotionComponent _locomotion;
        private PawnStatusComponent _status;

        public PawnAnimatorComponent Animator => _animator;
        public PawnEquipmentComponent Equipment => _equipment;
        public PawnInventoryComponent Inventory => _inventory;
        public PawnLocomotionComponent Locomotion => _locomotion;
        public PawnStatusComponent Status => _status;

        public virtual void Initialize()
        {
            _animator = GetComponent<PawnAnimatorComponent>();
            _equipment = GetComponent<PawnEquipmentComponent>();
            _inventory = GetComponent<PawnInventoryComponent>();
            _locomotion = GetComponent<PawnLocomotionComponent>();
            _status = GetComponent<PawnStatusComponent>();
            _animator.Initialize();
            _equipment.Initialize();
            _inventory.Initialize();
            _locomotion.Initialize();
            _status.Initialize();
        }

        public virtual void Enable()
        {
            _animator.Enable();
            _equipment.Enable();
            _inventory.Enable();
            _locomotion.Enable();
            _status.Enable();
        }

        public virtual void Disable()
        {
            _animator.Disable();
            _equipment.Disable();
            _inventory.Disable();
            _locomotion.Disable();
            _status.Disable();
        }

        public virtual void OnFixedUpdate()
        {
            _animator.OnFixedUpdate();
            _equipment.OnFixedUpdate();
            _inventory.OnFixedUpdate();
            _locomotion.OnFixedUpdate();
            _status.OnFixedUpdate();
        }
    }
}