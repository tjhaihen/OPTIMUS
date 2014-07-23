Option Strict On
Option Explicit On 

Imports System
Imports System.Diagnostics
Imports System.Configuration
Imports System.Collections
Imports System.Xml
Imports System.Collections.Specialized

Namespace Raven.SystemFramework

    Public Class ApplicationConfiguration
        Implements IConfigurationSectionHandler

        Private Const TRACING_ENABLED As String = "SystemFramework.Tracing.Enabled"
        Private Const TRACING_TRACEFILE As String = "SystemFramework.Tracing.TraceFile"
        Private Const TRACING_TRACELEVEL As String = "SystemFramework.Tracing.TraceLevel"
        Private Const TRACING_SWITCHNAME As String = "SystemFramework.Tracing.SwitchName"
        Private Const TRACING_SWITCHDESCRIPTION As String = "SystemFramework.Tracing.SwitchDescription"
        Private Const EVENTLOG_ENABLED As String = "SystemFramework.EventLog.Enabled"
        Private Const EVENTLOG_MACHINENAME As String = "SystemFramework.EventLog.Machine"
        Private Const EVENTLOG_SOURCENAME As String = "SystemFramework.EventLog.SourceName"
        Private Const EVENTLOG_TRACELEVEL As String = "SystemFramework.EventLog.LogLevel"

        Private Shared fieldTracingEnabled As Boolean
        Private Shared fieldTracingTraceFile As String
        Private Shared fieldTracingTraceLevel As TraceLevel
        Private Shared fieldTracingSettingsFile As String
        Private Shared fieldTracingSwitchName As String
        Private Shared fieldTracingSwitchDescription As String
        Private Shared fieldEventLogEnabled As Boolean
        Private Shared fieldEventLogMachineName As String
        Private Shared fieldEventLogSourceName As String
        Private Shared fieldEventLogTraceLevel As TraceLevel
        '
        ' The root directory of the application. Established in the OnApplicationStart callback form Global.asax.
        '
        Private Shared fieldAppRoot As String

        Private Const TRACING_ENABLED_DEFAULT As Boolean = False
        Private Const TRACING_TRACEFILE_DEFAULT As String = "ApplicationTrace.txt"
        Private Const TRACING_TRACELEVEL_DEFAULT As TraceLevel = TraceLevel.Verbose
        Private Const TRACING_SWITCHNAME_DEFAULT As String = "ApplicationTraceSwitch"
        Private Const TRACING_SWITCHDESCRIPTION_DEFAULT As String = "Application error and tracing information"
        Private Const EVENTLOG_ENABLED_DEFAULT As Boolean = True
        Private Const EVENTLOG_MACHINENAME_DEFAULT As String = "."
        Private Const EVENTLOG_SOURCENAME_DEFAULT As String = "WebApplication"
        Private Const EVENTLOG_TRACELEVEL_DEFAULT As TraceLevel = TraceLevel.Error
        '
        ' overloaded from IConfigurationSectionHandler
        '
        Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal section As System.Xml.XmlNode) As Object _
        Implements IConfigurationSectionHandler.Create
            Dim settings As NameValueCollection = Nothing

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, section), NameValueCollection)
            Catch
            End Try

            If settings Is Nothing Then
                fieldTracingEnabled = TRACING_ENABLED_DEFAULT
                fieldTracingTraceFile = TRACING_TRACEFILE_DEFAULT
                fieldTracingTraceLevel = TRACING_TRACELEVEL_DEFAULT
                fieldTracingSwitchName = TRACING_SWITCHNAME_DEFAULT
                fieldTracingSwitchDescription = TRACING_SWITCHDESCRIPTION_DEFAULT
                fieldEventLogEnabled = EVENTLOG_ENABLED_DEFAULT
                fieldEventLogMachineName = EVENTLOG_MACHINENAME_DEFAULT
                fieldEventLogSourceName = EVENTLOG_SOURCENAME_DEFAULT
                fieldEventLogTraceLevel = EVENTLOG_TRACELEVEL_DEFAULT
                'Exit Function
            Else
                fieldTracingEnabled = ReadSetting(settings, TRACING_ENABLED, TRACING_ENABLED_DEFAULT)
                fieldTracingTraceFile = ReadSetting(settings, TRACING_TRACEFILE, TRACING_TRACEFILE_DEFAULT)
                fieldTracingTraceLevel = ReadSetting(settings, TRACING_TRACELEVEL, TRACING_TRACELEVEL_DEFAULT)
                fieldTracingSwitchName = ReadSetting(settings, TRACING_SWITCHNAME, TRACING_SWITCHNAME_DEFAULT)
                fieldTracingSwitchDescription = ReadSetting(settings, TRACING_SWITCHDESCRIPTION, TRACING_SWITCHDESCRIPTION_DEFAULT)
                fieldEventLogEnabled = ReadSetting(settings, EVENTLOG_ENABLED, EVENTLOG_ENABLED_DEFAULT)
                fieldEventLogMachineName = ReadSetting(settings, EVENTLOG_MACHINENAME, EVENTLOG_MACHINENAME_DEFAULT)
                fieldEventLogSourceName = ReadSetting(settings, EVENTLOG_SOURCENAME, EVENTLOG_SOURCENAME_DEFAULT)
                fieldEventLogTraceLevel = ReadSetting(settings, EVENTLOG_TRACELEVEL, EVENTLOG_TRACELEVEL_DEFAULT)
            End If
        End Function

#Region "Public Overloads Shared Function ReadSetting()"
        ' String version of ReadSetting
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As String) As String
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CStr(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        ' Boolean version of ReadSetting
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Boolean) As Boolean
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CBool(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        ' Long version of ReadSetting
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As Integer) As Integer
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CInt(setting)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function

        ' TraceLevel version of ReadSetting
        Public Overloads Shared Function ReadSetting(ByVal settings As NameValueCollection, ByVal key As String, ByVal defaultValue As TraceLevel) As TraceLevel
            Try
                Dim setting As Object = settings(key)
                If setting Is Nothing Then
                    ReadSetting = defaultValue
                Else
                    ReadSetting = CType(CInt(setting), TraceLevel)
                End If
            Catch
                ReadSetting = defaultValue
            End Try
        End Function
#End Region

        '
        ' Function to be called by Application_OnStart. (Initializes the application root.)
        '
        Public Shared Sub OnApplicationStart(ByVal AppRoot As String)
            fieldAppRoot = AppRoot
            System.Configuration.ConfigurationSettings.GetConfig("ApplicationConfiguration")
            System.Configuration.ConfigurationSettings.GetConfig("SysConfig")
        End Sub

        Public Shared ReadOnly Property AppRoot() As String
            Get
                AppRoot = fieldAppRoot
            End Get
        End Property

        Public Shared ReadOnly Property TracingEnabled() As Boolean
            Get
                TracingEnabled = fieldTracingEnabled
            End Get
        End Property

        Public Shared ReadOnly Property TracingTraceFile() As String
            Get
                TracingTraceFile = fieldAppRoot & "\" & fieldTracingTraceFile
            End Get
        End Property

        Public Shared ReadOnly Property TracingTraceLevel() As TraceLevel
            Get
                TracingTraceLevel = fieldTracingTraceLevel
            End Get
        End Property

        Public Shared ReadOnly Property TracingSwitchName() As String
            Get
                TracingSwitchName = fieldTracingSwitchName
            End Get
        End Property

        Public Shared ReadOnly Property TracingSwitchDescription() As String
            Get
                TracingSwitchDescription = fieldTracingSwitchDescription
            End Get
        End Property

        Public Shared ReadOnly Property EventLogEnabled() As Boolean
            Get
                EventLogEnabled = fieldEventLogEnabled
            End Get
        End Property

        Public Shared ReadOnly Property EventLogMachineName() As String
            Get
                EventLogMachineName = fieldEventLogMachineName
            End Get
        End Property

        Public Shared ReadOnly Property EventLogSourceName() As String
            Get
                EventLogSourceName = fieldEventLogSourceName
            End Get
        End Property

        Public Shared ReadOnly Property EventLogTraceLevel() As TraceLevel
            Get
                EventLogTraceLevel = fieldEventLogTraceLevel
            End Get
        End Property

    End Class

End Namespace