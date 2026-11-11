using System.Collections.Generic;
using System.Data.SqlClient;

// ───────────── 부서 Repository ─────────────
class DepartmentRepository
{
    private readonly string _connStr;

    public DepartmentRepository(string connStr)
    {
        _connStr = connStr;
    }

    public List<Department> GetAll()
    {
        var list = new List<Department>();
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(
                "SELECT DeptId, DeptCode, DeptName, Memo FROM dbo.Department ORDER BY DeptCode", conn))
            using (var r = cmd.ExecuteReader())
            {
                while (r.Read())
                {
                    list.Add(new Department
                    {
                        DeptId = r.GetInt32(0),
                        DeptCode = r.GetString(1),
                        DeptName = r.GetString(2),
                        Memo = Db.Str(r, 3)
                    });
                }
            }
        }
        return list;
    }

    public int Add(Department d)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(
                "INSERT INTO dbo.Department (DeptCode, DeptName, Memo) VALUES (@DeptCode, @DeptName, @Memo)", conn))
            {
                cmd.Parameters.AddWithValue("@DeptCode", d.DeptCode);
                cmd.Parameters.AddWithValue("@DeptName", d.DeptName);
                cmd.Parameters.AddWithValue("@Memo", Db.V(d.Memo));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public int Update(Department d)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand(
                "UPDATE dbo.Department SET DeptCode = @DeptCode, DeptName = @DeptName, Memo = @Memo WHERE DeptId = @DeptId", conn))
            {
                cmd.Parameters.AddWithValue("@DeptId", d.DeptId);
                cmd.Parameters.AddWithValue("@DeptCode", d.DeptCode);
                cmd.Parameters.AddWithValue("@DeptName", d.DeptName);
                cmd.Parameters.AddWithValue("@Memo", Db.V(d.Memo));
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public int Delete(int deptId)
    {
        using (var conn = new SqlConnection(_connStr))
        {
            conn.Open();
            using (var cmd = new SqlCommand("DELETE FROM dbo.Department WHERE DeptId = @DeptId", conn))
            {
                cmd.Parameters.AddWithValue("@DeptId", deptId);
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
