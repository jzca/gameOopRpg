using System;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero Hero { get; }
        public Shop Shop { get; }
        public EquipItems EquipItems { get; }
        public AchievementSystem AchievementSystem { get; set; }
        private string GameInput { get; set; }

        public Game()
        {
            Hero = new Hero();
            EquipItems = new EquipItems(Hero);
            Shop = new Shop(Hero, EquipItems);
            AchievementSystem = new AchievementSystem();
        }

        public void Start()
        {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");

            Hero.Name = Console.ReadLine();

            Console.WriteLine("Hello " + Hero.Name);

            Main();
        }

        public void Main()
        {
            GameInput = "0";

            while (GameInput != "9")
            {
                if (GameInput.ToLower() != "superhero" || GameInput.ToLower() != "tipme") // Un-Show CheatCodes
                {
                    Console.WriteLine("Type <SuperHero> to boost all data of Hero.");
                    Console.WriteLine("Type <TipMe> to get rich. Case does not matter.");
                }
                Console.WriteLine("Please choose an option by entering a number.");
                Console.WriteLine("1. View Stats");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Fight Monster");
                Console.WriteLine("4. View Jerry's Shop");
                Console.WriteLine("5. Un/Equip Items Or Recover HP");
                Console.WriteLine("6. View Achievements");
                Console.WriteLine("9. Exit");

                GameInput = Console.ReadLine();

                if (GameInput == "1")
                {
                    this.Stats();
                }
                else if (GameInput == "2")
                {
                    this.Inventory();
                }
                else if (GameInput == "3")
                {
                    this.Fight();
                }
                else if (GameInput == "4")
                {
                    Shop.OpenShop();
                }
                else if (GameInput == "5")
                {
                    EquipItems.OpenEquip();
                }
                else if (GameInput == "6")
                {
                    AchievementSystem.ShowAllAchievement();
                }

                if (Hero.CurrentHP <= 0)
                {
                    Console.WriteLine("You must recover your HP before fighting");
                }

                CheatCode();

            }
        }

        private void Stats()
        {
            Hero.ShowStats();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Inventory()
        {
            Hero.ShowInventory();

            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
        }

        private void Fight()
        {
            var fight = new Fight(Hero, EquipItems, AchievementSystem);

            fight.Start();
        }

        private void CheatCode()
        {
            if (GameInput.ToLower() == "superhero")
            {
                Hero.Balance = 1000;
                Hero.OriginalHP = 1000;
                Hero.Defense = 1000;
                Hero.Strength = 1000;
                Hero.CurrentHP = Hero.OriginalHP;
            }
            if (GameInput.ToLower() == "tipme")
            {
                Hero.Balance = 1000;
                Console.WriteLine($"You are as rich as ${Hero.Balance}");
            }
        }




    }

}