#region License

//*********************************License***************************************
//===============================================================================
//The MIT License (MIT)

//Copyright (c) 2016 FRC_Scouting_V2

//Permission is hereby granted, free of charge, to any person obtaining a copy
//of this software and associated documentation files (the "Software"), to deal
//in the Software without restriction, including without limitation the rights
//to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//copies of the Software, and to permit persons to whom the Software is
//furnished to do so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===============================================================================

#endregion

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;
using UsefulSnippets;

namespace FRC_Scouting_V2
{
    public class MySQLMethods
    {
        public static int GetNumberOfRowsInATable()
        {
            var numberOfRows = 0;
            try
            {
                var mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM " + Program.selectedEventName, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
            return numberOfRows;
        }

        public static int GetNumberOfRowsThatContainAValue(int teamNumber)
        {
            var numberOfRows = 0;
            try
            {
                var mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection {ConnectionString = mySqlConnectionString};

                var mySQLCommantText = string.Format("SELECT COUNT(*) FROM {0} WHERE TeamNumber={1}",
                    Program.selectedEventName, teamNumber);
                using (var cmd = new MySqlCommand(mySQLCommantText, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
            return numberOfRows;
        }

        public static string MakeMySqlConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder["Server"] = Settings.Default.mySqlDatabaseIP;
            builder["Database"] = Settings.Default.mySqlDatabaseName;
            builder["Port"] = Settings.Default.mySqlDatabasePort;
            builder["Uid"] = Settings.Default.mySqlDatabaseUsername;
            builder["Password"] = Security.DeCryptString(Settings.Default.mySqlDatabasePassword);
            builder.SslMode = MySqlSslMode.Preferred;
            return builder.ConnectionString;
        }

        [SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities")]
        public static void InitializeDatabases()
        {
            try
            {
                var conn = new MySqlConnection(MakeMySqlConnectionString());
                conn.Open();
                var cmd = new MySqlCommand {Connection = conn};
                var commands = Globals.mySQLTableCreationCommands;

                for (var i = 0; i < commands.Count; i++)
                {
                    try
                    {
                        cmd.CommandText = commands[i];
                        cmd.ExecuteNonQuery();
                        var numDone = i + 1;
                        ConsoleWindow.WriteLine("Successfully initialized: " + numDone + " of " + commands.Count);
                    }
                    catch (MySqlException error)
                    {
                        ConsoleWindow.WriteLine("Error Code: " + error.ErrorCode);
                        ConsoleWindow.WriteLine(error.Message);
                    }
                }
                conn.Close();

                //SQLiteConnection.CreateFile("database.sqlite");
                //var m_dbConnection = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
                //m_dbConnection.Open();
                //string sql = "CREATE TABLE RecycleRush_NorthBay_Teams (name VARCHAR(300), teamNumber INT)";
                //var command = new SQLiteCommand(sql, m_dbConnection);
                //command.ExecuteNonQuery();
                //m_dbConnection.Close();
                //ConsoleWindow.WriteLine("Team List Database Successfully Initialized");
            }
            catch (MySqlException ex)
            {
                ConsoleWindow.WriteLine("Error Code: " + ex.ErrorCode);
                ConsoleWindow.WriteLine(ex.Message);
            }
        }
    }
}