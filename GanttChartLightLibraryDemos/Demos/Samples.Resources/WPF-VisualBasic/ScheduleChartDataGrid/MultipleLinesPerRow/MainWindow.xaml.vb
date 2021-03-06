﻿Imports DlhSoft.Windows.Controls

''' <summary>
''' Interaction logic for MainWindow.xaml
''' </summary>
Partial Public Class MainWindow
    Inherits Window

    Public Sub New()
        InitializeComponent()

        Dim task1 As GanttChartItem = ScheduleChartDataGrid.Items(0).GanttChartItems(0)
        task1.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        task1.Finish = Date.Today.Add(TimeSpan.Parse("16:00:00"))
        task1.CompletedFinish = Date.Today.Add(TimeSpan.Parse("12:00:00"))

        Dim task21 As GanttChartItem = ScheduleChartDataGrid.Items(0).GanttChartItems(1)
        task21.Start = Date.Today.Add(TimeSpan.Parse("12:00:00"))
        task21.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"))
        task21.AssignmentsContent = "50%"

        Dim task22 As GanttChartItem = ScheduleChartDataGrid.Items(1).GanttChartItems(0)
        task22.Start = Date.Today.AddDays(1).Add(TimeSpan.Parse("12:00:00"))
        task22.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"))

        Dim task3 As GanttChartItem = ScheduleChartDataGrid.Items(2).GanttChartItems(0)
        task3.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        task3.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("16:00:00"))

        Dim task4 As GanttChartItem = ScheduleChartDataGrid.Items(3).GanttChartItems(0)
        task4.Start = Date.Today.Add(TimeSpan.Parse("08:00:00"))
        task4.Finish = Date.Today.AddDays(1).Add(TimeSpan.Parse("16:00:00"))

        Dim task5 As GanttChartItem = ScheduleChartDataGrid.Items(3).GanttChartItems(1)
        task5.Start = Date.Today.AddDays(3).Add(TimeSpan.Parse("10:00:00"))
        task5.Finish = Date.Today.AddDays(3).Add(TimeSpan.Parse("16:00:00"))

        Dim task6 As GanttChartItem = ScheduleChartDataGrid.Items(3).GanttChartItems(2)
        task6.Start = Date.Today.AddDays(1).Add(TimeSpan.Parse("12:00:00"))
        task6.Finish = Date.Today.AddDays(2).Add(TimeSpan.Parse("12:00:00"))

        For i As Integer = 5 To 16
            Dim item As ScheduleChartItem = New ScheduleChartItem With {.Content = "Resource " & i}
            For j As Integer = 1 To (i - 1) Mod 4 + 1
                item.GanttChartItems.Add(New GanttChartItem With {.Content = "Task " & i & "." & j, .Start = Date.Today.AddDays(i + (i - 1) * (j - 1)), .Finish = Date.Today.AddDays(i * 2 + (i - 1) * (j - 1) + 1), .CompletedFinish = Date.Today.AddDays(i + (i - 1) * (j - 1)).AddDays(If((i + j) Mod 5 = 2, 2, 0))})
            Next j
            ScheduleChartDataGrid.Items.Add(item)
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
        ScheduleChartDataGrid.Resources.MergedDictionaries.Add(themeResourceDictionary)
    End Sub
End Class
