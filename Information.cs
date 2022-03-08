using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar_Casstudy_Day1
{

    class Info
    {
        public void display(Student s1)
        {

            Console.WriteLine("Student Details :");
            Console.WriteLine("Student ID:" + s1.Id);
            Console.WriteLine("Student Name:" + s1.Name);
            Console.WriteLine("Student DOB:" + s1.DateOfBirth);
            Console.WriteLine();
        }
        public void Display(Course c)
        {
            Console.WriteLine("Course Details: \n");
            Console.WriteLine("Course ID: " + c.CID);
            Console.WriteLine("Course Name: " + c.CName);
            Console.WriteLine("Course Duration: " + c.Duration);
            Console.WriteLine("Course Fees: " + c.Fees);
            Console.WriteLine();
        }
    }
}