using System;
using System.Data.SqlClient;

// ───────────── 공통 ─────────────
static class Db
{
    // null → DBNull 변환 (선택 입력 컬럼용)
    public static object V(object value)
    {
        return value ?? DBNull.Value;
    }

    public static string Str(SqlDataReader r, int i)
    {
        return r.IsDBNull(i) ? null : r.GetString(i);
    }
}
