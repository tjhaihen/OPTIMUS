﻿Namespace Raven.Common
    Public NotInheritable Class Constants
        Public NotInheritable Class GroupCode
            Public Const ResourceType_SCode As String = "RSRCPOS"
            Public Const Sex_SCode As String = "SEX"
            Public Const Religion_SCode As String = "RELIGION"
            Public Const Nationality_SCode As String = "NATIONALITY"
            Public Const Priority_SCode As String = "PRIORITY"
            Public Const TypeOfReport_SCode As String = "TYPEOFREPORT"
            Public Const Weather_SCode As String = "WEATHER"
            Public Const WorkingType_SCode As String = "WORKINGTYPE"
            Public Const ServiceReportFor_SCode As String = "SVCRPTFOR"
            Public Const MPIType_SCode As String = "MPITYPE"
            Public Const MPIYoke_SCode As String = "MPIYOKE"
            Public Const MPICoil_SCode As String = "MPICOIL"
            Public Const MPIFluorescent_SCode As String = "MPIFLUOR"
            Public Const MPIContrastBW_SCode As String = "MPICONTBW"
            Public Const HardnessTestLocation_SCode As String = "HTLOCATION"
        End Class

        Public NotInheritable Class FormatString
            Public Const FORMAT_DATE As String = "dd-MM-yyyy"
            Public Const FORMAT_TIME As String = "HH:mm"
            Public Const FORMAT_CURRENCY As String = "#,##0.00"
        End Class

        Public NotInheritable Class MenuID
            Public Const Product_MenuID As String = "1003"
            Public Const ReportType_MenuID As String = "1004"
            Public Const Resource_MenuID As String = "1005"
            Public Const InspectionSpec_MenuID As String = "1006"
            Public Const Customer_MenuID As String = "1007"
            Public Const WorkRequest_MenuID As String = "3003"
            Public Const WorkRequestApproval_MenuID As String = "3009"
            Public Const CustomerInspectionInformation_MenuID As String = "8001"
            Public Const Site_MenuID As String = "9003"
            Public Const Profile_MenuID As String = "9005"
            Public Const User_MenuID As String = "9007"
            Public Const CommonCode_MenuID As String = "9008"
            Public Const SystemParameter_MenuID As String = "9009"
            Public Const ChangePassword_MenuID As String = "9010"
        End Class

        Public NotInheritable Class MaskFormat
            Public Const TIME_MASK As String = "99:99"
        End Class

        Public NotInheritable Class MessageBoxText
            Public Const Validate_IsSystem As String = "This record is used by system and cannot be modified or deleted."
        End Class

        Public NotInheritable Class Parameter
            Public Const IS_DISPLAY_REPORT_CRITERIA As String = "isDisplayReportCriteria"
            Public Const PARAM_FORMAT_MRN As String = "format_norm"
        End Class

        Public NotInheritable Class ReportTypePanelID
            Public Const ServiceAcceptance_PanelID As String = "pnlServiceAcceptance"
            Public Const SummaryOfInspection_PanelID As String = "pnlSummaryOfInspection"
            Public Const TimeSheet_PanelID As String = "pnlTimeSheet"
            Public Const DailyProgressReport_PanelID As String = "pnlDailyProgressReport"
            Public Const DailyInspectionReport_PanelID As String = "pnlDailyInspectionReport"
            Public Const ServiceReport_PanelID As String = "pnlServiceReport"
            Public Const MPIReport_PanelID As String = "pnlMPIReport"
            Public Const DrillPipeInspectionReport_PanelID As String = "pnlDrillPipeInspectionReport"
            Public Const ThroughVisualInspectionReport_PanelID As String = "pnlThroughVisualInspectionReport"
            Public Const InspectionTallyReport_PanelID As String = "pnlInspectionTallyReport"
            Public Const UTSpotCheck_PanelID As String = "pnlUTSpotCheck"
            Public Const RotaryShoulderConnectionReport_PanelID As String = "pnlRotaryShoulderConnectionReport"
            Public Const UTSpotEndArea_PanelID As String = "pnlUTSpotEndArea"
            Public Const CheckListCompletionReport_PanelID As String = "pnlCheckListCompletionReport"
            Public Const CertificateOfInspection_PanelID As String = "pnlCertificateInspection"
            Public Const HardnessTest_PanelID As String = "pnlHardnessTestReport"
        End Class

        Public NotInheritable Class IDPrefix
            Public Const WorkRequestPrefix As String = "WR"            
        End Class

        Public NotInheritable Class ReportTypeCode
            Public Const ServiceAcceptanceCertificate As String = "SAC"
            Public Const SummaryOfInspection As String = "SOI"
            Public Const TimeSheet As String = "TS"
            Public Const DailyProgressReport As String = "DPR"            
            Public Const DrillPipeInspectionReport As String = "DPI"
            Public Const ThroughVisualInspectionReport As String = "TVI"
            Public Const ServiceReportMPIDPI As String = "SRMPIDPI"
            Public Const ServiceReportMPILoadPullTest As String = "SRMPILPT"
            Public Const ServiceReportTubular As String = "SRT"            
            Public Const InspectionTallyReport As String = "ITR"
            Public Const UTSpotCheck As String = "UTS"
            Public Const RotaryShoulderConnectionReport As String = "RSC"
            Public Const UTSpotEndArea As String = "UTSEA"
            Public Const CheckListOfCompletionReport As String = "CLOC"
            Public Const MPIDPIReport As String = "MPIDPI"
            Public Const MPIBeforeLoadPullTest As String = "MPIBLPT"
            Public Const MPIAfterLoadPullTest As String = "MPIALPT"
            Public Const SlickDrillCollarInspectionReport As String = "SLDC"
            Public Const SpiralDrillCollarInspectionReport As String = "SPDC"
            Public Const HeavyWeightDrillPipeInspectionReport As String = "HWDP"
            Public Const HardnessTestInspectionReport As String = "HTI"
            Public Const DailyProgressReportTubular As String = "DPRT"
            Public Const WorkRequest As String = "WR"
        End Class

        Public NotInheritable Class ReportTypeCodeServiceReportFor
            Public Const MPIDPI As String = "MPIDPI"
            Public Const MPILoadTest As String = "MPILT"
            Public Const MPIPullTest As String = "MPIPT"
            Public Const Tubular As String = "TUB"
        End Class

        Public NotInheritable Class ReportTypeCodeMPIType
            Public Const MPIDPI As String = "MPIDPI"
            Public Const MPIBeforeLoadTest As String = "MPIBLT"
            Public Const MPIBeforePullTest As String = "MPIBPT"
            Public Const MPIAfterLoadTest As String = "MPIALT"
            Public Const MPIAfterPullTest As String = "MPIAPT"

            Public Const MPIBeforeLoadTestCaption As String = "MPI Before Load Test"
            Public Const MPIAfterLoadTestCaption As String = "MPI After Load Test"
        End Class

        'Public NotInheritable Class ReportTypeName
        '    Public Const ServiceAcceptance As String = "ServiceAcceptance"
        '    Public Const SummaryOfInspection As String = "SummaryOfInspection"
        '    Public Const TimeSheet As String = "TimeSheet"
        '    Public Const DailyProgressReport As String = "DailyProgressReport"
        '    Public Const ServiceReport As String = "ServiceReport"
        '    Public Const MPIReport As String = "MPIReport"
        '    Public Const DrillPipeInspectionReport As String = "DrillPipeInspectionReport"
        '    Public Const ThroughVisualInspectionReport As String = "ThroughVisualInspectionReport"
        '    Public Const InspectionTallyReport As String = "InspectionTallyReport"
        '    Public Const UTSpotCheck As String = "UTSpotCheck"
        '    Public Const RotaryShoulderConnectionReport As String = "RotaryShoulderConnectionReport"
        '    Public Const UTSpotEndArea As String = "UTSpotEndArea"
        '    Public Const CheckListCompletionReport As String = "CheckListCompletionReport"
        'End Class
    End Class
End Namespace

