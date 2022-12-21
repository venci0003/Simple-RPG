using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Models.Weapons
{
    public class Weapon
    {
        private string weaponName;

        private int damage;
        public Weapon(string weaponName, int damage)
        {
            WeaponName = weaponName;
            Damage = damage;
        }

        public string WeaponName
        {
            get { return weaponName; }

            set { weaponName = value; }
        }
        public int Damage
        {
            get { return damage; }

            set { damage = value; }
        }
    }
}
