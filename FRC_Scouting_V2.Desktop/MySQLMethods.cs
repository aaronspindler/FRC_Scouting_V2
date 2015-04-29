using System;
using System.Collections.Generic;
using System.Data.SQLite;
using FRC_Scouting_V2.Properties;
using MySql.Data.MySqlClient;

namespace FRC_Scouting_V2
{
    public class MySQLMethods
    {
        public static int GetNumberOfRowsInATable()
        {
            int numberOfRows = 0;
            try
            {
                string mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM " + Program.selectedEventName, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    cmd.Dispose();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem(ex.Message);
            }
            return numberOfRows;
        }

        public static int GetNumberOfRowsThatContainAValue(int teamNumber)
        {
            int numberOfRows = 0;
            try
            {
                string mySqlConnectionString = MakeMySqlConnectionString();
                var conn = new MySqlConnection { ConnectionString = mySqlConnectionString };

                string mySQLCommantText = String.Format("SELECT COUNT(*) FROM {0} WHERE TeamNumber={1}", Program.selectedEventName, teamNumber);
                using (var cmd = new MySqlCommand(mySQLCommantText, conn))
                {
                    conn.Open();
                    numberOfRows = int.Parse(cmd.ExecuteScalar().ToString());
                    conn.Close();
                    cmd.Dispose();
                    return numberOfRows;
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
            }
            return numberOfRows;
        }

        public static string MakeMySqlConnectionString()
        {
            var builder = new MySqlConnectionStringBuilder();
            builder["Server"] = Settings.Default.databaseIP;
            builder["Database"] = Settings.Default.databaseName;
            builder["Port"] = Settings.Default.databasePort;
            builder["Uid"] = Settings.Default.databaseUsername;
            builder["Password"] = UsefulSnippets.Security.DeCryptString(Settings.Default.databasePassword);
            builder.SslMode = MySqlSslMode.Preferred;
            return builder.ConnectionString;
        }

        public static void InitializeDatabases()
        {
            try
            {
                var conn = new MySqlConnection(MakeMySqlConnectionString());
                conn.Open();
                var cmd = new MySqlCommand { Connection = conn };
                var commands = new List<string>
                {
                    "CREATE TABLE `AerialAssist_Northbay` (`EntryID` int(11) NOT NULL,`TeamName` varchar(45) NOT NULL DEFAULT 'Default', `TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamColour` varchar(45) NOT NULL DEFAULT 'Default',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighTally` int(11) NOT NULL DEFAULT '0',`AutoLowTally` int(11) NOT NULL DEFAULT '0',`ControlledHighTally` int(11) NOT NULL DEFAULT '0',`ControlledLowTally` int(11) NOT NULL DEFAULT '0',`HotGoalTally` int(11) NOT NULL DEFAULT '0',`AutoPickup` int(11) NOT NULL DEFAULT '0',`ControlledPickup` int(11) NOT NULL DEFAULT '0',`MissedPickups` int(11) NOT NULL DEFAULT '0',`StartingLocationX` int(11) NOT NULL DEFAULT '0',`StartingLocationY` int(11) NOT NULL DEFAULT '0',`Comments` varchar(45) DEFAULT 'No Comment',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8",
                    "CREATE TABLE `AerialAssist_RahChaCha` (`EntryID` int(11) NOT NULL DEFAULT '0',`TeamNumber` int(11) NOT NULL DEFAULT '0',`TeamName` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Default',`TeamColour` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'Not Selected',`MatchNumber` int(11) NOT NULL DEFAULT '0',`AutoHighGoal` int(11) NOT NULL DEFAULT '0',`AutoHighMiss` int(11) NOT NULL DEFAULT '0',`AutoLowGoal` int(11) NOT NULL DEFAULT '0',`AutoLowMiss` int(11) NOT NULL DEFAULT '0',`ControlledHighGoal` int(11) NOT NULL DEFAULT '0',`ControlledHighMiss` int(11) NOT NULL DEFAULT '0',`ControlledLowGoal` int(11) NOT NULL DEFAULT '0',`ControlledLowMiss` int(11) NOT NULL DEFAULT '0',`HotGoals` int(11) NOT NULL DEFAULT '0',`HotGoalMiss` int(11) NOT NULL DEFAULT '0',`3AssistGoal` int(11) NOT NULL DEFAULT '0',`3AssistMiss` int(11) NOT NULL DEFAULT '0',`AutoBallPickup` int(11) NOT NULL DEFAULT '0',`AutoBallPickupMiss` int(11) NOT NULL DEFAULT '0',`ControlledBallPickup` int(11) NOT NULL DEFAULT '0',`ControlledBallPickupMiss` int(11) NOT NULL DEFAULT '0',`PickupFromHuman` int(11) NOT NULL DEFAULT '0',`MissedPickupFromHuman` int(11) NOT NULL DEFAULT '0',`PassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`MissedPassToAnotherRobot` int(11) NOT NULL DEFAULT '0',`SuccessfulTruss` int(11) NOT NULL DEFAULT '0',`UnsuccessfulTruss` int(11) NOT NULL DEFAULT '0',`StartingX` int(11) NOT NULL DEFAULT '0',`StartingY` int(11) NOT NULL DEFAULT '0',`DidRobotDie` tinyint(4) NOT NULL DEFAULT '0',`DriverRating` int(11) NOT NULL DEFAULT '0',`AutoMovement` tinyint(4) NOT NULL DEFAULT '0',`Comments` varchar(300) COLLATE utf8_unicode_ci DEFAULT NULL,PRIMARY KEY (`EntryID`)) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci",
                    "CREATE TABLE `RecycleRush_GTR_East_Matches` (`EntryID` int(11) NOT NULL AUTO_INCREMENT,`UniqueID` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Author` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`TimeCreated` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Team_Number` int(11) NOT NULL,`Team_Name` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Match_Number` int(11) NOT NULL,`Alliance_Colour` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Robot_Dead` tinyint(4) NOT NULL,`Auto_Starting_X` int(11) NOT NULL,`Auto_Starting_Y` int(11) NOT NULL,`Auto_Drive_To_Autozone` tinyint(4) NOT NULL,`Auto_Robot_Set` tinyint(4) NOT NULL,`Auto_Tote_Set` tinyint(4) NOT NULL,`Auto_Bin_Set` tinyint(4) NOT NULL,`Auto_Stacked_Tote_Set` tinyint(4) NOT NULL,`Auto_Acquired_Step_Bins` int(11) NOT NULL,`Auto_Fouls` int(11) NOT NULL,`Auto_Did_Nothing` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Upright` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Upside_Down` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Sideways` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Upright` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Upside_Down` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Sideways` tinyint(4) NOT NULL,`Tele_Human_Station_Load_Totes` tinyint(4) NOT NULL,`Tele_Human_Station_Stack_Totes` tinyint(4) NOT NULL,`Tele_Human_Station_Insert_Litter` tinyint(4) NOT NULL,`Tele_Human_Throwing_Litter` tinyint(4) NOT NULL,`Tele_Pushed_Litter_To_Landfill` tinyint(4) NOT NULL,`Tele_Fouls` int(11) NOT NULL,`Comments` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Stacks` varchar(5000) COLLATE utf8_unicode_ci NOT NULL,`Coopertition_Set` tinyint(4) NOT NULL,`Coopertition_Stack` tinyint(4) NOT NULL,`Final_Score_Red` int(11) NOT NULL,`Final_Score_Blue` int(11) NOT NULL,`Driver_Rating` int(11) NOT NULL,PRIMARY KEY (`EntryID`),UNIQUE KEY `EntryID_UNIQUE` (`EntryID`),UNIQUE KEY `UniqueID_UNIQUE` (`UniqueID`)) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;",
                    "CREATE TABLE `RecycleRush_Northbay_Matches` (`EntryID` int(11) NOT NULL AUTO_INCREMENT,`UniqueID` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Author` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`TimeCreated` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Team_Number` int(11) NOT NULL,`Team_Name` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Match_Number` int(11) NOT NULL,`Alliance_Colour` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Robot_Dead` tinyint(4) NOT NULL,`Auto_Starting_X` int(11) NOT NULL,`Auto_Starting_Y` int(11) NOT NULL,`Auto_Drive_To_Autozone` tinyint(4) NOT NULL,`Auto_Robot_Set` tinyint(4) NOT NULL,`Auto_Tote_Set` tinyint(4) NOT NULL,`Auto_Bin_Set` tinyint(4) NOT NULL,`Auto_Stacked_Tote_Set` tinyint(4) NOT NULL,`Auto_Acquired_Step_Bins` int(11) NOT NULL,`Auto_Fouls` int(11) NOT NULL,`Auto_Did_Nothing` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Upright` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Upside_Down` tinyint(4) NOT NULL,`Tele_Tote_Pickup_Sideways` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Upright` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Upside_Down` tinyint(4) NOT NULL,`Tele_Bin_Pickup_Sideways` tinyint(4) NOT NULL,`Tele_Human_Station_Load_Totes` tinyint(4) NOT NULL,`Tele_Human_Station_Stack_Totes` tinyint(4) NOT NULL,`Tele_Human_Station_Insert_Litter` tinyint(4) NOT NULL,`Tele_Human_Throwing_Litter` tinyint(4) NOT NULL,`Tele_Pushed_Litter_To_Landfill` tinyint(4) NOT NULL,`Tele_Fouls` int(11) NOT NULL,`Comments` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Stacks` varchar(5000) COLLATE utf8_unicode_ci NOT NULL,`Coopertition_Set` tinyint(4) NOT NULL,`Coopertition_Stack` tinyint(4) NOT NULL,`Final_Score_Red` int(11) NOT NULL,`Final_Score_Blue` int(11) NOT NULL,`Driver_Rating` int(11) NOT NULL,PRIMARY KEY (`EntryID`),UNIQUE KEY `EntryID_UNIQUE` (`EntryID`),UNIQUE KEY `UniqueID_UNIQUE` (`UniqueID`)) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;",
                    "CREATE TABLE `RecycleRush_Northbay_Pits` (`UniqueID` varchar(200) COLLATE utf8_unicode_ci NOT NULL,`Author` varchar(500) COLLATE utf8_unicode_ci NOT NULL,`Time_Created` varchar(500) COLLATE utf8_unicode_ci NOT NULL,`Team_Number` int(11) NOT NULL,`Team_Name` varchar(500) COLLATE utf8_unicode_ci NOT NULL,`Drive_Train` varchar(500) COLLATE utf8_unicode_ci DEFAULT NULL,`Number_Of_Robots` int(11) DEFAULT NULL,`Can_It_Manipulate_Totes` tinyint(4) DEFAULT NULL,`Can_It_Manipulate_Bins` tinyint(4) DEFAULT NULL,`Can_It_Manipulate_Litter` tinyint(4) DEFAULT NULL,`Needs_Special_Starting_Position` tinyint(4) DEFAULT NULL,`Special_Starting_Position` varchar(500) COLLATE utf8_unicode_ci DEFAULT NULL,`Max_Stack_Height` int(11) DEFAULT NULL,`Max_Bin_On_Stack_Height` int(11) DEFAULT NULL,`Human_Tote_Loading` tinyint(4) DEFAULT NULL,`Human_Litter_Loading` tinyint(4) DEFAULT NULL,`Human_Litter_Throwing` tinyint(4) DEFAULT NULL,`Does_It_have_A_Ramp` tinyint(4) DEFAULT NULL,`Comments` varchar(500) COLLATE utf8_unicode_ci DEFAULT NULL,`Front_Picture` longblob,`Left_Side_Picture` longblob,`Left_Isometric_Picture` longblob,`Other_Picture` longblob,PRIMARY KEY (`UniqueID`),UNIQUE KEY `EntryID_UNIQUE` (`EntryID`),UNIQUE KEY `UniqueID_UNIQUE` (`UniqueID`)) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;"
                };

                for (int i = 0; i < commands.Count; i++)
                {
                    try
                    {
                        cmd.CommandText = commands[i];
                        cmd.ExecuteNonQuery();
                        int numDone = i + 1;
                        Console.WriteLine("Successfully initialized: " + numDone + " of " + commands.Count);
                        ConsoleWindow.AddItem("Successfully initialized: " + numDone + " of " + commands.Count);
                    }
                    catch (MySqlException error)
                    {
                        Console.WriteLine("Error Code: " + error.ErrorCode);
                        Console.WriteLine(error.Message);
                        ConsoleWindow.AddItem("Error Code: " + error.ErrorCode);
                        ConsoleWindow.AddItem(error.Message);
                    }
                }
                conn.Close();

                SQLiteConnection.CreateFile("database.sqlite");
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=database.sqlite;Version=3;");
                m_dbConnection.Open();
                var sql = "CREATE TABLE RecycleRush_NorthBay_Teams (name VARCHAR(300), teamNumber INT)";
                var command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
                m_dbConnection.Close();
                Console.WriteLine("Team List Database Successfully Initialized");
                ConsoleWindow.AddItem("Team List Database Successfully Initialized");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error Code: " + ex.ErrorCode);
                Console.WriteLine(ex.Message);
                ConsoleWindow.AddItem("Error Code: " + ex.ErrorCode);
                ConsoleWindow.AddItem(ex.Message);
            }
        }
    }
}
