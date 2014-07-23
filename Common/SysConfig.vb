Option Strict On
Option Explicit On

Imports System
Imports System.Collections
Imports System.Configuration
Imports Raven.SystemFramework
Imports System.Collections.Specialized

Namespace Raven.Common

    Public Class SysConfig
        Implements IConfigurationSectionHandler

        Private Const WEB_ENABLEPAGECACHE As String = "Raven.Web.EnablePageCache"
        Private Const WEB_PAGECACHEEXPIRESINSECONDS As String = "Raven.Web.PageCacheExpiresInSeconds"
        Private Const WEB_ENABLESSL As String = "Raven.Web.EnableSsl"
        Private Const DATAACCESS_CONNECTIONSTRING As String = "Raven.DataAccess.ConnectionString"
        Private Const DATAACCESS_CONFIGURATION_CONNECTIONSTRING As String = "Raven.DataAccess.ConnectionString"
        Private Const APP_ID As String = "Raven.Web.AppId"
        Private Const REPORTS_FOLDER As String = "Raven.Web.ReportsFolder"
        Private Const CUSTOM_REPORTS_FOLDER As String = "Raven.Web.CustomReportsFolder"
        Private Const PHYSICAL_REPORTS_FOLDER As String = "Raven.Web.PhysicalReportsFolder"
        Private Const APPLICATION_URL As String = "Raven.Web.ApplicationURL"
        Private Const APPLICATION_URL_DEFAULT As String = ""

        Private Const MODULE_APPL As String = "Raven.Web.ModuleAppl"
        Private Const MODULE_APPLCL As String = "Raven.Web.ModuleApplCl"

        Private Shared fieldConnectionString As String
        Private Shared fieldConfigurationConnectionString As String
        Private Shared fieldPageCacheExpiresInSeconds As Integer
        Private Shared fieldEnablePageCache As Boolean
        Private Shared fieldEnableSsl As Boolean
        Private Shared fieldKodeCabang As String
        Private Shared fieldReportsFolder As String
        Private Shared fieldCustomReportsFolder As String
        Private Shared fieldPhysicalReportsFolder As String
        Private Shared fieldAppId As String
        Private Shared fieldModuleAppl As String
        Private Shared fieldModuleApplCl As String
        Private Shared fieldSetVarReportsAppl As String
        Private Shared fieldUrlLabRi As String
        Private Shared fieldApplicationUrl As String

        Private Shared fieldSetVarFontSize As String
        Private Shared fieldSetVarFontName As String
        Private Shared fieldSetVarCetakKwitansiOtomatis As Boolean
        Private Shared fieldSetVarUrlLabMD As String
        Private Shared fieldSetVarStBayarPelunasan As String
        Private Shared fieldSetVarStBayarPP As String
        Private Shared fieldSetVarStBayarPI As String
        Private Shared fieldSetVarPPn As Integer

        ' Constant values for all of the default settings.
        Private Const WEB_ENABLEPAGECACHE_DEFAULT As Boolean = True
        Private Const WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT As Integer = 3600
        Private Const DATAACCESS_CONNECTIONSTRING_DEFAULT As String = "server=localhost; User ID=sa;database=OPTIMUS"
        Private Const WEB_ENABLESSL_DEFAULT As Boolean = False
        Private Const REPORTS_FOLDER_DEFAULT As String = "/OPTIMUSReports/ASP/"        
        Private Const PHYSICAL_REPORTS_FOLDER_DEFAULT As String = "D:/Reports/"
        Private Const MODULE_APPLCL_DEFAULT As String = "/OPTIMUSReports/"
        Private Const APP_ID_DEFAULT As String = "TI"
        Private Const MODULE_APPL_DEFAULT As String = "/TechnicalInspection/"        

        Public Function Create(ByVal parent As Object, ByVal configContext As Object, ByVal input As Xml.XmlNode) As Object _
        Implements IConfigurationSectionHandler.Create

            Dim settings As NameValueCollection

            Try
                Dim baseHandler As NameValueSectionHandler
                baseHandler = New NameValueSectionHandler
                settings = CType(baseHandler.Create(parent, configContext, input), NameValueCollection)
            Catch
            End Try

            If settings Is Nothing Then
                fieldConnectionString = DATAACCESS_CONNECTIONSTRING_DEFAULT
                fieldConfigurationConnectionString = DATAACCESS_CONNECTIONSTRING_DEFAULT
                fieldPageCacheExpiresInSeconds = WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT
                fieldEnablePageCache = WEB_ENABLEPAGECACHE_DEFAULT
                fieldEnableSsl = WEB_ENABLESSL_DEFAULT
                fieldReportsFolder = REPORTS_FOLDER_DEFAULT                
                fieldPhysicalReportsFolder = PHYSICAL_REPORTS_FOLDER
                fieldAppId = APP_ID_DEFAULT
                fieldModuleAppl = MODULE_APPL_DEFAULT
                fieldModuleApplCl = MODULE_APPLCL_DEFAULT
                fieldApplicationUrl = APPLICATION_URL_DEFAULT
            Else
                fieldConnectionString = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT)
                fieldConfigurationConnectionString = ApplicationConfiguration.ReadSetting(settings, DATAACCESS_CONFIGURATION_CONNECTIONSTRING, DATAACCESS_CONNECTIONSTRING_DEFAULT)
                fieldPageCacheExpiresInSeconds = ApplicationConfiguration.ReadSetting(settings, WEB_PAGECACHEEXPIRESINSECONDS, WEB_PAGECACHEEXPIRESINSECONDS_DEFAULT)
                fieldEnablePageCache = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLEPAGECACHE, WEB_ENABLEPAGECACHE_DEFAULT)
                fieldEnableSsl = ApplicationConfiguration.ReadSetting(settings, WEB_ENABLESSL, WEB_ENABLESSL_DEFAULT)
                fieldReportsFolder = ApplicationConfiguration.ReadSetting(settings, REPORTS_FOLDER, REPORTS_FOLDER_DEFAULT)                
                fieldPhysicalReportsFolder = ApplicationConfiguration.ReadSetting(settings, PHYSICAL_REPORTS_FOLDER, PHYSICAL_REPORTS_FOLDER_DEFAULT)
                fieldAppId = ApplicationConfiguration.ReadSetting(settings, APP_ID, APP_ID_DEFAULT)
                fieldModuleAppl = ApplicationConfiguration.ReadSetting(settings, MODULE_APPL, MODULE_APPL_DEFAULT)
                fieldModuleApplCl = ApplicationConfiguration.ReadSetting(settings, MODULE_APPLCL, MODULE_APPLCL_DEFAULT)
                fieldApplicationUrl = ApplicationConfiguration.ReadSetting(settings, APPLICATION_URL, APPLICATION_URL_DEFAULT)
            End If
        End Function

        Private Function LoadConnectionStringFromXML() As String
            Dim XmlDoc As New Xml.XmlDocument
            XmlDoc.Load("D:\Source\OPTIMUSv1.1\CommonLibs\App_Data\config.xml")
            Dim node As Xml.XmlNode = XmlDoc.SelectSingleNode("/config/connectionString")
            Dim connStr As String = node.InnerText
            Return connStr
        End Function

#Region "Common SysConfig Properties"
        Public Shared ReadOnly Property EnablePageCache() As Boolean
            Get
                EnablePageCache = fieldEnablePageCache
            End Get
        End Property

        Public Shared ReadOnly Property PageCacheExpiresInSeconds() As Integer
            Get
                PageCacheExpiresInSeconds = fieldPageCacheExpiresInSeconds
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_ReportsAppl() As String
            Get
                SetVar_ReportsAppl = fieldSetVarReportsAppl
            End Get
        End Property

        '
        '   The database connection string 
        '
        Public Shared ReadOnly Property ConnectionString() As String
            Get
                ConnectionString = fieldConnectionString
            End Get
        End Property
        Public Shared ReadOnly Property ConfigurationConnectionString() As String
            Get
                ConfigurationConnectionString = fieldConfigurationConnectionString
            End Get
        End Property


        Public Shared ReadOnly Property EnableSsl() As Boolean
            Get
                EnableSsl = fieldEnableSsl
            End Get
        End Property

        Public Shared ReadOnly Property KodeCabang() As String
            Get
                KodeCabang = fieldKodeCabang
            End Get
        End Property

        Public Shared ReadOnly Property ReportsFolder() As String
            Get
                ReportsFolder = fieldReportsFolder
            End Get
        End Property

        Public Shared ReadOnly Property CustomReportsFolder() As String
            Get
                CustomReportsFolder = fieldCustomReportsFolder
            End Get
        End Property

        Public Shared ReadOnly Property PhysicalReportsFolder() As String
            Get
                PhysicalReportsFolder = fieldPhysicalReportsFolder
            End Get
        End Property

        Public Shared ReadOnly Property AppId() As String
            Get
                AppId = fieldAppId
            End Get
        End Property

        Public Shared ReadOnly Property ModuleAppl() As String
            Get
                ModuleAppl = fieldModuleAppl
            End Get
        End Property

        Public Shared ReadOnly Property ModuleApplCl() As String
            Get
                ModuleApplCl = fieldModuleApplCl
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPelunasan() As String
            Get
                SetVar_StBayarPelunasan = fieldSetVarStBayarPelunasan
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPP() As String
            Get
                SetVar_StBayarPP = fieldSetVarStBayarPP
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_StBayarPI() As String
            Get
                SetVar_StBayarPI = fieldSetVarStBayarPI
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_FontSize() As String
            Get
                SetVar_FontSize = fieldSetVarFontSize
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_Fontname() As String
            Get
                SetVar_Fontname = fieldSetVarFontName
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_CetakKwitansiOtomatis() As Boolean
            Get
                Return fieldSetVarCetakKwitansiOtomatis
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_UrlLabMD() As String
            Get
                Return fieldSetVarUrlLabMD
            End Get
        End Property

        Public Shared ReadOnly Property SetVar_PPn() As Integer
            Get
                SetVar_PPn = fieldSetVarPPn
            End Get
        End Property

        Public Shared ReadOnly Property UrlLabRI() As String
            Get
                UrlLabRI = fieldUrlLabRi
            End Get
        End Property

        Public Shared ReadOnly Property ApplicationURL() As String
            Get
                Return fieldApplicationUrl
            End Get
        End Property

        Public Shared ReadOnly Property IsDisplayReportCriteria() As String
            Get
                Dim result As String = "0"
                result = Methods.GetSettingParameter(Constants.Parameter.IS_DISPLAY_REPORT_CRITERIA)
                Return result
            End Get
        End Property

#End Region

    End Class

End Namespace
