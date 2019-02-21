using System;

namespace OOP_RPG
{
    public class Monster
    {
        public DifficultyLevel Difficulty { get; set; }
        public DayOfWeek RespawnDay { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(DayOfWeek respawnDay, DifficultyLevel difficulty, string name, int strength, int defense, int hp)
        {
            RespawnDay = respawnDay;
            Difficulty = difficulty;
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = hp;
            CurrentHP = hp;
        }

    }
}