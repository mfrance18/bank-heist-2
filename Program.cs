using System;
using System.Collections.Generic;

namespace Bank_Heist_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Hacker matt = new Hacker();
            LockSpecialist lockPickingLawyer = new LockSpecialist();
            Muscle arnold = new Muscle();
            Hacker mrRobot = new Hacker();
            Muscle leith = new Muscle();

            List<IRobber> rolodex = new List<IRobber>()
            {
                matt, lockPickingLawyer, arnold, mrRobot, leith
            };

            while (true)
            {
                Console.WriteLine($"Number of Operatives: {rolodex.Count}");

                Console.Write($"Enter the Name of a New Crew Member: ");

                string operativeName = Console.ReadLine();

                if (operativeName == "")
                {
                    break;
                }

                Console.Write($"Please choose an Operative: 1-Hacker(Disables alarms), 2-Muscle(Disarms Guards), 3-Lock Specialist(Cracks Vault): ");

                int operativeChoice = int.Parse(Console.ReadLine());

                Console.Write("Enter crew members skill level (0-100): ");

                int operativeSkillLevel = int.Parse(Console.ReadLine());

                Console.Write("Enter percentage cut for operative(0-100): ");

                int operativePercentage = int.Parse(Console.ReadLine());

                rolodex = AddOperative(operativeChoice, operativeName, operativeSkillLevel, operativePercentage, rolodex);
            }

            Random random = new Random();

            Bank newBank = new Bank
            {
                AlarmScore = random.Next(0, 101),
                VaultScore = random.Next(0, 101),
                SecurityGuardScore = random.Next(0, 101),
                CashOnHand = random.Next(50_000, 100_000_1),
            };

            string mostSecure = newBank.MostSecureSystem;
            string leastSecure = newBank.LeastSecureSystem;

            Console.WriteLine($"The most secure system is {mostSecure}");

            Console.WriteLine($"The least secure system is {leastSecure}");


        }


        public static List<IRobber> AddOperative(int choice, string name, int skillLevel, int percentageCut, List<IRobber> rolodex)
        {

            if (choice == 1)
            {
                Hacker newOperative = new Hacker()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut,
                };

                rolodex.Add(newOperative);
            }
            else if (choice == 2)
            {
                Muscle newOperative = new Muscle()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut,
                };
                rolodex.Add(newOperative);
            }
            else if (choice == 3)
            {
                LockSpecialist newOperative = new LockSpecialist()
                {
                    Name = name,
                    SkillLevel = skillLevel,
                    PercentageCut = percentageCut,
                };
                rolodex.Add(newOperative);
            };
            return rolodex;
        }
    }
}
