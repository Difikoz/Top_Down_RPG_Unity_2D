using UnityEngine;

namespace WinterUniverse
{
    public class CameraManager : BasicComponent
    {
        [SerializeField] private float _followSpeed = 10f;

        private PlayerInputActions _inputActions;
        private PlayerController _player;
        private Camera _camera;
        private Vector2 _cursorInput;

        public Camera Camera => _camera;

        public override void Initialize()
        {
            base.Initialize();
            _inputActions = new();
            _camera = GetComponentInChildren<Camera>();
        }

        public override void Enable()
        {
            base.Enable();
            _player = GameManager.StaticInstance.ControllersManager.Player;
            _inputActions.Enable();
            _inputActions.Camera.Cursor.performed += ctx => _cursorInput = ctx.ReadValue<Vector2>();
        }

        public override void Disable()
        {
            _inputActions.Camera.Cursor.performed -= ctx => _cursorInput = ctx.ReadValue<Vector2>();
            _inputActions.Disable();
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            _player.Input.LookPoint = _camera.ScreenToWorldPoint(_cursorInput);
            transform.position = Vector3.Lerp(transform.position, _player.Animator.BodyPoint.position, _followSpeed * Time.fixedDeltaTime);
        }
    }
}