using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLib;
using AppUI;


namespace TasksModelUnitTest

/*
 * RerurnTaskHeadersList()
 * DisplaySelectedRow(string txt)
 * DisplayTaskDescriptions(string TaskName)
 */
{
    [TestClass]
    public class SQLiteConnectionTest
    {
        //[TestMethod]
        //[DeploymentItem("Tasks.db")]
        //public void TestConnectionToDatabase()
        //{

        //    DataTable dt = SqliteDataAccess.LoadTasks();


        //    string field = dt.Rows[0][0].ToString();
        //    Assert.AreEqual(field, "1");

        //}

        //[TestMethod]
        //[DeploymentItem("Tasks.db")]
        //public void TestConnectionToDatabase2()
        //{


        //    DataTable dt = SqliteDataAccess.LoadMainTasks();


        //    string field = dt.Rows[0][0].ToString();
        //    Assert.AreEqual(field, "Smoothie");

        //}

        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase4()
        {


            List<string> dt = SqliteDataAccess.RerurnTaskHeadersList();


            string field = dt[0].ToString();
            Assert.AreEqual(field, "Smoothie");

        }


        //[TestMethod]
        //[DeploymentItem("Tasks.db")]
        //public void TestConnectionToDatabase5()
        //{


        //    List<string> dt = SqliteDataAccess.RerurnTaskHeadersListGeneral("TaskSetName", "TasksSet");


        //    string field = dt[0].ToString();
        //    Assert.AreEqual(field, "Smoothie");

        //}

        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase6()
        {


            DataTable dt = SqliteDataAccess.DisplaySelectedRow("Smoothie");


            string field = dt.Rows[0][0].ToString();
            Assert.AreEqual(field, "TestTask1");

        }


        //[TestMethod]
        //[DeploymentItem("Tasks.db")]
        //public void TestConnectionToDatabase7()
        //{


        //    DataTable dt = SqliteDataAccess.PopulateListView("Smoothie");


        //    string field = dt.Rows[0][0].ToString();
        //    Assert.AreEqual(field, "TestTask1");

        //}

        /*
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase8()
        {


            TaskSet taskset = SqliteDataAccess.SelectedRowToTaskSetModel("TaskSetId", "TasksSet", "TaskSetName", "Smoothie");


            long value = taskset.TaskSetId;
            Assert.AreEqual(value, 2);

        }
        */
        

        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase7()
        {

            DataTable dt = SqliteDataAccess.DisplayTaskDescriptions("Przygotuj wszystkie składniki");

            string field = dt.Rows[0][0].ToString();
            Assert.AreEqual(field, "SmothieTestDescription2", "returned values incompatibility");

        }
    }
}
