using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DevExpress.DataAccess.ConnectionParameters;
using System.Web.Helpers;
using DevExpress.Web.ASPxPivotGrid;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && !IsCallback)
            Session["PivotSource"] = null;
        if (Session["PivotSource"] != null)
            ASPxPivotGrid1.DataSource = Session["PivotSource"];
    }
    protected void dashboardViewer1_ConfigureDataConnection(object sender, DevExpress.DashboardWeb.ConfigureDataConnectionWebEventArgs e)
    {
        ((Access97ConnectionParameters)e.ConnectionParameters).FileName = Server.MapPath(@"~\App_Data\nwind.mdb");
    }
    protected void ASPxPivotGrid1_CustomCallback(object sender, DevExpress.Web.ASPxPivotGrid.PivotGridCustomCallbackEventArgs e)
    {
        dynamic result = Json.Decode(e.Parameters);
        DataTable dt = new DataTable();
        ASPxPivotGrid1.Fields.Clear();
        foreach (dynamic dimension in result.D)
        {
            dt.Columns.Add(dimension.Id);
            PivotGridField field = ASPxPivotGrid1.Fields.Add(dimension.Id, DevExpress.XtraPivotGrid.PivotArea.RowArea);
            field.Caption = dimension.Name;
        }
        foreach (dynamic measure in result.M)
        {
            dt.Columns.Add(measure.Id, typeof(decimal));
            PivotGridField field = ASPxPivotGrid1.Fields.Add(measure.Id, DevExpress.XtraPivotGrid.PivotArea.DataArea);
            field.Caption = measure.Name;
        }
        foreach (var row in result.R)
            dt.Rows.Add(row.RD);
        Session["PivotSource"] = dt;
        ASPxPivotGrid1.DataSource = dt;
        ASPxPivotGrid1.DataBind();
    }
}