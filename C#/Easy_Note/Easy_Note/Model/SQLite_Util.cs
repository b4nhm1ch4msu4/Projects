using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy_Note.Model
{
    public class SQLite_Util
    {
        public SQLiteConnection sqlite_conn { get; set; }
        string filePath = "F:\\Mike\\studySource\\Learning_Project\\Easy_Note\\Easy_Note\\DataBase\\test.db";
        /// <summary>
        /// Connect to database
        /// </summary>
        /// <returns>SQLiteConnection</returns>
        void ConnectDB()
        {
            String Connection_String = string.Format("DataSource={0};Version=3;", filePath);
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection(Connection_String);
        }
        /// <summary>
        /// Get data from sqlite connection
        /// </summary>
        public ObservableCollection<Note> ReadData()
        {
            ObservableCollection<Note> Data = new ObservableCollection<Note>();
            ConnectDB();
            try
            {
                using (sqlite_conn)
                {
                    sqlite_conn.Open();
                    SQLiteDataReader sqlite_datareader;
                    SQLiteCommand command = sqlite_conn.CreateCommand();
                    command.CommandText = "SELECT Title, Content FROM notes";

                    sqlite_datareader = command.ExecuteReader();
                    while (sqlite_datareader.Read())
                    {
                        string Title = sqlite_datareader.GetString(0);
                        string Content = sqlite_datareader.GetString(1);
                        Data.Add(new Note(Title, Content));
                    }
                }
            }catch (Exception ex) { }
            
            return Data;
        }

        void CreateData() { }
        public void AddData(Note item) {
            ConnectDB();
            try
            {
                using (sqlite_conn)
                {
                    sqlite_conn.Open();
                    SQLiteCommand command = sqlite_conn.CreateCommand();
                    command.CommandText = string.Format("INSERT INTO notes VALUES ('{0}','{1}');", item.Title, item.Content);
                    command.ExecuteNonQuery();
                }
            }catch (Exception ex)
            {

            }
            
            
        }
        public void DeleteData(string Title) {
            ConnectDB();
            try
            {
                using (sqlite_conn)
                {
                    sqlite_conn.Open();
                    SQLiteCommand command = sqlite_conn.CreateCommand();
                    command.CommandText = string.Format("DELETE FROM notes WHERE Title = '{0}';", Title);
                    command.ExecuteNonQuery();
                }
            }catch(Exception ex) { }
            
            
        }
    }
}
