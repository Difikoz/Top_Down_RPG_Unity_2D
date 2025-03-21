using System;
using System.Collections.Generic;

namespace WinterUniverse
{
    public class StatHolder
    {
        public Action OnStatsChanged;

        private Dictionary<string, Stat> _stats;

        public Dictionary<string, Stat> Stats => _stats;

        public StatHolder()
        {
            _stats = new();
        }

        public void CreateStats(List<StatConfig> stats)
        {
            foreach (StatConfig stat in stats)
            {
                _stats.Add(stat.ID, new(stat));
            }
        }

        public void RecalculateStats()
        {
            foreach (KeyValuePair<string, Stat> s in _stats)
            {
                s.Value.CalculateCurrentValue();
            }
        }

        public Stat GetStat(string id)
        {
            if (_stats.ContainsKey(id))
            {
                return _stats[id];
            }
            return null;
        }

        public void AddStatModifiers(List<StatModifierCreator> modifiers)
        {
            foreach (StatModifierCreator smc in modifiers)
            {
                AddStatModifier(smc);
            }
            RecalculateStats();
        }

        public void AddStatModifier(StatModifierCreator smc)
        {
            GetStat(smc.Stat.ID).AddModifier(smc.Modifier);
        }

        public void RemoveStatModifiers(List<StatModifierCreator> modifiers)
        {
            foreach (StatModifierCreator smc in modifiers)
            {
                RemoveStatModifier(smc);
            }
            RecalculateStats();
        }

        public void RemoveStatModifier(StatModifierCreator smc)
        {
            GetStat(smc.Stat.ID).RemoveModifier(smc.Modifier);
        }
    }
}