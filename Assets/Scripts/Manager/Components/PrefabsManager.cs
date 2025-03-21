using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class PrefabsManager : BasicComponent
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _npcPrefab;
        [SerializeField] private GameObject _itemPrefab;
        [SerializeField] private GameObject _projectilePrefab;

        public PlayerController GetPlayer(Transform point)
        {
            return GetPlayer(point.position, point.rotation);
        }

        public PlayerController GetPlayer(Vector3 position, Quaternion rotation)
        {
            return LeanPool.Spawn(_playerPrefab, position, rotation).GetComponent<PlayerController>();
        }

        public NPCController GetNPC(Transform point)
        {
            return GetNPC(point.position, point.rotation);
        }

        public NPCController GetNPC(Vector3 position, Quaternion rotation)
        {
            return LeanPool.Spawn(_npcPrefab, position, rotation).GetComponent<NPCController>();
        }

        //public InteractableItem GetItem(Transform point)
        //{
        //    return GetItem(point.position, point.rotation);
        //}

        //public InteractableItem GetItem(Vector3 position, Quaternion rotation)
        //{
        //    return LeanPool.Spawn(_itemPrefab, position, rotation).GetComponent<InteractableItem>();
        //}

        public ProjectileController GetProjectile(Transform point)
        {
            return GetProjectile(point.position, point.rotation);
        }

        public ProjectileController GetProjectile(Vector3 position, Quaternion rotation)
        {
            return LeanPool.Spawn(_projectilePrefab, position, rotation).GetComponent<ProjectileController>();
        }

        public void DespawnObject(GameObject go, float delay = 0f)
        {
            LeanPool.Despawn(go, delay);
        }
    }
}