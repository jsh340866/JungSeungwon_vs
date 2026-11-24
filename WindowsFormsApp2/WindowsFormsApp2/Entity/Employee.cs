namespace WindowsFormsApp2.Entity
{
    // 사원 엔티티
    public class Employee
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
        public byte[] Photo {  get; set; }

    }
}
