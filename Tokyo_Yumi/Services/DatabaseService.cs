using Microsoft.Data.Sqlite;
using Tokyo_Yumi.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace Tokyo_Yumi.Data
{
    // שירות לניהול מסד הנתונים של האפליקציה (SQLite).
    // מטפל ביצירת טבלאות, ניהול משתמשים ואטרקציות.
    public class DatabaseService
    {
        // מחרוזת התחברות המצביעה על קובץ בתיקיית הריצה של האפליקציה
        private readonly string _connectionString =
          $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.db")}";

        // בנאי השירות - דואג ליצירת קובץ מסד הנתונים והטבלאות במידה ואינם קיימים.
        public DatabaseService()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // יצירת טבלת משתמשים (Users)
            using var userCommand = new SqliteCommand(
                "CREATE TABLE IF NOT EXISTS Users (Id TEXT PRIMARY KEY, Name TEXT, UserName TEXT, Password TEXT, Role TEXT);", connection);
            userCommand.ExecuteNonQuery();

            // יצירת טבלת אטרקציות (Attractions)
            using var attrCommand = new SqliteCommand(
                "CREATE TABLE IF NOT EXISTS Attractions (" +
                "Id INTEGER PRIMARY KEY, " +
                "Name TEXT, " +
                "Description TEXT, " +
                "Category TEXT, " +
                "ImageUrl TEXT, " +
                "Address TEXT);", connection);
            attrCommand.ExecuteNonQuery();
        }

        // ==========================================
        //         ניהול אטרקציות (Attractions)
        // ==========================================

        // מאתחל את טבלת האטרקציות מתוך רשימה נתונה.
        public void InitializeAttractions(List<Attraction> attractions)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            foreach (var att in attractions)
            {
                using var insertCmd = new SqliteCommand(
                  "INSERT OR IGNORE INTO Attractions (Id, Name, Description, Category, ImageUrl, Address) " +
                  "VALUES (@Id, @Name, @Desc, @Cat, @Img, @Addr)", connection);

                // שימוש בפרמטרים למניעת SQL Injection וטיפול בערכי Null
                insertCmd.Parameters.AddWithValue("@Id", att.Id);
                insertCmd.Parameters.AddWithValue("@Name", att.Name);
                insertCmd.Parameters.AddWithValue("@Desc", att.Description ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@Cat", att.Category ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@Img", att.ImageUrl ?? (object)DBNull.Value);
                insertCmd.Parameters.AddWithValue("@Addr", att.Address ?? (object)DBNull.Value);

                insertCmd.ExecuteNonQuery();
            }
        }

        // שולף את כל האטרקציות הקיימות במסד הנתונים.
        public List<Attraction> GetAllAttractions()
        {
            var list = new List<Attraction>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var cmd = new SqliteCommand("SELECT * FROM Attractions", connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Attraction
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    ImageUrl = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Address = reader.IsDBNull(5) ? "" : reader.GetString(5)
                });
            }
            return list;
        }

        // ==========================================
        //           ניהול משתמשים (Users)
        // ==========================================

        // מחזיר רשימה של כל המשתמשים הרשומים.
        public List<User> GetUsers()
        {
            var users = new List<User>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("SELECT Id, Name, UserName, Password, Role FROM Users", connection);
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.IsDBNull(4) ? null : reader.GetString(4)));
            }
            return users;
        }

        // הוספת משתמש חדש למערכת.
        public void AddUser(User user)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("INSERT INTO Users (Id, Name, UserName, Password, Role) VALUES (@Id, @Name, @UserName, @Password, @Role)", connection);
            command.Parameters.AddWithValue("@Id", user.GetId());
            command.Parameters.AddWithValue("@Name", user.GetName());
            command.Parameters.AddWithValue("@UserName", user.GetUserName());
            command.Parameters.AddWithValue("@Password", user.GetPassword());
            command.Parameters.AddWithValue("@Role", user.GetRole());

            command.ExecuteNonQuery();
        }

        // עדכון פרטי משתמש קיים לפי מזהה (Id).
        public void UpdateUser(User user)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("UPDATE Users SET Name = @Name, UserName = @UserName, Password = @Password, Role = @Role WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", user.GetId());
            command.Parameters.AddWithValue("@Name", user.GetName());
            command.Parameters.AddWithValue("@UserName", user.GetUserName());
            command.Parameters.AddWithValue("@Password", user.GetPassword());
            command.Parameters.AddWithValue("@Role", user.GetRole());
            command.ExecuteNonQuery();
        }

        // מחיקת משתמש מהמערכת לפי מזהה.
        public void DeleteUser(string id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("DELETE FROM Users WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", id);
            command.ExecuteNonQuery();
        }

        // אימות פרטי התחברות (Login).
        public bool ValidateLogin(string userName, string password)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var command = new SqliteCommand("SELECT COUNT(*) FROM Users WHERE UserName = @UserName AND Password = @Password", connection);
            command.Parameters.AddWithValue("@UserName", userName);
            command.Parameters.AddWithValue("@Password", password);
            return Convert.ToInt32(command.ExecuteScalar()) > 0;
        }

        // פונקציה לעדכון פרטים בסיסיים של משתמש
        public void UpdateUserDetails(string id, string newFullName, string newUsername)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var sql = "UPDATE Users SET Name = @name, UserName = @username WHERE Id = @id";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@name", newFullName);
                    command.Parameters.AddWithValue("@username", newUsername);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        // פונקציה לעדכון תפקיד המשתמש (Admin/User)
        public void UpdateUserRole(string id, string newRole)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                var sql = "UPDATE Users SET Role = @role WHERE Id = @id";

                using (var command = new SqliteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@role", newRole);
                    command.Parameters.AddWithValue("@id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ToggleFavorite(string userId, int attractionId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            // בדיקה אם כבר קיים
            using var checkCmd = new SqliteCommand("SELECT COUNT(*) FROM Favorites WHERE UserId = @uid AND AttractionId = @aid", connection);
            checkCmd.Parameters.AddWithValue("@uid", userId);
            checkCmd.Parameters.AddWithValue("@aid", attractionId);

            bool exists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;

            if (exists)
            {
                using var deleteCmd = new SqliteCommand("DELETE FROM Favorites WHERE UserId = @uid AND AttractionId = @aid", connection);
                deleteCmd.Parameters.AddWithValue("@uid", userId);
                deleteCmd.Parameters.AddWithValue("@aid", attractionId);
                deleteCmd.ExecuteNonQuery();
            }
            else
            {
                using var insertCmd = new SqliteCommand("INSERT INTO Favorites (UserId, AttractionId) VALUES (@uid, @aid)", connection);
                insertCmd.Parameters.AddWithValue("@uid", userId);
                insertCmd.Parameters.AddWithValue("@aid", attractionId);
                insertCmd.ExecuteNonQuery();
            }
        }

        public List<int> GetUserFavoriteIds(string userId)
        {
            var ids = new List<int>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var cmd = new SqliteCommand("SELECT AttractionId FROM Favorites WHERE UserId = @uid", connection);
            cmd.Parameters.AddWithValue("@uid", userId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) ids.Add(reader.GetInt32(0));
            return ids;
        }
        public List<Attraction> GetUserFavorites(string userId)
        {
            var list = new List<Attraction>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var cmd = new SqliteCommand(
                "SELECT a.* FROM Attractions a INNER JOIN Favorites f ON a.Id = f.AttractionId WHERE f.UserId = @uid", connection);
            cmd.Parameters.AddWithValue("@uid", userId);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Attraction
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Category = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    ImageUrl = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Address = reader.IsDBNull(5) ? "" : reader.GetString(5)
                });
            }
            return list;
        }
    }
}