using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Shop
    {
        public Hero Hero { get; }
        public Weapon BoughtWeapon { get; set; }
        public Armor BoughtArmor { get; set; }
        public Armor BoughtShield { get; set; }

        public List<Weapon> WeaponsForSale { get; set; }
        public List<Armor> ArmorsForSale { get; set; }
        public List<Potion> PotionsForSale { get; set; }
        public List<Armor> ShieldForSale { get; set; }

        private EquipItems UserSellThings { get; }

        private int OrderNum { get; set; }


        public Shop(Hero hero, EquipItems sellThings)
        {
            WeaponsForSale = new List<Weapon>();
            ArmorsForSale = new List<Armor>();
            PotionsForSale = new List<Potion>();
            ShieldForSale = new List<Armor>();
            Hero = hero;
            OrderNum = 1;
            UserSellThings = sellThings;
            AddNewItems();
            AddNewPotions();
        }

        private void AddNewItems()
        {
            WeaponsForSale.Add(new Weapon("Sword", 3, 10));
            WeaponsForSale.Add(new Weapon("Axe", 4, 2));
            WeaponsForSale.Add(new Weapon("Longsword", 7, 15));

            ArmorsForSale.Add(new Armor("Wooden Vest", 10, 8));
            ArmorsForSale.Add(new Armor("Metal Vest", 12, 14));
            ArmorsForSale.Add(new Armor("Golden Vest", 15, 18));

            ShieldForSale.Add(new Armor("Wooden Shield", 3, 10));
            ShieldForSale.Add(new Armor("Battle Shield", 4, 12));
            ShieldForSale.Add(new Armor("Dragon Shield", 7, 15));
        }

        private void AddNewPotions()
        {
            PotionsForSale.Add(new Potion("Health Potion", 5, 7));
            PotionsForSale.Add(new Potion("Strong Health Potion", 10, 11));
            PotionsForSale.Add(new Potion("Great Health Potion", 15, 16));
        }

        public void OpenShop()
        {

            ShowALLItems();

            var shopAsk = "0";

            while (shopAsk != "9")
            {
                Console.WriteLine("Do you want to do?");
                Console.WriteLine("1. Buy an Item");
                Console.WriteLine("2. Sell an Item");
                Console.WriteLine("9. No. Leave & return to the main menu.");

                shopAsk = Console.ReadLine();

                if (shopAsk == "1")
                {
                    BuyItems();
                }
                else if (shopAsk == "2")
                {
                    SellItems();
                }
                else if (shopAsk == "9")
                {
                    Console.WriteLine("Bye Bye");
                }

            }
        }

        #region ShowWhatInTheShop

        private void ShowALLItems()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("*****  Shop ******");
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
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****  Weapons ******");
            WeaponsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--ST:{a.Strength}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowArmors()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*****  Armors ******");
            ArmorsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowShields()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("*****  Shields ******");
            ShieldForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        private void ShowPotions()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("*****  Potions ******");
            PotionsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--HP:{a.HP}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
            Console.ResetColor();
        }

        #endregion

        private void BuyItems()
        {
            ShowALLItems();
            var shopInput = "0";
            var ExitCode = "99";
            while (shopInput.ToLower() != ExitCode)
            {
                Console.WriteLine("Which one do you want?");
                Console.WriteLine("Type the StockId ");
                Console.WriteLine($"Type {ExitCode} to Leave ");

                shopInput = Console.ReadLine();


                if (shopInput == ExitCode) //Shopping Menu
                {
                    Console.WriteLine("Thank you for shopping :)"); // When you leave, it shows up.
                }
                else
                {
                    var BoughtWeapon = (from w in WeaponsForSale
                                        where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                        select w).ToList();
                    var BoughtArmor = (from w in ArmorsForSale
                                       where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                       select w).ToList();
                    var BoughtShield = (from w in ShieldForSale
                                        where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                        select w).ToList();
                    var BoughtPotion = (from w in PotionsForSale
                                        where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                        select w).ToList();

                    if (BoughtWeapon.Any()) // The Cart has 1 item.
                    {

                        var yourWeapon = BoughtWeapon[0]; // Switch to Index 0.


                        if (Hero.Balance >= yourWeapon.Price) //Check if the hero has enough money.
                        {
                            Hero.Balance = Hero.Balance - yourWeapon.Price; // Deduct from the balance.
                            Hero.WeaponsBag.Add(new Weapon(yourWeapon.Name, yourWeapon.Strength, yourWeapon.Price)); // Add item to the bag.
                            Console.WriteLine($"Your just bought <{yourWeapon.Name}> and your remaining balance is ${Hero.Balance}"); // Receipt
                        }
                        else
                        {
                            Console.WriteLine($"Your Balance: ${Hero.Balance} is too low."); // Show when the balance is too low to buy sth.
                        }
                    }
                    else if (BoughtArmor.Any())
                    {
                        var yourArmor = BoughtArmor[0];

                        if (Hero.Balance >= yourArmor.Price)
                        {
                            Hero.Balance = Hero.Balance - yourArmor.Price;
                            Hero.ArmorsBag.Add(new Armor(yourArmor.Name, yourArmor.Defense, yourArmor.Price));
                            Console.WriteLine($"Your just bought <{yourArmor.Name}> and your remaining balance is ${Hero.Balance}");
                        }
                        else
                        {
                            Console.WriteLine($"Your Balance: ${Hero.Balance} is too low.");
                        }
                    }
                    else if (BoughtShield.Any())
                    {
                        var yourShield = BoughtShield[0];

                        if (Hero.Balance >= yourShield.Price)
                        {
                            Hero.Balance = Hero.Balance - yourShield.Price;
                            Hero.ShieldsBag.Add(new Armor(yourShield.Name, yourShield.Defense, yourShield.Price));
                            Console.WriteLine($"Your just bought <{yourShield.Name}> and your remaining balance is ${Hero.Balance}");
                        }
                        else
                        {
                            Console.WriteLine($"Your Balance: ${Hero.Balance} is too low.");
                        }
                    }
                    else if (BoughtPotion.Any())
                    {
                        var yourPotion = BoughtPotion[0];

                        if (Hero.Balance >= yourPotion.Price)
                        {
                            Hero.Balance = Hero.Balance - yourPotion.Price;
                            Hero.PotionsBag.Add(new Potion(yourPotion.Name, yourPotion.HP, yourPotion.Price));
                            Console.WriteLine($"Your just bought <{yourPotion.Name}> and your remaining balance is ${Hero.Balance}");
                        }
                        else
                        {
                            Console.WriteLine($"Your Balance: ${Hero.Balance} is too low.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                    }

                }
            }




        }

        private void SellItems()
        {
            UserSellThings.ShowALLItems();
            var shopInput = "0";
            var ExitCode = "99".ToLower();
            while (shopInput.ToLower() != ExitCode)
            {
                Console.WriteLine("Which one do you want to sell?");
                Console.WriteLine("Type the StockId ");
                Console.WriteLine($"Type {ExitCode} to Leave ");

                shopInput = Console.ReadLine();


                if (shopInput.ToLower() == ExitCode) //Shopping Menu
                {
                    Console.WriteLine("Thank you for visiting :)"); // When you leave, it shows up.
                }
                else
                {

                    var myWeapon = (from w in Hero.WeaponsBag
                                    where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                    select w).ToList();
                    var myArmor = (from w in Hero.ArmorsBag
                                   where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                   select w).ToList();
                    var myShield = (from w in Hero.ShieldsBag
                                    where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                    select w).ToList();
                    var myPotion = (from w in Hero.PotionsBag
                                    where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                    select w).ToList();

                    if (Hero.EquippedArmor != null || Hero.EquippedShield != null || Hero.EquippedWeapon != null)
                    {
                        Console.WriteLine("You must Un-equip every item before selling anything");
                        Console.WriteLine("Sorry for any inconvenience");
                        Console.WriteLine(" ");
                    }
                    else
                    {

                    if (!myWeapon.Any() && !myArmor.Any() && !myShield.Any() && !myPotion.Any())
                    {
                        Console.WriteLine("[You have Nothing to sell] Or [Try to Type Correct StockId]");
                    }
                    else if (myWeapon.Any())
                    {
                        var potionToRemove = Hero.WeaponsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == shopInput);
                        Hero.WeaponsBag.Remove(potionToRemove);
                        Hero.Balance += Convert.ToInt32(potionToRemove.Price * 0.7);
                        Console.WriteLine($"You just sold <{potionToRemove.Name}> your new balance is ${Hero.Balance} ");
                    }
                    else if (myArmor.Any())
                    {
                        var potionToRemove = Hero.ArmorsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == shopInput);
                        Hero.ArmorsBag.Remove(potionToRemove);
                        Hero.Balance += Convert.ToInt32(potionToRemove.Price * 0.7);
                        Console.WriteLine($"You just sold <{potionToRemove.Name}> your new balance is ${Hero.Balance} ");
                    }
                    else if (myShield.Any())
                    {
                        var potionToRemove = Hero.ShieldsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == shopInput);
                        Hero.ShieldsBag.Remove(potionToRemove);
                        Hero.Balance += Convert.ToInt32(potionToRemove.Price * 0.7);
                        Console.WriteLine($"You just sold <{potionToRemove.Name}> your new balance is ${Hero.Balance} ");
                    }
                    else if (myPotion.Any())
                    {
                        var potionToRemove = Hero.PotionsBag.Single(del => del.GetHashCode().ToString().Substring(0, 4) == shopInput);
                        Hero.PotionsBag.Remove(potionToRemove);
                        Hero.Balance += Convert.ToInt32(potionToRemove.Price * 0.7);
                        Console.WriteLine($"You just sold <{potionToRemove.Name}> your new balance is ${Hero.Balance} ");
                    }

                    }


                }
            }



        }


















    }



}

