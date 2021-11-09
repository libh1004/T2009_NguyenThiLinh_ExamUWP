using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T2009_NguyenThiLinh_ExamUWP.Entity;
using Windows.Storage;

namespace T2009_NguyenThiLinh_ExamUWP.Model
{
    public class ContactModel
    {
        public bool Save(Contact contact)
        {
            string dbpath =
                Path.Combine(ApplicationData.Current.LocalFolder.Path, DataAccess.DatabaseName);
            using(SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand insertCommand = new SqliteCommand();
                insertCommand.Connection = db;
                insertCommand.CommandText = "INSERT INTO contact(name, phone_number) VALUES(@name, @phoneNumber)";
                insertCommand.Parameters.AddWithValue("@name", contact.Name);
                insertCommand.Parameters.AddWithValue("@phoneNumber", contact.PhoneNumber);
                insertCommand.ExecuteReader();
            }
            return false;
        }
        public List<Contact> FindAll()
        {
            List<Contact> listContact = new List<Contact>();
            string dbpath =
               Path.Combine(ApplicationData.Current.LocalFolder.Path, DataAccess.DatabaseName);
            using (SqliteConnection db = new SqliteConnection($"Filename={dbpath}"))
            {
                db.Open();
                SqliteCommand selectCommand = new SqliteCommand("SELECT * FROM contact", db);
                SqliteDataReader query = selectCommand.ExecuteReader();
                while (query.Read())
                {
                    var name = query.GetString(0);
                    var phoneNumber = query.GetString(1);
                    listContact.Add(new Contact
                    {
                        Name = name,
                        PhoneNumber = phoneNumber
                    });
                }
            }
            return listContact;
        }
    }
}
