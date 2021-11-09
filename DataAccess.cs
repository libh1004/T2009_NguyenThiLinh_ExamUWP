using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace T2009_NguyenThiLinh_ExamUWP
{
    public class DataAccess
    {
        public static string DatabaseName = "contact_manager";
        public async static void InitializeDatabase()
        {
            await ApplicationData.Current.LocalFolder.CreateFileAsync(DatabaseName, CreationCollisionOption.OpenIfExists);
            string dbpath = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName);
            using(SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                var tableCommand = "CREATE TABLE IF NOT EXISTS contact(name NVARCHAR(255) NULL, " +
                    "phone_number VARCHAR(20) PRIMARY KEY";
                SqliteCommand createTable = new SqliteCommand(tableCommand, db);
                createTable.ExecuteReader();
            }
        }
    }
}
