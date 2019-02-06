using System;
using AppLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TaskSetUnitTest
{
    [TestClass]
    public class TaskSetTest
    {
        [TestMethod]
        public void PropertiesTest()
        {
            //arrange
            long task_set_id = 1;
            string task_set_name = "Task1";

            //act
            TaskSet taskSet = new TaskSet();
            taskSet.TaskSetId = task_set_id;
            taskSet.TaskSetName = task_set_name;

            //assert
            Assert.AreEqual(task_set_id, taskSet.TaskSetId, "taskSetId incompatibility");
            Assert.AreEqual(task_set_name, taskSet.TaskSetName, "taskSetName incompatibility");
        }
    }
}
