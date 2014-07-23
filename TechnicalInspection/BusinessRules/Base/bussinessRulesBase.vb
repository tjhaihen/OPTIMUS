Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes

Imports Raven.Common

Namespace Raven.BussinessRules
    Public Enum RavenBRErr
        AllOk
        ' // Add more here (check the comma's!)
    End Enum

    Public Enum RavenRecStatus
        CurrentRecord = 0
        NextRecord = 1
        PreviousRecord = 2
    End Enum

    Public Interface ICommonDBAccess
        Function Insert() As Boolean
        Function Update() As Boolean
        Function Delete() As Boolean
        Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
        Function SelectAll() As DataTable
    End Interface


    Public MustInherit Class BRInteractionBase
        Implements IDisposable
        Implements ICommonDBAccess

#Region " Class Member Declarations "

        Protected _mainConnection As SqlConnection
        Protected _errorCode As SqlInt32
        Protected _transaction As SqlTransaction
        Private _connectionString As String
        Private _isDisposed As Boolean

#End Region


        Public Sub New()
            ' // Initialize the class' members.
            InitClass()
        End Sub


        Private Sub InitClass()
            ' // create all the objects and initialize other members.
            _mainConnection = New SqlConnection()
            _errorCode = New SqlInt32(RavenBRErr.AllOk)
            _isDisposed = False
            ' // default connectionstring, from configuration file..!!
            Me.ConnectionString = SysConfig.ConnectionString
        End Sub


        Public Overloads Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub

        Protected Overridable Overloads Sub Begintrans()
            _transaction = _mainConnection.BeginTransaction
        End Sub

        Protected Overridable Overloads Sub CommitTrans()
            _transaction.Commit()
        End Sub

        Protected Overridable Overloads Sub RollBackTrans()
            _transaction.Rollback()
        End Sub

        Protected Overridable Overloads Sub Dispose(ByVal isDisposing As Boolean)
            If Not _isDisposed Then
                If isDisposing Then
                    If Not _mainConnection Is Nothing Then
                        _mainConnection.Dispose()
                    End If
                    If Not _transaction Is Nothing Then
                        _transaction.Dispose()
                    End If

                    _mainConnection = Nothing
                    _transaction = Nothing
                End If
            End If
            _isDisposed = True
        End Sub


        Public Overridable Function Insert() As Boolean Implements ICommonDBAccess.Insert
            Throw New NotImplementedException()
        End Function


        Public Overridable Function Delete() As Boolean Implements ICommonDBAccess.Delete
            Throw New NotImplementedException()
        End Function


        Public Overridable Function Update() As Boolean Implements ICommonDBAccess.Update
            Throw New NotImplementedException()
        End Function


        Public Overridable Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable Implements ICommonDBAccess.SelectOne
            Throw New NotImplementedException()
        End Function


        Public Overridable Function SelectAll() As DataTable Implements ICommonDBAccess.SelectAll
            Throw New NotImplementedException()
        End Function


#Region " Class Property Declarations "

        Public ReadOnly Property ErrorCode() As SqlInt32
            Get
                Return _errorCode
            End Get
        End Property


        Public Property ConnectionString() As String
            Get
                Return _connectionString
            End Get
            Set(ByVal Value As String)
                _connectionString = Value
                _mainConnection.ConnectionString = _connectionString
            End Set
        End Property

#End Region

    End Class
End Namespace
