using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

// ───────────── 사원 Repository ─────────────
class EmployeeRepository
{
    private readonly string _connStr;

    public EmployeeRepository(string connStr)
    {
        _connStr = connStr;
    }

    // 사원 조회: 부서/사원 JOIN (deptId를 주면 해당 부서만)
    public List<Employee> GetAll(int? deptId)
    {
        var list = new List<Employee>();
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(@"
                SELECT e.EmpId, e.DeptId, d.DeptCode, d.DeptName, e.EmpCode, e.EmpName, e.Gender,
                       e.LoginId, e.Password, e.Position, e.EmpType, e.Phone, e.Email, e.MessengerId, e.Memo
                FROM dbo.Employee e
                JOIN dbo.Department d ON d.DeptId = e.DeptId
                WHERE (@DeptId IS NULL OR e.DeptId = @DeptId)
                ORDER BY d.DeptCode, e.EmpCode", conn))
            {
                cmd.Parameters.Add("@DeptId", SqlDbType.Int).Value = Db.V(deptId);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Employee
                        {
                            EmpId = r.GetInt32(0),
                            DeptId = r.GetInt32(1),
                            DeptCode = r.GetString(2),
                            DeptName = r.GetString(3),
                            EmpCode = r.GetString(4),
                            EmpName = r.GetString(5),
                            Gender = Db.Str(r, 6),
                            LoginId = r.GetString(7),
                            Password = r.GetString(8),
                            Position = Db.Str(r, 9),
                            EmpType = Db.Str(r, 10),
                            Phone = Db.Str(r, 11),
                            Email = Db.Str(r, 12),
                            MessengerId = Db.Str(r, 13),
                            Memo = Db.Str(r, 14)
                        });
                    }
                }
            }
        }
        return list;
    }

    public int Add(Employee e)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(@"
                INSERT INTO dbo.Employee
                  (DeptId, EmpCode, EmpName, Gender, LoginId, Password, Position, EmpType, Phone, Email, MessengerId, Memo)
                VALUES
                  (@DeptId, @EmpCode, @EmpName, @Gender, @LoginId, @Password, @Position, @EmpType, @Phone, @Email, @MessengerId, @Memo)", conn))
            {
                cmd.Parameters.AddWithValue("@DeptId", e.DeptId);
                cmd.Parameters.AddWithValue("@EmpCode", e.EmpCode);
                cmd.Parameters.AddWithValue("@EmpName", e.EmpName);
                cmd.Parameters.AddWithValue("@Gender", Db.V(e.Gender));
                cmd.Parameters.AddWithValue("@LoginId", e.LoginId);
                cmd.Parameters.AddWithValue("@Password", e.Password);
                cmd.Parameters.AddWithValue("@Position", Db.V(e.Position));
                cmd.Parameters.AddWithValue("@EmpType", Db.V(e.EmpType));
                cmd.Parameters.AddWithValue("@Phone", Db.V(e.Phone));
                cmd.Parameters.AddWithValue("@Email", Db.V(e.Email));
                cmd.Parameters.AddWithValue("@MessengerId", Db.V(e.MessengerId));
                cmd.Parameters.AddWithValue("@Memo", Db.V(e.Memo));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    // 사원 수정 (로그인ID/비밀번호는 별도 메서드)
    public int Update(Employee e)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(@"
                UPDATE dbo.Employee
                SET DeptId = @DeptId, EmpCode = @EmpCode, EmpName = @EmpName, Gender = @Gender,
                    Position = @Position, EmpType = @EmpType, Phone = @Phone, Email = @Email,
                    MessengerId = @MessengerId, Memo = @Memo
                WHERE EmpId = @EmpId", conn))
            {
                cmd.Parameters.AddWithValue("@EmpId", e.EmpId);
                cmd.Parameters.AddWithValue("@DeptId", e.DeptId);
                cmd.Parameters.AddWithValue("@EmpCode", e.EmpCode);
                cmd.Parameters.AddWithValue("@EmpName", e.EmpName);
                cmd.Parameters.AddWithValue("@Gender", Db.V(e.Gender));
                cmd.Parameters.AddWithValue("@Position", Db.V(e.Position));
                cmd.Parameters.AddWithValue("@EmpType", Db.V(e.EmpType));
                cmd.Parameters.AddWithValue("@Phone", Db.V(e.Phone));
                cmd.Parameters.AddWithValue("@Email", Db.V(e.Email));
                cmd.Parameters.AddWithValue("@MessengerId", Db.V(e.MessengerId));
                cmd.Parameters.AddWithValue("@Memo", Db.V(e.Memo));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    // 로그인정보 변경
    public int UpdateLogin(int empId, string loginId, string password)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(
                "UPDATE dbo.Employee SET LoginId = @LoginId, Password = @Password WHERE EmpId = @EmpId", conn))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@LoginId", loginId);
                cmd.Parameters.AddWithValue("@Password", password);
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public int Delete(int empId)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand("DELETE FROM dbo.Employee WHERE EmpId = @EmpId", conn))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
