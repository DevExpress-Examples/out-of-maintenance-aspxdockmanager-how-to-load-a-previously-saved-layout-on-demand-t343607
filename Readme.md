<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128554362/15.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T343607)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [LayoutDataParser.cs](./CS/App_Code/LayoutDataParser.cs) (VB: [LayoutDataParser.vb](./VB/App_Code/LayoutDataParser.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxDockManager - How to load a previously saved layout on demand
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t343607/)**
<!-- run online end -->


<p>The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxDockManager_ClientLayouttopic">ASPxDockManager.ClientLayout</a> event is used for saving and restoring the layout of panels and zones on a page. However, <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxClientLayoutArgs_LayoutModetopic">LayoutMode</a> is set to "Loading" only on the first page load, and on subsequent round-trips to the server only the "Saving" mode is used. This example demonstrates the technique of parsing previously saved layout data and applying it on a callback.</p>

<br/>


