using System;
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
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT TaskSetName FROM TasksSet", LoadConnectionString());
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
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT TaskSetName FROM TasksSet", LoadConnectionString());
                ad.Fill(dt);
                //
                List<string> TitlesList = new List<string>(dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    TitlesList.Add((string)row["TaskSetName"]);
                    
                }
                return TitlesList;
            }
        }
        public static List<string> RerurnTaskHeadersListGeneral(
            string Quantifier,
            string TableSetName
            )
        {
            string _TableSetName = TableSetName;
            string _Quantifier = Quantifier;

            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //set the passed query
                string strbuild = "Select " + _Quantifier + " from " + _TableSetName;
                SQLiteDataAdapter ad = new SQLiteDataAdapter(strbuild, LoadConnectionString());
                ad.Fill(dt);
                //
                List<string> SetsList = new List<string>(dt.Rows.Count);
                foreach (DataRow row in dt.Rows)
                {
                    SetsList.Add((string)row["TaskSetName"]);

                }
                return SetsList;
            }
        }
        public static DataTable DisplaySelectedRow(string txt)
        {
            DataTable dt = new DataTable();
            //using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string TaskName = txt;
                string strbuild = "Select TaskName from Tasks AS t INNER JOIN TasksSet AS ts ON t.TaskSetId = ts.TaskSetId where TaskSetName = '" + TaskName + "' ORDER BY Ordr";

                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn);
               
                ad.Fill(dt);
                return dt;
            }

        }

        public static DataTable PopulateListView(string txt)
        {
            DataTable dt = new DataTable();
            
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string TaskName = txt;
                string strbuild = "Select TaskName from Tasks AS t INNER JOIN TasksSet AS ts ON t.TaskSetId = ts.TaskSetId where TaskSetName = '" + TaskName + "' ORDER BY Ordr";

                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn);
                /*
                string[] words = text.Split(' ');
                _FirstName = words[0];
                _LastName = words[1];
                */
                ad.Fill(dt);
                return dt;
            }

        }
        /// <summary> Method to retrive data from SQLite row, extract it to custom Object <summary>
        public static TaskSet SelectedRowToTaskSetModel(string Quantifier, string TableName, string SearchedValue, string TaskSetName)
        {
            //Create DataTable
            DataTable dt1 = new DataTable();
            using (SQLiteConnection cnn1 = new SQLiteConnection(LoadConnectionString()))
            {

                //Open connection
                cnn1.Open();
                //pass the strings from method
                string _Quantifier = Quantifier;
                string _TableName = TableName;
                string _TaskSetName = TaskSetName;
                string _SearchedValue = SearchedValue;
                //build string                
                string strbuild = "Select "
                    + _Quantifier + " from "
                    + _TableName + " where "
                    + _SearchedValue + "= '"
                    + _TaskSetName + "' ";
                //Create new adapter for sqlite connection
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                //set the passed query
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn1);
                //pass result to datatable
                ad.Fill(dt1);
                //build object of class.
                TaskSet taskset = new TaskSet();
                //Convert DT to DR for easier datahndling
                DataRow dr = dt1.Rows[0];
                //get and pass values to local class instance
                //statically
                taskset.TaskSetId = (long)dr[0];
                taskset.TaskSetName = (string)dr[1];

                //return filled model
                return taskset;
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
