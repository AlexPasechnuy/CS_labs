using System;
using System.Collections.Generic;
using System.Linq;

namespace Labs.Lab3.IndTask
{

    class CreativeTeam<R, M>
    {
        private string direction;
        private Artist<R, M>[] members = new Artist<R, M>[0];

        public Artist<R, M> this[int index]   //indexer
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

        public IEnumerator<Artist<R, M>> GetEnumerator()  //enumerator
        {
            foreach (Artist<R, M> x in members)
            {
                yield return x;
            }
        }

        public string Name { set; get; }

        public int Length   //property for number of group members
        {
            get { return members.Length; }
        }

        public CreativeTeam(string name, string direction)
        {
            this.Name = name;
            this.direction = direction;
        }

        public static CreativeTeam<R, M> operator +(CreativeTeam<R, M> gr, Artist<R, M> ar)    //adding artist to the group
        {
            CreativeTeam<R, M> res = gr;
            Array.Resize(ref res.members, res.members.Length + 1);
            res.members[res.members.Length - 1] = ar;
            return res;
        }

        public static CreativeTeam<R, M> operator -(CreativeTeam<R, M> gr, Artist<R, M> art)  //deleting artist from group
        {
            CreativeTeam<R, M> res = gr;
            res.members = gr.members.Where(val => val != art).ToArray();
            return res;
        }

        public override string ToString()
        {
            string res = Name + ":\nArtists\n";
            foreach (Artist<R, M> art in members)
            {
                res += " -- " + art.ToString() + "\n";
            }
            return res;
        }

        public override bool Equals(object obj)
        {
            CreativeTeam<R, M> team = obj as CreativeTeam<R, M>;
            return team.direction == direction && team.Name == Name;
        }
    }

    class Group<R, M> : CreativeTeam<R, M>
    {
        public Group(string name) : base(name, "Music") { }
    }

    class Artist<R, M>
    {
        public string Name { set; get; }

        public string Surname { set; get; }

        public R Role { set; get; }

        public Country<M> Homeland { set; get; }

        public int EnrollYear { set; get; }

        public int GetExp()     //show years since enrollment to the group
        {
            string enrollString = "01.01." + EnrollYear;
            DateTime enrollDate = DateTime.Parse(enrollString);
            DateTime today = DateTime.Today;
            int years = today.Year - enrollDate.Year;
            if (enrollDate > today.AddYears(-years))
            {
                years--;
            }

            return ++years;
        }

        public Artist(string name, string surname, R role, Country<M> homeland, int enrollYear)
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
            Artist<R, M> artist = obj as Artist<R, M>;
            return artist.Name == Name && artist.Surname == Surname
                && artist.Role.Equals(Role) && artist.Homeland == Homeland
                && artist.EnrollYear == EnrollYear;
        }
    }

    class CompArtBySurn<R,M> : IComparer<Artist<R,M>>
    {
        public int Compare(Artist<R,M> r1, Artist<R,M> r2)
        {
            return r1.Surname.CompareTo(r2.Surname);
        }
    }

    class CompArtByExp<R, M> : IComparer<Artist<R, M>>
    {
        public int Compare(Artist<R, M> r1, Artist<R, M> r2)
        {
            return r1.GetExp().CompareTo(r2.GetExp());
        }
    }

    class Country<T>
    {
        public string Name { set; get; }

        public int Population { set; get; }

        public int Area { set; get; }

        public T Mainland { set; get; }

        public Country(string name, int population, int area, T mainland)
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
            Country<T> country = obj as Country<T>;
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

    public struct Role
    {
        public string role;

        // Definition of the equivalence
        public override bool Equals(object obj)
        {
            Role newRole = (Role)obj;
            return newRole.role == role;
        }

        // Definition of string representation:
        public override string ToString()
        {
            return role;
        }
    }


    class Main
    {
        public static void Run()
        {
            Console.WriteLine("Testing using structures: \n");
            usingStructs();
            Console.WriteLine("-----------------------------------" +
                "--------------------------------------------------------\n");
            Console.WriteLine("Testing using strings: \n");
            usingStrings();
            Console.ReadKey();
        }

        public static void usingStructs()
        {
            //mainlands creating
            Mainland Europe = new Mainland() { Name = "Europe", Area = 10180000 };
            Mainland NorthAm = new Mainland() { Name = "North America", Area = 24710000 };

            //roles creating
            Role soloist = new Role() { role = "soloist" };
            Role drummer = new Role() { role = "drummer" };
            Role guitarist = new Role() { role = "guitarist" };

            //countries creating
            Country<Mainland> USA = new Country<Mainland>("United States of America", 328239523, 9833520, NorthAm);
            Country<Mainland> GB = new Country<Mainland>("Great Britain", 63786000, 209331, Europe);
            Country<Mainland> Scotl = new Country<Mainland>("Scotland", 5424800, 77933, Europe);

            //group initialization
            CreativeTeam<Role, Mainland> ACDC = new Group<Role, Mainland>("AC/DC");

            //addition of artists using '+' operator
            ACDC += new Artist<Role, Mainland>("Axi", "Rose", soloist, USA, 2016);
            ACDC += new Artist<Role, Mainland>("Angus", "Young", guitarist, Scotl, 1973);
            ACDC += new Artist<Role, Mainland>("Stevie", "Young", guitarist, USA, 1988);
            ACDC += new Artist<Role, Mainland>("Chris", "Slade", drummer, GB, 1988);

            //group output
            Console.WriteLine(ACDC);


        }

        public static void usingStrings()
        {
            //countries creating
            Country<string> USA = new Country<string>("United States of America", 328239523, 9833520, "North America");
            Country<string> GB = new Country<string>("Great Britain", 63786000, 209331, "Europe");
            Country<string> Scotl = new Country<string>("Scotland", 5424800, 77933, "Europe");

            //group initialization
            CreativeTeam<string, string> ACDC = new Group<string, string>("AC/DC");

            //addition of artists using '+' operator
            ACDC += new Artist<string, string>("Axi", "Rose", "soloist", USA, 2016);
            ACDC += new Artist<string, string>("Angus", "Young", "guitarist", Scotl, 1973);
            ACDC += new Artist<string, string>("Stevie", "Young", "guitarist", USA, 1988);
            ACDC += new Artist<string, string>("Chris", "Slade", "drummer", GB, 1988);
            

        }
    }
}
