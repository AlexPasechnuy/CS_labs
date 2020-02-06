using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab1.IndTask
{
    class Group
    {
        string name;
        Artist[] members = new Artist[0];

        public Artist this[int index]
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

        public IEnumerator<Artist> GetEnumerator()
        {
            foreach (Artist x in members)
            {
                yield return x;
            }
        }

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public void Add(Artist artist)
        {
            Array.Resize(ref members, members.Length + 1);
            members[members.Length - 1] = artist;
        }

        public Group(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            string res = name + ":\nArtists\n";
            foreach (Artist art in members)
            {
                res += art.ToString() + "\n";
            }
            return res;
        }
    }

    class Artist
    {
        private string name, surname, role;
        private Country homeland;
        private int enrollYear;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public string Surname
        {
            set { surname = value; }
            get { return surname; }
        }

        public string Role
        {
            set { role = value; }
            get { return role; }
        }

        public Country Homeland
        {
            set { homeland = value; }
            get { return homeland; }
        }

        public int EnrollYear
        {
            set { EnrollYear = value;}
            get { return EnrollYear; }
        }

        public int getExp()
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
            this.name = name;
            this.surname = surname;
            this.role = role;
            this.homeland = homeland;
            this.enrollYear = enrollYear;
        }

        public override string ToString()
        {
            return "  " + name + " " + surname + ", " + role + ", enrolled in " + enrollYear
                + "\nCountry: " + homeland.ToString(); 
        }
    }

    class Country
    {
        private string name;
        private int population;
        private int area;
        private string mainland;

        public string Name
        {
            set { name = value; }
            get { return name; }
        }

        public int Population
        {
            set{ population = value; }
            get{ return population; }
        }

        public int Area
        {
            set { area = value; }
            get { return area; }
        }

        public string Mainland
        {
            set { mainland = value; }
            get { return mainland; }
        }

        public Country(string name, int population, int area, string mainland)
        {
            this.name = name;
            this.population = population;
            this.area = area;
            this.mainland = mainland;
        }

        public override string ToString()
        {
            return name + "; Population: " + population + 
                "; Area: " + area + "; Mainland: " + mainland;
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
