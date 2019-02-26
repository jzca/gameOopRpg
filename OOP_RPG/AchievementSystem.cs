using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{

    //public enum MessageOfAchievement
    //{

    //    Killing_1_Monster,
    //    Killing_3_Monster,
    //    Killing_5_Different_Monster,
    //    Killing_10_Monster,
    //}


    public class AchievementSystem
    {

        //public MessageOfAchievement MsgOfAchievement { get; set; }
        public int Points { get; set; }
        public int CounterOfMonsters { get; set; }
        public int NumberDiffMonsters { get; set; }
        public int PassAchievement { get; set; }
        public List<NameOfMonster> NameOfMonsters { get; set; }
        public string Level1 { get; set; }
        public string Level2 { get; set; }
        public string Level3 { get; set; }
        public string Level4 { get; set; }
        public DateTime Dl1 { get; set; }
        public DateTime Dl2 { get; set; }
        public DateTime Dl3 { get; set; }
        public DateTime Dl4 { get; set; }


        public AchievementSystem()
        {
            Points = 0;
            PassAchievement = 0;
            NameOfMonsters = new List<NameOfMonster>();

            Level1 = "Killing 1 monster";
            Level2 = "Killing 3 monster";
            Level3 = "Killing 10 monster";
            Level4 = "Killing 5 different monsters";
        }

        public void CountMonsters()
        {

            CounterOfMonsters++;
            ChecktheDiff();

        }

        public void ChecktheDiff()
        {

            // Basic Function + Testing
            var theDiff = (from d in NameOfMonsters
                           group d.Name by d.Name into repeatedName
                           select new
                           {
                               Text = repeatedName.Count()
                           }).ToList() ;

            theDiff.ForEach(p => Console.WriteLine($"Num: {p.Text}"));

            // Core Function

            if (theDiff.Any())
            {
                NumberDiffMonsters=Convert.ToInt32(theDiff.Count);
            }



        }

        public void AddNameMonster(string name)
        {
            var nameMonster = new NameOfMonster(name);

            NameOfMonsters.Add(nameMonster);
        }


        public void PublishAchievement()
        {
            if (CounterOfMonsters == 1)
            {
                Dl1 = DateTime.Now;
                PassAchievement=100;
                Points = 1;
                Console.WriteLine($"You archieved <{Level1}>--P: {Points}");
            }
            else if (CounterOfMonsters == 3)
            {
                Dl2 = DateTime.Now;
                Points += 2;
                Console.WriteLine($"You archieved <{Level2}>--P: {Points}");
                PassAchievement = 200;
            }
            else if (CounterOfMonsters == 10)
            {
                Dl3 = DateTime.Now;
                Points += 3;
                Console.WriteLine($"You archieved <{Level3}>--P: {Points}");
                PassAchievement = 300;
            }
            else if (NumberDiffMonsters == 5)
            {
                Dl4 = DateTime.Now;
                Points += 5;
                Console.WriteLine($"You archieved <{Level4}>--P: {Points}");
                PassAchievement = 400;
            }


        }

        public void ShowAllAchievement()
        {
            Console.WriteLine($"Achievements ({ Points } points)");
        
            if (PassAchievement==100 || PassAchievement>199)
            {
                Console.WriteLine($"<{Level1}>--{Dl1}");
            }
            if (PassAchievement == 200 || PassAchievement > 299)
            {
                Console.WriteLine($"<{Level2}>--{Dl2}");
            }

            if (PassAchievement == 300 || PassAchievement >399)
            {
                Console.WriteLine($"<{Level3}>--{Dl3}");
            }

            if (PassAchievement == 400)
            {
                Console.WriteLine($"<{Level4}>--{Dl4}");
            }

            if (PassAchievement==0)
            {
                Console.WriteLine($"You have no achievements.");
            }
        }

    }
}
