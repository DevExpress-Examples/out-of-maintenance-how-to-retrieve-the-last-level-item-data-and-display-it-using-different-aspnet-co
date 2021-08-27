<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128580356/14.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T170990)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DashboardScripts.js](./CS/DashboardScripts.js) (VB: [DashboardScripts.js](./VB/DashboardScripts.js))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# How to retrieve the last level item data and display it using different ASP.NET controls
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t170990/)**
<!-- run online end -->


<p>This solution can be used with both <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardWebASPxDashboardViewertopic">ASPxDashboardViewer </a> and <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardWebMvcMVCxDashboardViewertopic">MVCxDashboardViewer </a> controls:<br />To request data displayed in the specific <a href="https://documentation.devexpress.com/#Dashboard/CustomDocument16718">Dashboard Item</a>, you should call <a href="https://documentation.devexpress.com/#Dashboard/DevExpressDashboardWebScriptsASPxClientDashboardViewer_GetItemDatatopic">GetItemData</a> methods of the <a href="https://documentation.devexpress.com/#Dashboard/clsDevExpressDashboardWebScriptsASPxClientDashboardViewertopic">ASPxClientDashboardViewer</a> object. <br />Then, you need to iterate through the item's elements (rows, cells, points, etc ), collect information about corresponding dimensions and measures and store it as JSON collection. You can send this collection to the server in a string format using the <a href="http://msdn.microsoft.com/en-us/library/ie/cc836459(v=vs.94).aspx">JSON.stringify Function</a>. To parse the string on the server, you can use the <a href="http://msdn.microsoft.com/en-us/library/system.web.helpers.json.decode(v=vs.111).aspx">Json.Decode Method</a>. <br /><br />Note that the Pivot Item returns last level data only for completely expanded rows and columns.<br /><strong>See Also:</strong> <br /><a href="https://www.devexpress.com/Support/Center/p/T182186">T182186: How to get visible data from a certain dashboard item on the client side and process it on the server side</a><br /><a href="https://www.devexpress.com/Support/Center/p/T148767">T148767: How to obtain a dashboard item's client data in the Web Viewer</a></p>

<br/>


