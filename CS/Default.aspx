<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v14.1, Version=14.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Dashboard.v14.1.Web, Version=14.1.8.0, Culture=neutral, PublicKeyToken=B88D1754D700E49A"
    Namespace="DevExpress.DashboardWeb" TagPrefix="dxdb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="DashboardScripts.js" type="text/javascript"></script>
    <script type="text/javascript">
        function UpdatePivotData( itemName) {
            var dataJson = GetDashboardItemData(dashboardViewer1, itemName);
            pivotGrid.PerformCallback(JSON.stringify(dataJson));
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server" ClientIDMode="AutoID" ClientInstanceName="pivotGrid"
            OnCustomCallback="ASPxPivotGrid1_CustomCallback">
           
        </dx:ASPxPivotGrid>
        <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Get Grid Data" AutoPostBack="False">
            <ClientSideEvents Click="function(s, e) { UpdatePivotData('gridDashboardItem1'); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Get Pivot Data" AutoPostBack="False">
            <ClientSideEvents Click="function(s, e) { UpdatePivotData('pivotDashboardItem1'); }" />
        </dx:ASPxButton>
        <dx:ASPxButton ID="ASPxButton3" runat="server" Text="Get Chart Data" AutoPostBack="False">
            <ClientSideEvents Click="function(s, e) {UpdatePivotData('chartDashboardItem1'); }" />
        </dx:ASPxButton>
        <dxdb:ASPxDashboardViewer runat="server" ID="dashboardViewer1" Width="100%" Height="600px"
            FullscreenMode="False" RegisterJQuery="False" UseDataAccessApi="True" DashboardXmlFile="~/App_Data/Dashboards/ClientDataAPI.xml"
            ClientInstanceName="dashboardViewer1" OnConfigureDataConnection="dashboardViewer1_ConfigureDataConnection" />
        
    </div>
    </form>
</body>
</html>
