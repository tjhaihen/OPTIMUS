
Option Strict On
Option Explicit On 

Imports System
Imports System.Diagnostics
Imports System.Text

Imports Microsoft.VisualBasic

Namespace Raven.SystemFramework

    Public Class ApplicationAssert

#If Debug = 0 Then
        Public Const LineNumber As Integer = 0
#Else
        Public Shared ReadOnly Property LineNumber() As Integer
            Get
                Try
                    With New StackTrace(1, True)
                        LineNumber = .GetFrame(0).GetFileLineNumber
                    End With
                Catch
                End Try
            End Get
        End Property
#End If

        Public Shared Sub Check(ByVal condition As Boolean, ByVal errorText As String, Optional ByVal lineNumber As Integer = 0)

#If Debug = 1 Then
                Dim detailMessage As String
                Dim strBuilder As StringBuilder

                If Not condition Then
                    detailMessage = GenerateStackTrace(lineNumber)
                    strBuilder = New StringBuilder
                    strBuilder.Append("Assert: ").Append(ControlChars.CrLf).Append(errorText).Append(ControlChars.CrLf).Append(detailMessage)
                    ApplicationLog.WriteWarning(strBuilder.ToString)
                    Debug.Fail(errorText, detailMessage)
                End If
#End If
        End Sub

        Public Shared Sub CheckCondition(ByVal condition As Boolean, ByVal errorText As String, Optional ByVal lineNumber As Integer = 0)

            If Not condition Then
#If Debug = 1 Then
                    Debug.Fail(errorText, GenerateStackTrace(lineNumber))
#End If
                Throw (New ApplicationException(errorText))
            End If
        End Sub

#If Debug = 1 Then

        Private Shared Function GenerateStackTrace(ByVal lineNumber As Integer) As String
            Dim message As StringBuilder 
            Dim fileName As String       
            Dim currentLine As Integer   
            Dim sourceLine As String     
            Dim fileHandle As Integer    
            Dim openedFile As Boolean

            message = New StringBuilder

            Try
                With New StackTrace(2, True)
                    Try
                        With .GetFrame(0)
                            fileName = .GetFileName
                            If fileName Is Nothing Then fileName = "<UnknownName>"
                            If lineNumber <> 0 Then
                                currentLine = lineNumber
                            Else
                                currentLine = .GetFileLineNumber
                            End If
                            If fileName <> "<UnknownName>" And currentLine >= 0 Then
                                message.Append(fileName).Append(", Line: ").Append(currentLine)

                                fileHandle = FreeFile
                                FileOpen(fileHandle, fileName, OpenMode.Input)
                                openedFile = True

                                Do
                                    sourceLine = LineInput(fileHandle)
                                    currentLine = currentLine - 1
                                Loop While currentLine <> 0

                                message.Append(ControlChars.CrLf)

                                If lineNumber <> 0 Then
                                    message.Append("Current executable line:")
                                Else
                                    message.Append(ControlChars.CrLf).Append("Next executable line:")
                                End If

                                message.Append(ControlChars.CrLf).Append(sourceLine.Trim())
                            End If
                        End With
                    Catch
                    Finally
                        If openedFile Then FileClose(fileHandle)
                    End Try

                    return message.ToString
                End With
            Catch
            End Try
        End Function
#End If

    End Class

End Namespace

