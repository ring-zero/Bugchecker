﻿using System;
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

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Dictionary<string, string> openWith = new Dictionary<string, string>
        {
            { "0xa", "This indicates that Microsoft Windows or a kernel-mode driver accessed\n" + 
                    "paged memory at DISPATCH_LEVEL or above.\n\n" +
                    "What exactly does this mean?\n" +
                    "A Windows system driver (not 3rd party) or a 3rd party kernel-mode driver\n" + 
                    "(avast! Self Protection driver for example) caused a pagefault to be thrown,\n" +
                    "and since MmAccessFault cannot handle pagefaults at IRQL 2 (on both x86/x64)\n" + 
                    "or higher, the 0xA bug check is called.\n" },

            { "0xd1", "This indicates that a kernel-mode driver attempted to access pageable memory at\n" + 
                    "a process IRQL that was too high.\n\n" + 
                    "What exactly does this mean?\n" + 
                    "Similar to 0xA, 0xD1 is called when one of two things go wrong:\n\n" + 
                    "1. A kernel-mode driver attmpts to access paged out memory at or above IRQL 2,\n" + 
                    "and since this cannot happen, Windows' memory manager will be invoked to\n" + 
                    "page-in the memory which runs at IRQL 0 (on both x86/x64). Code residing in\n" + 
                    "lower IRQL cannot preempt code residing in a higher IRQL, therefore 0xD1 is\n" + 
                    "called as we'd just have a deadlock occur, which is what the memory manager\n" + 
                    "wants to avoid in kernel-mode.\n\n" + 
                    "2. A kernel-mode driver references an invalid address.\n\n" + 
                    "Tip: On x64, if a register is null (e.g. all zeros), don't assume it's invalid.\n" + 
                    "This is actually because the register is volatile, which implies it's a scratch\n" + 
                    "register and its contents are destroyed across a call by the caller.\n\n" + 
                    "Volatile registers: [rax], [rcx], [rdx], [r8], [r9], [r10:r11].\n"},

            { "0x1", "This indicates that there has been a mismatch in the APC state index." },

            { "0x2", "It indicates that a device queue was expected to be busy, but was not." },

            { "0x3", "It indicates a null of incorrect subset affinity." },
        };

            Console.WriteLine("Type a bug check code (for example - 0xD1), or \"exit\" to quit:\n");

            string userInput = "";
            while ((userInput = Console.ReadLine().ToLower()) != "exit")
            {

                if (openWith.ContainsKey(userInput))
                    Console.WriteLine(openWith[userInput]);
                else
                    Console.WriteLine("Not a valid bug check!\n");

                Console.WriteLine("Type another bug check, or \"exit\" to quit:");
            }
        }
    }
}