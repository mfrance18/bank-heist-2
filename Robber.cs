using System;

namespace Bank_Heist_2
{
    public interface IRobber
    {
        string Name { get; set; }

        int SkillLevel { get; set; }

        int PercentageCut { get; set; }

        string Job { get; set; }

        void PerformSkill(Bank Bank);

    }
}