using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public class ConfigsManager : BasicComponent
    {
        [SerializeField] private List<StatConfig> _stats = new();
        [SerializeField] private List<StateKeyConfig> _states = new();
        [SerializeField] private List<FactionConfig> _factions = new();
        [SerializeField] private List<MeleeWeaponItemConfig> _meleeWeapons = new();
        [SerializeField] private List<RangedWeaponItemConfig> _rangedWeapons = new();
        [SerializeField] private List<ArmorItemConfig> _armors = new();
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
            foreach (MeleeWeaponItemConfig config in _meleeWeapons)
            {
                _items.Add(config);
            }
            foreach (RangedWeaponItemConfig config in _rangedWeapons)
            {
                _items.Add(config);
            }
            foreach (ArmorItemConfig config in _armors)
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

        public MeleeWeaponItemConfig GetMeleeWeapon(string id)
        {
            foreach (MeleeWeaponItemConfig config in _meleeWeapons)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public RangedWeaponItemConfig GetRangedWeapon(string id)
        {
            foreach (RangedWeaponItemConfig config in _rangedWeapons)
            {
                if (config.ID == id)
                {
                    return config;
                }
            }
            return null;
        }

        public ArmorItemConfig GetArmor(string id)
        {
            foreach (ArmorItemConfig config in _armors)
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