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

/*
 * RerurnTaskHeadersList()
 * DisplaySelectedRow(string txt)
 * DisplayTaskDescriptions(string TaskName)
 */
{
    [TestClass]
    public class SQLiteConnectionTest
    {
        
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase4()
        {


            List<string> dt = SqliteDataAccess.RerurnTaskHeadersList();


            string field = dt[0].ToString();
            Assert.AreEqual(field, "Smoothie");

        }


        
        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase6()
        {

            string z = "Smoothie";            DataTable dt = SqliteDataAccess.DisplaySelectedRow(z);


            string field = dt.Rows[0][0].ToString();
            Assert.AreEqual(field, "Kup i umyj owoce");

        }


               

        [TestMethod]
        [DeploymentItem("Tasks.db")]
        public void TestConnectionToDatabase7()
        {

            DataTable dt = SqliteDataAccess.DisplayTaskDescriptions("Przygotuj wszystkie składniki");

            string field = dt.Rows[0][0].ToString();
            Assert.AreEqual(field, "SmothieTestDescription2", "returned values incompatibility");

        }

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
                closeMonitor.Wait();
            }));

            th.ApartmentState = ApartmentState.STA;
            th.Start();

            showMonitor.Wait(1);
            Task.Delay(1000).Wait();
            
            closeMonitor.Set();
        }


    }


}
