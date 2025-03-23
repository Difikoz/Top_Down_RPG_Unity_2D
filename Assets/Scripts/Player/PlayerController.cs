using UnityEngine;

namespace WinterUniverse
{
    public class PlayerController : PawnController
    {
        [SerializeField] private FactionConfig _startingFaction;
        [SerializeField] private InventoryConfig _startingInventory;

        private PlayerInputActions _inputActions;
        private bool _primaryActionInput;
        private bool _secondaryActionInput;

        public override void Initialize()
        {
            base.Initialize();
            _inputActions = new();
            _status.ChangeFaction(_startingFaction);
            foreach (ItemStack stack in _startingInventory.Stacks)
            {
                _inventory.AddItem(stack);
            }
        }

        public override void Enable()
        {
            base.Enable();
            _inputActions.Enable();
            _inputActions.Pawn.Interact.performed += ctx => OnInteractPerfomed();
            _inputActions.Pawn.PrimaryAction.performed += ctx => _primaryActionInput = true;
            _inputActions.Pawn.PrimaryAction.canceled += ctx => _primaryActionInput = false;
            _inputActions.Pawn.SecondaryAction.performed += ctx => _secondaryActionInput = true;
            _inputActions.Pawn.SecondaryAction.canceled += ctx => _secondaryActionInput = false;
            _inputActions.Pawn.ReloadRangedWeapon.performed += ctx => OnReloadPerfomed();
        }

        public override void Disable()
        {
            _inputActions.Pawn.Interact.performed -= ctx => OnInteractPerfomed();
            _inputActions.Pawn.PrimaryAction.performed -= ctx => _primaryActionInput = true;
            _inputActions.Pawn.PrimaryAction.canceled -= ctx => _primaryActionInput = false;
            _inputActions.Pawn.SecondaryAction.performed -= ctx => _secondaryActionInput = true;
            _inputActions.Pawn.SecondaryAction.canceled -= ctx => _secondaryActionInput = false;
            _inputActions.Pawn.ReloadRangedWeapon.performed -= ctx => OnReloadPerfomed();
            _inputActions.Disable();
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            if (GameManager.StaticInstance.InputMode == InputMode.UI)
            {
                _input.MoveDirection = Vector2.zero;
                return;
            }
            _input.MoveDirection = _inputActions.Pawn.Move.ReadValue<Vector2>();
            if (_primaryActionInput)
            {
                _equipment.WeaponSlot.PerformAttack();
            }
            if (_secondaryActionInput)
            {
                //_equipment.WeaponSlot.PerformAttack();
            }
        }

        private void OnInteractPerfomed()
        {
            if (GameManager.StaticInstance.InputMode == InputMode.UI)
            {
                return;
            }
        }

        private void OnReloadPerfomed()
        {
            if (GameManager.StaticInstance.InputMode == InputMode.UI)
            {
                return;
            }
            _equipment.WeaponSlot.ReloadWeapon();
        }
    }
}