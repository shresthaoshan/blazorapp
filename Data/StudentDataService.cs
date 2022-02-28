using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Part2.Data
{
    public class University : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string currentDirectory = System.Environment.CurrentDirectory;
            string parentDirectory = System.IO.Directory.GetParent(currentDirectory).FullName;
            string path = System.IO.Path.Combine(parentDirectory, "University.db");
            optionsBuilder.UseSqlite($"Filename={path}");
        }
    }
    public class StudentDataService
    {
        public Student[] GetStudents()
        {
            University uni = new University();
            IQueryable<Student> students = uni.Students;

            return students.ToArray();
        }
    }
}
