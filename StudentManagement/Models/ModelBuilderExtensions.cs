using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   Id = 1,
                   Name = "Adi",
                   Course = Course.IT,
                   Email = "adi@sveducation.com"

               },
               new Student
               {
                   Id = 2,
                   Name = "Jack",
                   Course = Course.MBA,
                   Email = "jack@sveducation.com"

               }
               );
        }
    }
}
