using UnityEngine;

namespace WinterUniverse
{
    public class PlayerController : PawnController
    {
        private PlayerInputActions _inputActions;
        private bool _primaryActionInput;
        private bool _secondaryActionInput;

        public override void Initialize()
        {
            base.Initialize();
            _inputActions = new();
        }

        public override void Enable()
        {
            base.Enable();
            _inputActions.Enable();
            _inputActions.Pawn.Interact.performed += ctx => OnInteractPerfomed();
            _inputActions.Pawn.Interact.performed += ctx => _primaryActionInput = true;
            _inputActions.Pawn.Interact.canceled += ctx => _primaryActionInput = false;
            _inputActions.Pawn.Interact.performed += ctx => _secondaryActionInput = true;
            _inputActions.Pawn.Interact.canceled += ctx => _secondaryActionInput = false;
        }

        public override void Disable()
        {
            _inputActions.Pawn.Interact.performed -= ctx => OnInteractPerfomed();
            _inputActions.Pawn.Interact.performed -= ctx => _primaryActionInput = true;
            _inputActions.Pawn.Interact.canceled -= ctx => _primaryActionInput = false;
            _inputActions.Pawn.Interact.performed -= ctx => _secondaryActionInput = true;
            _inputActions.Pawn.Interact.canceled -= ctx => _secondaryActionInput = false;
            _inputActions.Disable();
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            _input.MoveDirection = _inputActions.Pawn.Move.ReadValue<Vector2>();
            if (_equipment.CurrentWeaponType == WeaponType.Melee)
            {
                if (_secondaryActionInput)
                {
                    _equipment.ToggleWeaponSlot(WeaponType.Ranged);
                }
            }
            else if (_equipment.CurrentWeaponType == WeaponType.Ranged)
            {
                if (!_secondaryActionInput)
                {
                    _equipment.ToggleWeaponSlot(WeaponType.Melee);
                }
            }
            if (_primaryActionInput)
            {
                _equipment.PerformWeaponAction();
            }
            base.OnFixedUpdate();
        }

        private void OnInteractPerfomed()
        {

        }
    }
}