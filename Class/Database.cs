// using MySql.Data.MySqlClient;

// namespace FitnessTracker.Class
// {
//     public class Database
//     {
//         public static MySqlConnection GetConnection()
//         {
//             // Use @ to avoid escape issues with special characters in password
//             string connStr = @"server=localhost;database=fitness_tracker;user=root;password=Hsu&122219;";
//             return new MySqlConnection(connStr);
//         }
//     }
// }


using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using FitnessTracker.Models;

namespace FitnessTracker.Class
{
    public class Database
    {
        private static string connStr = @"server=localhost;database=fitness_tracker;user=root;password=Hsu&122219;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connStr);
        }

        // Fetch all activities
        public static List<Activity> GetActivities()
        {
            var list = new List<Activity>();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT activity_id, name FROM activities", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Activity
                    {
                        Id = reader.GetInt32("activity_id"),
                        Name = reader.GetString("name")
                    });
                }
            }
            return list;
        }

        // Fetch descriptions for a given activity
        public static List<ActivityDescription> GetActivityDescriptions(int activityId)
        {
            var list = new List<ActivityDescription>();
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT description_id, activity_id, description, MET FROM activitydescriptions WHERE activity_id=@id", conn);
                cmd.Parameters.AddWithValue("@id", activityId);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new ActivityDescription
                    {
                        Id = reader.GetInt32("description_id"),
                        ActivityId = reader.GetInt32("activity_id"),
                        Description = reader.GetString("description"),
                        MET = reader.GetDouble("MET")
                    });
                }
            }
            return list;
        }

        // Insert a new activity record
        public static void InsertActivityRecord(int userId, int activityId, int descriptionId,
                                                double duration, double metric1, double metric2, double metric3,
                                                double totalCalories, DateTime recordDate)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    @"INSERT INTO activityrecords
                      (user_id, activity_id, description_id, duration_minutes, metric1_value, metric2_value, metric3_value, total_calories, record_date)
                      VALUES (@userId, @activityId, @descriptionId, @duration, @metric1, @metric2, @metric3, @totalCalories, @recordDate)", conn);

                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@activityId", activityId);
                cmd.Parameters.AddWithValue("@descriptionId", descriptionId);
                cmd.Parameters.AddWithValue("@duration", duration);
                cmd.Parameters.AddWithValue("@metric1", metric1);
                cmd.Parameters.AddWithValue("@metric2", metric2);
                cmd.Parameters.AddWithValue("@metric3", metric3);
                cmd.Parameters.AddWithValue("@totalCalories", totalCalories);
                cmd.Parameters.AddWithValue("@recordDate", recordDate);

                cmd.ExecuteNonQuery();
            }
        }
        public static List<(double calories, DateTime date)> GetUserActivitySummary(int userId)
        {
            var list = new List<(double, DateTime)>();

            using (var conn = GetConnection())
            {
                conn.Open();
                var cmd = new MySqlCommand(
                    "SELECT total_calories, record_date FROM activityrecords WHERE user_id = @uid",
                    conn);
                cmd.Parameters.AddWithValue("@uid", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add((
                            reader.GetDouble("total_calories"),
                            reader.GetDateTime("record_date")
                        ));
                    }
                }
            }

            return list;
        }

    }

}
