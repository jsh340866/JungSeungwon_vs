
using System.Configuration;

namespace WindowsFormsApp2.Utils
{
    // DB 연결 설정
    internal static class Config
    {
        public static readonly string Connstr =
            ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
    }
}
    