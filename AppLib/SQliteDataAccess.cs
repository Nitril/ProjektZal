﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLib;



namespace AppLib
{
    public class SqliteDataAccess
    {

        /// <summary> Used for connecting to database and load the content of table from the query <summary>
        public static DataTable LoadTasks()  // List<TasksModel>
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                              



                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT * FROM Tasks",LoadConnectionString());
                ad.Fill(dt);

                //ar output = cnn.Query<TasksModel>("select * from tasks", new DynamicParameters());
                return dt;
            }
        }

        public static DataTable LoadMainTasks()  // List<TasksModel>
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT TaskName FROM Tasks", LoadConnectionString());
                ad.Fill(dt);

                //ar output = cnn.Query<TasksModel>("select * from tasks", new DynamicParameters());
                return dt;
            }
        }
        public static List<string> RerurnTaskHeadersList()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT TaskName FROM Tasks", LoadConnectionString());
                ad.Fill(dt);
                //
                List<string> TitlesList = new List<string>(dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    TitlesList.Add((string)row["TaskName"]);
                    
                }
                return TitlesList;
            }
            /*
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query             // <PersonModel>("select * from Person", new DynamicParameters());
                return output.ToList();
            }
            List<int> ids = new List<int>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                ids.Add((int)row["id"]);
                */
        }

        /// <summary> Method to save data into database. In progress<summary>
       /*public static void SaveTask(TasksModel person)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                //cnn.Execute("", taskname)
            }

        }*/


        // <summary> Load connection string from configuration manager with id="Default" <summary>
        private static string LoadConnectionString(string id = "Default")    //(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;

        }

    }
}
