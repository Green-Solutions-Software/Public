
using GS.Cordoba.Rest;
using GS.Cordoba.Rest.SDK.Models;
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

        static async void getPlant(UnitOfWork unitOfWork, Item item)
        {
            Console.Clear();

            var plant = await unitOfWork.Plants.Get(item.ID);
            Console.WriteLine("Name: " + plant.Name);
            Console.WriteLine("Name 2: " + plant.Name2);
            Console.ReadLine();

        }

        static async void querySearch(UnitOfWork unitOfWork)
        {
            int pageIndex = 0;
            string selection = null;
            do
            {
                var args = new GS.Cordoba.Rest.SDK.Models.SearchArgs();
                args.Types = new string[] { typeof(Plant).Name };
                var plants = (await unitOfWork.Search.Search(null, 1, 10, null, args)).Items;

                Console.WriteLine("Page: " + (pageIndex + 1));
                Console.WriteLine("(+) - Next page");
                Console.WriteLine("(-) - Prev page");
                Console.WriteLine("===================");
                Console.WriteLine();

                int i = 0;
                foreach (var plantSummary in plants)
                {
                    Console.WriteLine("(" + i + ") - " + plantSummary.Title);
                    i++;
                }
                Console.WriteLine();
                Console.Write("Choice: ");
                selection = Console.ReadLine();
                switch (selection)
                {
                    case "+":
                        pageIndex++;
                        Console.Clear();
                        break;
                    case "-":
                        pageIndex--;
                        Console.Clear();
                        break;
                    default:
                        if (!string.IsNullOrEmpty(selection))
                        {
                            Console.Clear();
                            getPlant(unitOfWork, plants.ElementAt(Convert.ToInt16(selection)));
                        }
                        break;

                }

            } while (selection == "+" || selection == "-");

        }


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
                Console.WriteLine("(1) - Query Search");
                Console.WriteLine("(2) - Get Plant");
                Console.WriteLine("");
                Console.Write("Choice: ");

                try
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            querySearch(unitOfWork);
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
