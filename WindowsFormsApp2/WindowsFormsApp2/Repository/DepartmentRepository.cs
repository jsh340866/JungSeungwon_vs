using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Entity;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Repository
{
    internal class DepartmentRepository
    {


        // 부서 + 상위부서 조회 
        public List<DepartmentDto> GetAll()
        {
            var list = new List<DepartmentDto>();
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"SELECT d.DeptId, d.DeptCode, d.DeptName, d.Memo, d.ParentDeptId,
                              p.ParentDeptCode, p.ParentDeptName, p.ParentMemo
                              FROM dbo.Department d
                              LEFT JOIN dbo.ParentDepartment p ON p.ParentDeptId = d.ParentDeptId
                              ORDER BY d.DeptCode";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read())
                        {
                            list.Add(new DepartmentDto
                            {
                                DeptId = r.GetInt32(0),
                                DeptCode = r.GetString(1),
                                DeptName = r.GetString(2),
                                Memo = GetStringOrNull(r, 3),
                                ParentDeptId = GetIntOrNull(r, 4),
                                ParentDeptCode = GetStringOrNull(r, 5),
                                ParentDeptName = GetStringOrNull(r, 6),
                                ParentMemo = GetStringOrNull(r, 7)
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
        // DB값이 NULL 이면 null, 아니면 Int를 돌려줌
        private static int? GetIntOrNull(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? (int?)null : r.GetInt32(i);
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
        public void Save(Department entity)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"INSERT INTO dbo.Department (DeptCode, DeptName, Memo, ParentDeptId)
                              VALUES(@DeptCode, @DeptName, @Memo, @ParentDeptId)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", entity.DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName", entity.DeptName);

                    // dept.Memo 값이 null이면 DBNull.Value 값을 저장
                    cmd.Parameters.AddWithValue("@Memo", entity.Memo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentDeptId", entity.ParentDeptId ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 부서 수정 메서드
        public void Update(Department entity)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"UPDATE dbo.Department 
                              SET DeptCode = @DeptCode, DeptName = @DeptName, Memo = @Memo, ParentDeptId = @ParentDeptId
                              WHERE DeptId = @DeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", entity.DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName", entity.DeptName);
                    cmd.Parameters.AddWithValue("@Memo", entity.Memo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DeptId", entity.DeptId);
                    cmd.Parameters.AddWithValue("@ParentDeptId", entity.ParentDeptId ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        

    }

}

