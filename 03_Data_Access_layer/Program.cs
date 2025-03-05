using _03_Data_Access_layer;
using System.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;
        DbSportShop db = new DbSportShop(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        //db.AddProduct(new Product()
        //{
        //    Name = "Ручка",
        //    Type = "Аксесуари",
        //    Quantity = 15,
        //    CostPrice = 50,
        //    Price = 150,
        //    Producer = "Україна"
        //});

        /*List<Product> products = db.getAll();
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }*/
        //Console.WriteLine(db.getOneProduct(1));
        //Product product = db.getOneProduct(1);
        //Console.WriteLine(product);
        //product.Name = "Test test";
        //db.Update(product);
        //Console.WriteLine(db.getOneProduct(1));

        db.Delete(5);
    }
}