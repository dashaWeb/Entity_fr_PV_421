using _07_EF_Data_annotation___fluent_api;

internal class Program
{
    private static void Main(string[] args)
    {
        Company_db context = new Company_db();

        /*context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
        context.Workers.FirstOrDefault(n => n.Name == "Tomm").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
        context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));


        context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));
        context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));

        context.SaveChanges();*/

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