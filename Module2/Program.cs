using DataAccess.DTO;
using DataAccess.Services;
Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.WriteLine("Chọn chức năng:");
Console.WriteLine("1. Thêm Công Nhân");
Console.WriteLine("2. Sửa thông tin  Công Nhân");
Console.WriteLine("3. Xóa Công Nhân");
Console.WriteLine("4. Tìm kiếm Công Nhân");
Console.WriteLine("5. Xuất báo cáo");
var option = Console.ReadLine();
WorkerServices workerServices = new WorkerServices();
Worker worker = new Worker();
switch (option)
{
     
    case "1":
        // Thêm  Công Nhân
        Console.WriteLine("Nhập tên Công nhân:");
        worker.WorkerName = Console.ReadLine();
        Console.WriteLine("Nhập mã công đoạn:");
        worker.Process = Console.ReadLine();
        Console.WriteLine("Nhập tên Công đoan:");
        worker.ProcessName = Console.ReadLine();
        Console.WriteLine("Nhập lương theo công đoạn:");
        worker.Price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhập số lượng công nhân đã làm:");
        worker.Qty = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(workerServices.AddWorker(worker).ReturnMsg);
        break;
    case "2":
        // Sửa thông tin Công Nhân
        Console.WriteLine("Nhập ID Công nhân!");
        worker.WorkerID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhập tên Công nhân:");
        worker.WorkerName = Console.ReadLine();
        Console.WriteLine("Nhập mã công đoạn:");
        worker.Process = Console.ReadLine();
        Console.WriteLine("Nhập tên Công đoan:");
        worker.ProcessName = Console.ReadLine();
        Console.WriteLine("Nhập lương theo công đoạn:");
        worker.Price = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhập số lượng công nhân đã làm:");
        worker.Qty = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(workerServices.UpdateWorker(worker).ReturnMsg);
        break;
    case "3":
        // Xóa  Công Nhân
        Console.WriteLine("Nhập ID Công nhân cần xóa!");
        int WrorkerID = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(workerServices.DeleteWorker(WrorkerID).ReturnMsg);
        break;
    case "4":
        // Tìm kiếm Công Nhân
        Console.WriteLine("Nhập tên công nhân hoặc tên công đoạn cần tìm!");
        string Findinput = Console.ReadLine();
        ReturndataReturnListWorker returndataReturnListWorker = new ReturndataReturnListWorker();
        returndataReturnListWorker = workerServices.SearchWorker(Findinput);
        Console.WriteLine(returndataReturnListWorker.ReturnMsg);
        if (returndataReturnListWorker.ListWorker == null) { break; }
        foreach (var item in returndataReturnListWorker.ListWorker)
        {
            Console.WriteLine("Tên Công Nhân "+item.WorkerName);
            Console.WriteLine("Tên Công đoạn " + item.ProcessName);
            Console.WriteLine("mã công đoạn " + item.Process);
            Console.WriteLine("lương theo công đoạn " + item.Price);
            Console.WriteLine("số lượng công nhân đã làm " + item.Qty);
        }
        break;
        
    case "5":
        // Xuất báo cáo
        workerServices.ReportWorker();
        break;
    default: Console.WriteLine("lựa chọn không hợp lệ!");
        break;
}