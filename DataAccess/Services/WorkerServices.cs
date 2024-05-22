using DataAccess.DBcontext;
using DataAccess.DTO;
using DataAccess.IServices;
using Microsoft.EntityFrameworkCore;
using Module2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Services
{
    public class WorkerServices : IWorkerServices
    {
        private WorkerDBcontext _dbcontext = new WorkerDBcontext();
        
    public ReturnData AddWorker(Worker worker)
        {
            ReturnData result = new ReturnData();
            try
            {
                if (worker == null
                    ||worker.WorkerName==null
                    ||worker.Process==null
                    ||worker.Qty<=0
                    ||worker.Price<=0
                    ||worker.ProcessName==null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (checkInput.CheckIsNullOrWhiteSpace(worker.WorkerName) == true
                    || checkInput.ContainsNumber(worker.WorkerName) == true
                    || checkInput.CheckIsNullOrWhiteSpace(worker.ProcessName) == true
                    || checkInput.ContainsNumber(worker.ProcessName) == true
                    || checkInput.CheckIsNullOrWhiteSpace(worker.Process) == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (_dbcontext.Worker.Find(worker.WorkerID) != null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Công nhân vừa nhập đã có trên hệ thống!";
                    return result;
                }
                _dbcontext.Add(worker);
                _dbcontext.SaveChanges();
                result.ReturnCode = 1;
                result.ReturnMsg = "Thêm công nhân thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public ReturnData DeleteWorker(int workerID)
        {
            ReturnData result = new ReturnData();     
            try
            {
                if(workerID <= 0) {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (_dbcontext.Worker.Find(workerID) == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Không có công nhân có ID"+workerID;
                    return result;
                }
                var worker = _dbcontext.Worker.Find(workerID);
                _dbcontext.Worker.Remove(worker);
                _dbcontext.SaveChanges();
                result.ReturnCode = 1;
                result.ReturnMsg = "xóa công nhân thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public void ReportWorker()
        {
            //phần báo cáo khó xin phép a e đưa console vào phần này ạ!
            var report = _dbcontext.Worker
                            .GroupBy(w => w.WorkerName)
                            .Select(group => new
                            {
                                Workername = group.Key,
                                WorkerTotalQty = group.Sum(w=>w.Qty),
                                Total = group.Sum(w => w.Qty * w.Price)
                            }).ToList();
            foreach (var item in report)
            {
                Console.WriteLine($"Tên Công Nhân: {item.Workername}, Tổng Tiền: {item.Total}, Tổng số lượng đã làm{item.WorkerTotalQty}");
            }
            var TotalALL = report.ToList().Sum(t => t.Total);
                Console.WriteLine("tổng tiền tất cả công nhân: "+TotalALL);
            var TotalALLQty = report.ToList().Sum(t => t.WorkerTotalQty);
                Console.WriteLine("tổng số sản lượng công nhân đã làm: " + TotalALLQty);
        }

        public ReturndataReturnListWorker SearchWorker(string context)
        {
            ReturndataReturnListWorker result = new ReturndataReturnListWorker();
            try
            {
                if (context == null
                    ||checkInput.ContainsNumber(context)==true
                    ||checkInput.CheckIsNullOrWhiteSpace(context)==true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                var workers= _dbcontext.Worker.Where(w => w.WorkerName.Contains(context) || w.ProcessName.Contains(context))
                            .ToList();
                if (workers.Count == 0)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Không tìm thấy công nhân có tên hoặc công đoạn "+context;
                    return result;
                }
                result.ListWorker= workers;
                result.ReturnCode = 1;
                result.ReturnMsg = "Tìm danh sách công nhân thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }

        public ReturnData UpdateWorker(Worker worker)
        {
            ReturnData result = new ReturnData();
            try
            {
                if (worker == null
                    || worker.WorkerName == null
                    || worker.Process == null
                    || worker.Qty <= 0
                    || worker.Price <= 0
                    || worker.ProcessName == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (checkInput.CheckIsNullOrWhiteSpace(worker.WorkerName) == true
                    || checkInput.ContainsNumber(worker.WorkerName) == true
                    || checkInput.CheckIsNullOrWhiteSpace(worker.ProcessName) == true
                    || checkInput.ContainsNumber(worker.ProcessName) == true
                    || checkInput.CheckIsNullOrWhiteSpace(worker.Process) == true)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Dữ liệu vào không hợp lệ!";
                    return result;
                }
                if (_dbcontext.Worker.Find(worker.WorkerID) == null)
                {
                    result.ReturnCode = -1;
                    result.ReturnMsg = "Công nhân vừa nhập Không có trên hệ thống!";
                    return result;
                }
                _dbcontext.Update(worker);
                _dbcontext.SaveChanges();
                result.ReturnCode = 1;
                result.ReturnMsg = "Cập nhật thông tin công nhân thành công!";
                return result;
            }
            catch (Exception ex)
            {
                result.ReturnCode = -1;
                result.ReturnMsg = "Hệ thống đang bận:" + ex.Message;
                return result;
            }
        }
    }
}
