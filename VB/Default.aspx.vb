Imports DevExpress.Web
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Private saveLayout As Boolean = False
    Private Property LayoutDataSource() As DataTable
        Get
            If Session("layout") Is Nothing Then
                Dim table As New DataTable()
                table.Columns.Add("Date")
                table.Columns.Add("LayoutString")
                Session("layout") = table
            End If
            Return TryCast(Session("layout"), DataTable)
        End Get
        Set(ByVal value As DataTable)
            Session("layout") = value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        If Not IsPostBack Then
            Session.Clear()
        End If

        grid.DataBind()
    End Sub
    Protected Sub grid_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        grid.DataSource = LayoutDataSource
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs)
        grid.Selection.UnselectAll()
        saveLayout = True
    End Sub
    Protected Sub ASPxDockManager1_ClientLayout(ByVal sender As Object, ByVal e As ASPxClientLayoutArgs)
        If e.LayoutMode = ClientLayoutMode.Saving AndAlso Me.saveLayout Then
            Dim row As DataRow = LayoutDataSource.NewRow()
            row("Date") = Date.Now.ToString()
            row("LayoutString") = e.LayoutData
            LayoutDataSource.Rows.Add(row)
        End If
        If e.LayoutMode = ClientLayoutMode.Loading AndAlso grid.Selection.Count <> 0 Then
            e.LayoutData = grid.GetSelectedFieldValues("LayoutString")(0).ToString()
        End If
    End Sub
    Protected Sub ASPxCallbackPanel1_Callback(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
        If e.Parameter = "" Then
            Return
        End If

        Dim layout As String = grid.GetRowValues(Convert.ToInt32(e.Parameter), "LayoutString").ToString()
        Dim parser As New LayoutDataParser()
        Dim list As List(Of DockPanel) = parser.GetPanelsInfo(layout)

        For Each panel As DockPanel In list
            Dim dockPanel As ASPxDockPanel = ASPxDockManager1.FindPanelByUID(panel.PanelUID)
            dockPanel.ShowOnPageLoad = panel.ShowOnPageLoad
            dockPanel.AllowedDockState = ConvertToDockState(panel.DockState)
            dockPanel.OwnerZoneUID = panel.OwnerZoneUID
            dockPanel.Width = panel.Width
            dockPanel.Height = panel.Height
            dockPanel.Top = panel.Top
            dockPanel.Left = panel.Left
            dockPanel.VisibleIndex = panel.VisibleIndex
        Next panel
    End Sub

    Private Function ConvertToDockState(ByVal value As String) As AllowedDockState
        Dim state As AllowedDockState = AllowedDockState.All
        Select Case value
            Case "All"
                state = AllowedDockState.All
            Case "DockedOnly"
                state = AllowedDockState.DockedOnly
            Case "FloatOnly"
                state = AllowedDockState.FloatOnly
        End Select
        Return state
    End Function
End Class