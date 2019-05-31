using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class MockStudentRepository : IStudentRepository
    {
        private readonly List<Student> _studentList;

        public MockStudentRepository()
        {
            _studentList = new List<Student>()
            {
                new Student(){Id = 1, Name = "Mary", Course = Course.IT, Email = "mary@mycom.com"},
                new Student(){Id = 2, Name = "Shelly", Course = Course.MBA, Email = "shelly@mycom.com"},
                new Student(){Id = 3, Name = "Ady", Course = Course.MIT, Email = "ady@mycom.com"}
            };
        }

        public Student Add(Student student)
        { 
             student.Id = _studentList.Max(s => s.Id) + 1 ;
            _studentList.Add(student);
            return student;
        }

        public Student Delete(int id)
        {
           Student student  = _studentList.FirstOrDefault(s => s.Id == id);
            if (student != null)
                _studentList.Remove(student);
            return student;

        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentList;
        }

        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(s => s.Id == Id);
        }

        public Student Update(Student studentChanges)
        {
            Student student = _studentList.FirstOrDefault(s => s.Id == studentChanges.Id);
            if (student != null)
            {
                student.Name = studentChanges.Name;
                student.Email = studentChanges.Email;
                student.Course = studentChanges.Course;
            }
               
            return student;
        }
    }
}
