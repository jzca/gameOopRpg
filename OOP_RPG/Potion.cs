namespace OOP_RPG
{
    public class Potion
    {
        public string Name { get; }
        public int HP { get; }
        public int Price { get; }

        public Potion(string name, int hp, int price)
        {
            Name = name;
            HP = hp;
            Price = price;
        }

    }
}