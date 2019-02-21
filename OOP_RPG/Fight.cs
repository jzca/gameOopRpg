using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; }
        private Hero Hero { get; }
        private Monster Enemy { get; set; }
        private int Damage { get; set; }
        private int Compare { get; set; }

        public Fight(Hero hero)
        {
            Hero = hero;
            Monsters = new List<Monster>();

            // Monday
            AddMonster("Easy", "Bulbasaur", 15, 5, 20);
            AddMonster("Easy", "Ivysaur", 15, 5, 20);
            AddMonster("Medium", "Pidgey", 20, 10, 25);
            AddMonster("Medium", "Pidgeotto", 20, 10, 25);
            AddMonster("Hard", "Nidoqueen", 25, 15, 30);

            //Tuesday
            AddMonster("Easy", "Venusaur", 15, 5, 20);
            AddMonster("Easy", "Charmander", 15, 5, 20);
            AddMonster("Medium", "Pidgeot", 20, 10, 25);
            AddMonster("Medium", "Rattata", 20, 10, 25);
            AddMonster("Hard", "Nidorino", 25, 15, 30);

            //Wednesday
            AddMonster("Easy", "Charmeleon", 15, 5, 20);
            AddMonster("Easy", "Charizard", 15, 5, 20);
            AddMonster("Medium", "Raticate", 20, 10, 25);
            AddMonster("Medium", "Spearow", 20, 10, 25);
            AddMonster("Hard", "Nidoking", 25, 15, 30);

            //Thursday
            AddMonster("Easy", "Squirtle", 15, 5, 20);
            AddMonster("Easy", "Wartortle", 15, 5, 20);
            AddMonster("Medium", "Fearow", 20, 10, 25);
            AddMonster("Medium", "Ekans", 20, 10, 25);
            AddMonster("Hard", "Clefairy", 25, 15, 30);

            //Friday
            AddMonster("Easy", "Blastoise", 15, 5, 20);
            AddMonster("Easy", "Metapod", 15, 5, 20);
            AddMonster("Medium", "Arbok", 20, 10, 25);
            AddMonster("Medium", "Pikachu", 20, 10, 25);
            AddMonster("Hard", "Clefable", 25, 15, 30);

            //Saturday
            AddMonster("Easy", "Butterfree", 15, 5, 20);
            AddMonster("Easy", "Weedle", 15, 5, 20);
            AddMonster("Medium", "Raichu", 20, 10, 25);
            AddMonster("Medium", "Sandshrew", 20, 10, 25);
            AddMonster("Hard", "Vulpix", 25, 15, 30);

            //Sunday
            AddMonster("Easy", "Kakuna", 15, 5, 20);
            AddMonster("Easy", "Beedrill", 15, 5, 20);
            AddMonster("Medium", "Sandslash", 20, 10, 25);
            AddMonster("Medium", "Nidoran", 20, 10, 25);
            AddMonster("Hard", "Ninetales", 25, 15, 30);

        }

        public void AddMonster(string difficulty, string name, int strength, int defense, int hp)
        {
            var monster = new Monster(difficulty, name, strength, defense, hp);

            monster.Difficulty = difficulty;
            monster.Name = name;
            monster.Strength = strength;
            monster.Defense = defense;
            monster.OriginalHP = hp;
            monster.CurrentHP = hp;

            Monsters.Add(monster);
        }


        public void Start()
        {

            if (Monsters.Count != 35)
            {
                throw new AmtOfMonsterException("Opps. There should be 35 monsters");
            }

            Random random = new Random();
            var todayIs = DateTime.Today.DayOfWeek;
            var todayMon = DayOfWeek.Monday;
            var todayTue = DayOfWeek.Tuesday;
            var todayWed = DayOfWeek.Wednesday;
            var todayThu = DayOfWeek.Thursday;
            var todayFri = DayOfWeek.Friday;
            var todaySat = DayOfWeek.Saturday;
            var todaySun = DayOfWeek.Sunday;

            if (todayIs == todayMon)
            {
                Enemy = Monsters[random.Next(0, 5)];
            }
            else if (todayIs == todayTue)
            {
                Enemy = Monsters[random.Next(5, 10)];
            }
            else if (todayIs == todayWed)
            {
                Enemy = Monsters[random.Next(10, 15)];
            }
            else if (todayIs == todayThu)
            {
                Enemy = Monsters[random.Next(15, 20)];
            }
            else if (todayIs == todayFri)
            {
                Enemy = Monsters[random.Next(20, 25)];
            }
            else if (todayIs == todaySat)
            {
                Enemy = Monsters[random.Next(25, 30)];
            }
            else if (todayIs == todaySun)
            {
                Enemy = Monsters[random.Next(30, 35)];
            }

            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0)
            {
                Console.WriteLine($"You've encountered a {Enemy.Name}! {Enemy.Difficulty} Level, {Enemy.Strength} Strength, {Enemy.Defense} Defense," +
                    $" { Enemy.CurrentHP} HP. What will you do?");

                Console.WriteLine("1. Fight");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
            }
        }

        private void HeroTurn()
        {
            Compare = Hero.Strength - Enemy.Defense;

            if (Compare <= 0)
            {
                Damage = 1;
                Enemy.CurrentHP -= Damage;
            }
            else
            {
                Damage = Compare;
                Enemy.CurrentHP -= Damage;
            }

            Console.WriteLine("You did " + Damage + " damage!");

            if (Enemy.CurrentHP <= 0)
            {
                Win();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void MonsterTurn()
        {
            Compare = Enemy.Strength - Hero.Defense;

            if (Compare <= 0)
            {
                Damage = 1;
                Hero.CurrentHP -= Damage;
            }
            else
            {
                Damage = Compare;
                Hero.CurrentHP -= Damage;
            }

            Console.WriteLine(Enemy.Name + " does " + Damage + " damage!");

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void Win()
        {
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle!");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }
    }
}
