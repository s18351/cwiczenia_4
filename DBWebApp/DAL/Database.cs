using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace DBWebApp.DAL
{
    public class Database
    {
        static string connectionString = "Data Source=db-mssql16;Initial Catalog=s18351;Integrated Security=True";

        public static IEnumerable<Animal> GetAll(string orderBy)
        {
            if (!typeof(Animal).GetProperties(BindingFlags.Public | BindingFlags.Instance).Any(x=>x.Name.ToLower() == orderBy.ToLower()))
            {
                throw new ApplicationException("Invalid order by parameter");
            }

            List<Animal> list = new List<Animal>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection= connection;
                command.CommandText = "SELECT * FROM ANIMAL ORDER BY " + orderBy;

                connection.Open();
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Animal(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                            , reader.GetString(3), reader.GetString(4)));
                    }

                }
                
            }
            return list;
        }

        public static void InsertAnimal (Animal animal) {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "INSERT INTO Animal (Name, Description, Category, Area) VALUES (@name, @description, @category, @area)";

                command.Parameters.AddWithValue("@name", animal.Name);
                command.Parameters.AddWithValue("@description", animal.Description);
                command.Parameters.AddWithValue("@category", animal.Category);
                command.Parameters.AddWithValue("@area", animal.Area);
                connection.Open();

                command.ExecuteNonQuery();
            }


        }

        public static void UpdateAnimal (int idAnimal ,Animal animal) {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Animal SET Name=@name, Description=@description, Category=@category, Area=@area WHERE IdAnimal=@idanimal";

                command.Parameters.AddWithValue("@name", animal.Name);
                command.Parameters.AddWithValue("@description", animal.Description);
                command.Parameters.AddWithValue("@category", animal.Category);
                command.Parameters.AddWithValue("@area", animal.Area);
                command.Parameters.AddWithValue("@idanimal", idAnimal);
                connection.Open();

                command.ExecuteNonQuery();
            }

        }

        public static void DeleteAnimal(int idAnimal)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Animal WHERE IdAnimal=@idanimal";

                command.Parameters.AddWithValue("@idanimal", idAnimal);
                connection.Open();

                command.ExecuteNonQuery();
            }
        }









        }
}
