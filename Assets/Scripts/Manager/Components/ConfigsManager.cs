using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ConfigsManager : BasicComponent
    {
        [SerializeField] private List<StatConfig> _stats = new();
        [SerializeField] private List<StateKeyConfig> _states = new();
        [SerializeField] private List<StateCreatorConfig> _stateCreators = new();
        [SerializeField] private List<FactionConfig> _factions = new();
        [SerializeField] private List<WeaponItemConfig> _weapons = new();
        [SerializeField] private List<EquipmentItemConfig> _equipments = new();
        [SerializeField] private List<AmmoItemConfig> _ammo = new();
        [SerializeField] private List<ConsumableItemConfig> _consumables = new();
        [SerializeField] private List<ResourceItemConfig> _resources = new();

        private List<ItemConfig> _items;

        public List<StatConfig> Stats => _stats;
        public List<StateKeyConfig> States => _states;
        public List<FactionConfig> Factions => _factions;
        public List<ItemConfig> Items => _items;

        public override void Initialize()
        {
            base.Initialize();
            _items = new();
            foreach (WeaponItemConfig config in _weapons)
            {
                _items.Add(config);
            }
            foreach (EquipmentItemConfig config in _equipments)
            {
                _items.Add(config);
            }
            foreach (AmmoItemConfig config in _ammo)
            {
                _items.Add(config);
            }
            foreach (ConsumableItemConfig config in _consumables)
            {
                _items.Add(config);
            }
            foreach (ResourceItemConfig config in _resources)
            {
                _items.Add(config);
            }
        }

        public StateCreatorConfig GetStateCreator(string id)
        {
            foreach (StateCreatorConfig config in _stateCreators)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public FactionConfig GetFaction(string id)
        {
            foreach (FactionConfig config in _factions)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public ItemConfig GetItem(string id)
        {
            foreach (ItemConfig config in _items)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public WeaponItemConfig GetWeapon(string id)
        {
            foreach (WeaponItemConfig config in _weapons)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public EquipmentItemConfig GetEquipment(string id)
        {
            foreach (EquipmentItemConfig config in _equipments)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public AmmoItemConfig GetAmmo(string id)
        {
            foreach (AmmoItemConfig config in _ammo)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public ConsumableItemConfig GetConsumable(string id)
        {
            foreach (ConsumableItemConfig config in _consumables)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public ResourceItemConfig GetResource(string id)
        {
            foreach (ResourceItemConfig config in _resources)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }
    }
}