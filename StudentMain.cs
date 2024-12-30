using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class StudentMain
    {
        public static List<Student> students = new List<Student>();

        public void AddStudent()
        {
            try
            {
                Console.WriteLine("Enter Student Id: ");
                int studentId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Student Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Grade: ");
                char grade = Convert.ToChar(Console.ReadLine());
                Console.WriteLine("Enter Student Email: ");
                string email = Console.ReadLine();

                Student s = new Student(studentId, name, age, grade, email);
                var context = new ValidationContext(s);
                var results = new List<ValidationResult>();
                bool isValid = Validator.TryValidateObject(s, context, results, true);

                if (isValid)
                {
                    Console.WriteLine("Data Validation success");
                    students.Add(s);
                    Console.WriteLine("Data Added successfully");
                }
                else
                {
                    Console.WriteLine("Data Validation failed!");
                    foreach(var i in results)
                    {
                        Console.WriteLine($"Error: {i}");
                    }
                }
                
            }
            catch(FormatException e)
            {
                Console.WriteLine("Enter in correct data type format!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}"+ex.StackTrace);
            }

        }
        public void DisplayStudents()
        {
            try
            {
                if (students == null)
                {
                    Console.WriteLine("No Record Found!!!");
                }
                else
                {
                    students.ForEach(s => Console.WriteLine(s));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception occured while displaying students: {e.Message}");
            }
        }

        public void SearchStudent()
        {
            try
            {
                Console.WriteLine("Choose \n1.To search with Name\n2.To search with Grade");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the Name:");
                        string name = Console.ReadLine().ToLower();

                        if (students != null)
                        {
                            var studentsByName = students
                            .Where(s => s.Name.ToLower().Contains(name))
                            .ToList();

                            if (studentsByName.Count > 0)
                            {
                                studentsByName.ForEach(student => Console.WriteLine(student));
                            }
                            else
                            {
                                Console.WriteLine("No students found with the given name!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Student found!");
                        }
                        break;

                    case 2:
                        Console.WriteLine("Enter the Grade:");
                        char grade = Convert.ToChar(Console.ReadLine());
                        if (students != null)
                        {
                            var studentsByGrade = students.Where(s => s.Grade == grade).ToList();
                            if (studentsByGrade.Count > 0)
                                studentsByGrade.ForEach(student => Console.WriteLine(student));
                            else
                                Console.WriteLine("No students found with the given grade!");
                        }
                        else
                        {
                            Console.WriteLine("No Students Found");
                        }

                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            catch(FormatException e)
            {
                Console.WriteLine("Enter in valid data format!");
            }
            catch(Exception e)
            {
                Console.WriteLine($"Error occured: {e.Message}");
            }      
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student Id to update:");
            int studentId = Convert.ToInt32(Console.ReadLine());
            if(students != null)
            {
                var student = students.FirstOrDefault(s => s.StudentId == studentId);

                if (student != null)
                {
                    Console.WriteLine("Enter new Name:");
                    student.Name = Console.ReadLine();
                    Console.WriteLine("Enter new Age:");
                    student.Age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new Grade:");
                    student.Grade = Convert.ToChar(Console.ReadLine());
                    Console.WriteLine("Enter new Email:");
                    student.Email = Console.ReadLine();
                    Console.WriteLine("Student details updated successfully!");
                }
                else
                {
                    Console.WriteLine("Student with the given Id not found!");
                }
            }
            else
            {
                Console.WriteLine("No Record found!");
            }
            
        }

        public void DeleteStudent()
        {
            try
            {
                Console.WriteLine("Enter Student Id to delete:");
                int studentId = Convert.ToInt32(Console.ReadLine());

                var student = students.FirstOrDefault(s => s.StudentId == studentId);

                if (student != null)
                {
                    students.Remove(student);
                    Console.WriteLine("Student deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Student with the given Id not found!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the correct data type!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the student: {ex.Message}");
            }

        }
    }
}
