using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    public abstract class ArmorItemConfig : ItemConfig
    {
        [SerializeField] protected Sprite _visualSprite;
        [SerializeField] protected List<StatModifierCreator> _modifiers = new();
        [SerializeField] protected List<EffectCreator> _onDamageEffects = new();

        public Sprite VisualSprite => _visualSprite;
        public List<StatModifierCreator> Modifiers => _modifiers;
        public List<EffectCreator> OnDamageEffects => _onDamageEffects;
    }
}