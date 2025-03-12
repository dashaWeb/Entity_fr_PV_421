using _06_EF_CodeFirst;
using _06_EF_CodeFirst.Entities;

internal class Program
{
    private static void Main(string[] args)
    {


        /*
         CompanyIT

        Worker
        Project
        Country
        Department
         */

        Company_db context = new Company_db();
        // add countries
        /*context.Countries.Add(new Country() { Name = "Ukraine" });
        context.Countries.Add(new Country() { Name = "Poland" });
        context.Countries.Add(new Country() { Name = "USA" });
        context.SaveChanges();

        // departments
        context.Departments.Add(new Department() { Name = "Management", Phone = "45-85-96" });
        context.Departments.Add(new Department() { Name = "Programming", Phone = "41-78-25" });
        context.Departments.Add(new Department() { Name = "Design", Phone = "47-85-96" });
        context.SaveChanges();

        // workers
        context.Workers.Add(new Worker()
        {
            Name = "Emma",
            Surname = "Miller",
            Salary = 2700,
            Birthdate = new DateTime(2005, 12, 12),
            Country = context.Countries.FirstOrDefault(n => n.Name == "Poland"),
            Department = context.Departments.FirstOrDefault(d => d.Name == "Design")
        }) ;
        context.Workers.Add(new Worker()
        {
            Name = "Taras",
            Surname = "Bondar",
            Salary = 5800,
            Birthdate = new DateTime(2007, 4, 26),
            Country = context.Countries.FirstOrDefault(n => n.Name == "Ukraine"),
            Department = context.Departments.FirstOrDefault(d => d.Name == "Programming")
        });
        context.Workers.Add(new Worker()
        {
            Name = "Tomm",
            Surname = "Doe",
            Salary = 3200,
            Birthdate = new DateTime(2012, 1, 13),
            Country = context.Countries.FirstOrDefault(n => n.Name == "USA"),
            Department = context.Departments.FirstOrDefault(d => d.Name == "Management")
        });
        context.SaveChanges();

        // projects
        context.Projects.Add(new Project() { Name = "Tetris", LaunchDate = new DateTime(1982, 12, 12) });
        context.Projects.Add(new Project() { Name = "CS", LaunchDate = new DateTime(2000, 1, 1) });
        context.Projects.Add(new Project() { Name = "PacMan", LaunchDate = new DateTime(1999, 3, 3) });
        context.SaveChanges();*/


        /*context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));*/
        /*context.Workers.FirstOrDefault(n => n.Name == "Tomm").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
        context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));*/


        /*context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));
        context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));*/

        //context.SaveChanges();

        var workers = context.Workers.ToList();

        foreach (var worker in workers)
        {
            Console.WriteLine($"\n\n {new string('-', 50)}");
            Console.WriteLine($"\t {worker.Name,16} {worker.Surname,16}");
            Console.WriteLine($"\t\t Birthdate :: {worker.Birthdate.ToShortDateString()}");
            Console.WriteLine($"\t\t Salary    :: {worker.Salary}$");
            context.Entry(worker).Reference(nameof(worker.Country)).Load();
            Console.WriteLine($"\t\t Country   :: {worker.Country.Name}");
            context.Entry(worker).Reference(nameof(worker.Department)).Load();
            Console.WriteLine($"\t\t Department:: {worker.Department.Name}");

            context.Entry(worker).Collection(nameof(worker.Projects)).Load();
            foreach (var item in worker.Projects)
            {
                Console.WriteLine($"\t\t{new string('-', 30)}");
                Console.WriteLine($"\t\t\t{item.Name}  {item.LaunchDate}");
            }
        }
        

    }
}