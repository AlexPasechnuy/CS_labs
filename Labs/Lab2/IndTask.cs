using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.IndTask
{
    class CreativeTeam
    {
        private string direction;
        private Artist[] members = new Artist[0];

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
                    Array.Resize(ref members, members.Length + 1);
                    members[members.Length - 1] = value;
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

        public string Name { set; get; }

        public int Length   //property for number of group members
        {
            get { return members.Length; }
        }
        
        public static CreativeTeam operator+(CreativeTeam gr, Artist ar)    //adding artist to the group
        {
            CreativeTeam res = gr;
            Array.Resize(ref res.members, res.members.Length + 1);
            res.members[res.members.Length - 1] = ar;
            return res;
        }

        public static CreativeTeam operator -(CreativeTeam gr, Artist art)  //deleting artist from group
        {
            CreativeTeam res = gr;
            res.members = gr.members.Where(val => val != art).ToArray();
            return res;
        }

        public CreativeTeam(string name, string direction)
        {
            this.Name = name;
            this.direction = direction;
        }

        public override string ToString()
        {
            string res = Name + ":\nArtists\n";
            foreach (Artist art in members)
            {
                res += " -- " + art.ToString() + "\n";
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            CreativeTeam team = obj as CreativeTeam;
            return team.direction == direction && team.Name == Name;
        }
    }

    class Group : CreativeTeam
    {
        public Group(string name) : base(name, "Music"){  }
    }

    class Artist
    {
        public string Name { set; get; }

        public string Surname { set; get; }

        public MusicRole Role { set; get; }

        public Country Homeland { set; get; }

        public int EnrollYear { set; get; }

        public int GetExp()     //show years since enrollment to the group
        {
            string enrollString = "01.01." + EnrollYear;
            DateTime enrollDate = DateTime.Parse(enrollString);
            DateTime today = DateTime.Today;
            int years = today.Year - enrollDate.Year;
            if (enrollDate > today.AddYears(-years))
                years--;
            return ++years;
        }

        public Artist(string name, string surname, MusicRole role, Country homeland, int enrollYear)
        {
            Name = name;
            Surname = surname;
            Role = role;
            Homeland = homeland;
            EnrollYear = enrollYear;
        }

        public override string ToString()
        {
            return "  " + Name + " " + Surname + ", " + Role + ", enrolled in " + EnrollYear
                + "\nCountry: " + Homeland.ToString();
        }
        public override bool Equals(object obj)
        {
            Artist artist = obj as Artist;
            return artist.Name == Name && artist.Surname == Surname
                && artist.Role.Equals(Role) && artist.Homeland == Homeland
                && artist.EnrollYear == EnrollYear;
        }
    }

    class Country
    {
        public string Name { set; get; }

        public int Population { set; get; }

        public int Area { set; get; }

        public Mainland Mainland { set; get; }

        public Country(string name, int population, int area, Mainland mainland)
        {
            Name = name;
            Population = population;
            Area = area;
            Mainland = mainland;
        }

        public override string ToString()
        {
            return Name + "; Population: " + Population +
                "; Area: " + Area + "; Mainland: " + Mainland;
        }

        public override bool Equals(object obj)
        {
            Country country = obj as Country;
            return country.Name == Name;
        }
    }

    public struct Mainland
    {
        public string Name;
        public long Area;

        // Definition of the equivalence
        public override bool Equals(object obj)
        {
            Mainland land = (Mainland)obj;
            return land.Name == Name && land.Area == Area;
        }

        // Definition of string representation:
        public override string ToString()
        {
            return Name + ", " + Area + " square kilemeters";
        }
    }

    public struct MusicRole
    {
        public string Role;

        // Definition of the equivalence
        public override bool Equals(object obj)
        {
            MusicRole role = (MusicRole)obj;
            return role.Role == Role;
        }

        // Definition of string representation:
        public override string ToString()
        {
            return Role;
        }
    }

    class Main
    {
        public static void Run()
        {
            //mainlands creating
            Mainland Europe = new Mainland() { Name = "Europe", Area = 10180000 };
            Mainland NorthAm = new Mainland() { Name = "North America", Area = 24710000 };

            //roles creating
            MusicRole soloist = new MusicRole() { Role = "Soloist" };
            MusicRole drummer = new MusicRole() { Role = "Drummer" };
            MusicRole guitarist = new MusicRole() { Role = "Guitarisr" };

            //countries creating
            Country USA = new Country("United States of America", 328239523, 9833520, NorthAm);
            Country GB = new Country("Great Britain", 63786000, 209331, Europe);
            Country Scotl = new Country("Scotland", 5424800, 77933, Europe);

            //group initialization
            CreativeTeam ACDC = new Group("AC/DC");

            //addition of artists using '+' operator
            Artist Axi = new Artist("Axi", "Rose", soloist, USA, 2016);
            ACDC += Axi;
            ACDC += new Artist("Angus", "Young", guitarist, Scotl, 1973);
            ACDC += new Artist("Stevie", "Young", guitarist, USA, 1988);
            ACDC += new Artist("Chris", "Slade", drummer, GB, 1988);

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

            //Test of '-' operator
            Console.WriteLine("\n\nAfter Axi deleting: ");
            ACDC -= Axi;
            Console.WriteLine(ACDC);
            Console.ReadKey();
        }
    }
}