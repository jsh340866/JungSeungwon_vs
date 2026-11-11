class Employee
{
    public int EmpId { get; set; }           // IDENTITY ID
    public int DeptId { get; set; }          // 외래키
    public string DeptCode { get; set; }     // 조회(JOIN) 시 채워짐
    public string DeptName { get; set; }     // 조회(JOIN) 시 채워짐
    public string EmpCode { get; set; }
    public string EmpName { get; set; }
    public string Gender { get; set; }       // "남" / "여" / null
    public string LoginId { get; set; }
    public string Password { get; set; }
    public string Position { get; set; }
    public string EmpType { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string MessengerId { get; set; }
    public string Memo { get; set; }
}
