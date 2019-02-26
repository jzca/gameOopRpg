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
        private int OrderNum { get; set; }


        public EquipItems(Hero hero)
        {
            Hero = hero;
            OrderNum = 1;
        }

        public void OpenEquip()
        {

            ShowALLItems();

            EquipInput = "0";

            while (EquipInput != "9")
            {
                Console.WriteLine("Do you want to do?");
                Console.WriteLine("1. Wear a WEAPON");
                Console.WriteLine("2. Wear a ARMOR");
                Console.WriteLine("3. Take off current WEAPON");
                Console.WriteLine("4. Take off current ARMOR");
                Console.WriteLine("5. Drink a POTION");
                Console.WriteLine("9. No. Leave & return to the main menu.");

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
                    if (Hero.PotionsBag.Any())
                    {
                        if (Hero.CurrentHP != Hero.OriginalHP) // check if HP IS NOT at max
                        {
                            DrinkPotion(); // then allow drinking.
                        }
                        else
                        {
                            Console.WriteLine("No need to drink b/c your HP is at Max");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Nothing to drink ");
                    }
                }
                else if (EquipInput == "9")
                {
                    Console.WriteLine("Bye Bye");
                }
            }
        }


        #region ShowWhatInTheBags

        public void ShowALLItems()
        {
            Console.WriteLine("*****  You have ******");
            ShowWeapons();
            OrderNum += 200;
            ShowArmors();
            OrderNum += 300;
            ShowPotions();
        }

        private void ShowWeapons()
        {

            Console.WriteLine("*****  Weapons ******");
            Hero.WeaponsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--ST:{a.Strength}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        private void ShowArmors()
        {

            Console.WriteLine("*****  Armors ******");
            Hero.ArmorsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        private void ShowPotions()
        {
            Console.WriteLine("*****  Potions ******");
            Hero.PotionsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--HP:{a.HP}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        #endregion


        private void WearWeapon()
        {

            ShowWeapons();

            if (Hero.WeaponsBag.Count == 1)
            {
                Hero.EquippedWeapon = Hero.WeaponsBag[0];
                Console.WriteLine($"You equipped: Weapon <{Hero.WeaponsBag[0].Name}>");
            }
            else
            {

                Console.WriteLine("Type the StockId to Wear Weapon");
                EquipInput = Console.ReadLine();
                var myWeapon = (from w in Hero.WeaponsBag
                                where w.GetHashCode().ToString().Substring(0, 4) == EquipInput
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

            ShowArmors();

            if (Hero.ArmorsBag.Count == 1)
            {
                Hero.EquippedArmor = Hero.ArmorsBag[0];
                Console.WriteLine($"You equipped: Armor <{Hero.ArmorsBag[0].Name}>");
            }
            else
            {

                Console.WriteLine("Type the StockId to Wear Armor");
                EquipInput = Console.ReadLine();
                var myArmor = (from w in Hero.ArmorsBag
                               where w.GetHashCode().ToString().Substring(0, 4) == EquipInput
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

        public void DrinkPotion()
        {

            ShowPotions();

            if (Hero.PotionsBag.Count == 1)
            {
                Hero.CurrentHP += Hero.PotionsBag[0].HP;

                if (Hero.CurrentHP > Hero.OriginalHP) // If recovered HP is larger than OriginalHP
                {
                    Hero.CurrentHP = Hero.OriginalHP; // Then use OriginalHP as CurrentHP
                }

                Console.WriteLine($"You drank: Potion <{Hero.PotionsBag[0].Name}> and your new HP is {Hero.CurrentHP}");
                Hero.PotionsBag.RemoveAt(0);
            }
            else
            {

                Console.WriteLine("Type the StockId to Drink Potion");
                EquipInput = Console.ReadLine();
                var myPotion = (from w in Hero.PotionsBag
                                where w.GetHashCode().ToString().Substring(0, 4) == EquipInput
                                select w).ToList();
                if (myPotion.Any())
                {
                    Hero.CurrentHP += myPotion[0].HP;

                    if (Hero.CurrentHP > Hero.OriginalHP) // If recovered HP is larger than OriginalHP
                    {
                        Hero.CurrentHP = Hero.OriginalHP; // Then use OriginalHP as CurrentHP
                    }

                    Console.WriteLine($"You drank: Potion <{myPotion[0].Name}>");
                    //myPotion.RemoveAt(0);
                    var potionToRemove = Hero.PotionsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == EquipInput);
                    Hero.PotionsBag.Remove(potionToRemove);
                    //myPotion = (from del in Hero.PotionsBag
                    //            where del.GetHashCode().ToString().Substring(0, 4) != EquipInput
                    //            select del).ToList();
                }
                else
                {
                    Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                }

            }

        }















    }

}


