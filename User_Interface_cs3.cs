using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zensar_Casstudy_Day1
{
	abstract class UserInterface
	{
		public abstract void showFirstScreen();
		public abstract void showStudentScreen();
		public abstract void showAdminScreen();
		public abstract void showAllStudentsScreen();
		public abstract void showStudentRegistrationScreen();
		public abstract void introduceNewCourseScreen();
		public abstract void showAllCoursesScreen();
	}
	class Institute_Details : UserInterface
	{
		string option;
		public override void showFirstScreen()
		{
			do
			{
				Console.WriteLine("Welcome to SMS(Student Management System)");
				Console.WriteLine("Tell us who you are : \n1. Student\n2. Admin");
				Console.WriteLine("Enter your choice ( 1 or 2) : ");
				int op = Convert.ToInt32(Console.ReadLine());
				switch (op)
				{
					case 1:
						showStudentScreen();
						break;
					case 2:
						showAdminScreen();
						break;
					default:
						Console.WriteLine("Enter valid Option....!");
						break;
				}
				Console.WriteLine("Do you want to Continue in Main Screen Y or N");
				option = Console.ReadLine();
			} while ((option == "Y") || (option == "y"));
		}
		public override void showStudentScreen()
		{
			do
			{
				AppEngine ae = new AppEngine();
				Console.WriteLine("Select: \n1.Check your Details(Existing User)\n2.Registration(New User)\n3.Search Available Courses\n4.Enroll to Course in List");
				int op = Convert.ToInt32(Console.ReadLine());

				switch (op)
				{
					case 1:
						// Checks whether new registrartion or already existing user
						ae.Student_Screen();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 2://New registration
						this.showStudentRegistrationScreen();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 3:
						//Showcase all available courses that student have an idea to enroll with particular CourseID during enrollment
						Console.WriteLine("--------------------List of Courses------------------------");
						ae.Available_Courses();
						Console.WriteLine("Action Completed you may Exit....!");
						break;

					case 4:
						//Student enrolling to particular course
						ae.enrolling_Course();
						Console.WriteLine("You have successfully enrolled you may Exit the Screen now");
						break;
					default:
						Console.WriteLine("Enter valid Option....!");
						break;

				}
				Console.WriteLine("Do you want to Continue in Student Screen Y or N");
				option = Console.ReadLine();

			}
			while ((option == "Y") || (option == "y"));
		}
		public override void showAdminScreen()
		{
			do
			{
				AppEngine aE = new AppEngine();
				Console.WriteLine("Select: \n1.Introduce New Course\n2.Courses Available\n3.Update Course Details\n4.Retrieve Particular Course in List\n5.Deleting Existing Student\n6.Delete Course\n7.Update Student Details\n8.AllRegistered Students");
				int op = Convert.ToInt32(Console.ReadLine());
				switch (op)
				{
					case 1:
						//If any new course want to add for Organization
						this.introduceNewCourseScreen();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 2:
						//list of existing courses
						Console.WriteLine("-------------All Available Courses in Institute-------------------");
						this.showAllCoursesScreen();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 3:
						//updates in Course structure
						aE.Changes_inCourse();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 4:
						//getting particular course details
						aE.Retrieve_Particular_Course();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 5:
						//deletes particular student
						aE.Delete_aStudent();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 6:
						//deletes existing course only that are not enrolled by any students
						aE.Deletion_OfCourse();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 7:
						//modify existing student details
						aE.Changes_inStudDetails();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					case 8:
						//retrieving all student details
						aE.Show_all_registered_Students();
						Console.WriteLine("Action Completed you may Exit....!");
						break;
					default:
						Console.WriteLine("Enter valid Option....!");
						break;

				}
				Console.WriteLine("Do you want to Continue in Admin Screen Y or N");
				option = Console.ReadLine();
			}
			while ((option == "Y") || (option == "y"));
		}
		public override void showAllStudentsScreen()
		{
			//Navigates to pool of students in Database
			AppEngine Ae = new AppEngine();
			Ae.Show_all_registered_Students();
			Console.WriteLine("Action Completed you may Exit....!");
		}
		public override void showStudentRegistrationScreen()
		{
			//navigates to registration block
			AppEngine A = new AppEngine();
			A.New_StudentRegistration();
		}
		public override void introduceNewCourseScreen()
		{
			// Navigates to registering new courses to academy
			AppEngine AE = new AppEngine();
			AE.Introducing_NewCourse();

		}
		public override void showAllCoursesScreen()
		{
			//Navigates to pool of Courses in Database
			AppEngine ape = new AppEngine();
			ape.Available_Courses();
		}
	}
}