using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Monitel.Rtdb.Api;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Monitel.Rtdb.Api.IRtdbProvider provider = Monitel.Rtdb.Api.RtdbProvider.CreateProvider())
            {
                Monitel.Rtdb.Api.IRtdbProxy proxy;
                var connectionString = "CK11-IA-3.pl03n/lcl";
                try
                {
                    proxy = provider.Connect(connectionString);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }
}
