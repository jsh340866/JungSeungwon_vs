using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Repository
{
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

        // DB가 NULL이면 null, 아니면 문자열을 돌려줌 (NULL을 바로 읽으면 예외가 나기 때문)
        private static string GetStringOrNull(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? null : r.GetString(i);
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

        // 로그인정보 업데이트
        public void UpdateLoginInfo(string LoginId, string Password, int EmpId)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = "UPDATE dbo.Employee SET LoginId = @LoginId, Password = @Password WHERE EmpId = @EmpId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@EmpId", EmpId);
                    cmd.Parameters.AddWithValue("@LoginId", LoginId);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 사원 수정 업데이트
        public void UpdateEmployee (Employee emp)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"UPDATE dbo.Employee SET 
                                DeptId = (SELECT DeptId FROM dbo.Department WHERE DeptCode = @DeptCode),
                                EmpCode =@EmpCode,
                                EmpName = @EmpName, 
                                Gender = @Gender, 
                                Position = @Position, 
                                EmpType = @EmpType, 
                                Memo = @Memo, 
                                Email = @Email, 
                                MessengerId = @MessengerId, 
                                Phone = @Phone
                                WHERE EmpId = @EmpId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", emp.DeptCode);
                    cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Position", emp.Position ?? (object)DBNull.Value); 
                    cmd.Parameters.AddWithValue("@EmpType", emp.EmpType ?? (object)DBNull.Value);   
                    cmd.Parameters.AddWithValue("@Memo", emp.Memo ?? (object)DBNull.Value); 
                    cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);   
                    cmd.Parameters.AddWithValue("@MessengerId", emp.MessengerId ?? (object)DBNull.Value);   
                    cmd.Parameters.AddWithValue("@Phone", emp.Phone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                    cmd.ExecuteNonQuery();  
                }
            }
        }

        // 사원 추가 저장 메서드
        public void EmployeeAddSave(Employee emp)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.Employee(DeptId, EmpCode, EmpName, LoginId, Password, Position, EmpType, Gender,
                               Phone, Email, MessengerId, Memo) 
                               VALUES ( (SELECT DeptId FROM dbo.Department WHERE DeptCode = @DeptCode), @EmpCode, @EmpName, @LoginId, 
                               @Password, @Position, @EmpType, @Gender, @Phone, @Email, @MessengerId, @Memo)";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", emp.DeptCode);
                    cmd.Parameters.AddWithValue("@EmpCode", emp.EmpCode);
                    cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);
                    cmd.Parameters.AddWithValue("@LoginId", emp.LoginId);
                    cmd.Parameters.AddWithValue("@Password", emp.Password);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Position", emp.Position ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@EmpType", emp.EmpType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Memo", emp.Memo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", emp.Email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MessengerId", emp.MessengerId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Phone", emp.Phone ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }



        // 사원 수정 부서코드, 부서명 연동 사전
        public Dictionary<string, string> DeptCodeName()
        {
            var dict = new Dictionary<string, string>();
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string Sql = @"SELECT DeptCode, DeptName FROM dbo.Department";
                using (var cmd = new SqlCommand(Sql, conn))
                {
                    using (var c = cmd.ExecuteReader())
                    {
                        while (c.Read())
                        {
                            dict.Add(c.GetString(0),c.GetString(1));
                        }
                    }
                    return dict;
                }
            }
        }

       


        
    }
}
