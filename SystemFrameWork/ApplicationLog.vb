Option Strict On
Option Explicit On 

Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.FileSystem
Imports Microsoft.VisualBasic.Strings

Imports System
Imports System.IO
Imports System.Configuration
Imports System.Text
Imports System.Diagnostics
Imports System.Threading

Namespace Raven.SystemFramework

    Public Class ApplicationLog

        Private Shared debugSwitch As TraceSwitch
        Private Shared debugWriter As StreamWriter
        Private Shared eventLogTraceLevel As TraceLevel

        Public Shared Sub WriteError(ByVal message As String)
            WriteLog(TraceLevel.Error, message)
        End Sub
        Public Shared Sub WriteWarning(ByVal message As String)
            WriteLog(TraceLevel.Warning, message)
        End Sub
        Public Shared Sub WriteInfo(ByVal message As String)
            WriteLog(TraceLevel.Info, message)
        End Sub
        Public Shared Sub WriteTrace(ByVal message As String)
            WriteLog(TraceLevel.Verbose, message)
        End Sub

        Public Shared Function FormatException(ByVal ex As Exception, Optional ByVal catchInfo As String = "") As String
            With New StringBuilder
                If Len(catchInfo) <> 0 Then .Append(catchInfo).Append(ControlChars.CrLf)
                Return .Append(ex.Message).Append(ControlChars.CrLf).Append(ex.StackTrace).ToString
            End With
        End Function

        Private Shared Sub WriteLog(ByVal level As TraceLevel, ByVal messageText As String)
            Try
                If Not debugWriter Is Nothing Then
                    If level <= debugSwitch.Level Then
                        SyncLock debugWriter
                            Debug.WriteLine(messageText)
                            debugWriter.Flush()
                        End SyncLock
                    End If
                End If

                If level <= eventLogTraceLevel Then

                    Dim logEntryType As EventLogEntryType

                    Select Case level
                        Case TraceLevel.Error
                            logEntryType = EventLogEntryType.Error
                        Case TraceLevel.Warning
                            logEntryType = EventLogEntryType.Warning
                        Case TraceLevel.Info
                            logEntryType = EventLogEntryType.Information
                        Case TraceLevel.Verbose
                            logEntryType = EventLogEntryType.SuccessAudit
                    End Select

                    Dim eventLog As New eventLog("Application", ApplicationConfiguration.EventLogMachineName, ApplicationConfiguration.EventLogSourceName)

                    eventLog.WriteEntry(messageText, logEntryType)
                End If
            Catch
                'ignore any exceptions.
            End Try
        End Sub

    End Class

End Namespace