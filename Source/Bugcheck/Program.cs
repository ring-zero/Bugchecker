using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugcheck
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializing variables.
            string bugcheckExit = "exit";
            var message = "";
            var afterMessage = "Type another bug check, or \"exit\" to quit:\n";

            // Write welcome message to screen.
            Console.WriteLine("Type the bug check code you experienced (for example - 0xD1), or \"exit\" to quit:\n");

            // While loop here.
            while (true)
            {               
                
                // Take in user input.
                string userInput = Console.ReadLine().ToLower();

                // Check user input.
                if (userInput == bugcheckExit)
                    System.Environment.Exit(1);

                // Checking value of bug check.
                if (userInput == "0xd1")
                    message = "This indicates that a kernel-mode driver attempted to access pageable memory at\n" + 
                        "a process IRQL that was too high.\n";
                else if (userInput == "0xa")
                    message = "This indicates that Microsoft Windows or a kernel-mode driver accessed\n" +
                        "paged memory at DISPATCH_LEVEL or above.\n";
                else if (userInput == "0x1e")
                    message = "This indicates that a kernel-mode program generated an exception which the\n" +
                        "error handler did not catch.\n";
                else
                    message = "Not a valid bug check, please try again.\n";

                Console.WriteLine(message);
                Console.WriteLine(afterMessage);
            }
        }
    }
}