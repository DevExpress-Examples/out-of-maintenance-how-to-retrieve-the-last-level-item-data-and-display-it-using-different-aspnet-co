Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Data
Imports DevExpress.DataAccess.ConnectionParameters
Imports System.Web.Helpers
Imports DevExpress.Web.ASPxPivotGrid

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If (Not IsPostBack) AndAlso (Not IsCallback) Then
            Session("PivotSource") = Nothing
        End If
        If Session("PivotSource") IsNot Nothing Then
            ASPxPivotGrid1.DataSource = Session("PivotSource")
        End If
    End Sub
    Protected Sub dashboardViewer1_ConfigureDataConnection(ByVal sender As Object, ByVal e As DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs)
        CType(e.ConnectionParameters, Access97ConnectionParameters).FileName = Server.MapPath("~\App_Data\nwind.mdb")
    End Sub
    Protected Sub ASPxPivotGrid1_CustomCallback(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxPivotGrid.PivotGridCustomCallbackEventArgs)
        Dim result As Object = Json.Decode(e.Parameters)
        Dim dt As New DataTable()
        ASPxPivotGrid1.Fields.Clear()
        For Each dimension As Object In result.D
            dt.Columns.Add(dimension.Id)
            Dim field As PivotGridField = ASPxPivotGrid1.Fields.Add(dimension.Id, DevExpress.XtraPivotGrid.PivotArea.RowArea)
            field.Caption = dimension.Name
        Next dimension
        For Each measure As Object In result.M
            dt.Columns.Add(measure.Id, GetType(Decimal))
            Dim field As PivotGridField = ASPxPivotGrid1.Fields.Add(measure.Id, DevExpress.XtraPivotGrid.PivotArea.DataArea)
            field.Caption = measure.Name
        Next measure
        For Each row In result.R
            dt.Rows.Add(row.RD)
        Next row
        Session("PivotSource") = dt
        ASPxPivotGrid1.DataSource = dt
        ASPxPivotGrid1.DataBind()
    End Sub
End Class