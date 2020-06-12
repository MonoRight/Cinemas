using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Cinemas
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowTables tables = new ShowTables();

            do
            {
                Console.Clear();
                Console.WriteLine("\t\tMENU");
                Console.WriteLine("1. Display tables.");
                Console.WriteLine("2. Udpate film table.");
                Console.WriteLine("3. Delete film from table.");


                Console.WriteLine("Choose variant: ");
                string v = Console.ReadLine();

                switch(v)
                {
                    case "1":
                        {
                            Console.Clear();
                            tables.Show();
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            tables.Update();
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Console.Clear();
                            tables.Delete();
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Console.Clear();
                            ForDecorate dec = new ForDecorate();
                            dec.FilmsDecorate();
                            Console.ReadLine();
                            break;
                        }
                }

            } while (true);
        }
    }
}
