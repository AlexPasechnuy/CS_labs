using System;
using IndTask;

namespace Labs.Lab3.IndTask
{
    class Main
    {
        public static void Run()
        {
            //countries creating
            Country USA = new Country("United States of America", 328239523, 9833520, "North America");
            Country GB = new Country("Great Britain", 63786000, 209331, "Europe");
            Country Scotl = new Country("Scotland", 5424800, 77933, "Europe");

            //group initialization
            Group<Country> ACDC = new Group<Country>("AC/DC");

            //addition of artists using '+' operator
            ACDC += new Artist<Country>("Axi", "Rose", "soloist", USA, 2016);
            ACDC += new Artist<Country>("Angus", "Young", "guitarist", Scotl, 1973);
            ACDC += new Artist<Country>("Stevie", "Young", "guitarist", USA, 1988);
            ACDC += new Artist<Country>("Chris", "Slade", "drummer", GB, 1988);

            //group output
            Console.WriteLine(ACDC);

            ACDC.SaveArtists("Files/Lab3/IndTask/ACDC.xml");

            Console.WriteLine("Sorted by surname: ");
            ACDC.sortBySurn();
            Console.WriteLine(ACDC);

            Console.WriteLine("Sorted by experience: ");
            ACDC.sortByExp();
            Console.WriteLine(ACDC);

            try
            {
                Group<Country> newACDC = new Group<Country>("newAC/DC");
                newACDC.ReadArtists("Files/Lab3/IndTask/ACDC.xml");
                Console.WriteLine("new AC/DC: ");
                Console.WriteLine(newACDC);
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------Exception:-----------");
                Console.WriteLine(ex.GetType());
                Console.WriteLine("------------Message:------------");
                Console.WriteLine(ex.Message);
                Console.WriteLine("----------Stack Trace:----------");
                Console.WriteLine(ex.StackTrace);
            }
            Console.ReadKey();
        }
    }
}
