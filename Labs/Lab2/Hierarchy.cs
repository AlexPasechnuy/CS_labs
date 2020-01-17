using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Lab2.Hierarchy
{
    class Person
    {
        private string name, surname, gender;
        private DateTime birthDate;

        public Person(string name, string surname, string gender, string birthDate) {
            this.name = name;
            this.surname = surname;
            this.gender = gender;
            this.birthDate = DateTime.Parse(birthDate);
        }

        public int getAge()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--;
            return age;
        }

        public override string ToString()
        {
            return name + " " + surname + ", " + gender + 
                ", was born " + birthDate.ToShortDateString() + "(" + getAge() + " years)\n";
        }
    }

    class Citizen : Person
    {
        string country;

        public Citizen(string name, string surname, string gender, string birthDate, 
            string country)
            : base(name, surname, gender, birthDate)
        {
            this.country = country;
        }

        public override string ToString()
        {
            return base.ToString() + "Country: " + country + ";\n";
        }
    }

    class Student : Citizen
    {
        string university;
        string group;
        int enrollYear;

        public Student(string name, string surname, string gender, string birthDate, string country,
            string university, string group, int enrollYear) : base(name, surname, gender, birthDate, country)
        {
            this.university = university;
            this.group = group;
            this.enrollYear = enrollYear;
        }

        public int getCourse()
        {
            string enrollString = "01.09." + enrollYear;
            DateTime enrollDate = DateTime.Parse(enrollString);
            DateTime today = DateTime.Today;
            int years = today.Year - enrollDate.Year;
            if (enrollDate > today.AddYears(-years))
                years--;
            return ++years;
        }

        public override string ToString()
        {
            return base.ToString() + "University: " + university + " group: " + group +
                ", year of enrollment: " + enrollYear + " (" + getCourse() + " course);\n";
        }
    }

    class Employee : Citizen
    {
        string company;
        string position;
        DateTime enrollDate;

        public Employee(string name, string surname, string gender, string birthDate,
            string country,
            string company, string position, string enrollDate)
            : base(name, surname, gender, birthDate, country)
        {
            this.company = company;
            this.position = position;
            this.enrollDate = DateTime.Parse(enrollDate);
        }

        public int getExp()
        {
            DateTime today = DateTime.Today;
            int years = today.Year - enrollDate.Year;
            if (enrollDate > today.AddYears(-years))
                years--;
            return years;
        }

        public override string ToString()
        {
            return base.ToString() + "Company: " + company + ", position: " + position + 
                ", date of enrollment: " + enrollDate.ToShortDateString() + " (" + getExp() + " years exprience);\n";
        }
    }


    class Main
    {
        public static void Run()
        {
            Person[] group = new Person[4];
            group[0] = new Person("Vasya", "Pupkin", "Male", "22.11.1990");
            group[1] = new Citizen("Alex", "Pushkin", "Male", "06.06.1799", "Russia");
            group[2] = new Student("Olga", "Volochkova", "Female", "14.05.2001", "Ukraine", 
                "NTU \"KhPi\"", "1.KN218.ge" ,  2018);
            group[3] = new Employee("Alexandra", "Kapustina", "Female", "29.08.1990", "Ukraine",
    "NIX Solutions", "Senior C++ Developer" , "23.08.2010");
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine(group[i]);
            }
            Console.ReadKey();
        }
    }
}
