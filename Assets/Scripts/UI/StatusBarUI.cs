using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class StatusBarUI : BasicComponent
    {
        [SerializeField] private List<GameObject> _pages = new();

        private int _currentPageIndex;
        private EquipmentBarUI _equipmentBar;
        private InventoryBarUI _inventoryBar;
        private JournalBarUI _journalBar;
        private FactionsBarUI _factionsBar;
        private MapBarUI _mapBar;

        public EquipmentBarUI EquipmentBar => _equipmentBar;
        public InventoryBarUI InventoryBar => _inventoryBar;
        public JournalBarUI JournalBar => _journalBar;
        public FactionsBarUI FactionsBar => _factionsBar;
        public MapBarUI MapBar => _mapBar;

        public override void Initialize()
        {
            base.Initialize();
            _equipmentBar = GetComponentInChildren<EquipmentBarUI>();
            _inventoryBar = GetComponentInChildren<InventoryBarUI>();
            _journalBar = GetComponentInChildren<JournalBarUI>();
            _factionsBar = GetComponentInChildren<FactionsBarUI>();
            _mapBar = GetComponentInChildren<MapBarUI>();
            _equipmentBar.Initialize();
            _inventoryBar.Initialize();
            _journalBar.Initialize();
            _factionsBar.Initialize();
            _mapBar.Initialize();
        }

        public override void Enable()
        {
            base.Enable();
            _equipmentBar.Enable();
            _inventoryBar.Enable();
            _journalBar.Enable();
            _factionsBar.Enable();
            _mapBar.Enable();
            ShowTab(0);
            gameObject.SetActive(false);
        }

        public override void Disable()
        {
            _equipmentBar.Disable();
            _inventoryBar.Disable();
            _journalBar.Disable();
            _factionsBar.Disable();
            _mapBar.Disable();
            base.Disable();
        }

        public void PreviousTab()
        {
            if (_currentPageIndex > 0)
            {
                ShowTab(_currentPageIndex - 1);
            }
            else
            {
                ShowTab(_pages.Count - 1);
            }
        }

        public void NextTab()
        {
            if (_currentPageIndex < _pages.Count - 1)
            {
                ShowTab(_currentPageIndex + 1);
            }
            else
            {
                ShowTab(0);
            }
        }

        public void ShowTab(int index)
        {
            _currentPageIndex = index;
            for (int i = 0; i < _pages.Count; i++)
            {
                _pages[i].SetActive(i == _currentPageIndex);
            }
        }
    }
}