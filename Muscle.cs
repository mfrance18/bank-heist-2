using System;

namespace Bank_Heist_2
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public string Job { get; set; }

        public void PerformSkill(Bank Bank)
        {
            Bank.SecurityGuardScore = Bank.SecurityGuardScore - SkillLevel;

            Console.WriteLine($"{Name} is fighting security guard. Decreased Security by {SkillLevel}");

            if (Bank.SecurityGuardScore <= 0)
            {
                Console.WriteLine($"{Name} has defeated the Security Guard");
            }
            else Console.WriteLine($"Security Guard has defeated {Name}");
        }
    }
}