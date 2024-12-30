using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentMain s = new StudentMain();
            char c;
            do
            {
                Console.WriteLine("Choose the option:\n1.Add Students\n2.Display Student\n3.Search student\n4.Update Student\n5.Delete student\n6.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        s.AddStudent();
                        break;
                    case 2:
                        s.DisplayStudents();
                        break;
                    case 3:
                        s.SearchStudent();
                        break;
                    case 4:
                        s.UpdateStudent();
                        break;
                    case 5:
                        s.DeleteStudent();
                        break;
                    case 6:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
                Console.WriteLine("Enter Y/y to choose again or other key to exit!");
                c = Convert.ToChar(Console.ReadLine());
            } while (c == 'Y' || c == 'y');
            Console.WriteLine("Exited Successfully!!!");
        }
    }
}
