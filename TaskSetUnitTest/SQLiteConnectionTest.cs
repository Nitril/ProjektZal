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
using System.Threading;

namespace TasksModelUnitTest


{
    /// <summary> 
    /// Class containing unit testing for methods responsible for  database connection and displaying main window.
    /// </summary>
    [TestClass]
    public class SQLiteConnectionTest
    {
        /// <summary> 
        /// Method used to test connection to Database and check if it can retrieve recipe name using method RerurnTaskHeadersList
        /// </summary>
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase4()
        {

            
            List<string> dt = SqliteDataAccess.RerurnTaskHeadersList();

            
            string field = dt[0].ToString();

            
            Assert.AreEqual(field, "Kotlet schabowy");

        }


        /// <summary> 
        /// Method used to test connection to Database and check if it can retrieve task from selected recipe name using method DisplaySelectedRow
        /// </summary>
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase6()
        {

            string z = "Kotlet schabowy";
            DataTable dt = SqliteDataAccess.DisplaySelectedRow(z);


            string field = dt.Rows[0][0].ToString();
            Assert.AreEqual(field, "Mięso na schabowe");

        }



        /// <summary> 
        /// Method used to test connection to Database and check if it can retrieve task descriptions basing on selected meal task name using method DisplayTaskDescriptions
        /// </summary>
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase7()
        {

            DataTable dt = SqliteDataAccess.DisplayTaskDescriptions("Mięso na schabowe");

            string field = dt.Rows[0][0].ToString().Substring(0,9);
            Assert.AreEqual(field, "Przygotuj");

        }

        /// <summary> 
        /// Test if main window is displayed
        /// </summary>
        [TestMethod]
        public void Test_window()
        {
            var showMonitor = new ManualResetEventSlim(false);
            var closeMonitor = new ManualResetEventSlim(false);

            Thread th = new Thread(new ThreadStart(delegate
            {
                var mw = new MainWindow();
                mw.Show();

                showMonitor.Set();
                closeMonitor.Wait(1);
            }));

            th.ApartmentState = ApartmentState.STA;
            th.Start();

            showMonitor.Wait(1);
            Task.Delay(1000).Wait(1);
            
            closeMonitor.Set();
        }
        /// <summary> 
        /// Testing if DT conversion to string is working properly.
        /// </summary>
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConvertingDTtoString()
        {
            string z = "Kotlet schabowy";
            DataTable dt = SqliteDataAccess.DisplaySelectedRow(z);            
            string chk = SqliteDataAccess.convertDataTableToString(dt);
            string chk1 = "Mięso na schabowe Przygotowanie panierki Smażenie mięsa Gotowanie ziemniaków Podanie schabowych ";
            Assert.AreEqual(chk, chk1);
        }

    }


}
