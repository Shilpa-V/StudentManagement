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
                new Student(){Id = 1, Name = "Mary", Course = "IT", Email = "mary@mycom.com"},
                new Student(){Id = 2, Name = "Shelly", Course = "B.Tech", Email = "shelly@mycom.com"},
                new Student(){Id = 3, Name = "Ady", Course = "MBA", Email = "ady@mycom.com"}
            };
        }
        public Student GetStudent(int Id)
        {
            return _studentList.FirstOrDefault(s => s.Id == Id);
        }
    }
}
