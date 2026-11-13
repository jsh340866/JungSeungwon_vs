using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Repository
{
    internal class DepartmentRepository
    {
        // 부서 조회
        public List<Department> GetAll()
        {
            var list = new List<Department>();

            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();


                string sql = @"SELECT DeptId, DeptCode, DeptName, Memo
                              FROM dbo.Department
                              ORDER BY DeptCode";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Department 
                            { 
                            DeptId = reader.GetInt32(0),
                            DeptCode = reader.GetString(1),
                            DeptName = reader.GetString(2),
                            Memo = GetStringOrNull(reader, 3)
                            });
                        }
                    }
                }
            }
            return list;
        }

        // DB값이 NULL이면 null, 아니면 문자열을 돌려줌 (NULL을 바로 읽으면 예외가 나기 때문)
        private static string GetStringOrNull(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? null : r.GetString(i);
        }


        // 부서 삭제 메서드
        public void Delete(int deptId)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"DELETE FROM dbo.Department WHERE DeptId = @DeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptId", deptId);
                    cmd.ExecuteNonQuery();
                }
            
            }
        }

        // 부서 추가 메서드
        public void Save(Department dept) 
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.Department (DeptCode, DeptName, Memo)
                              VALUES(@DeptCode, @DeptName, @Memo)";
                using(var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", dept.DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                    cmd.Parameters.AddWithValue("@Memo", dept.Memo ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 부서 수정 메서드
        public void Update(Department dept)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"UPDATE dbo.Department 
                              SET DeptCode = @DeptCode, DeptName = @DeptName, Memo = @Memo
                              WHERE DeptId = @DeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", dept.DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName", dept.DeptName);
                    cmd.Parameters.AddWithValue("@Memo", dept.Memo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DeptId", dept.DeptId);  
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

    }
}
