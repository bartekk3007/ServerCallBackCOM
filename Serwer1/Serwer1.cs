using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using KSR_WCF2;

namespace Serwer1
{
    public class Zadanie3 : IZadanie3
    {
        public void TestujZwrotny()
        {
            var callback = OperationContext.Current.GetCallbackChannel<IZadanie3Zwrotny>();
            for (int x = 0; x < 31; x++)
            {
                callback.WolanieZwrotne(x, x * x * x - x * x);
            }
        }
    }

    public class Task3Server
    {
        public static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Zadanie3));
            host.AddServiceEndpoint(typeof(IZadanie3), new NetNamedPipeBinding(), "net.pipe://localhost/ksr-wcf2-zad3");

            host.Open();
            Console.WriteLine("Host opened");
            Console.ReadKey();

            host.Close();
            Console.WriteLine("Host closed");
            Console.ReadKey();

        }
    }
}
