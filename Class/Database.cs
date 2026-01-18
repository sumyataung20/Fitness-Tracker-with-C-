using MySql.Data.MySqlClient;

namespace FitnessTracker.Class
{
    public class Database
    {
        public static MySqlConnection GetConnection()
        {
            // Use @ to avoid escape issues with special characters in password
            string connStr = @"server=localhost;database=fitness_tracker;user=root;password=Hsu&122219;";
            return new MySqlConnection(connStr);
        }
    }
}
