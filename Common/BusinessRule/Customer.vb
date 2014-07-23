Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Customer
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _customerID, _parentCustomerID, _customerCode, _customerName, _address1, _address2, _address3 As String
        Private _city, _postalCode, _phone, _mobile, _fax, _email, _url As String
        Private _isActive As Boolean
        Private _userIDinsert, _userIDupdate As String
        Private _insertDate, _updateDate As DateTime
#End Region

        Public Sub New()
            ' // Nothing for now.
        End Sub

        Public Sub New(ByVal strConnectionString As String)
            ConnectionString = strConnectionString
        End Sub

#Region " C,R,U,D "
        Public Overrides Function Insert() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "INSERT INTO Customer " + _
                                        "(customerID, parentCustomerID, customerCode, customerName, " + _
                                        "address1, address2, address3, city, postalCode, phone, mobile, fax, email, url, " + _
                                        "isActive, userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@customerID, @parentCustomerID, @customerCode, @customerName, " + _
                                        "@address1, @address2, @address3, @city, @postalCode, @phone, @mobile, @fax, @email, @url, " + _
                                        "@isActive, @userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strcustomerID As String = ID.GenerateIDNumber("Customer", "customerID")

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", strcustomerID)
                cmdToExecute.Parameters.AddWithValue("@parentCustomerID", _parentCustomerID)
                cmdToExecute.Parameters.AddWithValue("@customerCode", _customerCode)
                cmdToExecute.Parameters.AddWithValue("@customerName", _customerName)
                cmdToExecute.Parameters.AddWithValue("@address1", _address1)
                cmdToExecute.Parameters.AddWithValue("@address2", _address2)
                cmdToExecute.Parameters.AddWithValue("@address3", _address3)
                cmdToExecute.Parameters.AddWithValue("@city", _city)
                cmdToExecute.Parameters.AddWithValue("@postalCode", _postalCode)
                cmdToExecute.Parameters.AddWithValue("@phone", _phone)
                cmdToExecute.Parameters.AddWithValue("@mobile", _mobile)
                cmdToExecute.Parameters.AddWithValue("@fax", _fax)
                cmdToExecute.Parameters.AddWithValue("@email", _email)
                cmdToExecute.Parameters.AddWithValue("@url", _url)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _customerID = strcustomerID
                Return True
            Catch ex As Exception
                ExceptionManager.Publish(ex)
            Finally
                _mainConnection.Close()
                cmdToExecute.Dispose()
            End Try
        End Function

        Public Overrides Function Update() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE customer " + _
                                        "SET parentCustomerID=@parentCustomerID, customerCode=@customerCode, customerName=@customerName, " + _
                                        "address1=@address1, address2=@address2, address3=@address3, " + _
                                        "city=@city, postalCode=@postalCode, phone=@phone, mobile=@mobile, fax=@fax, email=@email, url=@url, " + _
                                        "isActive=@isActive, userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE customerID=@customerID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)
                cmdToExecute.Parameters.AddWithValue("@parentCustomerID", _parentCustomerID)
                cmdToExecute.Parameters.AddWithValue("@customerCode", _customerCode)
                cmdToExecute.Parameters.AddWithValue("@customerName", _customerName)
                cmdToExecute.Parameters.AddWithValue("@address1", _address1)
                cmdToExecute.Parameters.AddWithValue("@address2", _address2)
                cmdToExecute.Parameters.AddWithValue("@address3", _address3)
                cmdToExecute.Parameters.AddWithValue("@city", _city)
                cmdToExecute.Parameters.AddWithValue("@postalCode", _postalCode)
                cmdToExecute.Parameters.AddWithValue("@phone", _phone)
                cmdToExecute.Parameters.AddWithValue("@mobile", _mobile)
                cmdToExecute.Parameters.AddWithValue("@fax", _fax)
                cmdToExecute.Parameters.AddWithValue("@email", _email)
                cmdToExecute.Parameters.AddWithValue("@url", _url)
                cmdToExecute.Parameters.AddWithValue("@isActive", _isActive)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

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

        Public Overrides Function SelectAll() As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT c.*, cp.customerCode AS parentCustomerCode FROM customer c " + _
                                        "LEFT JOIN customer cp ON c.parentCustomerID = cp.customerID " + _
                                        "ORDER BY c.customerCode"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("customer")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)
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

        Public Overrides Function SelectOne(Optional ByVal recStatus As RavenRecStatus = RavenRecStatus.CurrentRecord) As DataTable
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "SELECT * FROM customer WHERE customerID=@customerID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("customer")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _customerID = CType(toReturn.Rows(0)("customerID"), String)
                    _parentCustomerID = CType(ProcessNull.GetString(toReturn.Rows(0)("parentCustomerID")), String)
                    _customerCode = CType(toReturn.Rows(0)("customerCode"), String)
                    _customerName = CType(toReturn.Rows(0)("customerName"), String)
                    _address1 = CType(toReturn.Rows(0)("address1"), String)
                    _address2 = CType(toReturn.Rows(0)("address2"), String)
                    _address3 = CType(toReturn.Rows(0)("address3"), String)
                    _city = CType(toReturn.Rows(0)("city"), String)
                    _postalCode = CType(toReturn.Rows(0)("postalCode"), String)
                    _phone = CType(toReturn.Rows(0)("phone"), String)
                    _mobile = CType(toReturn.Rows(0)("mobile"), String)
                    _fax = CType(toReturn.Rows(0)("fax"), String)
                    _email = CType(toReturn.Rows(0)("email"), String)
                    _url = CType(toReturn.Rows(0)("url"), String)
                    _isActive = CType(toReturn.Rows(0)("isActive"), Boolean)
                    _userIDinsert = CType(toReturn.Rows(0)("userIDinsert"), String)
                    _userIDupdate = CType(toReturn.Rows(0)("userIDupdate"), String)
                    _insertDate = CType(toReturn.Rows(0)("insertDate"), DateTime)
                    _updateDate = CType(toReturn.Rows(0)("updateDate"), DateTime)
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

        Public Overrides Function Delete() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "DELETE FROM customer " + _
                                        "WHERE customerID=@customerID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@customerID", _customerID)

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

#Region " Class Property Declarations "
        Public Property [CustomerID]() As String
            Get
                Return _customerID
            End Get
            Set(ByVal Value As String)
                _customerID = Value
            End Set
        End Property

        Public Property [ParentCustomerID]() As String
            Get
                Return _parentCustomerID
            End Get
            Set(ByVal Value As String)
                _parentCustomerID = Value
            End Set
        End Property

        Public Property [CustomerCode]() As String
            Get
                Return _customerCode
            End Get
            Set(ByVal Value As String)
                _customerCode = Value
            End Set
        End Property

        Public Property [CustomerName]() As String
            Get
                Return _customerName
            End Get
            Set(ByVal Value As String)
                _customerName = Value
            End Set
        End Property

        Public Property [Address1]() As String
            Get
                Return _address1
            End Get
            Set(ByVal Value As String)
                _address1 = Value
            End Set
        End Property

        Public Property [Address2]() As String
            Get
                Return _address2
            End Get
            Set(ByVal Value As String)
                _address2 = Value
            End Set
        End Property

        Public Property [Address3]() As String
            Get
                Return _address3
            End Get
            Set(ByVal Value As String)
                _address3 = Value
            End Set
        End Property

        Public Property [City]() As String
            Get
                Return _city
            End Get
            Set(ByVal Value As String)
                _city = Value
            End Set
        End Property

        Public Property [PostalCode]() As String
            Get
                Return _postalCode
            End Get
            Set(ByVal Value As String)
                _postalCode = Value
            End Set
        End Property

        Public Property [Phone]() As String
            Get
                Return _phone
            End Get
            Set(ByVal Value As String)
                _phone = Value
            End Set
        End Property

        Public Property [Mobile]() As String
            Get
                Return _mobile
            End Get
            Set(ByVal Value As String)
                _mobile = Value
            End Set
        End Property

        Public Property [Fax]() As String
            Get
                Return _fax
            End Get
            Set(ByVal Value As String)
                _fax = Value
            End Set
        End Property

        Public Property [Email]() As String
            Get
                Return _email
            End Get
            Set(ByVal Value As String)
                _email = Value
            End Set
        End Property

        Public Property [Url]() As String
            Get
                Return _url
            End Get
            Set(ByVal Value As String)
                _url = Value
            End Set
        End Property

        Public Property [IsActive]() As Boolean
            Get
                Return _isActive
            End Get
            Set(ByVal Value As Boolean)
                _isActive = Value
            End Set
        End Property

        Public Property [userIDinsert]() As String
            Get
                Return _userIDinsert
            End Get
            Set(ByVal Value As String)
                _userIDinsert = Value
            End Set
        End Property

        Public Property [userIDupdate]() As String
            Get
                Return _userIDupdate
            End Get
            Set(ByVal Value As String)
                _userIDupdate = Value
            End Set
        End Property

        Public Property [insertDate]() As DateTime
            Get
                Return _insertDate
            End Get
            Set(ByVal Value As DateTime)
                _insertDate = Value
            End Set
        End Property

        Public Property [updateDate]() As DateTime
            Get
                Return _updateDate
            End Get
            Set(ByVal Value As DateTime)
                _updateDate = Value
            End Set
        End Property
#End Region

    End Class
End Namespace
