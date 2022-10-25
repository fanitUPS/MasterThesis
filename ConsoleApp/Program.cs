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
                
                var connectionString = "10.221.3.18:900";
                
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

                var signalGuid = new Guid("F597F644-69E0-436B-96FD-82771BCBB0F0");
                var uidsArray = new Guid[] { signalGuid };

                var request = CreateValuesSliceRead(uidsArray);

                using (var tracker = proxy.SendRequest(request))
                {
                    try
                    {
                        var response = tracker.WaitResponse();
                        foreach (Ck.RtdbValue value in response.Values)
                        {
                            Console.WriteLine(value.Value);
                            Console.WriteLine(value.Type);
                            Console.WriteLine(value.Uid);
                            Console.WriteLine(value.QualityCodes);
                            Console.WriteLine(value.Time);
                        }
                        Console.ReadKey();
                    }
                    catch (Ck.RequestException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                

            }
        }

        static Ck.Requests.ValuesSliceReadRequest CreateValuesSliceRead(Guid[] uids)
        {
            return new Ck.Requests.ValuesSliceReadRequest(uids, null);
        }
    }
}
