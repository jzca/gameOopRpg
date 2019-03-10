using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }


        // Additions
        public int Balance { get; set; }
        public List<Potion> PotionsBag { get; set; }
        public Armor EquippedShield { get; set; }
        public List<Armor> ShieldsBag { get; set; }

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
            PotionsBag = new List<Potion>();
            ShieldsBag = new List<Armor>();
            Strength = 16;
            Defense = 12;
            OriginalHP = 40;
            CurrentHP = 50;
            Balance = 40;
        }

        //These are the Methods of our Class.
        public void ShowStats()
        {

            Console.WriteLine("*****" + Name + "*****");
            Console.WriteLine("Hitpoints: " + CurrentHP + "/" + OriginalHP);
            Console.WriteLine("Balance: " + Balance);

            if (EquippedWeapon == null && EquippedArmor == null && EquippedShield == null)
            {
                Console.WriteLine("Nothing equipped");
                Console.WriteLine("Strength: " + Strength);
                Console.WriteLine("Defense: " + Defense);
            }
            else if (EquippedWeapon != null && EquippedArmor != null && EquippedShield != null)
            {
                Console.WriteLine("A Weapon & an Armor & a Shield  equipped");
                Console.WriteLine($"Total Strength: {Strength + EquippedWeapon.Strength} (+{EquippedWeapon.Strength}) ");
                Console.WriteLine($"Total Defense: {Defense + EquippedArmor.Defense + EquippedShield.Defense}" +
                    $"(+{EquippedArmor.Defense}, +{EquippedShield.Defense})");
            }
            else if (EquippedWeapon != null && EquippedArmor != null)
            {
                Console.WriteLine("A Weapon & an Armor equipped");
                Console.WriteLine($"Total Strength: {Strength + EquippedWeapon.Strength} (+{EquippedWeapon.Strength})");
                Console.WriteLine($"Total Defense: {Defense + EquippedArmor.Defense} (+{EquippedArmor.Defense})");
            }
            else if (EquippedWeapon != null && EquippedShield != null)
            {
                Console.WriteLine("A Weapon & a Shield equipped");
                Console.WriteLine($"Total Strength: {Strength + EquippedWeapon.Strength} (+{EquippedWeapon.Strength})");
                Console.WriteLine($"Total Defense: {Defense + EquippedShield.Defense} (+{EquippedShield.Defense})");
            }
            else if (EquippedArmor != null && EquippedShield != null)
            {
                Console.WriteLine("An Armor & a Shield equipped");
                Console.WriteLine("Strength: " + Strength);
                Console.WriteLine($"Total Defense: {Defense + EquippedArmor.Defense + EquippedShield.Defense} " +
                    $"(+{EquippedArmor.Defense}, +{EquippedShield.Defense})");
            }
            else if (EquippedWeapon != null)
            {
                Console.WriteLine("A Weapon equipped");
                Console.WriteLine($"Total Strength: {Strength + EquippedWeapon.Strength} (+{EquippedWeapon.Strength})");
                Console.WriteLine("Defense: " + Defense);
            }
            else if (EquippedArmor != null)
            {
                Console.WriteLine("An Armor equipped");
                Console.WriteLine("Strength: " + Strength);
                Console.WriteLine($"Total Defense: {Defense + EquippedArmor.Defense} (+{EquippedArmor.Defense})");
            }
            else if (EquippedShield != null)
            {
                Console.WriteLine("A Shield equipped");
                Console.WriteLine("Strength: " + Strength);
                Console.WriteLine($"Total Defense: {Defense + EquippedShield.Defense} (+{EquippedShield.Defense})");
            }


        }

        public void ShowInventory()
        {
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine("Weapons: ");

            foreach (var weapon in WeaponsBag)
            {
                Console.WriteLine(weapon.Name + " of " + weapon.Strength + " Strength");
            }

            Console.WriteLine("Armor: ");

            foreach (var armor in ArmorsBag)
            {
                Console.WriteLine(armor.Name + " of " + armor.Defense + " Defense");
            }


            Console.WriteLine("Shield: ");

            foreach (var shield in ShieldsBag)
            {
                Console.WriteLine(shield.Name + " of " + shield.Defense + " Defense");
            }

            Console.WriteLine("Potions: ");

            foreach (var potion in PotionsBag)
            {
                Console.WriteLine(potion.Name + " of " + potion.HP + " Health Points");
            }


        }
    }
}