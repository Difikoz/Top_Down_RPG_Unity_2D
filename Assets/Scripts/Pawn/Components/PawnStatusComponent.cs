using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnStatusComponent : PawnComponent
    {
        public Action<float, float> OnHealthChanged;
        public Action<float, float> OnStaminaChanged;
        public Action OnDied;
        public Action OnRevived;

        private EffectHolder _effectHolder;
        private StatHolder _statHolder;
        private StateHolder _stateHolder;
        private float _healthCurrent;
        private float _staminaCurrent;

        public EffectHolder EffectHolder => _effectHolder;
        public StatHolder StatHolder => _statHolder;
        public StateHolder StateHolder => _stateHolder;

        public override void Initialize()
        {
            base.Initialize();
            _effectHolder = new(_pawn);
            _statHolder = new();
            _stateHolder = new();
            //_statHolder.CreateStats();
            //_stateHolder.CreateStates();
            Revive();
        }

        public void ReduceHealthCurrent(float value, DamageTypeConfig type, PawnController source)
        {
            if (_stateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            float resistance = _statHolder.GetStat(type.ResistanceStat.ID).CurrentValue;
            if (resistance < 100f)
            {
                value -= value * resistance / 100f;
                _healthCurrent = Mathf.Clamp(_healthCurrent - value, 0f, _statHolder.GetStat("HP MAX").CurrentValue);
                if (_healthCurrent > 0f)
                {
                    OnHealthChanged?.Invoke(_healthCurrent, _statHolder.GetStat("HP MAX").CurrentValue);
                }
                else
                {
                    Die(source);
                }
            }
            else if (resistance > 100f)
            {
                RestoreHealthCurrent(value * (resistance - 100f) / 100f);
            }
        }

        public void RestoreHealthCurrent(float value)
        {
            if (_stateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            _healthCurrent = Mathf.Clamp(_healthCurrent + value, 0f, _statHolder.GetStat("HP MAX").CurrentValue);
            OnHealthChanged?.Invoke(_healthCurrent, _statHolder.GetStat("HP MAX").CurrentValue);
        }

        public void ReduceStaminaCurrent(float value)
        {
            if (_stateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            _staminaCurrent = Mathf.Clamp(_staminaCurrent + value, 0f, _statHolder.GetStat("SP MAX").CurrentValue);
            OnStaminaChanged?.Invoke(_staminaCurrent, _statHolder.GetStat("SP MAX").CurrentValue);
        }

        public void RestoreStaminaCurrent(float value)
        {
            if (_stateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            _staminaCurrent = Mathf.Clamp(_staminaCurrent + value, 0f, _statHolder.GetStat("SP MAX").CurrentValue);
            OnStaminaChanged?.Invoke(_staminaCurrent, _statHolder.GetStat("SP MAX").CurrentValue);
        }

        public void Die(PawnController source)
        {
            if (_stateHolder.CompareStateValue("Is Dead", true))
            {
                return;
            }
            _healthCurrent = 0f;
            OnHealthChanged?.Invoke(_healthCurrent, _statHolder.GetStat("HP MAX").CurrentValue);
            _stateHolder.SetStateValue("Is Dead", true);
            OnDied?.Invoke();
        }

        public void Revive()
        {
            _stateHolder.SetStateValue("Is Dead", false);
            RestoreHealthCurrent(_statHolder.GetStat("HP MAX").CurrentValue);
            RestoreStaminaCurrent(_statHolder.GetStat("SP MAX").CurrentValue);
            OnRevived?.Invoke();
        }
    }
}