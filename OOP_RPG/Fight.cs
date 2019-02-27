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
        private int BaseDamage { get; set; }
        private int MinDamage { get; set; }
        private int MaxDamage { get; set; }
        private Random rdmDmg { get; set; }
        private Random rdmEscape { get; set; }
        private EquipItems RecoverHP { get; }
        private bool NotEscape { get; set; }
        private AchievementSystem Achievement { get; set; }



        public Fight(Hero hero, EquipItems recoverHP, AchievementSystem achievement)
        {
            Hero = hero;
            Monsters = new List<Monster>();
            rdmDmg = new Random();
            rdmEscape = new Random();
            RecoverHP = recoverHP;
            NotEscape = true;
            Achievement = achievement;

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
            AddMonster(DayOfWeek.Sunday, DifficultyLevel.Easy, "Kakuna", 5, 5, 20);
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

            while (Enemy.CurrentHP > 0 && Hero.CurrentHP > 0 && NotEscape)
            {
                Console.WriteLine($"You've encountered a {Enemy.Name}! {Enemy.Difficulty} Level, {Enemy.Strength} Strength, {Enemy.Defense} Defense," +
                    $" { Enemy.CurrentHP } HP. What will you do?");

                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Run Away");

                var input = Console.ReadLine();

                if (input == "1")
                {
                    HeroTurn();
                }
                else if (input == "2")
                {
                    CanEscape();
                }
            }
        }

        private void HeroTurn()
        {

            // New Damage Calculation

            int WeaponStrength = 0;

            if (Hero.EquippedWeapon != null)
            {
                WeaponStrength = Hero.EquippedWeapon.Strength;
            }
            BaseDamage = Hero.Strength + WeaponStrength - Enemy.Defense;
            MinDamage = Convert.ToInt32(BaseDamage * 0.5);
            MaxDamage = Convert.ToInt32(BaseDamage * 1.5);
            if (MinDamage < MaxDamage)
            {
                Compare = rdmDmg.Next(MinDamage, MaxDamage + 1);
            }
            else
            {
                Compare = BaseDamage;
            }

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
                AchievementProcess();
                Win();
            }
            else
            {
                MonsterTurn();
            }
        }

        private void AchievementProcess()
        {
            Achievement.AddNameMonster(Enemy.Name);
            Achievement.CountMonsters();
            Achievement.PublishAchievement();
        }

        private void MonsterTurn()
        {
            MonsterTurnBasic();

            if (Hero.CurrentHP <= 20)  // When HP is less than 20
            {
                MoreLife(); // Ask the gamer if he wants to recover HP
            }


            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }

        private void EscapeMonsterTurn()
        {
            MonsterTurnBasic();

            if (Hero.CurrentHP <= 0)
            {
                Lose();
            }
        }


        private void MonsterTurnBasic()
        {
            int ArmorDefense = 0;
            int ShieldDefense = 0;

            if (Hero.EquippedArmor != null)
            {
                ArmorDefense = Hero.EquippedArmor.Defense;
            }
            if (Hero.EquippedShield != null)
            {
                ShieldDefense = Hero.EquippedShield.Defense;
            }

            BaseDamage = Enemy.Strength - (ArmorDefense + ShieldDefense + Hero.Defense);

            MinDamage = Convert.ToInt32(BaseDamage - BaseDamage * 0.5);

            MaxDamage = Convert.ToInt32(BaseDamage + BaseDamage * 0.5);
            if (MinDamage < MaxDamage)
            {
                Compare = rdmDmg.Next(MinDamage, MaxDamage + 1);
            }
            else
            {
                Compare = BaseDamage;
            }


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


        }

        private void MoreLife()
        {
            Console.WriteLine($"Your Current HP is [{Hero.CurrentHP}].");
            Console.WriteLine("Would you like to recover HP ?");
            Console.WriteLine("Type 1 for [Yay], Anything-else for [Nay].");
            var userInput = Console.ReadLine();
            if (userInput == "1")
            {
                if (Hero.PotionsBag.Any())
                {
                    RecoverHP.DrinkPotion();
                }
                else
                {
                    Console.WriteLine("Sorry. You don't have any potion.");
                }
            }
            else
            {
                Console.WriteLine("Happy Fighting");
                BlankSpace();
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
            BlankSpace();
        }

        private void Trophy()
        {
            Random rdm = new Random();

            if (Enemy.Difficulty == DifficultyLevel.Easy)
            {
                TrophyEarned = rdm.Next(1, 11);
            }
            else if (Enemy.Difficulty == DifficultyLevel.Medium)
            {
                TrophyEarned = rdm.Next(11, 21);
            }
            else if (Enemy.Difficulty == DifficultyLevel.Hard)
            {
                TrophyEarned = rdm.Next(21, 31);
            }

            Hero.Balance += TrophyEarned;

        }

        private void CanEscape()
        {

            if (Enemy.Difficulty == DifficultyLevel.Easy && rdmEscape.Next(0, 101) < 51)
            {
                RunAway();
            }
            else if (Enemy.Difficulty == DifficultyLevel.Medium && rdmEscape.Next(0, 101) < 26)
            {
                RunAway();
            }
            else if (Enemy.Difficulty == DifficultyLevel.Hard && rdmEscape.Next(0, 101) < 6)
            {
                RunAway();
            }
            else
            {
                MsgFailedRunAway();
                BlankSpace();
                EscapeMonsterTurn();
            }
        }

        private void RunAway()
        {
            NotEscape = false;
            Console.WriteLine("Congrats! You Escaped from the Monster!");
            BlankSpace();
        }

        private void MsgFailedRunAway()
        {
            Console.WriteLine("Opps. Failed to Escape! You will be hit.");
        }

        private void BlankSpace()
        {
            Console.WriteLine(" ");
        }




    }
}
