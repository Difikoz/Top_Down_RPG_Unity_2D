using System;
using UnityEngine;

namespace WinterUniverse
{
    public class PawnStatusComponent : PawnComponent
    {
        public Action<float, float> OnHealthChanged;
        public Action<float, float> OnStaminaChanged;
        public Action OnDied;
        public Action OnRevived;//OnFactionChaged
        public Action OnFactionChanged;

        [SerializeField] private float _healthRegenerationTickTime = 0.5f;
        [SerializeField] private float _staminaRegenerationTickTime = 0.25f;
        [SerializeField] private float _healthRegenerationDelayTime = 10f;
        [SerializeField] private float _staminaRegenerationDelayTime = 5f;

        private EffectHolder _effectHolder;
        private StatHolder _statHolder;
        private StateHolder _stateHolder;
        private FactionConfig _faction;
        private float _healthCurrent;
        private float _staminaCurrent;
        private float _healthRegenerationCurrentTickTime;
        private float _staminaRegenerationCurrentTickTime;
        private float _healthRegenerationCurrentDelayTime;
        private float _staminaRegenerationCurrentDelayTime;

        public EffectHolder EffectHolder => _effectHolder;
        public StatHolder StatHolder => _statHolder;
        public StateHolder StateHolder => _stateHolder;
        public FactionConfig Faction => _faction;

        public override void Initialize()
        {
            base.Initialize();
            _effectHolder = new(_pawn);
            _statHolder = new();
            _stateHolder = new();
            _statHolder.CreateStats(GameManager.StaticInstance.ConfigsManager.Stats);
            _stateHolder.CreateStates(GameManager.StaticInstance.ConfigsManager.States);
        }

        public override void Enable()
        {
            base.Enable();
            _statHolder.OnStatsChanged += ForceUpdateVitalities;
            Revive();
        }

        public override void Disable()
        {
            _statHolder.OnStatsChanged -= ForceUpdateVitalities;
            base.Disable();
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();
            if (_healthRegenerationCurrentDelayTime >= _healthRegenerationDelayTime)
            {
                if (_healthRegenerationCurrentTickTime >= _healthRegenerationTickTime)
                {
                    RestoreHealthCurrent(_statHolder.GetStat("HP REGEN").CurrentValue * _healthRegenerationTickTime);
                    _healthRegenerationCurrentTickTime = 0f;
                }
                else
                {
                    _healthRegenerationCurrentTickTime += Time.fixedDeltaTime;
                }
            }
            else
            {
                _healthRegenerationCurrentDelayTime += Time.deltaTime;
            }
            if (_staminaRegenerationCurrentDelayTime >= _staminaRegenerationDelayTime)
            {
                if (_staminaRegenerationCurrentTickTime >= _staminaRegenerationTickTime)
                {
                    RestoreStaminaCurrent(_statHolder.GetStat("SP REGEN").CurrentValue * _staminaRegenerationTickTime);
                    _staminaRegenerationCurrentTickTime = 0f;
                }
                else
                {
                    _staminaRegenerationCurrentTickTime += Time.fixedDeltaTime;
                }
            }
            else
            {
                _staminaRegenerationCurrentDelayTime += Time.deltaTime;
            }
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
                _healthRegenerationCurrentDelayTime = 0f;
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
            _staminaRegenerationCurrentDelayTime = 0f;
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

        public void ForceUpdateVitalities()
        {
            _healthCurrent = Mathf.Clamp(_healthCurrent, 0f, _statHolder.GetStat("HP MAX").CurrentValue);
            OnHealthChanged?.Invoke(_healthCurrent, _statHolder.GetStat("HP MAX").CurrentValue);
            _staminaCurrent = Mathf.Clamp(_staminaCurrent, 0f, _statHolder.GetStat("SP MAX").CurrentValue);
            OnStaminaChanged?.Invoke(_staminaCurrent, _statHolder.GetStat("SP MAX").CurrentValue);
        }

        public void ChangeFaction(FactionConfig config)
        {
            _faction = config;
            OnFactionChanged?.Invoke();
        }
    }
}