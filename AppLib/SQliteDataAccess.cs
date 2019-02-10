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
    
    /*
    The main database connection class
    Contains all methods for performing connection and retrieving data from database
    */
    public class SqliteDataAccess
    {

        /// <summary> 
        /// Used for connecting to database and load the content of database table from the query 
        /// </summary>
        /// <returns>
        /// The string list with the list of recipe names.
        /// </returns>
        public static List<string> RerurnTaskHeadersList()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter("SELECT TaskSetName FROM TasksSet", LoadConnectionString());
                ad.Fill(dt);
                //populate string list with recipies names
                List<string> TitlesList = new List<string>(dt.Rows.Count);

                //iterate through datarows in datatable and pass recipe name to string list
                foreach (DataRow row in dt.Rows)
                {
                    TitlesList.Add((string)row["TaskSetName"]);
                }
                return TitlesList;
            }
        }

        /// <summary> Used for connecting to database and load selected row on MealTaskList to DataTable variable </summary>
        /// <returns>
        /// Populated datatable with meal tasks - main steps required to acomplish for each recipe. 
        /// </returns>
        public static DataTable DisplaySelectedRow(string txt)
        {
            DataTable dt = new DataTable();
            //establish connection using connection string returned from LoadConnectionString method
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                
                string TaskName = txt;
                //string with database query 
                string strbuild = "Select TaskName from Tasks AS t INNER JOIN TasksSet AS ts ON t.TaskSetId = ts.TaskSetId where TaskSetName = '" + TaskName + "' ORDER BY Ordr";

                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn);
               //populate and return as datatable
                ad.Fill(dt);
                return dt;
            }

        }

        /// <summary> Used for connecting to database and load detail task for selected MealTask to DataTable variable</summary>
        /// <returns>
        /// Populated datatable with meal task description description for specified meal task. 
        /// </returns>
        public static DataTable DisplayTaskDescriptions(string TaskName)
        {
            DataTable dt = new DataTable();
            //establish connection using connection string returned from LoadConnectionString method
            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //string with database query 
                string strbuild = "Select TaskDescription from Tasks where TaskName = '" + TaskName + "' ORDER BY Ordr";
                //set the passed query
                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn);
                //populate and return datatable
                ad.Fill(dt);
                return dt;
            }
        }
        /// <summary> Convert datatable to string for reading </summary>
        /// /// <returns>
        /// Converted string 
        /// </returns>
        public static string convertDataTableToString(DataTable dataTable)
        {
            string data = string.Empty;
            int rowsCount = dataTable.Rows.Count;
            for (int i = 0; i < rowsCount; i++)
            {
                DataRow row = dataTable.Rows[i];
                data += row[0].ToString();
                data += " ";
            }
            return data;
        }
        /// <summary> Load connection string from configuration manager App.Config file with id="Default" </summary>
        /// <returns>
        /// connection string used to connecting with SQLite database 
        /// </returns>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
