using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    // DB의 사원 한 행( + 부서 join 결과)을 담은 클래스
    public class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }

        // 부서 테이블에서 join으로 가져오는 값
        public string DeptCode { get; set; }
        public string DeptName { get; set; }

        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Phone { get; set; }
        public string EmpType { get; set; }
        public string Email { get; set; }
        public string MessengerId { get; set; }
        public string Memo { get; set; }

    }
}
