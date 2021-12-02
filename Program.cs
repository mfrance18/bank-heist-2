using System;
using System.Collections.Generic;

namespace Bank_Heist_2
{
    class Program
    {
        static void Main(string[] args)
        {

            List<IRobber> rolodex = new List<IRobber>();

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
                Console.WriteLine("");

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
            Console.WriteLine("");

            List<IRobber> crew = new List<IRobber>();

            while (true)
            {
                try
                {
                    var count = 1;

                    Console.WriteLine("Member selection");

                    foreach (IRobber operative in rolodex)
                    {
                        Console.WriteLine($"{count++}-Name: {operative.Name}, Job: {operative.Job}, Skill: {operative.SkillLevel}, Percentage Cut: {operative.PercentageCut}");
                    }

                    Console.Write("Please Select an operative for your heist by typing the number assigned to them: ");
                    Console.WriteLine("");

                    int selection = int.Parse(Console.ReadLine());

                    if (Convert.ToString(selection) == "")
                    {
                        break;
                    }

                    Console.WriteLine("Here is your current crew: ");


                    crew.Add(rolodex[selection - 1]);
                    rolodex.RemoveAt(selection - 1);
                    var crewCount = crew.Count - 1;


                    Console.WriteLine($"You have added {crew[crewCount].Name} to your crew");
                    Console.WriteLine("");



                    Console.WriteLine("Here is your current crew: ");

                    foreach (IRobber member in crew)
                    {
                        Console.WriteLine($"{member.Name}, {member.Job}, {member.SkillLevel}, {member.PercentageCut}");
                    }
                    Console.WriteLine("");

                }

                catch (FormatException)
                {
                    Console.WriteLine("Your crew is complete");
                    break;

                }
            }

            Console.WriteLine("Time to perform the heist");

            foreach (IRobber operative in crew)
            {
                operative.PerformSkill(newBank);
            }


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
                    Job = "Hacker"
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
                    Job = "Muscle"
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
                    Job = "Lock Specialist"
                };
                rolodex.Add(newOperative);
            };
            return rolodex;
        }
    }
}
