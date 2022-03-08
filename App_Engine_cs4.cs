using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar_Casstudy_Day1
{

    class Enroll
    {
        private Student student { get; set; }
        private Course course { get; set; }
        private DateTime enrollmentDate { get; set; }
        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            this.student = student;
            this.course = course;
            this.enrollmentDate = enrollmentDate;
        }
    }
    class AppEngine
    {
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        //public static SqlDataReader dr1;
        public static SqlConnection con;
        static SqlConnection getConnection()
        {

            con = new SqlConnection("data source=INFINITY;initial catalog=CaseStudyDB;integrated security=true");
            con.Open();
            return con;

        }


        public void Show_all_registered_Students()
        {
            //whenever we need to retrieve total no.of students in the institute and there details from admin level
            con = getConnection();
            cmd = new SqlCommand("Select *from Student", con);
            int res = cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Student Details : ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Student Id : " + " " + dr[0]);
                Console.WriteLine("Student Name :" + " " + dr[1]);
                Console.WriteLine("Student DOB :" + " " + dr[2]);
                Console.WriteLine();
            }
        }

        public void New_StudentRegistration()
        {
            //Whenever we are trying to register for the Institution as a new user as well as admin can also updates new list of student in there institute
            //Console.WriteLine("New Student Registrations............!");
            int n;
            Console.WriteLine("Enter No. Of Student Details you need to insert: ");
            n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                con = getConnection();
                Console.WriteLine("Enter Student Details SId,StdName,Dob");
                int Id;
                string Name, DateOfBirth;
                Id = Convert.ToInt32(Console.ReadLine());
                Name = Console.ReadLine();
                DateOfBirth = Console.ReadLine();
                cmd = new SqlCommand("insert into Student values (@S_ID,@S_Name,@S_Dob)", con);
                cmd.Parameters.AddWithValue("@S_ID", Id);
                cmd.Parameters.AddWithValue("@S_Name", Name);
                cmd.Parameters.AddWithValue("@S_Dob", DateOfBirth);
                int res1 = cmd.ExecuteNonQuery();
                if (res1 > 0)
                {
                    Console.WriteLine("Student details inserted Sucessfully");
                }
                else
                    Console.WriteLine("Please enter valid Student details");
            }

        }
        public void Introducing_NewCourse()
        {
            //Admin trying to introduce new courses for there institution
            int num;
            Console.WriteLine("Enter No. Of Course Details you need to insert: ");
            num = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < num; i++)
            {
                con = getConnection();
                Console.WriteLine("Enter Course Details CourseId,CourseName,Duration,Fee_Structure");
                int CId, Fees;
                string CName, Duration;
                CId = Convert.ToInt32(Console.ReadLine());
                CName = Console.ReadLine();
                Duration = Console.ReadLine();
                Fees = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("insert into Course values (@C_ID,@C_Name,@C_Dur,@Fees)", con);
                cmd.Parameters.AddWithValue("@C_ID", CId);
                cmd.Parameters.AddWithValue("@C_Name", CName);
                cmd.Parameters.AddWithValue("@C_Dur", Duration);
                cmd.Parameters.AddWithValue("@Fees", Fees);
                int res2 = cmd.ExecuteNonQuery();
                if (res2 > 0)
                {
                    Console.WriteLine("Course details inserted Sucessfully");
                }
                else
                    Console.WriteLine("Please enter valid Course details");
            }
        }
        public void Available_Courses()
        {
            //Admin module reveals courses in there Institute
            con = getConnection();
            cmd = new SqlCommand("Select *from Course", con);
            int res6 = cmd.ExecuteNonQuery();
            Console.WriteLine("Courses Available In the Institution are................!");
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.WriteLine("Course Details : ");
                Console.WriteLine("--------------------------");
                Console.WriteLine("Course Id : " + " " + dr[0]);
                Console.WriteLine("Course Name :" + " " + dr[1]);
                Console.WriteLine("Course Duration :" + " " + dr[2]);
                Console.WriteLine("Course Fees :" + " " + dr[3]);
                Console.WriteLine();

            }

        }

        public void enrolling_Course()
        {
            con = getConnection();
            int SId, CID;
            DateTime Enroll_Date;
            Console.WriteLine("Enter Student Id");
            SId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course Id");
            CID = Convert.ToInt32(Console.ReadLine());
            Enroll_Date = DateTime.UtcNow;
            cmd = new SqlCommand("insert into Enroll values(@cid,@S_id,@EnrollDate)", con);
            cmd.Parameters.AddWithValue("@cid", CID);
            cmd.Parameters.AddWithValue("@S_id", SId);
            cmd.Parameters.AddWithValue("@EnrollDate", Enroll_Date);
            int res3 = cmd.ExecuteNonQuery();
            if (res3 > 0)
            {
                Console.WriteLine("Student enrolled to the Course Sucessfully");
            }
            else
                Console.WriteLine("Please enter valid details");
        }

        public void Changes_inCourse()
        {

            con = getConnection();
            Console.WriteLine("Enter course Id you need to update: ");
            int cId = Convert.ToInt32(Console.ReadLine());
            string a;
            Console.WriteLine("Are you Sure you want to Update: Y/N ");
            a = Console.ReadLine();
            if (a == "Y" || a == "y")
            {
                Console.WriteLine("Enter New Course Duration");
                string CDur;
                CDur = Console.ReadLine();
                int Fees;
                Console.WriteLine("Enter New Course Fee");
                Fees = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("update Course set C_Dur = @cdur,Fees=@fees where C_Id=@cid", con);
                cmd.Parameters.AddWithValue("@cid", cId);
                cmd.Parameters.AddWithValue("@cdur", CDur);
                cmd.Parameters.AddWithValue("@fees", Fees);
                int res4 = cmd.ExecuteNonQuery();
                if (res4 > 0)
                {
                    Console.WriteLine("Course updated Sucessfully");
                }
                else
                    Console.WriteLine("Please enter valid Course Id");

            }
            else
            {
                Console.WriteLine("You are not supposed to Update Course details...!");
            }
        }
        public void Changes_inStudDetails()
        {
            con = getConnection();
            Console.WriteLine("Enter Student Id you need to update: ");
            int SId = Convert.ToInt32(Console.ReadLine());
            string a;
            Console.WriteLine("Are you Sure you want to Update: Y/N ");
            a = Console.ReadLine();
            if (a == "Y" || a == "y")
            {
                Console.WriteLine("Enter New Student DOB :");
                string SDOB;
                SDOB = Console.ReadLine();
                string SName;
                Console.WriteLine("Enter Updated Student Name :");
                SName = Console.ReadLine();
                cmd = new SqlCommand("update Student set S_Dob = @sdob,S_Name=@sname where S_ID=@sid", con);
                cmd.Parameters.AddWithValue("@sdob", SDOB);
                cmd.Parameters.AddWithValue("@sname", SName);
                cmd.Parameters.AddWithValue("@sid", SId);
                int res5 = cmd.ExecuteNonQuery();
                if (res5 > 0)
                {
                    Console.WriteLine("Student details updated Sucessfully");
                }
                else
                    Console.WriteLine("Please enter valid Student Id to update");
            }
            else
            {
                Console.WriteLine("You are not supposed to update Student details...!");
            }
        }
        public void Deletion_OfCourse()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter course Id that you need to Delete: ");
                int cId = Convert.ToInt32(Console.ReadLine());
                string a;
                Console.WriteLine("Are you Sure you want to Delete: Y/N ");
                a = Console.ReadLine();
                if (a == "Y" || a == "y")
                {
                    cmd = new SqlCommand("delete Course where C_Id=@cid", con);
                    cmd.Parameters.AddWithValue("@cid", cId);
                    int res6 = cmd.ExecuteNonQuery();
                    if (res6 > 0)
                    {
                        Console.WriteLine("Course deleted Sucessfully");
                    }
                    else
                        Console.WriteLine("Please enter valid Course Id to delete");
                }
                else
                {
                    Console.WriteLine("You are not supposed to delete the course please try again...!");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("Course cannot be deleted because students got enrolled", se);
            }
        }
        public void Delete_aStudent()
        {
            try
            {
                con = getConnection();
                Console.WriteLine("Enter Student Id that you need to Delete: ");
                int SId = Convert.ToInt32(Console.ReadLine());
                string a;
                Console.WriteLine("Are you Sure you want to Delete: Y/N ");
                a = Console.ReadLine();
                if (a == "Y" || a == "y")
                {
                    cmd = new SqlCommand("delete Student where S_ID=@sid", con);
                    cmd.Parameters.AddWithValue("@sid", SId);
                    int res7 = cmd.ExecuteNonQuery();
                    if (res7 > 0)
                    {
                        Console.WriteLine("Student deleted Sucessfully");
                    }
                    else
                        Console.WriteLine("Please enter valid Student Id to delete");
                }
                else
                {
                    Console.WriteLine("You are not supposed to delete the Student please try again...!");
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("OOPS...! Something went wrong", se);
            }
        }
        public void Student_Screen()
        {
            try
            {
                //whenever we are trying to retrieve particular student details
                con = getConnection();
                int SId;
                Console.WriteLine("Enter Student Id");
                SId = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select *from Student where S_ID=@SId", con);
                cmd.Parameters.AddWithValue("@SId", SId);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Student Details : ");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Student Id : " + " " + dr[0]);
                    Console.WriteLine("Student Name :" + " " + dr[1]);
                    Console.WriteLine("Student DOB :" + " " + dr[2]);
                    Console.WriteLine();
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("Students Doesn't Exist.....Start New Registration", se);
            }

        }
        public void Retrieve_Particular_Course()
        {
            try
            {
                //whenever we are trying to retrieve particular student details
                con = getConnection();
                int CId;
                Console.WriteLine("Enter Course Id");
                CId = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("select *from Course where C_Id=@cId", con);
                cmd.Parameters.AddWithValue("@cId", CId);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("Particular Course Details : ");
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("Course Id : " + " " + dr[0]);
                    Console.WriteLine("Course Name :" + " " + dr[1]);
                    Console.WriteLine("Course Duration :" + " " + dr[2]);
                    Console.WriteLine("Course Fees :" + " " + dr[3]);
                    Console.WriteLine();
                }
            }
            catch (SqlException se)
            {
                Console.WriteLine("Course Doesn't Exist...........!", se);
            }


        }



    }
}