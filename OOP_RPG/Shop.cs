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

        public List<Weapon> WeaponsForSale { get; set; }
        public List<Armor> ArmorsForSale { get; set; }
        public List<Potion> PotionsForSale { get; set; }

        private int OrderNum { get; set; }


        public Shop(Hero hero)
        {
            WeaponsForSale = new List<Weapon>();
            ArmorsForSale = new List<Armor>();
            PotionsForSale = new List<Potion>();
            Hero = hero;
            OrderNum = 1;
            AddNewMonsters();
            AddNewPotions();
        }

        private void AddNewMonsters()
        {
            WeaponsForSale.Add(new Weapon("Sword", 3, 10));
            WeaponsForSale.Add(new Weapon("Axe", 4, 2));
            WeaponsForSale.Add(new Weapon("Longsword", 7, 15));
            ArmorsForSale.Add(new Armor("Wooden Vest", 10, 8));
            ArmorsForSale.Add(new Armor("Metal Vest", 12, 14));
            ArmorsForSale.Add(new Armor("Golden Vest", 15, 18));
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
                Console.WriteLine("Do you want to buy my items?");
                Console.WriteLine("1. Yes. Buy a WEAPON");
                Console.WriteLine("2. Yes. Buy a ARMOR");
                Console.WriteLine("3. Yes. Buy a POTION");
                Console.WriteLine("9. No. Leave & return to the main menu.");

                shopAsk = Console.ReadLine();

                if (shopAsk == "1")
                {
                    BuyWeapon();
                }
                else if (shopAsk == "2")
                {
                    BuyArmor();
                }
                else if (shopAsk == "3")
                {
                    BuyPotion();
                }
                else if (shopAsk == "9")
                {
                    Console.WriteLine("Bye Bye");
                }
                else if (shopAsk.ToLower() == "tipme")
                {
                    Hero.Balance = 1000;
                    Console.WriteLine($"You are as rich as ${Hero.Balance}");
                }
            }
        }

        #region ShowWhatInTheShop

        private void ShowALLItems()
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
            WeaponsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--ST:{a.Strength}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        private void ShowArmors()
        {

            Console.WriteLine("*****  Armors ******");
            ArmorsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--DE:{a.Defense}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        private void ShowPotions()
        {
            Console.WriteLine("*****  Potions ******");
            PotionsForSale.ForEach(a => Console.WriteLine($"{OrderNum++}. {a.Name}--HP:{a.HP}--${a.Price}--StockId: {a.GetHashCode().ToString().Substring(0, 4)}"));
            OrderNum = 1;
        }

        #endregion

        private void BuyWeapon()
        {
            ShowWeapons();
            var shopInput = "0";
            var ExitCode = "99".ToLower();
            while (shopInput.ToLower() != ExitCode)
            {
                Console.WriteLine("Which Weapon do you want?");
                Console.WriteLine("Type the StockId ");
                Console.WriteLine($"Type {ExitCode} to Leave ");

                shopInput = Console.ReadLine();


                if (shopInput.ToLower() == ExitCode) //Shopping Menu
                {
                    Console.WriteLine("Thank you for shopping :)"); // When you leave, it shows up.
                }
                else
                {
                    var BoughtWeapon = (from w in WeaponsForSale
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
                    else
                    {
                        Console.WriteLine("Invalid StockId! Try again."); // Show when the input is wrong.
                    }

                }
            }



        }

        private void BuyArmor()
        {
            ShowArmors();
            var shopInput = "0";
            var ExitCode = "99".ToLower();
            while (shopInput.ToLower() != ExitCode)
            {
                Console.WriteLine("Which Armor do you want?");
                Console.WriteLine("Type the StockId ");
                Console.WriteLine($"Type {ExitCode} to Leave ");

                shopInput = Console.ReadLine();

                if (shopInput.ToLower() == ExitCode)
                {
                    Console.WriteLine("Thank you for shopping :)");
                }
                else
                {
                    var BoughtArmor = (from w in ArmorsForSale
                                       where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                       select w).ToList();

                    if (BoughtArmor.Any())
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
                    else
                    {
                        Console.WriteLine("Invalid StockId! Try again.");
                    }

                }
            }



        }


        private void BuyPotion()
        {
            ShowPotions();
            var shopInput = "0";
            var ExitCode = "99".ToLower();
            while (shopInput.ToLower() != ExitCode)
            {
                Console.WriteLine("Which Potion do you want?");
                Console.WriteLine("Type the StockId ");
                Console.WriteLine($"Type {ExitCode} to Leave");

                shopInput = Console.ReadLine();

                if (shopInput.ToLower() == ExitCode)
                {
                    Console.WriteLine("Thank you for shopping :)");
                }
                else
                {
                    var BoughtPotion = (from w in PotionsForSale
                                        where w.GetHashCode().ToString().Substring(0, 4) == shopInput
                                        select w).ToList();

                    if (BoughtPotion.Any())
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
                        Console.WriteLine("Invalid StockId! Try again.");
                    }

                }
            }
        }










    }



}

#region Drafts




//    private List<Shop> Items { get; set; }

//public Shop()
//{
//    Game = new Game();
//}

//public void Add(string name, string description)
//{
//    var task = new Task(name, description);
//    Tasks.Add(task);
//}


//var sword = new Weapon("Sword", 3, 10);
//var axe = new Weapon("Axe", 4, 2);
//var longsword = new Weapon("Longsword", 7, 15);
//var wooden = new Armor("Wooden Vest", 10, 8);
//var metal = new Armor("Metal Vest", 12, 14);
//var golden = new Armor("Golden Vest", 15, 18);

//var shop = new Shop();




//                    if (BoughtArmor.Any())
//                    {
//                        var yourArmor = BoughtArmor[0];
//        bool? haveNotBought;

//        Hero.ArmorsBag.ForEach(a =>
//                        {
//                            if (a.Name != yourArmor.Name)
//                            {
//                                haveNotBought = true;
//                            };
//});

//public void AddW()
//{
//    var weapon = new Weapon(name, strength, price);
//    Weapon.Add(weapon);
//}

//public void ShowShop()
//{
//    Console.WriteLine("*****  Jerry's Shop ******");
//    Console.WriteLine("Weapons: ");
//    Console.WriteLine($"{WeaponsForSale.ToString()}");
//    Console.WriteLine("Armor: ");

//}

//else if (shopInput == "1")
//{

//    //var BoughtWeapon = (from w in Shop.WeaponsForSale
//    //                    where == "Sword"
//    //                    select w).ToList();
//    var BoughtWeapon = WeaponsForSale[0];
//    Hero.WeaponsBag.Add(new Weapon(BoughtWeapon.Name, BoughtWeapon.Strength, BoughtWeapon.Price));
//}
//else if (shopInput == "2")
//{
//    var BoughtWeapon = WeaponsForSale[1];
//    Hero.WeaponsBag.Add(new Weapon(BoughtWeapon.Name, BoughtWeapon.Strength, BoughtWeapon.Price));
//}
//else if (shopInput == "3")
//{
//    var BoughtWeapon = WeaponsForSale[2];
//    Hero.WeaponsBag.Add(new Weapon(BoughtWeapon.Name, BoughtWeapon.Strength, BoughtWeapon.Price));
//}
//else if (shopInput == "4")
//{
//    var BoughtArmor = ArmorsForSale[0];
//    Hero.ArmorsBag.Add(new Armor(BoughtArmor.Name, BoughtArmor.Defense, BoughtArmor.Price));
//}
//else if (shopInput == "5")
//{
//    var BoughtArmor = ArmorsForSale[1];
//    Hero.ArmorsBag.Add(new Armor(BoughtArmor.Name, BoughtArmor.Defense, BoughtArmor.Price));
//}
//else if (shopInput == "6")
//{
//    var BoughtArmor = ArmorsForSale[2];
//    Hero.ArmorsBag.Add(new Armor(BoughtArmor.Name, BoughtArmor.Defense, BoughtArmor.Price));
//}
//else if (shopInput == "7")
//{
//    Console.WriteLine("Thank you for shopping");
//}


//Hero.WeaponsBag.ForEach(a => Console.WriteLine($"{orderNum++}. {a.Name}--D:{a.Strength}--${a.Price}"));
//Console.WriteLine();
//Console.ReadKey();
#endregion
