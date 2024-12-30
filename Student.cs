using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem
{
    internal class Student
    {
        public int studentId { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public char grade { get; set; }
        public string email { get; set; }

        public Student(int studentId, string name, int age, char grade, string email)
        {
            this.studentId = studentId;
            this.name = name;
            this.age = age;
            this.grade = grade;
            this.email = email;
        }

        public override string ToString()
        {
            return $"Student: Id-{studentId}, Name-{name}, Age-{age}, Grade-{grade}, Email-{email}";
        }

    }

}
