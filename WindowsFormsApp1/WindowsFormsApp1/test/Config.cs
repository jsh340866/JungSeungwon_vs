// 서버 이름만 본인 환경에 맞게 수정 (지금은 LocalDB)
static class Config
{
    public const string ConnStr =
        "Server=(localdb)\\MSSQLLocalDB;Database=testdb;Trusted_Connection=True;";
}
