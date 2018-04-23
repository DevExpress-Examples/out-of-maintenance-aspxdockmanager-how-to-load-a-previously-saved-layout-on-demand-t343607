using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page {

    bool saveLayout = false;
    private DataTable LayoutDataSource {
        get {
            if (Session["layout"] == null) {
                DataTable table = new DataTable();
                table.Columns.Add("Date");
                table.Columns.Add("LayoutString");
                Session["layout"] = table;
            }
            return Session["layout"] as DataTable;
        }
        set { Session["layout"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e) {
        if (!IsPostBack)
            Session.Clear();

        grid.DataBind();
    }
    protected void grid_DataBinding(object sender, EventArgs e) {
        grid.DataSource = LayoutDataSource;
    }
    protected void btnSave_Click(object sender, EventArgs e) {
        grid.Selection.UnselectAll();
        saveLayout = true;
    }  
    protected void ASPxDockManager1_ClientLayout(object sender, ASPxClientLayoutArgs e) {
        if (e.LayoutMode == ClientLayoutMode.Saving && this.saveLayout) {
            DataRow row = LayoutDataSource.NewRow();
            row["Date"] = DateTime.Now.ToString();
            row["LayoutString"] = e.LayoutData;
            LayoutDataSource.Rows.Add(row);
        }
        if (e.LayoutMode == ClientLayoutMode.Loading && grid.Selection.Count != 0) {
            e.LayoutData = grid.GetSelectedFieldValues("LayoutString")[0].ToString();
        }
    }
    protected void ASPxCallbackPanel1_Callback(object sender, CallbackEventArgsBase e) {
        if (e.Parameter == "")
            return;
        
        string layout = grid.GetRowValues(Convert.ToInt32(e.Parameter), "LayoutString").ToString();
        LayoutDataParser parser = new LayoutDataParser();
        List<DockPanel> list = parser.GetPanelsInfo(layout);

        foreach (DockPanel panel in list) {
            ASPxDockPanel dockPanel = ASPxDockManager1.FindPanelByUID(panel.PanelUID);
            dockPanel.ShowOnPageLoad = panel.ShowOnPageLoad;
            dockPanel.AllowedDockState = ConvertToDockState(panel.DockState);
            dockPanel.OwnerZoneUID = panel.OwnerZoneUID;
            dockPanel.Width = panel.Width;
            dockPanel.Height = panel.Height;
            dockPanel.Top = panel.Top;
            dockPanel.Left = panel.Left;
            dockPanel.VisibleIndex = panel.VisibleIndex;
        }
    }

    private AllowedDockState ConvertToDockState(string value) {
        AllowedDockState state = AllowedDockState.All;
        switch (value) {
            case "All":
                state = AllowedDockState.All;
                break;
            case "DockedOnly":
                state = AllowedDockState.DockedOnly;
                break;
            case "FloatOnly":
                state = AllowedDockState.FloatOnly;
                break;
        }
        return state;
    }
}