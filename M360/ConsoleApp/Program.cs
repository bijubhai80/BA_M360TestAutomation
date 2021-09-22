using System;
using System.Collections.Generic;
using System.Linq;

namespace M360TestAutomation.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program();
            program.ProcessCommandLine(args);
            program.Run();
        }

        public void ProcessCommandLine(string[] args)
        {
            // normally we might do command line parsing in here, but currently the program only does one thing.
        }

        public void Run()
        {
            // Create a PolicyData object containing the values you want to create the policy with.  Almost all values are the codes of the
            // corresponding entity.
            var policyData = new PolicyData()
            {
                branch = "060",
                team = "007",
                broker1Username = "BASTD",
                client = "MARBL",
                fromDate = new DateTime(2021, 01, 01),
                toDate = new DateTime(2021, 01, 01),
                insuranceClass = "HH",
                locations = new[] { "SA", "TAS" }.ToList(),
                marketSegment = "CT",
                maxLiability = 2000000,
                scheduleText = "",
                situationText = "Anywhere in Australia",
                underwriters = new[] { "ALZS", "SUNA" }.ToList(),
            };

            Console.WriteLine("Creating policy for the following data:");
            Console.WriteLine(policyData.PrettyPrint("    ") + "\n\n");

            var creator = new PolicyCreator();
            var success = creator.CreatePolicy(policyData, out PolicyMetaData policyMetaData, out List<string> errorList);

            if (success)
            {
                Console.WriteLine($"Successfully created a new policy for client {policyData.client}");
                Console.WriteLine($"\tPolicy Number = {policyMetaData.PolicyNumber}"
                                  + $"\tPolicyId = {policyMetaData.PolicyId}\n"
                                  + $"\tPolicyVersionId = {policyMetaData.PolicyVersionId}\n");
            }
            else
            {
                Console.WriteLine($"Failed to create policy for client: {policyData.client}");
                foreach (var error in errorList)
                {
                    Console.WriteLine("    " + error);
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
