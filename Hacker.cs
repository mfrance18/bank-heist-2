using System;

namespace Bank_Heist_2
{
    public class Hacker : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public string Job { get; set; }



        public void PerformSkill(Bank Bank)
        {
            Bank.AlarmScore = Bank.AlarmScore - SkillLevel;

            Console.WriteLine($"{Name} is hacking the alarms. Decreased Security by {SkillLevel}");

            if (Bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} has disabled alarm");
            }
            else Console.WriteLine($"{Name} was unable to disable alarm");
        }
    }
}