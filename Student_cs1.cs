using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar_Casstudy_Day1
{
    class App
    {
        public static void Scenario_1()
        {
            Console.WriteLine("----------------Student Class Scenario1------------------");
            Info info = new Info();
            Student st = new Student(1, "Rishabh", "03-12-1998");
            info.display(st);
            Student st1 = new Student(2, "Deepansh", "14-06-1998");
            info.display(st1);
            Student st2 = new Student(3, "Pawan", "26-01-1997");
            info.display(st2);
        }
        public static void Scenario_2()
        {
            Console.WriteLine("------------------Student Class Scenario 2---------------");
            Student[] Stud = new Student[3];
            Info info1 = new Info();
            Stud[0] = new Student(11, "Aniket", "23-05-1999");
            Stud[1] = new Student(12, "Siddhartha", "21-9-1998");
            Stud[2] = new Student(13, "Shivam", "15-9-1997");
            for (int i = 0; i < Stud.Length; i++)
            {

                info1.display(Stud[i]);
                Console.WriteLine();
            }
        }
        public static void Scenario_3()
        {
            Console.WriteLine("---------------Student Class Scenario 3-----------------");
            Console.WriteLine("Enter n Value to insert student details");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] std = new Student[n];
            for (int i = 0; i < std.Length; i++)
            {
                Console.WriteLine("Enter Student ID: ");
                int ID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name of the Student: ");
                string Name = Console.ReadLine();
                Console.WriteLine("Enter Student Date of Birth:");
                string DOB = Console.ReadLine();
                Student s1 = new Student(ID, Name, DOB);
                std[i] = s1;
            }
            foreach (var r in std)
            {
                Console.WriteLine("\nStudent ID:{0}\nStudent Name:{1}\nStudent DOB:{2}\n", r.Id, r.Name, r.DateOfBirth);
            }
        }
        public static void CScenario_1()
        {
            Info info = new Info();
            Console.WriteLine("----------------Course Class Scenario1------------------");
            Course c1 = new Course(1001, "C", "3 Months", 1500);
            info.Display(c1);
            Course c2 = new Course(1002, "Core Java", "6 Months", 6000);
            info.Display(c2);
            Course c3 = new Course(1003, "HTML", "1 Month", 1200);
            info.Display(c3);
        }
        public static void CScenario_2()
        {
            Console.WriteLine("-----------------Course Class Scenario 2---------------");
            Course[] c = new Course[3];
            Info info = new Info();
            c[0] = new Course(1004, "CPP", "5 Months", 6500);
            c[1] = new Course(1005, "Cyber Security", "4 Months", 8000);
            c[2] = new Course(1006, "Ethical Hacking", "3 Months", 6000);
            for (int i = 0; i < c.Length; i++)
            {

                info.Display(c[i]);
                Console.WriteLine();
            }
        }
        public static void CScenario_3()
        {
            Console.WriteLine("---------------Course Class Scenario 3-----------------");
            Console.WriteLine("Enter n Value to insert student details");
            int n = Convert.ToInt32(Console.ReadLine());
            Course[] c1 = new Course[n];
            for (int i = 0; i < c1.Length; i++)
            {
                Console.WriteLine("Enter Course ID: ");
                int CID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Name : ");
                string CName = Console.ReadLine();
                Console.WriteLine("Enter Course Duration :");
                string Duration = Console.ReadLine();
                Console.WriteLine("Enter Course Fees :");
                int Fees = Convert.ToInt32(Console.ReadLine());
                Course c = new Course(CID, CName, Duration, Fees);
                c1[i] = c;
            }
            foreach (var r in c1)
            {
                Console.WriteLine("\nCourse ID:{0}\nCourse Name:{1}\nCourse Duration:{2}\nCourse Fees:{3}", r.CID, r.CName, r.Duration, r.Fees);
            }
        }

        static void Main(string[] args)
        {
            Scenario_1();
            Scenario_2();
            Scenario_3();
            CScenario_1();
            CScenario_2();
            CScenario_3();
            Institute_Details IU = new Institute_Details();
            IU.showFirstScreen();
            Console.ReadLine();



        }
    }
}
