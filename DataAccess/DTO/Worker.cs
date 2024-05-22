using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class Worker
    {
        
        [Key]public int WorkerID { set; get; }
        public string WorkerName { set; get; }
        public string Process { set; get; }
        public string ProcessName { set; get; }
        public int Qty { set; get; }
        public decimal Price { set; get; }
    }
}
