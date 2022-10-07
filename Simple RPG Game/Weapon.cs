using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    public class Weapon
    {
        private string weaponName;

        private int damage;
        public Weapon(string weaponName, int damage)
        {
            this.WeaponName = weaponName;
            this.Damage = damage;
        }

        public string WeaponName
        {
            get { return this.weaponName; }

            set { this.weaponName = value; }
        }
        public int Damage
        {
            get { return this.damage; }

            set { this.damage = value; }
        }
    }
}
