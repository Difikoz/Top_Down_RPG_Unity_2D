using UnityEngine;

namespace WinterUniverse
{
    [CreateAssetMenu(fileName = "Melee Weapon", menuName = "Winter Universe/Item/Weapon/New Melee Weapon")]
    public class MeleeWeaponItemConfig : WeaponItemConfig
    {
        [SerializeField] private float _attackRange = 1f;
        [SerializeField] private float _attackSpeed = 1f;
        [SerializeField] private float _attackCooldown = 0.5f;

        public float AttackRange => _attackRange;
        public float AttackSpeed => _attackSpeed;
        public float AttackCooldown => _attackCooldown;

        private void OnValidate()
        {
            _itemType = ItemType.Weapon;
            _weaponType = WeaponType.Melee;
        }
    }
}