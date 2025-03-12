using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFirst.Entities
{
    public class Worker
    {
        public Worker()
        {
            Projects = new List<Project>();
        }
        // ID / id / ID / WorkerId  --> PR
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
        // EntityID --> FK
        public int DepartmentId { get; set; }
        public int CountryId { get; set; }

        // Navigation property
        public Department Department { get; set; }
        public Country Country { get; set; }
        public ICollection<Project> Projects { get; set; }
    }
}
