using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppLib
{

    /// <summary>
    /// TasksModel class is model class to having the class representation of Tasks table with recipe steps
    /// </summary>
    public class TasksModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string TaskSetId { get; set; }

        public string Ordr { get; set; }
    }

}
