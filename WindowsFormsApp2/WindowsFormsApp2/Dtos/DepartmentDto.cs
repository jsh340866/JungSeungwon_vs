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
        public int? ParentDeptId { get; set; }

        // LEFT JOIN으로 ParentDepartmenet 에서 가져옴
        public string ParentDeptCode { get; set; }
        public string ParentDeptName { get; set; }
        public string ParentMemo { get; set; }
       
    }
}
