using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Utils
{
    internal class Logger
    {
        public static readonly Logger Instance = new Logger();
        private readonly object _lock = new object();      // 동시에 쓰는 것 방지
        private readonly string _logDir =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs");

        public void Write(string level, string message, Exception ex = null)
        {
            try
            {
                Directory.CreateDirectory(_logDir);                        // 폴더 없으면 생성
                string file = Path.Combine(_logDir, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
                string line = DateTime.Now.ToString("HH:mm:ss") + " [" + level + "] " + message;
                if (ex != null) line += Environment.NewLine + ex;          // 호출 스택까지 포함
                lock (_lock) { File.AppendAllText(file, line + Environment.NewLine); }
            }
            catch { }   // 로그 기록 때문에 앱이 멈추면 안 됨
        }

        // 레벨별 편의 메서드: Write("ERROR", ...) 대신 Error(...)처럼 짧게 호출
        public void Info(string message) { Write("INFO", message); }
        public void Warn(string message) { Write("WARN", message); }   
        public void Error(string message, Exception ex = null) { Write("ERROR", message, ex); }
    }
}
