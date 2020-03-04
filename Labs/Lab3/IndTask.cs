using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Labs.Lab3.IndTask
{
    public struct Country
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Population { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Area { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Mainland { set; get; }

        public Country(string name, int population, int area, string mainland)
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
            Country country = (Country)obj;
            return country.Name == Name;
        }
    }

    public class Artist<TCountry>
    {
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Surname { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Role { set; get; }

        [System.Xml.Serialization.XmlElement()]
        public TCountry Homeland { set; get; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
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

        //constructors
        public Artist() { }

        public Artist(string name, string surname, string role, TCountry homeland, int enrollYear)
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
            Artist<TCountry> artist = obj as Artist<TCountry>;
            return artist.Name == Name && artist.Surname == Surname
                && artist.Role.Equals(Role) && artist.Homeland.Equals(Homeland)
                && artist.EnrollYear == EnrollYear;
        }
    }

    public class CreativeTeam<TCountry>
    {
        public List<Artist<TCountry>> Members { get; set; }

        // Constructors
        public CreativeTeam() { Members = new List<Artist<TCountry>>(0); }

        public CreativeTeam(List<Artist<TCountry>> memb)
        {
            Members = memb;
        }

        // Indexer
        public Artist<TCountry> this[int index]
        {
            set
            {
                if (index < Members.Count)
                {
                    Members[index] = value;
                }
                else
                {
                    Members.Add(value);
                }
            }

            get
            {
                if (index < Members.Count) { return Members[index]; }
                else { throw new IndexOutOfRangeException(); }
            }
        }

        public IEnumerator<Artist<TCountry>> GetEnumerator()
        {
            foreach (Artist<TCountry> x in Members)
            {
                yield return x;
            }
        }

        public static CreativeTeam<TCountry> operator +(CreativeTeam<TCountry> gr, Artist<TCountry> ar)    //adding artist to the group
        {
            CreativeTeam<TCountry> res = gr;
            res.Members.Add(ar);
            return res;
        }

        public static CreativeTeam<TCountry> operator -(CreativeTeam<TCountry> gr, Artist<TCountry> art)  //deleting artist from group
        {
            CreativeTeam<TCountry> res = gr;
            res.Members = gr.Members.Where(val => val != art).ToList();
            return res;
        }

        // Comparers
        private class CompArtBySurn<TCountry> : IComparer<Artist<TCountry>>
        {
            public int Compare(Artist<TCountry> r1, Artist<TCountry> r2)
            {
                return r1.Surname.CompareTo(r2.Surname);
            }
        }

        private class CompArtByExp<TCountry> : IComparer<Artist<TCountry>>
        {
            public int Compare(Artist<TCountry> r1, Artist<TCountry> r2)
            {
                return r1.GetExp().CompareTo(r2.GetExp());
            }
        }

        // Sorting functions
        public void sortBySurn()
        {
            Members.Sort(new CompArtBySurn<TCountry>());
        }

        public void sortByExp()
        {
            Members.Sort(new CompArtByExp<TCountry>());
        }

        // Serialization
        public void SaveArtists(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Artist<TCountry>>));
            using (TextWriter textWriter = new StreamWriter(filename))
            {
                serializer.Serialize(textWriter, Members);
            }
        }

        // Deserialization
        public void ReadArtists(string filename)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Artist<TCountry>>));
            using (TextReader textReader = new StreamReader(filename))
            {
                Members = (List<Artist<TCountry>>)deserializer.Deserialize(textReader);
            }
        }

        public override string ToString()
        {
            string res = "";
            foreach (Artist<TCountry> art in Members)
            {
                res += " -- " + art.ToString() + "\n";
            }
            return res;
        }
    }

    public class Group<TCountry> : CreativeTeam<TCountry>
    {
        string Name { get; set; }
        public Group() : base() { }
        public Group(string name) : base() {
            Name = name;
        }

        override public string ToString()
        {
            return Name + "\n" + base.ToString();
        }

        public static Group<TCountry> operator +(Group<TCountry> gr, Artist<TCountry> art)    //adding artist to the group
        {
            Group<TCountry> newGrp = new Group<TCountry>(gr.Name)
            {
                Members =gr.Members
            };
            newGrp.Members.Add(art);
            return newGrp;
        }

        public static Group<TCountry> operator -(Group<TCountry> gr, Artist<TCountry> art)  //deleting artist from group
        {
            Group<TCountry> newGrp = new Group<TCountry>(gr.Name)
            {
                Members = gr.Members
            };
            newGrp.Members.Remove(art);
            return newGrp;
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
