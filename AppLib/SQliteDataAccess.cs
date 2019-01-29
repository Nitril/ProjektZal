﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                SQLiteDataAdapter ad = new SQLiteDataAdapter($"SELECT * FROM {zmienna}");
                ad.Fill(dt);

                //ar output = cnn.Query<TasksModel>("select * from tasks", new DynamicParameters());
                return dt;
            }
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
