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

        /// <summary> Used for connecting to database and load selected row on MealTaskList to DataTable variable <summary>
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

        /// <summary> Used for connecting to database and load detail task for selected MealTask to DataTable variable<summary>
        public static DataTable DisplayTaskDescriptions(string TaskName)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string strbuild = "Select TaskDescription from Tasks where TaskName = '" + TaskName + "' ORDER BY Ordr";

                SQLiteDataAdapter ad = new SQLiteDataAdapter();
                ad.SelectCommand = new SQLiteCommand(strbuild, cnn);

                ad.Fill(dt);
                return dt;
            }
        }

        // <summary> Load connection string from configuration manager with id="Default" <summary>
        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
