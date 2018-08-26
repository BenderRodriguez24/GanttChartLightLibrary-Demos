﻿
'------------------------------------------------------------------------------
' <auto-generated>
'    This code was generated from a template.
'
'    Manual changes to this file may cause unexpected behavior in your application.
'    Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.ComponentModel
Imports System.Data.EntityClient
Imports System.Data.Objects
Imports System.Data.Objects.DataClasses
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.Xml.Serialization


<Assembly: EdmSchemaAttribute("c8b29149-76fc-4725-8a89-a8ceed99457f")>
#Region "EDM Relationship Metadata"
<Assembly: EdmRelationshipAttribute("DatabaseModel", "Tasks_PredecessorHosts", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Task), "Predecessor", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Predecessor), True)>
<Assembly: EdmRelationshipAttribute("DatabaseModel", "Tasks_Predecessors", "Task", System.Data.Metadata.Edm.RelationshipMultiplicity.One, GetType(Task), "Predecessor", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, GetType(Predecessor), True)>

#End Region

#Region "Contexts"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
Public Partial Class DatabaseEntities
    Inherits ObjectContext

    #Region "Constructors"

    ''' <summary>
    ''' Initializes a new DatabaseEntities object using the connection string found in the 'DatabaseEntities' section of the application configuration file.
    ''' </summary>
    Public Sub New()
        MyBase.New("name=DatabaseEntities", "DatabaseEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new DatabaseEntities object.
    ''' </summary>
    Public Sub New(ByVal connectionString As String)
        MyBase.New(connectionString, "DatabaseEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    ''' <summary>
    ''' Initialize a new DatabaseEntities object.
    ''' </summary>
    Public Sub New(ByVal connection As EntityConnection)
        MyBase.New(connection, "DatabaseEntities")
        MyBase.ContextOptions.LazyLoadingEnabled = true
        OnContextCreated()
    End Sub

    #End Region

    #Region "Partial Methods"

    Partial Private Sub OnContextCreated()
    End Sub

    #End Region

    #Region "ObjectSet Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Public ReadOnly Property Predecessors() As ObjectSet(Of Predecessor)
        Get
            If (_Predecessors Is Nothing) Then
                _Predecessors = MyBase.CreateObjectSet(Of Predecessor)("Predecessors")
            End If
            Return _Predecessors
        End Get
    End Property

    Private _Predecessors As ObjectSet(Of Predecessor)

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    Public ReadOnly Property Tasks() As ObjectSet(Of Task)
        Get
            If (_Tasks Is Nothing) Then
                _Tasks = MyBase.CreateObjectSet(Of Task)("Tasks")
            End If
            Return _Tasks
        End Get
    End Property

    Private _Tasks As ObjectSet(Of Task)

    #End Region

    #Region "AddTo Methods"

    ''' <summary>
    ''' Deprecated Method for adding a new object to the Predecessors EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
    ''' </summary>
    Public Sub AddToPredecessors(ByVal predecessor As Predecessor)
        MyBase.AddObject("Predecessors", predecessor)
    End Sub

    ''' <summary>
    ''' Deprecated Method for adding a new object to the Tasks EntitySet. Consider using the .Add method of the associated ObjectSet(Of T) property instead.
    ''' </summary>
    Public Sub AddToTasks(ByVal task As Task)
        MyBase.AddObject("Tasks", task)
    End Sub

    #End Region

End Class

#End Region

#Region "Entities"

''' <summary>
''' No Metadata Documentation available.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="DatabaseModel", Name:="Predecessor")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class Predecessor
    Inherits EntityObject
    #Region "Factory Method"

    ''' <summary>
    ''' Create a new Predecessor object.
    ''' </summary>
    ''' <param name="dependentTaskID">Initial value of the DependentTaskID property.</param>
    ''' <param name="predecessorTaskID">Initial value of the PredecessorTaskID property.</param>
    ''' <param name="dependencyType">Initial value of the DependencyType property.</param>
    Public Shared Function CreatePredecessor(dependentTaskID As Global.System.Int32, predecessorTaskID As Global.System.Int32, dependencyType As Global.System.Int32) As Predecessor
        Dim predecessor as Predecessor = New Predecessor
        predecessor.DependentTaskID = dependentTaskID
        predecessor.PredecessorTaskID = predecessorTaskID
        predecessor.DependencyType = dependencyType
        Return predecessor
    End Function

    #End Region

    #Region "Primitive Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property DependentTaskID() As Global.System.Int32
        Get
            Return _DependentTaskID
        End Get
        Set
            If (_DependentTaskID <> Value) Then
                OnDependentTaskIDChanging(value)
                ReportPropertyChanging("DependentTaskID")
                _DependentTaskID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("DependentTaskID")
                OnDependentTaskIDChanged()
            End If
        End Set
    End Property

    Private _DependentTaskID As Global.System.Int32
    Private Partial Sub OnDependentTaskIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnDependentTaskIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property PredecessorTaskID() As Global.System.Int32
        Get
            Return _PredecessorTaskID
        End Get
        Set
            If (_PredecessorTaskID <> Value) Then
                OnPredecessorTaskIDChanging(value)
                ReportPropertyChanging("PredecessorTaskID")
                _PredecessorTaskID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("PredecessorTaskID")
                OnPredecessorTaskIDChanged()
            End If
        End Set
    End Property

    Private _PredecessorTaskID As Global.System.Int32
    Private Partial Sub OnPredecessorTaskIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnPredecessorTaskIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property DependencyType() As Global.System.Int32
        Get
            Return _DependencyType
        End Get
        Set
            OnDependencyTypeChanging(value)
            ReportPropertyChanging("DependencyType")
            _DependencyType = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("DependencyType")
            OnDependencyTypeChanged()
        End Set
    End Property

    Private _DependencyType As Global.System.Int32
    Private Partial Sub OnDependencyTypeChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnDependencyTypeChanged()
    End Sub

    #End Region

    #Region "Navigation Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("DatabaseModel", "Tasks_PredecessorHosts", "Task")>
    Public Property DependentTask() As Task
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_PredecessorHosts", "Task").Value
        End Get
        Set
            CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_PredecessorHosts", "Task").Value = value
        End Set
    End Property
    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <BrowsableAttribute(False)>
    <DataMemberAttribute()>
    Public Property DependentTaskReference() As EntityReference(Of Task)
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_PredecessorHosts", "Task")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedReference(Of Task)("DatabaseModel.Tasks_PredecessorHosts", "Task", value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("DatabaseModel", "Tasks_Predecessors", "Task")>
    Public Property Task() As Task
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_Predecessors", "Task").Value
        End Get
        Set
            CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_Predecessors", "Task").Value = value
        End Set
    End Property
    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <BrowsableAttribute(False)>
    <DataMemberAttribute()>
    Public Property TaskReference() As EntityReference(Of Task)
        Get
            Return CType(Me, IEntityWithRelationships).RelationshipManager.GetRelatedReference(Of Task)("DatabaseModel.Tasks_Predecessors", "Task")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedReference(Of Task)("DatabaseModel.Tasks_Predecessors", "Task", value)
            End If
        End Set
    End Property

    #End Region

End Class

''' <summary>
''' No Metadata Documentation available.
''' </summary>
<EdmEntityTypeAttribute(NamespaceName:="DatabaseModel", Name:="Task")>
<Serializable()>
<DataContractAttribute(IsReference:=True)>
Public Partial Class Task
    Inherits EntityObject
    #Region "Factory Method"

    ''' <summary>
    ''' Create a new Task object.
    ''' </summary>
    ''' <param name="id">Initial value of the ID property.</param>
    ''' <param name="index">Initial value of the Index property.</param>
    ''' <param name="name">Initial value of the Name property.</param>
    ''' <param name="indentation">Initial value of the Indentation property.</param>
    ''' <param name="start">Initial value of the Start property.</param>
    ''' <param name="finish">Initial value of the Finish property.</param>
    ''' <param name="completion">Initial value of the Completion property.</param>
    ''' <param name="isMilestone">Initial value of the IsMilestone property.</param>
    ''' <param name="assignments">Initial value of the Assignments property.</param>
    Public Shared Function CreateTask(id As Global.System.Int32, index As Global.System.Int32, name As Global.System.String, indentation As Global.System.Int32, start As Global.System.DateTime, finish As Global.System.DateTime, completion As Global.System.DateTime, isMilestone As Global.System.Boolean, assignments As Global.System.String) As Task
        Dim task as Task = New Task
        task.ID = id
        task.Index = index
        task.Name = name
        task.Indentation = indentation
        task.Start = start
        task.Finish = finish
        task.Completion = completion
        task.IsMilestone = isMilestone
        task.Assignments = assignments
        Return task
    End Function

    #End Region

    #Region "Primitive Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=true, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property ID() As Global.System.Int32
        Get
            Return _ID
        End Get
        Set
            If (_ID <> Value) Then
                OnIDChanging(value)
                ReportPropertyChanging("ID")
                _ID = StructuralObject.SetValidValue(value)
                ReportPropertyChanged("ID")
                OnIDChanged()
            End If
        End Set
    End Property

    Private _ID As Global.System.Int32
    Private Partial Sub OnIDChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnIDChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Index() As Global.System.Int32
        Get
            Return _Index
        End Get
        Set
            OnIndexChanging(value)
            ReportPropertyChanging("Index")
            _Index = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("Index")
            OnIndexChanged()
        End Set
    End Property

    Private _Index As Global.System.Int32
    Private Partial Sub OnIndexChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnIndexChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Name() As Global.System.String
        Get
            Return _Name
        End Get
        Set
            OnNameChanging(value)
            ReportPropertyChanging("Name")
            _Name = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Name")
            OnNameChanged()
        End Set
    End Property

    Private _Name As Global.System.String
    Private Partial Sub OnNameChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnNameChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Indentation() As Global.System.Int32
        Get
            Return _Indentation
        End Get
        Set
            OnIndentationChanging(value)
            ReportPropertyChanging("Indentation")
            _Indentation = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("Indentation")
            OnIndentationChanged()
        End Set
    End Property

    Private _Indentation As Global.System.Int32
    Private Partial Sub OnIndentationChanging(value As Global.System.Int32)
    End Sub

    Private Partial Sub OnIndentationChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Start() As Global.System.DateTime
        Get
            Return _Start
        End Get
        Set
            OnStartChanging(value)
            ReportPropertyChanging("Start")
            _Start = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("Start")
            OnStartChanged()
        End Set
    End Property

    Private _Start As Global.System.DateTime
    Private Partial Sub OnStartChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnStartChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Finish() As Global.System.DateTime
        Get
            Return _Finish
        End Get
        Set
            OnFinishChanging(value)
            ReportPropertyChanging("Finish")
            _Finish = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("Finish")
            OnFinishChanged()
        End Set
    End Property

    Private _Finish As Global.System.DateTime
    Private Partial Sub OnFinishChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnFinishChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Completion() As Global.System.DateTime
        Get
            Return _Completion
        End Get
        Set
            OnCompletionChanging(value)
            ReportPropertyChanging("Completion")
            _Completion = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("Completion")
            OnCompletionChanged()
        End Set
    End Property

    Private _Completion As Global.System.DateTime
    Private Partial Sub OnCompletionChanging(value As Global.System.DateTime)
    End Sub

    Private Partial Sub OnCompletionChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property IsMilestone() As Global.System.Boolean
        Get
            Return _IsMilestone
        End Get
        Set
            OnIsMilestoneChanging(value)
            ReportPropertyChanging("IsMilestone")
            _IsMilestone = StructuralObject.SetValidValue(value)
            ReportPropertyChanged("IsMilestone")
            OnIsMilestoneChanged()
        End Set
    End Property

    Private _IsMilestone As Global.System.Boolean
    Private Partial Sub OnIsMilestoneChanging(value As Global.System.Boolean)
    End Sub

    Private Partial Sub OnIsMilestoneChanged()
    End Sub

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <EdmScalarPropertyAttribute(EntityKeyProperty:=false, IsNullable:=false)>
    <DataMemberAttribute()>
    Public Property Assignments() As Global.System.String
        Get
            Return _Assignments
        End Get
        Set
            OnAssignmentsChanging(value)
            ReportPropertyChanging("Assignments")
            _Assignments = StructuralObject.SetValidValue(value, false)
            ReportPropertyChanged("Assignments")
            OnAssignmentsChanged()
        End Set
    End Property

    Private _Assignments As Global.System.String
    Private Partial Sub OnAssignmentsChanging(value As Global.System.String)
    End Sub

    Private Partial Sub OnAssignmentsChanged()
    End Sub

    #End Region

    #Region "Navigation Properties"

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("DatabaseModel", "Tasks_PredecessorHosts", "Predecessor")>
     Public Property Predecessors() As EntityCollection(Of Predecessor)
        Get
            Return CType(Me,IEntityWithRelationships).RelationshipManager.GetRelatedCollection(Of Predecessor)("DatabaseModel.Tasks_PredecessorHosts", "Predecessor")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedCollection(Of Predecessor)("DatabaseModel.Tasks_PredecessorHosts", "Predecessor", value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' No Metadata Documentation available.
    ''' </summary>
    <XmlIgnoreAttribute()>
    <SoapIgnoreAttribute()>
    <DataMemberAttribute()>
    <EdmRelationshipNavigationPropertyAttribute("DatabaseModel", "Tasks_Predecessors", "Predecessor")>
     Public Property Successors() As EntityCollection(Of Predecessor)
        Get
            Return CType(Me,IEntityWithRelationships).RelationshipManager.GetRelatedCollection(Of Predecessor)("DatabaseModel.Tasks_Predecessors", "Predecessor")
        End Get
        Set
            If (Not value Is Nothing)
                CType(Me, IEntityWithRelationships).RelationshipManager.InitializeRelatedCollection(Of Predecessor)("DatabaseModel.Tasks_Predecessors", "Predecessor", value)
            End If
        End Set
    End Property

    #End Region

End Class

#End Region


