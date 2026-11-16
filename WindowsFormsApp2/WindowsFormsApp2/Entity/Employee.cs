using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Entity
{
    internal class Employee
    {
        public int EmpId { get; set; }
        public int DeptId { get; set; }

        public string EmpCode { get; set; }
        public string EmpName { get; set; }
        public string Gender { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string EmpType { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MessengerId { get; set; }
        public string Memo { get; set; }

    }
}
