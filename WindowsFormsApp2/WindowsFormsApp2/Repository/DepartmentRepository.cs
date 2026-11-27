using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Entity;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Repository
{
    internal class DepartmentRepository
    {


        // 부서 + 상위부서 조회 
        public async Task<List<DepartmentDto>> GetAllAsync()
        {
            var list = new List<DepartmentDto>();
            using (var conn = new SqlConnection(Config.Connstr))
            {
                await conn.OpenAsync();
                string sql = @"SELECT d.DeptId, d.DeptCode, d.DeptName, d.Memo, d.ParentDeptId
                              FROM dbo.Department d
                              LEFT JOIN dbo.Department p ON p.DeptId = d.ParentDeptId
                              ORDER BY d.DeptCode";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var r = await cmd.ExecuteReaderAsync())
                    {
                        while (await r.ReadAsync())
                        {
                            list.Add(new DepartmentDto
                            {
                                DeptId = r.GetInt32(0),
                                DeptCode = r.GetString(1),
                                DeptName = r.GetString(2),
                                Memo = GetStringOrNull(r, 3),
                                ParentDeptId = GetIntOrNull(r, 4)
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
        public async Task DeleteAsync(int deptId)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                await conn.OpenAsync();
                string sql = @"DELETE FROM dbo.Department WHERE DeptId = @DeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptId", deptId);
                    await cmd.ExecuteNonQueryAsync();
                }

            }
        }

        // 부서 추가 메서드
        public async Task SaveAsync(Department entity)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                await conn.OpenAsync();
                string sql = @"INSERT INTO dbo.Department (DeptCode, DeptName, Memo, ParentDeptId)
                              VALUES(@DeptCode, @DeptName, @Memo, @ParentDeptId)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@DeptCode", entity.DeptCode);
                    cmd.Parameters.AddWithValue("@DeptName", entity.DeptName);

                    // dept.Memo 값이 null이면 DBNull.Value 값을 저장
                    cmd.Parameters.AddWithValue("@Memo", entity.Memo ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ParentDeptId", entity.ParentDeptId ?? (object)DBNull.Value);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        // 부서 수정 메서드
        public async Task UpdateAsync(Department entity)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                await conn.OpenAsync();
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
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        

    }

}

