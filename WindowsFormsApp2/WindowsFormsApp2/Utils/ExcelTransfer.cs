using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp2.Utils
{
    public class ExcelTransfer
    {
        // gridview 엑셀변환 메서드
        public void ExportExcel(string filename, GridView gridview)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Excel 파일 (*.xlsx)|*.xlsx|PDF 파일 (*.pdf)|*.pdf|CSV 파일 (*.csv)|*.csv";
                dlg.FileName = $"{filename}_{DateTime.Now:yyyy/MM/dd}"; // 파일명 + 저장날짜

                // 파일저장 취소시 엑셀 변환 x
                if (dlg.ShowDialog() != DialogResult.OK) { return; }

                try
                {
                    switch (dlg.FilterIndex) 
                    {
                        case 1: gridview.ExportToXlsx(dlg.FileName); break;
                        case 2: gridview.ExportToPdf(dlg.FileName); break;
                        case 3: gridview.ExportToCsv(dlg.FileName); break;
                        default: throw new ArgumentOutOfRangeException(nameof(dlg.FilterIndex));
                    }
                    MessageBox.Show("파일을 저장했습니다.");
                }
                catch (System.Exception ex)
                {
                    Logger.Instance.Error("자료변환 실패", ex);
                    MessageBox.Show("파일 저장 중 오류가 발생했습니다.\n\n" + ex.Message);
                }
            }
        }

        
    }
}
