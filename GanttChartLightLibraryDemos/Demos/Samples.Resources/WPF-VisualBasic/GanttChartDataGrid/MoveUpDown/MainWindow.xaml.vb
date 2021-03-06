﻿Imports DlhSoft.Windows.Controls

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        Dim item0 As GanttChartItem = GanttChartDataGrid.Items(0)

        Dim item1 As GanttChartItem = GanttChartDataGrid.Items(1)
        item1.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        item1.Finish = Date.Today.Add(TimeSpan.Parse("16:00:00"))
        item1.CompletedFinish = Date.Today.Add(TimeSpan.Parse("12:00:00"))
        item1.AssignmentsContent = "Resource 1"

        Dim item2 As GanttChartItem = GanttChartDataGrid.Items(2)
        item2.Start = Date.Today.AddDays(1).Add(TimeSpan.Parse("08:00:00"))
        item2.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"))
        item2.AssignmentsContent = "Resource 1, Resource 2"
        item2.Predecessors.Add(New PredecessorItem With {.Item = item1})

        Dim item3 As GanttChartItem = GanttChartDataGrid.Items(3)
        item3.Predecessors.Add(New PredecessorItem With {.Item = item0, .DependencyType = DependencyType.StartStart})

        Dim item4 As GanttChartItem = GanttChartDataGrid.Items(4)
        item4.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        item4.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("12:00:00"))

        Dim item6 As GanttChartItem = GanttChartDataGrid.Items(6)
        item6.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        item6.Finish = Date.Today.AddDays(3).Add(TimeSpan.Parse("12:00:00"))

        Dim item7 As GanttChartItem = GanttChartDataGrid.Items(7)
        item7.Start = Date.Today.AddDays(4)
        item7.IsMilestone = True
        item7.Predecessors.Add(New PredecessorItem With {.Item = item4})
        item7.Predecessors.Add(New PredecessorItem With {.Item = item6})

        For i As Integer = 3 To 25
            GanttChartDataGrid.Items.Add(New GanttChartItem With {.Content = "Task " & i, .Indentation = If(i Mod 3 = 0, 0, 1), .Start = Date.Today.AddDays(If(i <= 8, (i - 4) * 2, i - 8)), .Finish = Date.Today.AddDays((If(i <= 8, (i - 4) * 2 + (If(i > 8, 6, 1)), i - 2)) + 2), .CompletedFinish = Date.Today.AddDays(If(i <= 8, (i - 4) * 2, i - 8)).AddDays(If(i Mod 6 = 4, 3, 0))})
        Next i
    End Sub

    Private theme As String = "Generic-bright"
    Public Sub New(theme As String)
        Me.New()
        Me.theme = theme
        ApplyTemplate()
    End Sub
    Public Overrides Sub OnApplyTemplate()
        LoadTheme()
        MyBase.OnApplyTemplate()
    End Sub
    Private Sub LoadTheme()
        If theme Is Nothing OrElse theme = "Default" OrElse theme = "Aero" Then
            Return
        End If
        Dim themeResourceDictionary = New ResourceDictionary With {.Source = New Uri("/" & Me.GetType().Assembly.GetName().Name & ";component/Themes/" & theme & ".xaml", UriKind.Relative)}
        GanttChartDataGrid.Resources.MergedDictionaries.Add(themeResourceDictionary)
    End Sub

    Private Sub MoveUpButton_Click(sender As Object, e As RoutedEventArgs)
        If GanttChartDataGrid.GetSelectedItemCount() <= 0 Then
            MessageBox.Show("Cannot move selected item(s) as the selection is empty; select an item first.", "Information", MessageBoxButton.OK)
            Return
        End If
        Dim selectedItems = GanttChartDataGrid.GetSelectedItems().ToArray()
        If selectedItems.Select(Function(i) i.Parent).Distinct().Count() > 1 Then
            MessageBox.Show("Cannot move selected item(s) as the selection includes items that have different parents; select only root items or only items having the same parent.", "Information", MessageBoxButton.OK)
            Return
        End If
        For Each item As GanttChartItem In selectedItems
            GanttChartDataGrid.MoveUp(item, True, True)
        Next item
        GanttChartDataGrid.SelectedItems.Clear()
        For Each item As GanttChartItem In selectedItems
            GanttChartDataGrid.SelectedItems.Add(item)
        Next item
    End Sub

    Private Sub MoveDownButton_Click(sender As Object, e As RoutedEventArgs)
        If GanttChartDataGrid.GetSelectedItemCount() <= 0 Then
            MessageBox.Show("Cannot move selected item(s) as the selection is empty; select an item first.", "Information", MessageBoxButton.OK)
            Return
        End If
        Dim selectedItems = GanttChartDataGrid.GetSelectedItems().Reverse().ToArray()
        If selectedItems.Select(Function(i) i.Parent).Distinct().Count() > 1 Then
            MessageBox.Show("Cannot move selected item(s) as the selection includes items that have different parents; select only root items or only items having the same parent.", "Information", MessageBoxButton.OK)
            Return
        End If
        For Each item As GanttChartItem In selectedItems
            GanttChartDataGrid.MoveDown(item, True, True)
        Next item
        GanttChartDataGrid.SelectedItems.Clear()
        For Each item As GanttChartItem In selectedItems
            GanttChartDataGrid.SelectedItems.Add(item)
        Next item
    End Sub
End Class
