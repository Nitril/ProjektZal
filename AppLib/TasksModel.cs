using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AppLib
{
    public class TasksModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public string TaskSetId { get; set; }

        public string Ordr { get; set; }
    }

}
