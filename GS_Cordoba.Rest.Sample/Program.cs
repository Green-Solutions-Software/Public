
using GS.Cordoba.Rest;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_PflanzenCMS.Net.Rest.Sample
{
    class Program
    {

        static void Main(string[] args)
        {

            using (var unitOfWork = new UnitOfWork("Test", "<endpoint>", "<token>"))
            {
                unitOfWork.OnExecuteRequest = (s) =>
                {
                    Console.WriteLine("Query data..."+s);
                };

                Console.WriteLine("Connected to: "+unitOfWork.Endpoint);
                Console.WriteLine("");

                Console.WriteLine("Please select:");
                Console.WriteLine("(1) - authorize");
                Console.WriteLine("(2) - Query articles");
                Console.WriteLine("(3) - Query orders");
                Console.WriteLine("(4) - Create article");
                Console.WriteLine("(5) - Quuery article by External_Key");
                Console.WriteLine("(6) - Clear caches  (OutputCache, EF Cache u.s.w.)");
                Console.WriteLine("(7) - Query chainstores");
                Console.WriteLine("(8) - Query customers");
                Console.WriteLine("(9) - Open Order Management");
                Console.WriteLine("(10) - Availabilities");
                Console.WriteLine("(11) - Create order");
                Console.WriteLine("(12) - Query vouchers");
                Console.WriteLine("(13) - Availabilities");
                Console.WriteLine("(14) - Positionupdates");
                Console.WriteLine("(15) - Create Linktarget");
                Console.WriteLine("");
                Console.Write("Choice: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            //validate(unitOfWork);
                            break;
                        
                        default:
                            Console.WriteLine("Choice not supported");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

                Console.WriteLine("");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
            
        }
    }
}
