using System;
using System.Xml.Serialization;
using System.IO;

namespace Labs.Lab3.Serial
{
    public class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int RecBookNum { get; set; }
        public int EnrollYear { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname + ", " + RecBookNum + ", " + EnrollYear;
        }
    }

    public class Group
    {
        public Student[] Students{ get; set; }
        public string Name { get; set; }

        public int GetStudNum()
        {
            return Students.Length;
        }

        public Student getStud(int num)
        {
            if (num > Students.Length - 1)
            {
                throw new IndexOutOfRangeException();
            }
            return Students[num];
        }
        public override string ToString()
        {
            string res = "Students of " + Name + " group:\n";
            for (int i = 0; i < GetStudNum(); i++)
            {
                res += "    " + getStud(i) + "\n";
            }
            return res;
        }
    }

    class Main
    {
        public static void Run()
        {
            Student[] studs = new Student[4];
            studs[0] = new Student()
            {
                Name = "Alexey",
                Surname = "Panin",
                RecBookNum = 2362179,
                EnrollYear = 2017
            };
            studs[1] = new Student()
            {
                Name = "Viktor",
                Surname = "Reznov",
                RecBookNum = 2362179,
                EnrollYear = 2017
            };
            studs[2] = new Student()
            {
                Name = "Nikolay",
                Surname = "Shevtsov",
                RecBookNum = 7319654,
                EnrollYear = 2017
            };
            studs[3] = new Student()
            {
                Name = "Sergey",
                Surname = "Bunin",
                RecBookNum = 1365075,
                EnrollYear = 2017
            };
            Group kn218g = new Group()
            {
                Students = studs,
                Name = "KN218g"
            };
            //serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Group));
            using (TextWriter textWriter = new StreamWriter("Files/Lab3/Serial/Serial.xml"))
            {
                serializer.Serialize(textWriter, kn218g);
            }
            //deserialization
            Group newGrp;
            XmlSerializer deserializer = new XmlSerializer(typeof(Group));
            using (TextReader textReader = new StreamReader("Files/Lab3/Serial/Serial.xml"))
            {
                newGrp = (Group)deserializer.Deserialize(textReader);
            }
            Console.WriteLine(newGrp);
            Console.ReadKey();
        }
    }
}
