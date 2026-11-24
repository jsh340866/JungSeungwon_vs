namespace WindowsFormsApp2.Entity
{
    // 부서 엔티티
    public class Department
    {
        public int DeptId {  get; set; }
        public string DeptCode {  get; set; }
        public string DeptName {  get; set; }
        public string Memo {  get; set; }
        public int? ParentDeptId { get; set; }

    }
}
