using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.Dtos;
using WindowsFormsApp2.Entity;
using WindowsFormsApp2.Utils;

namespace WindowsFormsApp2.Repository
{
    internal class ParentDepartmentRepository
    {
        // 상위부서 조회
        public List<ParentDepartmentDto> GetAll()
        {
            var list = new List<ParentDepartmentDto>();
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"SELECT ParentDeptId, ParentDeptCode, ParentDeptName, ParentMemo
                              FROM dbo.ParentDepartment
                              ORDER BY ParentDeptCode";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    using (var r = cmd.ExecuteReader())
                    {
                        while (r.Read()) {
                            list.Add(new ParentDepartmentDto()
                            {
                                ParentDeptId = r.GetInt32(0),
                                ParentDeptCode = r.GetString(1),
                                ParentDeptName = r.GetString(2),
                                ParentMemo = GetStringOrNull(r,3)
                            }
                            );
                        }
                    }
                }      
            } 
            return list;

        }
        private static string GetStringOrNull(SqlDataReader r, int i)
        {
            return r.IsDBNull(i) ? null : r.GetString(i);
        }

        // 상위부서 삭제 메서드
        public void Delete(int pdeptId)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"DELETE FROM dbo.ParentDepartment WHERE ParentDeptId = @ParentDeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ParentDeptId", pdeptId);
                    cmd.ExecuteNonQuery();
                }

            }
        }

        // 상위부서 추가 메서드
        public void Save(ParentDepartment pdept)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"INSERT INTO 
                             dbo.ParentDepartment (ParentDeptCode, ParentDeptName, ParentMemo)
                             VALUES(@ParentDeptCode, @ParentDeptName, @ParentMemo)";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ParentDeptCode", pdept.ParentDeptCode);
                    cmd.Parameters.AddWithValue("@ParentDeptName", pdept.ParentDeptName);
                    cmd.Parameters.AddWithValue("@ParentMemo", pdept.ParentMemo ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 상위부서 수정 메서드
        public void Update(ParentDepartment pdept)
        {
            using (var conn = new SqlConnection(Config.Connstr))
            {
                conn.Open();
                string sql = @"UPDATE dbo.ParentDepartment 
                              SET ParentDeptCode = @ParentDeptCode, ParentDeptName = @ParentDeptName, ParentMemo = @ParentMemo
                              WHERE ParentDeptId = @ParentDeptId";
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ParentDeptId", pdept.ParentDeptId);
                    cmd.Parameters.AddWithValue("@ParentDeptCode", pdept.ParentDeptCode);
                    cmd.Parameters.AddWithValue("@ParentDeptName", pdept.ParentDeptName);
                    cmd.Parameters.AddWithValue("@ParentMemo", pdept.ParentMemo ?? (object)DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}


        
    

