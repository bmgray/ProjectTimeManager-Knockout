using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dapper_Model_Classes
{
    public class TimeLog
    {
        public int Id { get; set; }
        public int Employee_EmployeeId { get; set; }
        public int Project_ProjectId { get; set; }
        public string LogDescription { get; set; }
        public TimeSpan LogStartTime { get; set; }
        public TimeSpan LogEndTime { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
