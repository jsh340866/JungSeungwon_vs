using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Forms;

namespace WindowsFormsApp2.Utils
{
    internal static class Program
    {
        
        [STAThread]
        static void Main()
        {

            // UI 스레드에서 처리되지 않은 예외는 우리가 정한 핸들러로 보낸다.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);


            // 버튼 클릭 등 UI 이벤트 안에서 터진 오류
            Application.ThreadException += (s, e) =>
            {
                Logger.Instance.Error("처리되지 않은 UI예외", e.Exception);
                MessageBox.Show("예상하지 못한 오류가 발생했습니다.\n 자세한 내용은 로그를 확인하세요.");
            };


            // UI 스레드가 아닌 곳에서 터진 오류 (백그라운드)
            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                Logger.Instance.Error("처리되지 않은 예외", e.ExceptionObject as Exception);
            };




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
