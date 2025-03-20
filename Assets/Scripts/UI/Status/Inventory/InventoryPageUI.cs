using Lean.Pool;
using UnityEngine;

namespace WinterUniverse
{
    public class InventoryPageUI : MonoBehaviour
    {
        [SerializeField] private Transform _contentRoot;
        [SerializeField] private GameObject _slotPrefab;

        public void Initialize()
        {

        }

        public void Enable()
        {

        }

        public void Disable()
        {

        }

        private void UpdateUI()
        {
            while (_contentRoot.childCount > 0)
            {
                LeanPool.Despawn(_contentRoot.GetChild(0).gameObject);
            }
            
        }
    }
}