using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Data_Access_layer
{
    /*  CRUD
        [C] - Create
        [R] - Read
        [U] - Update
        [D] - Delete
    */
    internal class DbSportShop
    {
        private SqlConnection connection;
        public DbSportShop(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            connection.Open();
            Console.WriteLine("Connected to database");
        }

        //[C] - Create
        public void AddProduct(Product product)
        {
            string cmd = @"insert into Products 
                                values(@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand command= new SqlCommand(cmd,connection);
            setCommandParams(ref command, product);
            command.ExecuteNonQuery();
        }

        private void setCommandParams(ref SqlCommand command, Product product)
        {
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
            command.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
            command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
        }
        //[R] - Read

        public List<Product> getAll()
        {
            string cmd = @"select * from Products";
            SqlCommand command= new SqlCommand(cmd,connection);
            return getAllProducts(command);
        }
        public Product getOneProduct(int id)
        {
            string cmd = "select * from Products where Id = @id";
            SqlCommand command = new SqlCommand(cmd,connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            return getAllProducts(command).FirstOrDefault()!;
        }
        private List<Product> getAllProducts(SqlCommand command)
        {
            List<Product> products = new List<Product>();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                products.Add(new Product()
                {
                    Id = reader.GetInt32(0), // (int)reader[0],
                    Name = reader.GetString(1),
                    Type = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    CostPrice = reader.GetInt32(4),
                    Producer = reader.GetString(5),
                    Price = reader.GetInt32(6)
                });
            }
            reader.Close();
            return products;
        }
        //[U] - Update
        public void Update(Product product)
        {
            string cmd = @"update Products
                            set
                                Name = @name,
                                TypeProduct = @type,
                                Quantity = @quantity,
                                CostPrice = @cost_price,
                                Producer = @producer,
                                Price = @price
                            where Id = @id
                            ";
            SqlCommand command = new SqlCommand(cmd, connection);
            setCommandParams(ref command, product);
            command.Parameters.Add("@id",System.Data.SqlDbType.Int).Value=product.Id;
            command.ExecuteNonQuery();
        }
        //[D] - Delete
        public void Delete(int id)
        {
            string cmd = @"delete from Products where Id = @id";
            SqlCommand command = new SqlCommand(cmd, connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }
        ~DbSportShop()
        {
            connection.Close();
        }
    }
}
