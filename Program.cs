using dnlib.DotNet;
using System;

namespace WebhookSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string x = args[0];
                Console.Title = "Webhook searcher | https://github.com/AizonF";
                Search_File(x);
            }
            catch
            {
                Red_Console();
                Console.WriteLine("[+] Drag and drop please!");
                Console.ReadLine();
            }

        }
        static void Red_Console()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        static void Green_Console()
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void Search_File(string pts)
        {
            ModuleDefMD mod = ModuleDefMD.Load(pts);
            foreach (var type in mod.Types)
            {
                foreach (var method in type.Methods)
                {
                    foreach(var instructions in method.Body.Instructions)
                    {
                        string op = instructions.OpCode.ToString();
                        if (op.Contains("ldstr"))
                        {
                            string op2 = instructions.Operand.ToString();
                            if (op2.Contains("https://discord.com/api/webhooks/"))
                            {
                                SMOG();

                                string Fi = method.Name;

                                Console.WriteLine("\nWebhook Found in {0}\n\n" + op2, Fi);
                                Console.ReadLine();
                            }
                        }
                    }
                }
            }
        }
        static void SMOG()
        {
            Green_Console();
            Console.WriteLine("Please credit me on github https://github.com/AizonF");
        }
    }
}
