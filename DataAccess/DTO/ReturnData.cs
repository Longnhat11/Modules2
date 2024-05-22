using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ReturnData
    {
        public int ReturnCode { get; set; }
        public string ReturnMsg { get; set; }
    }
    public class ReturnDataReturnWorker:ReturnData {
        public Worker Worker { get; set; }
    }
    public class ReturndataReturnListWorker:ReturnData
    {
        public List<Worker> ListWorker { get; set; }
    }
}
