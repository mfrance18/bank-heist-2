using System;

namespace Bank_Heist_2
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public string Job { get; set; }

        public void PerformSkill(Bank Bank)
        {
            Bank.VaultScore = Bank.VaultScore - SkillLevel;

            Console.WriteLine($"{Name} is opening the Vault. Decreased Security by {SkillLevel}");

            if (Bank.VaultScore <= 0)
            {
                Console.WriteLine($"{Name} has opened Vault");
            }
            else Console.WriteLine($"{Name} was unable to open the Vault");
        }
    }
}