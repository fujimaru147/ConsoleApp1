using System;
using System.Collections.Generic;

namespace AttendanceManagement
{
    public class AttendanceRecord
    {
        public string EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
    }

    public class AttendanceManager
    {
        private List<AttendanceRecord> records = new List<AttendanceRecord>();

        public void ClockIn(string employeeId)
        {
            var today = DateTime.Today;
            var record = records.Find(r => r.EmployeeId == employeeId && r.Date == today);
            if (record == null)
            {
                record = new AttendanceRecord
                {
                    EmployeeId = employeeId,
                    Date = today,
                    ClockIn = DateTime.Now
                };
                records.Add(record);
            }
            else
            {
                record.ClockIn = DateTime.Now;
            }
            Console.WriteLine($"{employeeId} さんが出勤しました: {DateTime.Now}");
        }

        public void ClockOut(string employeeId)
        {
            var today = DateTime.Today;
            var record = records.Find(r => r.EmployeeId == employeeId && r.Date == today);
            if (record != null)
            {
                record.ClockOut = DateTime.Now;
                Console.WriteLine($"{employeeId} さんが退勤しました: {DateTime.Now}");
            }
            else
            {
                Console.WriteLine("出勤記録がありません。");
            }
        }

        public void ShowRecords()
        {
            foreach (var record in records)
            {
                Console.WriteLine($"社員ID: {record.EmployeeId}, 日付: {record.Date.ToShortDateString()}, 出勤: {record.ClockIn}, 退勤: {record.ClockOut}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AttendanceManager manager = new AttendanceManager();

            while (true)
            {
                Console.WriteLine("1: 出勤 2: 退勤 3: 勤怠記録表示 0: 終了");
                var input = Console.ReadLine();
                if (input == "0") break;

                switch (input)
                {
                    case "1":
                        Console.Write("社員IDを入力してください: ");
                        var inId = Console.ReadLine();
                        manager.ClockIn(inId);
                        break;
                    case "2":
                        Console.Write("社員IDを入力してください: ");
                        var outId = Console.ReadLine();
                        manager.ClockOut(outId);
                        break;
                    case "3":
                        manager.ShowRecords();
                        break;
                }
            }
        }
    }
}