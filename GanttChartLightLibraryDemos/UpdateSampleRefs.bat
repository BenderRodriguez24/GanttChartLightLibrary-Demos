for /d %%t in ("C:\GCLL-Demos\GanttChartLightLibraryDemos\Demos\Samples\*") do for /d %%c in ("%%t\*") do for /d %%f in (%%c\*) do cd %%f & "C:\GCLL-Demos\GanttChartLightLibraryDemos\Demos\Tools\SampleUpdater.exe" ref DlhSoft.HierarchicalData.LightWPF.Controls:4.0.10.0:4.0.10.1:4.0.10:4.0.10.1 DlhSoft.ProjectData.GanttChart.LightWPF.Controls:4.3.42.0:4.3.42.1:4.3.42:4.3.42.1 DlhSoft.ProjectData.PertChart.LightWPF.Controls:4.3.42.0:4.3.42.1:4.3.42:4.3.42.1