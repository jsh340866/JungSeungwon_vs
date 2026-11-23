using DevExpress.CodeParser;
using DevExpress.XtraDashboardLayout;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                dlg.Filter = "Excel 파일 (*.xlsx)|*.xlsx";
                dlg.FileName = $"{filename}_{DateTime.Now:yyyy/MM/dd}"; // 파일명 + 저장날짜

                // 파일저장 취소시 엑셀 변환 x
                if (dlg.ShowDialog() != DialogResult.OK) { return; }

                try
                {
                    gridview.ExportToXlsx(dlg.FileName);
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
