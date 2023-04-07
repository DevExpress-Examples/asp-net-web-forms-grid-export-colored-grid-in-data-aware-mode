using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraPrinting;
using System.Drawing;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        ASPxGridView1.DataSource = Product.GetData();
        ASPxGridView1.DataBind();
    }

    protected void ASPxButton1_Click(object sender, EventArgs e) {
        var exportOptions = new XlsxExportOptionsEx();
        exportOptions.CustomizeCell += ExportOptions_CustomizeCell;
        ASPxGridView1.ExportXlsxToResponse(exportOptions);
    }

    void ExportOptions_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs ea) {
        if (ea.ColumnFieldName != "UnitsOnOrder" || ea.AreaType != DevExpress.Export.SheetAreaType.DataArea) return;
        int cellValue = 0;
        if (int.TryParse(ea.Value.ToString(), out cellValue) && cellValue == 0) {
            ea.Formatting.BackColor = Color.Salmon;
            ea.Formatting.Font.Color = Color.Blue;
            ea.Formatting.Font.Bold = true;
        }
        else
            ea.Formatting.BackColor = Color.LightBlue;
        ea.Handled = true;
    }
    protected void ASPxGridView1_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e) {
        if (e.DataColumn.FieldName != "UnitsOnOrder") return;
        if (Convert.ToInt32(e.CellValue) == 0) {
            e.Cell.BackColor = Color.Salmon;
            e.Cell.Font.Bold = true;
            e.Cell.ForeColor = Color.Blue;
        }
        else
            e.Cell.BackColor = Color.LightBlue;
    }
}
