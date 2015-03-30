Option Explicit On

Imports System
Imports System.Data
Imports System.Data.SqlTypes
Imports System.Data.SqlClient
Imports Raven.Common

Namespace Raven.Common.BussinessRules
    Public Class Person
        Inherits BRInteractionBase

#Region " Class Member Declarations "
        Private _personID, _firstName, _middleName, _lastName, _salutation, _academicTitle As String
        Private _genderSCode, _sexSCode, _religionSCode, _nationalitySCode As String
        Private _address1, _address2, _address3, _city, _postalCode, _phone, _mobile, _fax, _email, _url As String
        Private _signaturePic As SqlBinary
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
            cmdToExecute.CommandText = "INSERT INTO Person " + _
                                        "(personID, firstName, middleName, lastName, salutation, academicTitle, " + _
                                        "genderSCode, sexSCode, religionSCode, nationalitySCode, " + _
                                        "address1, address2, address3, city, postalCode, phone, mobile, fax, email, url, " + _
                                        "userIDinsert, userIDupdate, insertDate, updateDate) " + _
                                        "VALUES " + _
                                        "(@personID, @firstName, @middleName, @lastName, @salutation, @academicTitle, " + _
                                        "@genderSCode, @sexSCode, @religionSCode, @nationalitySCode, " + _
                                        "@address1, @address2, @address3, @city, @postalCode, @phone, @mobile, @fax, @email, @url, " + _
                                        "@userIDinsert, @userIDupdate, GETDATE(), GETDATE())"
            cmdToExecute.CommandType = CommandType.Text
            cmdToExecute.Connection = _mainConnection

            Dim strpersonID As String = ID.GenerateIDNumber("Person", "personID")

            Try
                cmdToExecute.Parameters.AddWithValue("@personID", strpersonID)
                cmdToExecute.Parameters.AddWithValue("@firstName", _firstName)
                cmdToExecute.Parameters.AddWithValue("@middleName", _middleName)
                cmdToExecute.Parameters.AddWithValue("@lastName", _lastName)
                cmdToExecute.Parameters.AddWithValue("@salutation", _salutation)
                cmdToExecute.Parameters.AddWithValue("@academicTitle", _academicTitle)
                cmdToExecute.Parameters.AddWithValue("@genderSCode", _genderSCode)
                cmdToExecute.Parameters.AddWithValue("@sexSCode", _sexSCode)
                cmdToExecute.Parameters.AddWithValue("@religionSCode", _religionSCode)
                cmdToExecute.Parameters.AddWithValue("@nationalitySCode", _nationalitySCode)
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
                cmdToExecute.Parameters.AddWithValue("@userIDinsert", _userIDinsert)
                cmdToExecute.Parameters.AddWithValue("@userIDupdate", _userIDupdate)

                ' // Open Connection
                _mainConnection.Open()

                ' // Execute Query
                cmdToExecute.ExecuteNonQuery()

                _personID = strpersonID
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
            cmdToExecute.CommandText = "UPDATE Person " + _
                                        "SET firstName=@firstName, middleName=@middleName, lastName=@lastName, salutation=@salutation, " + _
                                        "academicTitle=@academicTitle, genderSCode=@genderSCode, sexSCode=@sexSCode, religionSCode=@religionSCode, " + _
                                        "nationalitySCode=@nationalitySCode, address1=@address1, address2=@address2, address3=@address3, " + _
                                        "city=@city, postalCode=@postalCode, phone=@phone, mobile=@mobile, fax=@fax, email=@email, url=@url, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE personID=@personID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@personID", _personID)
                cmdToExecute.Parameters.AddWithValue("@firstName", _firstName)
                cmdToExecute.Parameters.AddWithValue("@middleName", _middleName)
                cmdToExecute.Parameters.AddWithValue("@lastName", _lastName)
                cmdToExecute.Parameters.AddWithValue("@salutation", _salutation)
                cmdToExecute.Parameters.AddWithValue("@academicTitle", _academicTitle)
                cmdToExecute.Parameters.AddWithValue("@genderSCode", _genderSCode)
                cmdToExecute.Parameters.AddWithValue("@sexSCode", _sexSCode)
                cmdToExecute.Parameters.AddWithValue("@religionSCode", _religionSCode)
                cmdToExecute.Parameters.AddWithValue("@nationalitySCode", _nationalitySCode)
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
            cmdToExecute.CommandText = "SELECT * FROM Person"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Person")
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
            cmdToExecute.CommandText = "SELECT * FROM Person WHERE personID=@personID"
            cmdToExecute.CommandType = CommandType.Text

            Dim toReturn As DataTable = New DataTable("Person")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmdToExecute)

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@personID", _personID)

                ' // Open connection.
                _mainConnection.Open()

                ' // Execute query.
                adapter.Fill(toReturn)

                If toReturn.Rows.Count > 0 Then
                    _personID = CType(toReturn.Rows(0)("personID"), String)
                    _firstName = CType(toReturn.Rows(0)("firstName"), String)
                    _middleName = CType(toReturn.Rows(0)("middleName"), String)
                    _lastName = CType(toReturn.Rows(0)("lastName"), String)
                    _salutation = CType(toReturn.Rows(0)("salutation"), String)
                    _academicTitle = CType(toReturn.Rows(0)("academicTitle"), String)
                    _genderSCode = CType(toReturn.Rows(0)("genderSCode"), String)
                    _sexSCode = CType(toReturn.Rows(0)("sexSCode"), String)
                    _religionSCode = CType(toReturn.Rows(0)("religionSCode"), String)
                    _nationalitySCode = CType(toReturn.Rows(0)("nationalitySCode"), String)
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
                    If Not IsDBNull(toReturn.Rows(0)("signaturePic")) Then
                        _signaturePic = CType(toReturn.Rows(0)("signaturePic"), Byte())
                    End If
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
            cmdToExecute.CommandText = "DELETE FROM Person " + _
                                        "WHERE personID=@personID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@personID", _personID)

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

#Region " Custom Functions "
        Public Function UpdatePic() As Boolean
            Dim cmdToExecute As SqlCommand = New SqlCommand
            cmdToExecute.CommandText = "UPDATE Person " + _
                                        "SET signaturePic=@signaturePic, " + _
                                        "userIDupdate=@userIDupdate, updateDate=GETDATE() " + _
                                        "WHERE personID=@personID"
            cmdToExecute.CommandType = CommandType.Text

            cmdToExecute.Connection = _mainConnection

            Try
                cmdToExecute.Parameters.AddWithValue("@personID", _personID)
                cmdToExecute.Parameters.AddWithValue("@signaturePic", _signaturePic)
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
#End Region

#Region " Class Property Declarations "
        Public Property [PersonID]() As String
            Get
                Return _personID
            End Get
            Set(ByVal Value As String)
                _personID = Value
            End Set
        End Property

        Public Property [FirstName]() As String
            Get
                Return _firstName
            End Get
            Set(ByVal Value As String)
                _firstName = Value
            End Set
        End Property

        Public Property [MiddleName]() As String
            Get
                Return _middleName
            End Get
            Set(ByVal Value As String)
                _middleName = Value
            End Set
        End Property

        Public Property [LastName]() As String
            Get
                Return _lastName
            End Get
            Set(ByVal Value As String)
                _lastName = Value
            End Set
        End Property

        Public Property [Salutation]() As String
            Get
                Return _salutation
            End Get
            Set(ByVal Value As String)
                _salutation = Value
            End Set
        End Property

        Public Property [AcademicTitle]() As String
            Get
                Return _academicTitle
            End Get
            Set(ByVal Value As String)
                _academicTitle = Value
            End Set
        End Property

        Public Property [GenderSCode]() As String
            Get
                Return _genderSCode
            End Get
            Set(ByVal Value As String)
                _genderSCode = Value
            End Set
        End Property

        Public Property [SexSCode]() As String
            Get
                Return _sexSCode
            End Get
            Set(ByVal Value As String)
                _sexSCode = Value
            End Set
        End Property

        Public Property [ReligionSCode]() As String
            Get
                Return _religionSCode
            End Get
            Set(ByVal Value As String)
                _religionSCode = Value
            End Set
        End Property

        Public Property [NationalitySCode]() As String
            Get
                Return _nationalitySCode
            End Get
            Set(ByVal Value As String)
                _nationalitySCode = Value
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

        Public Property [SignaturePic]() As SqlBinary
            Get
                Return _signaturePic
            End Get
            Set(ByVal Value As SqlBinary)
                _signaturePic = Value
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
