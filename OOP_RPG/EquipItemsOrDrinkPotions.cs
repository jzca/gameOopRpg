using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    public class EquipItemsOrDrinkPotions
    {
        public Hero Hero { get; }
        public Shop Shop { get; }
        private string EquipInput { get; set; }
        private int OrderNum { get; set; }


        public EquipItemsOrDrinkPotions(Hero hero)
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
                Console.WriteLine("3. Wear a SHIELD");
                Console.WriteLine("4. Take off current WEAPON");
                Console.WriteLine("5. Take off current ARMOR");
                Console.WriteLine("6. Take off current SHIELD");
                Console.WriteLine("7. Drink a POTION");
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
                        Console.WriteLine("No Weapon to wear ");
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
                        Console.WriteLine("No Armor to wear ");
                    }
                }
                else if (EquipInput == "3")
                {
                    if (Hero.ShieldsBag.Any())
                    {
                        WearShield();
                    }
                    else
                    {
                        Console.WriteLine("No Shield to wear ");
                    }
                }
                else if (EquipInput == "4")
                {

                    if (Hero.EquippedWeapon != null)
                    {
                        TakeOffWeapon();
                    }
                    else
                    {
                        Console.WriteLine("No Weapon to take off ");
                    }


                }
                else if (EquipInput == "5")
                {
                    if (Hero.EquippedArmor != null)
                    {
                        TakeOffArmor();
                    }
                    else
                    {
                        Console.WriteLine("No Armor to take off ");
                    }
                }
                else if (EquipInput == "6")
                {
                    if (Hero.EquippedShield != null)
                    {
                        TakeOffShield();
                    }
                    else
                    {
                        Console.WriteLine("No Shield to take off ");
                    }
                }
                else if (EquipInput == "7")
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****  You have ******");
            ShowWeapons();
            OrderNum += 200;
            ShowArmors();
            OrderNum += 300;
            ShowPotions();
            OrderNum += 400;
            ShowShields();
            Console.ResetColor();
        }

        private void ShowWeapons()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****  Weapons ******");
            Hero.WeaponsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--ST:{a.Strength}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowArmors()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("*****  Armors ******");
            Hero.ArmorsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowShields()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("*****  Shield ******");
            Hero.ShieldsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowPotions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*****  Potions ******");
            Hero.PotionsBag.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--HP:{a.HP}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
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

        private void WearShield()
        {
            ShowShields();

            if (Hero.ShieldsBag.Count == 1)
            {
                Hero.EquippedShield = Hero.ShieldsBag[0];
                Console.WriteLine($"You equipped: Shield <{Hero.ShieldsBag[0].Name}>");
            }
            else
            {

                Console.WriteLine("Type the StockId to Wear Shield");
                EquipInput = Console.ReadLine();
                var myShield = (from w in Hero.ShieldsBag
                                where w.GetHashCode().ToString().Substring(0, 4) == EquipInput
                                select w).ToList();
                if (myShield.Any())
                {

                    Hero.EquippedShield = myShield[0];
                    Console.WriteLine($"You equipped: Shield <{myShield[0].Name}>");
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
            Console.WriteLine($"You Un-equipped your Armor");
        }

        private void TakeOffShield()
        {
            Hero.EquippedShield = null;
            Console.WriteLine($"You Un-equipped your Shield");
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

                    Console.WriteLine($"You drank: Potion <{myPotion[0].Name}> and your new HP is {Hero.CurrentHP}");
                    var potionToRemove = Hero.PotionsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == EquipInput);
                    Hero.PotionsBag.Remove(potionToRemove);
                }
                else
                {
                    Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                }

            }

        }















    }

}


