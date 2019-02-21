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
        private int Damage { get; set; }
        private int Compare { get; set; }
        private int TrophyEarned { get; set; }

        public Fight(Hero hero)
        {
            Hero = hero;
            Monsters = new List<Monster>();

            #region AddMonsters
            // Monday
            AddMonster(DayOfWeek.Monday, DifficultyLevel.Easy, "Bulbasaur", 15, 5, 20);
            AddMonster(DayOfWeek.Monday, DifficultyLevel.Easy, "Ivysaur", 15, 5, 20);
            AddMonster(DayOfWeek.Monday, DifficultyLevel.Medium, "Pidgey", 20, 10, 25);
            AddMonster(DayOfWeek.Monday, DifficultyLevel.Medium, "Pidgeotto", 20, 10, 25);
            AddMonster(DayOfWeek.Monday, DifficultyLevel.Hard, "Nidoqueen", 25, 15, 30);

            //Tuesday
            AddMonster(DayOfWeek.Tuesday, DifficultyLevel.Easy, "Venusaur", 15, 5, 20);
            AddMonster(DayOfWeek.Tuesday, DifficultyLevel.Easy, "Charmander", 15, 5, 20);
            AddMonster(DayOfWeek.Tuesday, DifficultyLevel.Medium, "Pidgeot", 20, 10, 25);
            AddMonster(DayOfWeek.Tuesday, DifficultyLevel.Medium, "Rattata", 20, 10, 25);
            AddMonster(DayOfWeek.Tuesday, DifficultyLevel.Hard, "Nidorino", 25, 15, 30);

            //Wednesday
            AddMonster(DayOfWeek.Wednesday, DifficultyLevel.Easy, "Charmeleon", 15, 5, 20);
            AddMonster(DayOfWeek.Wednesday, DifficultyLevel.Easy, "Charizard", 15, 5, 20);
            AddMonster(DayOfWeek.Wednesday, DifficultyLevel.Medium, "Raticate", 20, 10, 25);
            AddMonster(DayOfWeek.Wednesday, DifficultyLevel.Medium, "Spearow", 20, 10, 25);
            AddMonster(DayOfWeek.Wednesday, DifficultyLevel.Hard, "Nidoking", 25, 15, 30);

            //Thursday
            AddMonster(DayOfWeek.Thursday, DifficultyLevel.Easy, "Squirtle", 15, 5, 20);
            AddMonster(DayOfWeek.Thursday, DifficultyLevel.Easy, "Wartortle", 15, 5, 20);
            AddMonster(DayOfWeek.Thursday, DifficultyLevel.Medium, "Fearow", 20, 10, 25);
            AddMonster(DayOfWeek.Thursday, DifficultyLevel.Medium, "Ekans", 20, 10, 25);
            AddMonster(DayOfWeek.Thursday, DifficultyLevel.Hard, "Clefairy", 25, 15, 30);

            //Friday
            AddMonster(DayOfWeek.Friday, DifficultyLevel.Easy, "Blastoise", 15, 5, 20);
            AddMonster(DayOfWeek.Friday, DifficultyLevel.Easy, "Metapod", 15, 5, 20);
            AddMonster(DayOfWeek.Friday, DifficultyLevel.Medium, "Arbok", 20, 10, 25);
            AddMonster(DayOfWeek.Friday, DifficultyLevel.Medium, "Pikachu", 20, 10, 25);
            AddMonster(DayOfWeek.Friday, DifficultyLevel.Hard, "Clefable", 25, 15, 30);

            //Saturday
            AddMonster(DayOfWeek.Saturday, DifficultyLevel.Easy, "Butterfree", 15, 5, 20);
            AddMonster(DayOfWeek.Saturday, DifficultyLevel.Easy, "Weedle", 15, 5, 20);
            AddMonster(DayOfWeek.Saturday, DifficultyLevel.Medium, "Raichu", 20, 10, 25);
            AddMonster(DayOfWeek.Saturday, DifficultyLevel.Medium, "Sandshrew", 20, 10, 25);
            AddMonster(DayOfWeek.Saturday, DifficultyLevel.Hard, "Vulpix", 25, 15, 30);

            //Sunday
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Easy, "Kakuna", 15, 5, 20);
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Easy, "Beedrill", 15, 5, 20);
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Medium, "Sandslash", 20, 10, 25);
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Medium, "Nidoran", 20, 10, 25);
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Hard, "Ninetales", 25, 15, 30);
            #endregion
        }

        public void AddMonster(DayOfWeek respawnDay, DifficultyLevel difficulty, string name, int strength, int defense, int hp)
        {
            var monster = new Monster(respawnDay, difficulty, name, strength, defense, hp);

            Monsters.Add(monster);
        }

        public void Start()
        {

            if (Monsters.Count != 35)
            {
                throw new AmtOfMonsterException("Opps. There must be 35 monsters");
            }

            var todayIs = DateTime.Today.DayOfWeek;

            Enemy = (from m in Monsters
                     where m.RespawnDay == todayIs
                     orderby Guid.NewGuid().ToString()
                     select m).First();

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
            Trophy();
            Console.WriteLine(Enemy.Name + " has been defeated! You win the battle!");
            Console.WriteLine($"You earned ${TrophyEarned} and your balance is now: ${Hero.Balance}.");
        }

        private void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            Console.WriteLine("Press any key to exit the game");
            Console.ReadKey();
        }

        private void Trophy()
        {
            Random rdm = new Random();

            if (Enemy.Difficulty == DifficultyLevel.Easy)
            {
                TrophyEarned=rdm.Next(1, 11);
                Hero.Balance = Hero.Balance + TrophyEarned;
            }
            else if (Enemy.Difficulty == DifficultyLevel.Medium)
            {
                TrophyEarned = rdm.Next(11, 21);
                Hero.Balance = Hero.Balance + TrophyEarned;
            }
            else if (Enemy.Difficulty == DifficultyLevel.Hard)
            {
                TrophyEarned = rdm.Next(21, 31);
                Hero.Balance = Hero.Balance + TrophyEarned;
            }
        }
    }
}
