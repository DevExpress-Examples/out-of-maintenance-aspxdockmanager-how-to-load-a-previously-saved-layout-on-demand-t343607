Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Public Class DockPanel
    Public Property PanelUID() As String
    Public Property ShowOnPageLoad() As Boolean
    Public Property DockState() As String
    Public Property OwnerZoneUID() As String
    Public Property Width() As Integer
    Public Property Height() As Integer
    Public Property Left() As Integer
    Public Property Top() As Integer
    Public Property VisibleIndex() As Integer
End Class

Public Class LayoutDataParser
    Public Function GetPanelsInfo(ByVal layoutData As String) As List(Of DockPanel)
        Dim list As New List(Of DockPanel)()

        Dim separators() As String = { "{", "}", "'", "[", "px" }
        Dim temp() As String = layoutData.Split(separators, StringSplitOptions.RemoveEmptyEntries)
        Dim layoutString As String = String.Join("", temp)

        Dim panelsInfo() As String = layoutString.Split(New String() { "]," }, StringSplitOptions.None)
        For Each panel As String In panelsInfo
            Dim properties() As String = panel.Split(":"c)
            Dim dockPanel As New DockPanel()
            dockPanel.PanelUID = properties(0)

            Dim values() As String = properties(1).Split(","c)
            dockPanel.ShowOnPageLoad = Convert.ToBoolean(values(0))
            dockPanel.DockState = values(1)
            dockPanel.OwnerZoneUID = values(2)
            If values(3) <> "" Then
                dockPanel.Width = Convert.ToInt32(values(3))
            End If
            If values(4) <> "" Then
                dockPanel.Height = Convert.ToInt32(values(4))
            End If
            dockPanel.Left = Convert.ToInt32(values(5))
            dockPanel.Top = Convert.ToInt32(values(6))
            If values(7).Contains("]") Then
                dockPanel.VisibleIndex = Convert.ToInt32(values(7).Replace("]", ""))
            Else
                dockPanel.VisibleIndex = Convert.ToInt32(values(7))
            End If

            list.Add(dockPanel)
        Next panel
        Return list
    End Function
End Class