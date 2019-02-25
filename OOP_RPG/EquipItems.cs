using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class EquipItems
    {
        public Hero Hero { get; }
        public Shop Shop { get; }
        private string EquipInput { get; set; }


        public EquipItems(Hero hero)
        {
            //WeaponsForSale = new List<Weapon>();
            //ArmorsForSale = new List<Armor>();

            Hero = hero;
        }

        public void OpenEquip()
        {
            int orderNum = 1;
            Console.WriteLine("*****  You have ******");
            Console.WriteLine("*****  Weapons ******");
            Hero.WeaponsBag.ForEach(a => Console.WriteLine($"{orderNum++}. {a.Name}--S:{a.Strength}--${a.Price}--StockId: {a.GetHashCode()}"));
            Console.WriteLine("*****  Armors ******");
            Hero.ArmorsBag.ForEach(a => Console.WriteLine($"{orderNum++}. {a.Name}--D:{a.Defense}--${a.Price}--StockId: {a.GetHashCode()}"));

            EquipInput = "0";

            while (EquipInput != "5")
            {
                Console.WriteLine("Do you want to wear any items?");
                Console.WriteLine("1. Wear a WEAPON");
                Console.WriteLine("2. Wear a ARMOR");
                Console.WriteLine("3. Take off current WEAPON");
                Console.WriteLine("4. Take off current ARMOR");
                Console.WriteLine("5. No. Leave & return to the main menu.");

                EquipInput = Console.ReadLine();

                if (EquipInput == "1")
                {
                    if (Hero.WeaponsBag.Any())
                    {
                        WearWeapon();
                    }
                    else
                    {
                        Console.WriteLine("Nothing to wear ");
                    }

                }
                else if (EquipInput == "2")
                {
                    if (Hero.ArmorsBag.Any())
                    {
                        WearArmor();
                    }
                    else
                    {
                        Console.WriteLine("Nothing to wear ");
                    }
                }
                else if (EquipInput == "3")
                {

                    if (Hero.EquippedWeapon != null)
                    {
                        TakeOffWeapon();
                    }
                    else
                    {
                        Console.WriteLine("Nothing to take off ");
                    }


                }
                else if (EquipInput == "4")
                {
                    if (Hero.EquippedArmor != null)
                    {
                        TakeOffArmor();
                    }
                    else
                    {
                        Console.WriteLine("Nothing to take off ");
                    }
                }
                else if (EquipInput == "5")
                {
                    Console.WriteLine("Bye Bye");
                }
            }
        }

        private void WearWeapon()
        {
            if (Hero.WeaponsBag.Count == 1)
            {
                Hero.EquippedWeapon = Hero.WeaponsBag[0];
                Console.WriteLine($"You equipped: Weapon <{Hero.WeaponsBag[0].Name}>");
            } else
            {

                Console.WriteLine("Type the StockId to Wear Weapon");
                EquipInput = Console.ReadLine();
                var myWeapon = (from w in Hero.WeaponsBag
                                where w.GetHashCode().ToString() == EquipInput
                                select w).ToList();
                if (myWeapon.Any())
                {
                    Hero.EquippedWeapon = myWeapon[0];
                    Console.WriteLine($"You equipped: Weapon <{myWeapon[0].Name}>");
                }
                else
                {
                    Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                }

            }

        }

        private void WearArmor()
        {

            if (Hero.ArmorsBag.Count==1)
            {
                Hero.EquippedArmor = Hero.ArmorsBag[0];
                Console.WriteLine($"You equipped: Armor <{Hero.ArmorsBag[0].Name}>");
            }
            else
            {

                Console.WriteLine("Type the StockId to Wear Armor");
                EquipInput = Console.ReadLine();
                var myArmor = (from w in Hero.ArmorsBag
                               where w.GetHashCode().ToString() == EquipInput
                               select w).ToList();
                if (myArmor.Any())
                {

                    Hero.EquippedArmor = myArmor[0];
                    Console.WriteLine($"You equipped: Armor <{myArmor[0].Name}>");
                }
                else
                {
                    Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                }

            }

        }

        private void TakeOffWeapon()
        {
            Hero.EquippedWeapon = null;
            Console.WriteLine($"You Un-equipped your Weapon");
        }

        private void TakeOffArmor()
        {
            Hero.EquippedArmor = null;
            Console.WriteLine($"You Un-equipped yourArmor");
        }
















    }

}


