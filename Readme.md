<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128534107/15.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T262239)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# ASPxGridView - How to export a colored grid when the Data Aware export mode is used
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/128534107/)**
<!-- run online end -->


<p><strong>UPDATED:</strong><br><br>Starting with version v2015 vol 2 (v15.2), this functionality is available out of the box. Use <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridView_FormatConditionstopic">ASPxGridView.FormatCondition</a> rules to define conditional formatting in Browse Mode and keep the applied appearance in the Exported Document. Please refer to the <a href="https://community.devexpress.com/blogs/aspnet/archive/2015/11/10/asp-net-grid-view-data-range-filter-adaptivity-and-more-coming-soon-in-v15-2.aspx">ASP.NET Grid View - Data Range Filter, Adaptivity and More (Coming soon in v15.2)</a> blog post and the <a href="http://demos.devexpress.com/ASPxGridViewDemos/Exporting/ExportWithFormatConditions.aspx">Export with Format Conditions</a> demo for more information.<br>If you have version v15.2+ available, consider using the built-in functionality instead of the approach detailed below.<br><br>If you need to apply custom appearance in the Exported Document only or define fine tuned complex appearance (for instance, based on some runtime calculated values, custom business rules, etc.), use the CsvExportOptionsEx / XlsExportOptionsEx / XlsxExportOptionsEx <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPrintingXlsxExportOptionsEx_CustomizeCelltopic">CustomizeCell</a> event in the <strong>Data Aware</strong> export mode.<br><br>In v2014 vol 2, we introduced the Excel Data Aware Export feature into our grid. While this feature significantly improves the export capabilities (see the <a href="https://community.devexpress.com/blogs/thinking/archive/2014/11/11/winforms-asp-net-and-wpf-grid-controls-new-excel-data-export-engine-coming-soon-in-v14-2.aspx">New Excel Data Export Engine</a> blog post), it also has some limitations. Most of them are described in the <a href="https://www.devexpress.com/Support/Center/p/T186064">T186064: ASPxGridView / MVC GridView Extension - Excel Data Aware Export FAQ</a> article.<br>One of them is that the ASPxGridViewExporter.RenderBrick event is not raised when the data-aware export is used. Commonly, this event is used for customizing the cell appearance in resulted documents (a back color, fonts, a format, etc.). While this event is not available, it is still possible to accomplish this task. The <a href="https://documentation.devexpress.com/#CoreLibraries/clsDevExpressXtraPrintingXlsxExportOptionsExtopic">XlsxExportOptionsEx</a> object provides the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPrintingXlsxExportOptionsEx_CustomizeCelltopic">CustomizeCell</a> event that can be used for customizing cells in the exported document:</p>


```cs
var exportOptions = new XlsxExportOptionsEx();
exportOptions.CustomizeCell += exportOptions_CustomizeCell;
ASPxGridViewExporter1.WriteXlsxToResponse(exportOptions);

...

void exportOptions_CustomizeCell(DevExpress.Export.CustomizeCellEventArgs ea) {
        if (ea.ColumnFieldName != "UnitsOnOrder") return;
        if (Convert.ToInt32(ea.Value) == 0)
            ea.Formatting.BackColor = Color.Salmon;
        else
            ea.Formatting.BackColor = Color.LightGray;
        ea.Handled = true;
}
```


<p> </p>


```vb
Dim exportOptions = New XlsxExportOptionsEx()
AddHandler exportOptions.CustomizeCell, AddressOf exportOptions_CustomizeCell
ASPxGridViewExporter1.WriteXlsxToResponse(exportOptions)
...

Private Sub exportOptions_CustomizeCell(ByVal ea As DevExpress.Export.CustomizeCellEventArgs)
		If ea.ColumnFieldName <> "UnitsOnOrder" Then
			Return
		End If
		If Convert.ToInt32(ea.Value) = 0 Then
			ea.Formatting.BackColor = Color.Salmon
		Else
			ea.Formatting.BackColor = Color.LightGray
		End If
		ea.Handled = True
End Sub
```


<p>This example illustrates a sample scenario with exporting a colored grid when the Data Aware export mode is used.<br><br><strong>See Also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/E2533">How to export the colored ASPxGridView</a></p>

<br/>


