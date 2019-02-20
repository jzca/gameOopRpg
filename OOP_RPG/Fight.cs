using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {
        private List<Monster> Monsters { get; }
        private Hero Hero { get; }
        private Monster Enemy { get; set; }

        public Fight(Hero hero)
        {
            Hero = hero;
            Monsters = new List<Monster>();
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
            var compare = Hero.Strength - Enemy.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                Enemy.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                Enemy.CurrentHP -= damage;
            }

            Console.WriteLine("You did " + damage + " damage!");

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
            int damage;
            var compare = Enemy.Strength - Hero.Defense;

            if (compare <= 0)
            {
                damage = 1;
                Hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                Hero.CurrentHP -= damage;
            }

            Console.WriteLine(Enemy.Name + " does " + damage + " damage!");

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


//// Test Random Q5P1 
//int rdNum1 = random.Next(0, 5);
//int rdNum2 = random.Next(5, 10);
//int rdNum3 = random.Next(10, 15);
//int rdNum4 = random.Next(15, 20);
//int rdNum5 = random.Next(20, 25);
//int rdNum6 = random.Next(25, 30);
//int rdNum7 = random.Next(30, 35);
//Console.WriteLine(rdNum1);
//Console.WriteLine(rdNum2);
//Console.WriteLine(rdNum3);
//Console.WriteLine(rdNum4);
//Console.WriteLine(rdNum5);
//Console.WriteLine(rdNum6);
//Console.WriteLine(random.Next(5, 10));
//Console.WriteLine(random.Next(5, 10));
// Extra: AddMonster("Medium", "Nidorina", 20, 10, 25);