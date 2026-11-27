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
    }
}
