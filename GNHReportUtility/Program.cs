using GeetaNeutriHealUtility;
using GNHReportUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNHReportUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Geeta Neutri Heal Centre");
            Console.WriteLine();
            Console.WriteLine("Ensure that the MS Word application is closed, before running this utility");

            Console.WriteLine("Press Y and Enter key to proceed or any other key to stop");

            string command = Console.ReadLine();

            if (command.ToUpper().Equals("Y"))
            {
                Console.WriteLine("Report processig is about to start, it may take a while to complete");

                MsWordUtility obj = new MsWordUtility();
                obj.AddHeaderAndFooterToDocFile();

                Console.WriteLine("{0} files were processed successfully", obj.NoOfFilesProcessed);
                Console.WriteLine("Press any key to stop ");
                Console.Read();
            }
            else
            {
                Console.WriteLine("Application Exiting");
                Environment.Exit(0);
            }

        }
    }
}
