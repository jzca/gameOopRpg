using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; }
        public int Defense { get; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }

        // Additions
        public int Balance { get; set; }

        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            ArmorsBag = new List<Armor>();
            WeaponsBag = new List<Weapon>();
            Strength = 16;
            Defense = 12;
            OriginalHP = 40;
            CurrentHP = 40;
            Balance = 40;
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {

            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
            Console.WriteLine("Balance: " + this.Balance);

            if (this.EquippedWeapon == null && this.EquippedArmor == null)
            {
                Console.WriteLine("Nothing equipped");
                Console.WriteLine("Strength: " + this.Strength);
                Console.WriteLine("Defense: " + this.Defense);
            }
            else if (this.EquippedWeapon != null && this.EquippedArmor != null)
            {
                Console.WriteLine("A Weapon & an Armor equipped");
                Console.WriteLine($"Total Strength: {this.Strength + this.EquippedWeapon.Strength} (+{this.EquippedWeapon.Strength})");
                Console.WriteLine($"Total Defense: {this.Defense + this.EquippedArmor.Defense} (+{this.EquippedArmor.Defense})");
            }
            else if (this.EquippedWeapon != null)
            {
                Console.WriteLine("A Weapon equipped");
                Console.WriteLine($"Total Strength: {this.Strength + this.EquippedWeapon.Strength} (+{this.EquippedWeapon.Strength})");
                Console.WriteLine("Defense: " + this.Defense);
            }
            else if (this.EquippedArmor != null)
            {
                Console.WriteLine("An Armor equipped");
                Console.WriteLine("Strength: " + this.Strength);
                Console.WriteLine($"Total Defense: {this.Defense + this.EquippedArmor.Defense} (+{this.EquippedArmor.Defense})");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");

            foreach (var weapon in this.WeaponsBag)
            {
                Console.WriteLine(weapon.Name + " of " + weapon.Strength + " Strength");
            }

            Console.WriteLine("Armor: ");

            foreach (var armor in this.ArmorsBag)
            {
                Console.WriteLine(armor.Name + " of " + armor.Defense + " Defense");
            }
        }
    }
}