using dnlib.DotNet;
using System;
using System.Net;

namespace WebhookSearcher
{
    class Program
    {
        static string ist { get; set; }
        static void Main(string[] args)
        {
            try
            {
                string x = args[0];
                Console.Title = "Webhook searcher | https://github.com/AizonF";

                Search_File(x);
            }
            catch (Exception ex)
            {
                Red_Console();
                Console.WriteLine(ex.ToString());
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
            try
            {
                ModuleDefMD mod = ModuleDefMD.Load(pts);
                foreach (var type in mod.Types)
                {
                    foreach (var method in type.Methods)
                    {
                        foreach (var instructions in method.Body.Instructions)
                        {
                            string op = instructions.OpCode.ToString();
                            if (op.Contains("ldstr"))
                            {
                                string op2 = instructions.Operand.ToString();
                                if (op2.Contains("https://discord.com/api/webhooks/") && op2.Length <= 120)
                                {
                                    SMOG();


                                    string Fi = method.FullName;

                                    Console.WriteLine("\nWebhook Found in {0}\n\n" + op2, Fi);
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.ReadLine();
            }
        }


        static void SMOG()
        {
            Green_Console();
            Console.WriteLine("Please credit me on github https://github.com/AizonF");
        }
    }
}
