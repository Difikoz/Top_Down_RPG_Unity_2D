using UnityEngine;

namespace WinterUniverse
{
    public class GameManager : Singleton<GameManager>
    {
        private InputMode _inputMode;
        private AudioManager _audioManager;
        private ConfigsManager _configsManager;
        private ControllersManager _controllersManager;
        private LayersManager _layersManager;
        private PrefabsManager _prefabsManager;
        private SpawnersManager _spawnersManager;
        private UIManager _uiManager;

        public InputMode InputMode => _inputMode;
        public AudioManager AudioManager => _audioManager;
        public ConfigsManager ConfigsManager => _configsManager;
        public ControllersManager ControllersManager => _controllersManager;
        public LayersManager LayersManager => _layersManager;
        public PrefabsManager PrefabsManager => _prefabsManager;
        public SpawnersManager SpawnersManager => _spawnersManager;
        public UIManager UIManager => _uiManager;

        protected override void Awake()
        {
            base.Awake();
            GetComponents();
            InitializeComponents();
        }

        private void OnEnable()
        {
            EnableComponents();
        }

        private void OnDisable()
        {
            DisableComponents();
        }

        private void GetComponents()
        {
            _audioManager = GetComponentInChildren<AudioManager>();
            _configsManager = GetComponentInChildren<ConfigsManager>();
            _controllersManager = GetComponentInChildren<ControllersManager>();
            _layersManager = GetComponentInChildren<LayersManager>();
            _prefabsManager = GetComponentInChildren<PrefabsManager>();
            _spawnersManager = GetComponentInChildren<SpawnersManager>();
            _uiManager = GetComponentInChildren<UIManager>();
        }

        private void InitializeComponents()
        {
            _audioManager.Initialize();
            _configsManager.Initialize();
            _controllersManager.Initialize();
            _layersManager.Initialize();
            _prefabsManager.Initialize();
            _spawnersManager.Initialize();
            _uiManager.Initialize();
            SetInputMode(InputMode.Game);
        }

        private void EnableComponents()
        {
            _audioManager.Enable();
            _configsManager.Enable();
            _controllersManager.Enable();
            _layersManager.Enable();
            _prefabsManager.Enable();
            _spawnersManager.Enable();
            _uiManager.Enable();
        }

        private void DisableComponents()
        {
            _audioManager.Disable();
            _configsManager.Disable();
            _controllersManager.Disable();
            _layersManager.Disable();
            _prefabsManager.Disable();
            _spawnersManager.Disable();
            _uiManager.Disable();
        }

        private void FixedUpdate()
        {
            _audioManager.OnFixedUpdate();
            _configsManager.OnFixedUpdate();
            _controllersManager.OnFixedUpdate();
            _layersManager.OnFixedUpdate();
            _prefabsManager.OnFixedUpdate();
            _spawnersManager.OnFixedUpdate();
            _uiManager.OnFixedUpdate();
        }

        public void SetInputMode(InputMode mode)
        {
            _inputMode = mode;
            switch (_inputMode)
            {
                case InputMode.Game:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case InputMode.UI:
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    break;
            }
        }
    }
}