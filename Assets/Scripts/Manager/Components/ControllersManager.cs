using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ControllersManager : BasicComponent
    {
        private PlayerController _player;
        private List<NPCController> _controllers;

        public PlayerController Player => _player;

        public override void Initialize()
        {
            base.Initialize();
            _player = GameManager.StaticInstance.PrefabsManager.GetPlayer(transform);
            _player.Initialize();
            _controllers = new();
        }

        public override void Enable()
        {
            base.Enable();
            _player.Enable();
            foreach (NPCController controller in _controllers)
            {
                controller.Enable();
            }
        }

        public override void Disable()
        {
            _player.Disable();
            foreach (NPCController controller in _controllers)
            {
                controller.Disable();
            }
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            _player.OnFixedUpdate();
            foreach (NPCController controller in _controllers)
            {
                controller.OnFixedUpdate();
            }
        }

        public void AddController(NPCController controller)
        {
            _controllers.Add(controller);
        }

        public void RemoveController(NPCController controller)
        {
            if (_controllers.Contains(controller))
            {
                _controllers.Remove(controller);
            }
        }
    }
}