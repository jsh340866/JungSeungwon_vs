namespace WindowsFormsApp2.Dtos
{

    // 부서차트 데이터소스에 넣을 x축,y축,시리즈 저장할 dto
    internal class DeptChartDto
    {
        public string ParentDeptName_X { get; set; }
        public string DeptName_S {  get; set; }
        public int Count_Y {  get; set; }
    }
}
