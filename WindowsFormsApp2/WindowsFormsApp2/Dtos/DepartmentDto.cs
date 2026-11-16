using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.Dtos
{
    // 부서 dto
    public class DepartmentDto
    {
        public int DeptId {  get; set; }
        public string DeptCode {  get; set; }
        public string DeptName { get; set; }
        public string Memo { get; set; }
    }
}
