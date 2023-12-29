<!-- default file list -->
*Files to look at*:

* [LayoutDataParser.cs](./CS/App_Code/LayoutDataParser.cs) (VB: [LayoutDataParser.vb](./VB/App_Code/LayoutDataParser.vb))
* **[Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))**
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxDockManager - How to load a previously saved layout on demand


<p>The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxDockManager_ClientLayouttopic">ASPxDockManager.ClientLayout</a> event is used for saving and restoring the layout of panels and zones on a page. However, <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxClientLayoutArgs_LayoutModetopic">LayoutMode</a> is set to "Loading" only on the first page load, and on subsequent round-trips to the server only the "Saving" mode is used. This example demonstrates the technique of parsing previously saved layout data and applying it on a callback.</p>

<br/>


