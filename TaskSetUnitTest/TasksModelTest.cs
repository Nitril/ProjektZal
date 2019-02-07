using System;
using AppLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TasksModelUnitTest
{
    [TestClass]
    public class TasksModelTest
    {
        [TestMethod]
        public void TasksModelPropertiesTest()
        {
            //arrange
            int tasks_model_id = 1;
            string tasks_model_name = "Task1";
            string tasks_model_description = "DescriptionTask1";
            string tasks_model_set_id = "2";
            string tasks_model_ordr = "1";

            //act
            TasksModel tasksModel = new TasksModel();

            tasksModel.TaskId = tasks_model_id;
            tasksModel.TaskName = tasks_model_name;
            tasksModel.TaskDescription = tasks_model_description;
            tasksModel.TaskSetId = tasks_model_set_id;
            tasksModel.Ordr = tasks_model_ordr;

            //assert
            Assert.AreEqual(tasks_model_id, tasksModel.TaskId, "TaskId incompatibility");
            Assert.AreEqual(tasks_model_name, tasksModel.TaskName, "TaskName incompatibility");
            Assert.AreEqual(tasks_model_description, tasksModel.TaskDescription, "TaskDescription incompatibility");
            Assert.AreEqual(tasks_model_set_id, tasksModel.TaskSetId, "TaskSetId incompatibility");
            Assert.AreEqual(tasks_model_ordr, tasksModel.Ordr, "Ordr incompatibility");
        }
    }
}
