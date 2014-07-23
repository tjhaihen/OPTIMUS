Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Company
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _companyID, _companyCode, _companyName As String
        Private _taxRegisterNo, _address1, _address2, _address3 As String
        Private _city, _postalCode, _phone, _fax, _email, _url As String
        Private _establishedDate As DateTime        
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " Update "
        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Company " + _
                                        "SET companyCode=@companyCode, companyName=@companyName, " + _
                                        "taxRegisterNo=@taxRegisterNo, address1=@address1, address2=@address2, address3=@address3, " + _
                                        "city=@city, postalCode=@postalCode, phone=@phone, fax=@fax, email=@email, url=@url, " + _
                                        "establishedDate=@establishedDate " + _
                                        "WHERE companyID=@companyID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@companyID", _companyID)
                cmdToExecute.Parameters.AddWithValue("@companyCode", _companyCode)
                cmdToExecute.Parameters.AddWithValue("@companyName", _companyName)
                cmdToExecute.Parameters.AddWithValue("@taxRegisterNo", _taxRegisterNo)
                cmdToExecute.Parameters.AddWithValue("@address1", _address1)
                cmdToExecute.Parameters.AddWithValue("@address2", _address2)
                cmdToExecute.Parameters.AddWithValue("@address3", _address3)
                cmdToExecute.Parameters.AddWithValue("@city", _city)
                cmdToExecute.Parameters.AddWithValue("@postalCode", _postalCode)
                cmdToExecute.Parameters.AddWithValue("@phone", _phone)
                cmdToExecute.Parameters.AddWithValue("@fax", _fax)
                cmdToExecute.Parameters.AddWithValue("@email", _email)
                cmdToExecute.Parameters.AddWithValue("@url", _url)
                cmdToExecute.Parameters.AddWithValue("@establishedDate", _establishedDate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try

        End Function
#End Region

#Region " Select One "
        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT TOP 1 * FROM Company"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Company")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _companyID = CType(toReturn.Rows(0)("companyID"), String)
                    _companyCode = CType(toReturn.Rows(0)("companyCode"), String)
                    _companyName = CType(toReturn.Rows(0)("companyName"), String)
                    _taxRegisterNo = CType(toReturn.Rows(0)("taxRegisterNo"), String)
                    _address1 = CType(toReturn.Rows(0)("address1"), String)
                    _address2 = CType(toReturn.Rows(0)("address2"), String)
                    _address3 = CType(toReturn.Rows(0)("address3"), String)
                    _city = CType(toReturn.Rows(0)("city"), String)
                    _postalCode = CType(toReturn.Rows(0)("postalCode"), String)
                    _phone = CType(toReturn.Rows(0)("phone"), String)
                    _fax = CType(toReturn.Rows(0)("fax"), String)
                    _email = CType(toReturn.Rows(0)("email"), String)
                    _url = CType(toReturn.Rows(0)("url"), String)
                    _establishedDate = CType(toReturn.Rows(0)("establishedDate"), DateTime)
                End If                
            Catch ex As Exception
                ' // some error occured. Bubble it to caller and encapsulate Exception object
                ExceptionManager.Publish(ex)
            Finally
                ' // Close connection.
                _mainConnection.Close()
                cmdToExecute.Dispose()
                adapter.Dispose()
            End Try

            Return toReturn
        End Function
#End Region

#Region " Class Property Declarations "

        Public Property [companyID]() As String
            Get
                Return _companyID
            End Get
            Set(ByVal Value As String)
                _companyID = Value
            End Set
        End Property

        Public Property [companyCode]() As String
            Get
                Return _companyCode
            End Get
            Set(ByVal Value As String)
                _companyCode = Value
            End Set
        End Property

        Public Property [companyName]() As String
            Get
                Return _companyName
            End Get
            Set(ByVal Value As String)
                _companyName = Value
            End Set
        End Property

        Public Property [taxRegisterNo]() As String
            Get
                Return _taxRegisterNo
            End Get
            Set(ByVal Value As String)
                _taxRegisterNo = Value
            End Set
        End Property

        Public Property [address1]() As String
            Get
                Return _address1
            End Get
            Set(ByVal Value As String)
                _address1 = Value
            End Set
        End Property

        Public Property [address2]() As String
            Get
                Return _address2
            End Get
            Set(ByVal Value As String)
                _address2 = Value
            End Set
        End Property

        Public Property [address3]() As String
            Get
                Return _address3
            End Get
            Set(ByVal Value As String)
                _address3 = Value
            End Set
        End Property

        Public Property [city]() As String
            Get
                Return _city
            End Get
            Set(ByVal Value As String)
                _city = Value
            End Set
        End Property

        Public Property [postalCode]() As String
            Get
                Return _postalCode
            End Get
            Set(ByVal Value As String)
                _postalCode = Value
            End Set
        End Property

        Public Property [phone]() As String
            Get
                Return _phone
            End Get
            Set(ByVal Value As String)
                _phone = Value
            End Set
        End Property

        Public Property [fax]() As String
            Get
                Return _fax
            End Get
            Set(ByVal Value As String)
                _fax = Value
            End Set
        End Property

        Public Property [email]() As String
            Get
                Return _email
            End Get
            Set(ByVal Value As String)
                _email = Value
            End Set
        End Property

        Public Property [url]() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property [establishedDate]() As DateTime
            Get
                Return _establishedDate
            End Get
            Set(ByVal Value As DateTime)
                _establishedDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
