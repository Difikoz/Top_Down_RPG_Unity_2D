using UnityEngine;

namespace WinterUniverse
{
    public abstract class ItemConfig : BasicInfoConfig
    {
        [SerializeField] protected ItemType _itemType;
        [SerializeField] protected int _stackSize = 1;
        [SerializeField] protected float _weight = 1f;
        [SerializeField] protected int _price = 100;

        public ItemType ItemType => _itemType;
        public int StackSize => _stackSize;
        public float Weight => _weight;
        public int Price => _price;

        public void OnUse(PawnController pawn, bool fromInventory = true)
        {
            switch (_itemType)
            {
                case ItemType.MeleeWeapon:
                    MeleeWeaponItemConfig melee = (MeleeWeaponItemConfig)this;
                    pawn.Equipment.EquipMeleeWeapon(melee, fromInventory);
                    break;
                case ItemType.RangedWeapon:
                    RangedWeaponItemConfig ranged = (RangedWeaponItemConfig)this;
                    pawn.Equipment.EquipRangedWeapon(ranged, fromInventory);
                    break;
                case ItemType.Helmet:
                    HelmetArmorItemConfig helmet = (HelmetArmorItemConfig)this;
                    pawn.Equipment.EquipHelmet(helmet, fromInventory);
                    break;
                case ItemType.Chest:
                    ChestArmorItemConfig chest = (ChestArmorItemConfig)this;
                    pawn.Equipment.EquipChest(chest, fromInventory);
                    break;
                case ItemType.Consumable:
                    ConsumableItemConfig consumable = (ConsumableItemConfig)this;
                    if (!fromInventory || pawn.Inventory.RemoveItem(this))
                    {
                        pawn.Status.EffectHolder.ApplyEffects(consumable.Effects);
                    }
                    break;
            }
        }
    }
}