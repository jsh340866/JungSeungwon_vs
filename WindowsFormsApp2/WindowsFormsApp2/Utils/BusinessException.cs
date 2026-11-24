using System;

namespace WindowsFormsApp2.Utils
{
    // 예외처리 관리, 메시지 저장용
    public class BusinessException : Exception
    {
        public BusinessException(string msg) : base(msg) { }
    }
}
