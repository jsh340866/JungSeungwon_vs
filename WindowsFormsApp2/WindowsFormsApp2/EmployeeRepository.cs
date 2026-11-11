using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    // 사원 테이블에서 데이터를 읽어 오는 클래스
    internal class EmployeeRepository
    {
        // 사원 전체 조회 (부서 테이블과 JOIN)
        public List<Employee> GetAll()
        {
            var list = new List<Employee>();

            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();

                string sql = @"
                    SELECT e.EmpId, e.DeptId, d.DeptCode, d.DeptName,
                           e.EmpCode, e.EmpName, e.Gender, e.LoginId, e.Password,
                           e.Position, e.EmpType, e.Phone, e.Email, e.MessengerId, e.Memo
                    FROM dbo.Employee e
                    JOIN dbo.Department d ON d.DeptId = e.DeptId
                    ORDER BY d.DeptCode, e.EmpCode";

                using (var cmd = new SqlCommand(sql, conn))
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
                            Gender = GetStringOrNull(r, 6),
                            LoginId = r.GetString(7),
                            Password = r.GetString(8),
                            Position =GetStringOrNull(r, 9),
                            EmpType = GetStringOrNull(r, 10),
                            Phone = GetStringOrNull(r, 11),
                            Email = GetStringOrNull(r, 12),
                            MessengerId = GetStringOrNull(r, 13),
                            Memo = GetStringOrNull(r, 14)
                        });
                    }
                }
            }

            return list;
        }

        // 사원 삭제 메서드
        public void Delete(int empId)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = "DELETE FROM dbo.Employee WHERE EmpId = @EmpID";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", empId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // DB가 NULL이면 null, 아니면 문자열을 돌려줌 (NULL을 바로 읽으면 예외가 나기 때문)
        private static string GetStringOrNull(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? null : r.GetString(i);
        }
    }
}
