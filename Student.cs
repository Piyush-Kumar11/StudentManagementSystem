using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Student
    {
        [Required(ErrorMessage ="Id is required!")]
        public int StudentId { get; set; }

        [StringLength(25,ErrorMessage ="Name should be between 2 to 25 letters only!"),MinLength(2)]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Range(1,100,ErrorMessage ="Age must be greater than 0")]
        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Grade is required!")]
        public char Grade { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage ="Invalid Email entered!")]
        public string Email { get; set; }

        public Student(int studentId, string name, int age, char grade, string email)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Grade = grade;
            Email = email;
        }

        public override string ToString()
        {
            return $"Student: Id-{StudentId}, Name-{Name}, Age-{Age}, Grade-{Grade}, Email-{Email}";
        }

    }

}
