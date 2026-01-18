using MySql.Data.MySqlClient;
using FitnessTracker.Models;

namespace FitnessTracker.Class
{
    public class UserService
    {
        public static bool UsernameExists(string username)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM users WHERE username = @username";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public static bool RegisterUser(User user)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO users 
    (username, password_hash, calorie_goal, weight_kg, time_taken_days) 
    VALUES (@username, @password, @goal, @weight, @days)";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", user.Username);
                    cmd.Parameters.AddWithValue("@password", user.PasswordHash);
                    cmd.Parameters.AddWithValue("@goal", user.CalorieGoal);
                    cmd.Parameters.AddWithValue("@weight", user.WeightKg);
cmd.Parameters.AddWithValue("@days", user.TimeTakenDays);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static User? Login(string username, string passwordHash)
        {
            using (var conn = Database.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM users WHERE username=@username AND password_hash=@password";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", passwordHash);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = reader.GetInt32("user_id"),
                                Username = reader.GetString("username"),
                                PasswordHash = reader.GetString("password_hash"),
                                CalorieGoal = reader.GetInt32("calorie_goal")
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
