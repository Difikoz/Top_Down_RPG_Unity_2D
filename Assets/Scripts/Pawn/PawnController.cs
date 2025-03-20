using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(PawnEquipmentComponent))]
    [RequireComponent(typeof(PawnInventoryComponent))]
    [RequireComponent(typeof(PawnLocomotionComponent))]
    [RequireComponent(typeof(PawnAnimatorComponent))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnController : MonoBehaviour
    {
        private PawnAnimatorComponent _animator;
        private PawnEquipmentComponent _equipment;
        private PawnInventoryComponent _inventory;
        private PawnLocomotionComponent _locomotion;

        public PawnAnimatorComponent Animator => _animator;
        public PawnEquipmentComponent Equipment => _equipment;
        public PawnInventoryComponent Inventory => _inventory;
        public PawnLocomotionComponent Locomotion => _locomotion;

        public virtual void Initialize()
        {
            _animator = GetComponent<PawnAnimatorComponent>();
            _equipment = GetComponent<PawnEquipmentComponent>();
            _inventory = GetComponent<PawnInventoryComponent>();
            _locomotion = GetComponent<PawnLocomotionComponent>();
            _animator.Initialize();
            _equipment.Initialize();
            _inventory.Initialize();
            _locomotion.Initialize();
        }

        public virtual void Enable()
        {
            _animator.Enable();
            _equipment.Enable();
            _inventory.Enable();
            _locomotion.Enable();
        }

        public virtual void Disable()
        {
            _animator.Disable();
            _equipment.Disable();
            _inventory.Disable();
            _locomotion.Disable();
        }

        public virtual void OnFixedUpdate()
        {
            _animator.OnFixedUpdate();
            _equipment.OnFixedUpdate();
            _inventory.OnFixedUpdate();
            _locomotion.OnFixedUpdate();
        }
    }
}