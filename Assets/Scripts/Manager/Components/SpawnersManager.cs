using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class SpawnersManager : BasicComponent
    {
        //private List<SpawnerBase> _spawners = new();

        public override void Initialize()
        {
            base.Initialize();
            //SpawnerBase[] spawners = FindObjectsByType<SpawnerBase>(FindObjectsSortMode.None);
            //foreach (SpawnerBase spawner in spawners)
            //{
            //    _spawners.Add(spawner);
            //    spawner.Initialize();
            //}
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            //foreach (SpawnerBase spawner in _spawners)
            //{
            //    spawner.OnUpdate();
            //}
        }
    }
}