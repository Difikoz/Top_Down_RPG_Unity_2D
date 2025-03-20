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
    }
}