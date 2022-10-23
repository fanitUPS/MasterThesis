using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ck = Monitel.Rtdb.Api;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Ck.IRtdbProvider provider = Ck.RtdbProvider.CreateProvider())
            {
                Ck.IRtdbProxy proxy;
                //var connectionString = "CK11-IA-3.pl03n.lcl";
                var connectionString = "10.221.3.18";
                
                try
                {
                    proxy = provider.Connect(connectionString);
                    Console.WriteLine("GOOD");
                    Console.ReadKey();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
