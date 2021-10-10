using System;
using System.Collections.Generic;
enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTeacher,
    GetListPersons
}
namespace Homework_2
{

    class Program
    {
        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();

        }
        static public void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeader();
            PrintListMenu();
            InputMenuFromKeyboard();
        }
        static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("----------------------------------------------------");
        }
        static void PrintListMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Register new Teacher.");
            Console.WriteLine("3. Get List Persons.");
        }
        static public void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(menu);
        }
        static public PersonList personList;
        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                Student.ShowInputRegisterNewStudentScreen();
            }

            else if (menu == Menu.RegisterNewTeacher)
            {
                Teacher.ShowInputRegisterNewTeacherScreen();
            }

            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }

            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            Program.InputMenuFromKeyboard();
        }
        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
            InputExitFromKeyboard();
        }
        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.WriteLine("Input: ");
                text = Console.ReadLine();
            }
            Console.Clear();
            PrintMenuScreen();
        }
        static public string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        static public string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        static public string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        static public string InputIdentityID()
        {
            Console.Write("Identity ID: ");
            return Console.ReadLine();
        }
    }
    class Person
    {
        protected string name;
        protected string address;
        protected string identityID;
        public Person(string name, string address, string identityID)
        {
            this.name = name;
            this.address = address;
            this.identityID = identityID;
        }
        public string GetName()
        {
            return this.name;
        }
    }
    class Student : Person
    {
        private string studentID;
        public Student(string name, string address, string identityID, string studentID)
        : base(name, address, identityID)
        {
            this.studentID = studentID;
        }
        static public void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderRegisterStudent();
            int totalStudent = TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }
        static public void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }
        static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");

            return int.Parse(Console.ReadLine());
        }
        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                Student.PrintHeaderRegisterStudent();
                Student student = CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
        static Student CreateNewStudent()
        {
            return new Student(Program.InputName(),
            Program.InputAddress(),
            Program.InputIdentityID(),
            Program.InputStudentID());
        }
    }
    class Teacher : Person
    {
        private string employeeID;

        public Teacher(string name, string address, string identityID, string employeeID)
        : base(name, address, identityID)
        {
            this.employeeID = employeeID;
        }
        static public void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderRegisterTeacher();
            int totalTeacher = TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }
        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderRegisterTeacher();
                Teacher teacher = CreateNewTeacher();
                Program.personList.AddNewPerson(teacher);
            }
            Console.Clear();
            Program.PrintMenuScreen();
        }
        static Teacher CreateNewTeacher()
        {
            return new Teacher(Program.InputName(), Program.InputAddress(), Program.InputIdentityID(), InputEmployeeID());
        }
        static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }
        static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("---------------------");
        }
        static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");
            return int.Parse(Console.ReadLine());
        }
    }
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("---------------------");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name: {0} \nType: Student \n", person.GetName());

                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher \n", person.GetName());

                }
            }
        }
    }
}