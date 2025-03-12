using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_EF_CodeFirst.Entities
{
    public class Department
    {
        public Department()
        {
            Workers= new List<Worker>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }

        // Navigation property
        public ICollection<Worker> Workers { get; set; }
    }
}
