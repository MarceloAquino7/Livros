using System;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace ProjetoLivros.Infra.Data.DBsetup
{
    /// <summary>
    /// This class represents the configuration and the communication with the local database
    /// </summary>
    public class DBManager
    {
        SQLiteConnection dbConnection;
        SQLiteCommand command;
        string sqlCommand;
        readonly string dbPath = Environment.CurrentDirectory + "\\DB";
        string dbFilePath;

        /// <summary>
        /// Constructor where it creates the database, connection, tables and fill tables with default values.
        /// </summary>
        public DBManager()
        {
            CreateDbFile();
            CreateDbConnection();
            CreateTables();
            FillTables();
        }

        /// <summary>
        /// Create the database file
        /// </summary>
        public void CreateDbFile()
        {
            if (!string.IsNullOrEmpty(dbPath) && !Directory.Exists(dbPath))
            {
                Directory.CreateDirectory(dbPath);
            }

            dbFilePath = dbPath + "\\MyDB.sqlite";
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
            }
        }

        /// <summary>
        /// Create the database connection
        /// </summary>
        /// <returns></returns>
        public string CreateDbConnection()
        {
            string strCon = string.Format("Data Source={0};", dbFilePath);
            dbConnection = new SQLiteConnection(strCon);
            dbConnection.Open();
            command = dbConnection.CreateCommand();
            return strCon;
        }

        /// <summary>
        /// Create the tables
        /// </summary>
        public void CreateTables()
        {

            if (!CheckIfExist(Tables.Book.ToString()))
            {
                sqlCommand = string.Format(@"
                    CREATE TABLE {0} (
                        BookId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT not null,
                        Author TEXT not null,
                        PublisherName TEXT not null,
                        Price REAL not null
                    )
                ", Tables.Book);
                ExecuteQuery(sqlCommand);
            }
        }

        /// <summary>
        /// Check if a table exists
        /// </summary>
        /// <param name="tableName">Table name for check if exists</param>
        /// <returns>True if table exists, false if it doesn't</returns>
        public bool CheckIfExist(string tableName)
        {
            command.CommandText = "SELECT name FROM sqlite_master WHERE name='" + tableName + "'";
            var result = command.ExecuteScalar();

            return result != null && result.ToString() == tableName ? true : false;
        }

        /// <summary>
        /// Execute a query on the database
        /// </summary>
        /// <param name="sqlQuery">Query to be executed</param>
        /// <returns>SQLiteDataReader containing the results</returns>
        public SQLiteDataReader ExecuteQuery(string sqlQuery)
        {
            SQLiteCommand triggerCommand = dbConnection.CreateCommand();
            triggerCommand.CommandText = sqlQuery;
            return triggerCommand.ExecuteReader();
        }

        /// <summary>
        /// Execute a non-query sql command
        /// </summary>
        /// <param name="sqlCommand">Command to be executed</param>
        public void ExecuteNonQuery(string sqlCommand)
        {
            SQLiteCommand triggerCommand = dbConnection.CreateCommand();
            triggerCommand.CommandText = sqlCommand;
            triggerCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Check if a table contains data
        /// </summary>
        /// <param name="tableName">Table name to be searched</param>
        /// <returns></returns>
        public bool CheckIfTableContainsData(string tableName)
        {
            command.CommandText = "SELECT count(*) FROM " + tableName;
            var result = command.ExecuteScalar();

            return Convert.ToInt32(result) > 0 ? true : false;
        }

        /// <summary>
        /// Fill tables with default values
        /// </summary>
        public void FillTables()
        {
            if (!CheckIfTableContainsData(Tables.Book.ToString()))
            {
                sqlCommand = string.Format(@"INSERT INTO {0} (Name, Author, PublisherName, Price) 
                        VALUES ('Book1', 'Author1', 'Publisher1', 120)", Tables.Book);
                ExecuteQuery(sqlCommand);
            }
        }
    }
}

