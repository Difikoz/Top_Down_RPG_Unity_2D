using System.Collections.Generic;
using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Winter Universe/Item/New Consumable")]
    public class ConsumableItemConfig : ItemConfig
    {
        //[SerializeField] private List<EffectCreator> _effects = new();

        //public List<EffectCreator> Effects => _effects;

        private void OnValidate()
        {
            _itemType = ItemType.Consumable;
        }

        //public override void Use(bool fromInventory = true)
        //{
        //    if (GameManager.StaticInstance.ControllersManager.Player.Status.IsDead)
        //    {
        //        return;
        //    }
        //    if (!fromInventory || (fromInventory && GameManager.StaticInstance.ControllersManager.Player.Inventory.RemoveItem(this)))
        //    {
        //        //if (_playAnimationOnUse)
        //        //{
        //        //    pawn.Animator.PlayAction(_animationOnUse);
        //        //}
        //        GameManager.StaticInstance.ControllersManager.Player.Effects.ApplyEffects(_effects, null);
        //    }
        //}
    }
}