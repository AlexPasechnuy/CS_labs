using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.IndTask
{
    class Group
    {
        public string Name { set; get; }
        private Artist[] members = new Artist[0];

        public Group(string name)   //constuctor
        {
            Name = name;
        }

        public Artist this[int index]   //indexer
        {
            set
            {
                if (index < members.Length)
                {
                    members[index] = value;
                }
                else
                {
                    Add(value);
                }
            }

            get
            {
                if (index < members.Length) { return members[index]; }
                else { throw new IndexOutOfRangeException(); }
            }
        }

        public IEnumerator<Artist> GetEnumerator()  //enumerator
        {
            foreach (Artist x in members)
            {
                yield return x;
            }
        }

        public void Add(Artist artist)  //method for adding artistd to group
        {
            Array.Resize(ref members, members.Length + 1);
            members[members.Length - 1] = artist;
        }

        public override string ToString()
        {
            string res = Name + ":\nArtists\n";
            foreach (Artist art in members)
            {
                res += art.ToString() + "\n";
            }
            return res;
        }
    }

    class Artist
    {
        private int enrollYear;

        public string Name { set; get; }

        public string Surname { set; get; }

        public string Role { set; get; }

        public Country Homeland { set; get; }

        public int EnrollYear
        {
            set { EnrollYear = value;}
            get { return EnrollYear; }
        }

        public int getExp()         //shows years since enrollment to the group
        {
            string enrollString = "01.01." + enrollYear;
            DateTime enrollDate = DateTime.Parse(enrollString);
            DateTime today = DateTime.Today;
            int years = today.Year - enrollDate.Year;
            if (enrollDate > today.AddYears(-years))
                years--;
            return ++years;
        }

        public Artist(string name, string surname, string role, Country homeland, int enrollYear)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Homeland = homeland;
            this.enrollYear = enrollYear;
        }

        public override string ToString()
        {
            return "  " + Name + " " + Surname + ", " + Role + ", enrolled in " + enrollYear
                + "\nCountry: " + Homeland.ToString(); 
        }
    }

    class Country
    {
        public string Name { set; get; }

        public int Population { set; get; }

        public int Area { set; get; }

        public string Mainland { set; get; }

        public Country(string name, int population, int area, string mainland)
        {
            this.Name = name;
            this.Population = population;
            this.Area = area;
            this.Mainland = mainland;
        }

        public override string ToString()
        {
            return Name + "; Population: " + Population + 
                "; Area: " + Area + "; Mainland: " + Mainland;
        }
    }

    class Main
    {
        public static void Run()
        {
            //countries creating
            Country USA = new Country("United States of America", 328239523, 9833520, "North America");
            Country GB = new Country("Great Britain", 63786000, 209331, "Europe");
            Country Scotl = new Country("Scotland", 5424800, 77933, "Europe");

            //group initialization
            Group ACDC = new Group("AC/DC");
            ACDC.Add(new Artist("Axi", "Rose", "Soloist", USA, 2016));
            ACDC.Add(new Artist("Angus", "Young", "Guitarist", Scotl, 1973));
            ACDC.Add(new Artist("Stevie", "Young", "Rhytm-guitar", USA, 1988));
            ACDC.Add(new Artist("Chris", "Slade", "Drums", GB, 1988));
            
            //group output
            Console.WriteLine(ACDC);

            //results of some search
            Console.WriteLine("Artists from USA:");
            foreach (Artist art in ACDC)
            {
                if (art.Homeland == USA)
                {
                    Console.WriteLine(art);
                }
            }

            Console.WriteLine("\n\nArtists with surname \"Young\":");
            foreach (Artist art in ACDC)
            {
                if (art.Surname == "Young")
                {
                    Console.WriteLine(art);
                }
            }
            Console.ReadKey();
        }
    }
}
