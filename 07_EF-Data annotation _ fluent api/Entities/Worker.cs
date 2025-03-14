using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF_Data_annotation___fluent_api.Entities
{
    //[Table("WorkersTable")]
    public class Worker
    {
        /*public Worker()
        {
            Projects = new List<Project>();
        }*/
        // ID / id / ID / WorkerId  --> PR
        /*[Key] // - primary key
        [Column("Id")]*/
        public int Number { get; set; }
        /*[MaxLength(100)]
        [Required]
        [Column("FirstName")]*/
        public string Name { get; set; }
       /* [MaxLength(50), Column("LastName"), Required]*/
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public double Salary { get; set; }
        // EntityID --> FK
        public int DepartmentId { get; set; }
        public int CountryId { get; set; }
        public string  FullName { get => Name + " " + Surname; }
/*        [NotMapped]
        public string Email { get; set; }*/

        // Navigation property
        public Department Department { get; set; }
        public Country Country { get; set; }
        //public ICollection<Project> Projects { get; set; }
        
    }
}
