Option Explicit On 
Option Strict On

Namespace Raven.Common

    Public NotInheritable Class ProcessNull
        Private Sub New()
        End Sub

        Public Shared Function GetBoolean(ByVal Value As Object) As Boolean
            If IsDBNull(Value) Then
                Return False
            Else
                Return CType(Value, Boolean)
            End If
        End Function

        Public Shared Function GetString(ByVal Value As Object) As String
            If IsDBNull(Value) Then
                Return ""
            Else
                Return CType(Value, String).TrimEnd()
            End If
        End Function

        Public Shared Function GetInt16(ByVal Value As Object) As Int16
            If IsDBNull(Value) Then
                Return 0
            Else
                Return CType(Value, Int16)
            End If
        End Function

        Public Shared Function GetInt32(ByVal Value As Object) As Int32
            If IsDBNull(Value) Then
                Return 0
            Else
                Return CType(Value, Int32)
            End If
        End Function

        Public Shared Function GetDecimal(ByVal Value As Object) As Decimal
            If IsDBNull(Value) Then
                Return 0
            Else
                Return CType(Value, Decimal)
            End If
        End Function

        Public Shared Function GetDouble(ByVal Value As Object) As Double
            If IsDBNull(Value) Then
                Return 0
            Else
                Return CType(Value, Double)
            End If
        End Function

        Public Shared Function GetDateTime(ByVal Value As Object) As DateTime
            If IsDBNull(Value) Then
                Return DateTime.Now
            Else
                Return CType(Value, DateTime)
            End If
        End Function

        Public Shared Function GetSqlValue(ByVal Value As Object) As Object
            If IsDBNull(Value) Then
                Return Nothing
            Else
                Return Value
            End If
        End Function

        Public Shared Function GetByte(ByVal Value As Object) As Byte
            If IsDBNull(Value) Then
                Return 0
            Else
                Return CType(Value, Byte)
            End If
        End Function

        Public Shared Function GetBytes(ByVal Value As Object) As Byte()
            If IsDBNull(Value) Then
                Return Nothing
            Else
                Return CType(Value, Byte())
            End If
        End Function

    End Class

End Namespace
