namespace OOP_RPG
{
    public class Monster
    {
        public string Difficulty { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(string difficulty, string name, int strength, int defense, int hp)
        {
            Difficulty = difficulty;
            Name = name;
            Strength = strength;
            Defense = defense;
            OriginalHP = hp;
            CurrentHP = hp;
        }

    }
}