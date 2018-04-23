using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DockPanel {
    public string PanelUID { get; set; }
    public bool ShowOnPageLoad { get; set; }
    public string DockState { get; set; }
    public string OwnerZoneUID { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public int Left { get; set; }
    public int Top { get; set; }
    public int VisibleIndex { get; set; }
}

public class LayoutDataParser {
    public List<DockPanel> GetPanelsInfo(string layoutData) {
        List<DockPanel> list = new List<DockPanel>();

        string[] separators = new string[] { "{", "}", "'", "[", "px" };
        string[] temp = layoutData.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        string layoutString = String.Join("", temp);

        string[] panelsInfo = layoutString.Split(new string[] { "]," }, StringSplitOptions.None);
        foreach (string panel in panelsInfo) {
            string[] properties = panel.Split(':');
            DockPanel dockPanel = new DockPanel();
            dockPanel.PanelUID = properties[0];

            string[] values = properties[1].Split(',');
            dockPanel.ShowOnPageLoad = Convert.ToBoolean(values[0]);
            dockPanel.DockState = values[1];
            dockPanel.OwnerZoneUID = values[2];
            if (values[3] != "")
                dockPanel.Width = Convert.ToInt32(values[3]);
            if (values[4] != "")
                dockPanel.Height = Convert.ToInt32(values[4]);
            dockPanel.Left = Convert.ToInt32(values[5]);
            dockPanel.Top = Convert.ToInt32(values[6]);
            if (values[7].Contains("]"))
                dockPanel.VisibleIndex = Convert.ToInt32(values[7].Replace("]", ""));
            else
                dockPanel.VisibleIndex = Convert.ToInt32(values[7]);

            list.Add(dockPanel);
        }
        return list;
    }
}