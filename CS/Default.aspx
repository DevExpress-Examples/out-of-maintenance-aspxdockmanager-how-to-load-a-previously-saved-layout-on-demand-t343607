<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.20.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function OnInit(s, e) {
            s.Refresh();
        }
        function OnSelectionChanged(s, e) {
            if (e.isSelected) {
                panel.PerformCallback(e.visibleIndex);
            }
        }
    </script>
    <style type="text/css">
        td {
            vertical-align: top;
            padding: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <dx:ASPxGridView ID="grid" runat="server" KeyFieldName="Date" AutoGenerateColumns="false"
                        OnDataBinding="grid_DataBinding" ClientInstanceName="grid" Width="235px">
                        <SettingsBehavior AllowSelectByRowClick="true" AllowSelectSingleRowOnly="true" />
                        <ClientSideEvents Init="OnInit" SelectionChanged="OnSelectionChanged" />
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="Date"></dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                    <br />
                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save Layout" OnClick="btnSave_Click">
                    </dx:ASPxButton>
                </td>
                <td rowspan="2">
                    <dx:ASPxCallbackPanel ID="ASPxCallbackPanel1" runat="server" ClientInstanceName="panel" OnCallback="ASPxCallbackPanel1_Callback">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <dx:ASPxDockManager ID="ASPxDockManager1" runat="server" OnClientLayout="ASPxDockManager1_ClientLayout">
                                </dx:ASPxDockManager>
                                <table>
                                    <tr>
                                        <td colspan="2">
                                            <dx:ASPxDockZone ID="dockZone1" runat="server" BackColor="#ffffcc" Height="100px" Width="100%">
                                            </dx:ASPxDockZone>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <dx:ASPxDockZone ID="dockZone2" runat="server" BackColor="#99ccff" Height="200px" Width="200px">
                                            </dx:ASPxDockZone>
                                        </td>
                                        <td>
                                            <dx:ASPxDockZone ID="dockZone3" runat="server" BackColor="#99ff99" Height="200px" Width="200px">
                                            </dx:ASPxDockZone>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <dx:ASPxDockZone ID="dockZone4" runat="server" BackColor="#ffcccc" Height="100px" Width="100%">
                                            </dx:ASPxDockZone>
                                        </td>
                                    </tr>
                                </table>
                                <dx:ASPxDockPanel ID="ASPxDockPanel1" runat="server" AllowResize="true" OwnerZoneUID="dockZone1">
                                    <ContentCollection>
                                        <dx:PopupControlContentControl runat="server">Panel 1</dx:PopupControlContentControl>
                                    </ContentCollection>
                                </dx:ASPxDockPanel>

                                <dx:ASPxDockPanel ID="ASPxDockPanel2" runat="server" AllowResize="true" OwnerZoneUID="dockZone2">
                                    <ContentCollection>
                                        <dx:PopupControlContentControl runat="server">Panel 2</dx:PopupControlContentControl>
                                    </ContentCollection>
                                </dx:ASPxDockPanel>

                                <dx:ASPxDockPanel ID="ASPxDockPanel3" runat="server" AllowResize="true" OwnerZoneUID="dockZone3">
                                    <ContentCollection>
                                        <dx:PopupControlContentControl runat="server">Panel 3</dx:PopupControlContentControl>
                                    </ContentCollection>
                                </dx:ASPxDockPanel>

                                <dx:ASPxDockPanel ID="ASPxDockPanel4" runat="server" AllowResize="true" OwnerZoneUID="dockZone4">
                                    <ContentCollection>
                                        <dx:PopupControlContentControl runat="server">Panel 4</dx:PopupControlContentControl>
                                    </ContentCollection>
                                </dx:ASPxDockPanel>
                            </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxCallbackPanel>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
