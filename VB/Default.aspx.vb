Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraPrinting
Imports System.Drawing

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        ASPxGridView1.DataSource = Product.GetData()
        ASPxGridView1.DataBind()
    End Sub

    Protected Sub ASPxButton1_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim exportOptions = New XlsxExportOptionsEx()
        AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
        ASPxGridViewExporter1.WriteXlsxToResponse(exportOptions)
    End Sub

    Private Sub exportOptions_CustomizeCell(ByVal ea As DevExpress.Export.CustomizeCellEventArgs)
        If ea.ColumnFieldName <> "UnitsOnOrder" OrElse ea.AreaType <> DevExpress.Export.SheetAreaType.DataArea Then
            Return
        End If
        Dim cellValue As Integer = 0
        If Integer.TryParse(ea.Value.ToString(), cellValue) AndAlso cellValue = 0 Then
            ea.Formatting.BackColor = Color.Salmon
            ea.Formatting.Font.Color = Color.Blue
            ea.Formatting.Font.Bold = True
        Else
            ea.Formatting.BackColor = Color.LightBlue
        End If
        ea.Handled = True
    End Sub
    Protected Sub ASPxGridView1_HtmlDataCellPrepared(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxGridViewTableDataCellEventArgs)
        If e.DataColumn.FieldName <> "UnitsOnOrder" Then
            Return
        End If
        If Convert.ToInt32(e.CellValue) = 0 Then
            e.Cell.BackColor = Color.Salmon
            e.Cell.Font.Bold = True
            e.Cell.ForeColor = Color.Blue
        Else
            e.Cell.BackColor = Color.LightBlue
        End If
    End Sub
End Class