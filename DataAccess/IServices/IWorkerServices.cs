using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IServices
{
    public interface IWorkerServices
    {
        public ReturnData AddWorker(Worker worker);
        public ReturnData UpdateWorker(Worker worker);
        public ReturnData DeleteWorker(int workerID);
        public ReturndataReturnListWorker SearchWorker(string context);
        public void ReportWorker();
    }
}
