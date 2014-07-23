Imports Raven.OPTIMUS.Data.Service
Imports System.Collections.Generic

Namespace CommonLibs
    Public Class DataLayerGenerator
        Inherits System.Web.UI.Page

        Protected WithEvents cboTable As DropDownList
        Protected WithEvents cboView As DropDownList
        Protected WithEvents txtTableName As TextBox
        Protected WithEvents txtViewName As TextBox
        Protected WithEvents btnGenerate As Button
        Protected WithEvents btnGenerateView As Button
        Protected WithEvents divResult As HtmlGenericControl
        Protected WithEvents divBusinessLayer As HtmlGenericControl

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            If Not IsPostBack Then
                Dim lstTable As List(Of SysObjects) = BusinessLayer.GetSysObjectsList("type = 'U' ORDER BY name ASC")
                SetComboBoxField(cboTable, lstTable, "Name", "ObjectID")

                Dim lstView As List(Of SysObjects) = BusinessLayer.GetSysObjectsList("type = 'V' ORDER BY name ASC")
                SetComboBoxField(cboView, lstView, "Name", "ObjectID")
            End If
        End Sub

        Protected Sub SetComboBoxField(Of T)(ByRef ctl As DropDownList, ByVal list As List(Of T), ByVal textField As String, ByVal valueField As String)
            ctl.DataTextField = textField
            ctl.DataValueField = valueField
            ctl.DataSource = list
            ctl.DataBind()
        End Sub

        Private Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
            Dim lstColumns As List(Of SysColumns) = BusinessLayer.GetSysColumnsList("object_ID = " + cboView.SelectedValue)

            Dim tableName As String = txtTableName.Text
            Dim oldTableName As String = cboTable.SelectedItem.Text
            Dim listPK As List(Of String) = BusinessLayer.GetSysColumnsPKList(tableName)

            Dim listMember As String = ""
            Dim listField As String = ""
            Dim paramPK As String = ""
            Dim passParamPK As String = ""

            For Each col As SysColumns In lstColumns
                Dim colType As String = col.Type
                Dim identity As String = ""
                If col.IsIdentity Then
                    identity = ", IsIdentity = true"
                End If
                Dim nullable As String = ""
                If col.IsNullable Then
                    nullable = ", IsNullable = true"
                    If colType.Contains("Int") Then
                        colType += "?"
                    End If
                End If
                listMember += String.Format("private {0} _{1}<br>", colType, col.Name)

                Dim primaryKey As String = ""
                If listPK.Contains(col.Name) Then
                    primaryKey = ", IsPrimaryKey = true"
                    If paramPK <> "" Then
                        paramPK += ", "
                        paramPK += String.Format("{0} {1}", col.Type, col.Name)
                    End If
                    If passParamPK <> "" Then
                        passParamPK += ", "
                        passParamPK += String.Format("{0}", col.Name)
                    End If
                End If
                listField += String.Format("[Column(Name = ""{0}"", DataType = ""{1}""{2}{3}{4})]<br>", col.Name, col.Type, primaryKey, identity, nullable)
                listField += String.Format("public {1} {0}<br>{{<br>get {{ return _{0} }}<br>set {{ _{0} = value }}<br>}}<br>", col.Name, colType)

            Next

            Dim result As String = ""
            result = String.Format("#region {0}<br>[Serializable]<br>[Table(Name = ""{1}"")]<br>public class {0} : DbDataModel<br>{{<br>", tableName, oldTableName)
            result += listMember + "<br>"
            result += listField
            result += "}<br><br>"

            'Dao
            Dim listStringPK As String = ""
            Dim ctxPK As String = ""
            For Each pk As String In listPK
                listStringPK += String.Format("private const string p_{0} = ""@p_{0}""<br>", pk)
                ctxPK += String.Format("_ctx.Add(p_{0}, {0})<br>", pk)
            Next

            result += String.Format("public class {0}Dao<br>{{<br>private readonly IDbContext _ctx = DbFactory.Configure()<br>private readonly DbHelper _helper = new DbHelper(typeof({0}))<br>private bool _isAuditLog = false<br>", tableName)
            result += listStringPK

            result += String.Format("public {0}Dao(){{ }}<br>", tableName)
            result += String.Format("public {0}Dao(IDbContext ctx)<br>{{<br>_ctx = ctx<br>}}<br>", tableName)

            result += String.Format("public {0} Get({1})<br>{{<br>_ctx.CommandText = _helper.GetRecord()<br>{2}DataRow row = DaoBase.GetDataRow(_ctx)<br>return (row == null) ? null : ({0})_helper.DataRowToObject(row, new {0}())<br>}}<br>", tableName, paramPK, ctxPK)

            result += String.Format("public int Insert({0} record)<br>{{<br>_helper.Insert(_ctx, record, _isAuditLog)<br>return DaoBase.ExecuteNonQuery(_ctx)<br>}}<br>", tableName)

            result += String.Format("public int Update({0} record)<br>{{<br>_helper.Update(_ctx, record, _isAuditLog)<br>return DaoBase.ExecuteNonQuery(_ctx, true)<br>}}<br>", tableName)

            result += String.Format("public int Delete({1})<br>{{<br>{0} record<br>if (_ctx.Transaction == null)<br>record = new {0}Dao().Get({2})<br>else<br>record = Get({2})<br>_helper.Delete(_ctx, record, _isAuditLog)<br>return DaoBase.ExecuteNonQuery(_ctx)<br>}}<br>", tableName, paramPK, passParamPK)
            result += "}<br>#endregion"
            divResult.InnerHtml = result




            Dim resultBusinessLayer As String = ""
            resultBusinessLayer = String.Format("#region {0}<br>", tableName)
            resultBusinessLayer += String.Format("public static {0} Get{0}({1})<br>{{<br>return new {0}Dao().Get({2})<br>}}<br>", tableName, paramPK, passParamPK)

            resultBusinessLayer += String.Format("public static int Insert{0}({0} record)<br>{{<br>return new {0}Dao().Insert(record)<br>}}<br>", tableName)

            resultBusinessLayer += String.Format("public static int Update{0}({0} record)<br>{{<br>return new {0}Dao().Update(record)<br>}}<br>", tableName)

            resultBusinessLayer += String.Format("public static int Delete{0}({1})<br>{{<br>return new {0}Dao().Delete({2})<br>}}<br>", tableName, paramPK, passParamPK)

            resultBusinessLayer += String.Format("public static List(OfOf {0} ) Get{0}List(string filterExpression)<br>{{<br>", tableName)
            resultBusinessLayer += String.Format("List(OfOf {0} ) result = new List(OfOf {0} )()<br>", tableName)
            resultBusinessLayer += "IDbContext ctx = DbFactory.Configure()<br>try<br>{<br>"
            resultBusinessLayer += String.Format("DbHelper helper = new DbHelper(typeof({0}))<br>ctx.CommandText = helper.Select(filterExpression)<br>", tableName)
            resultBusinessLayer += "using (IDataReader reader = DaoBase.GetDataReader(ctx))<br>while (reader.Read())<br>"
            resultBusinessLayer += String.Format("result.Add(({0})helper.IDataReaderToObject(reader, new {0}()))<br>", tableName)
            resultBusinessLayer += "}<br>catch (Exception ex)<br>{<br>throw new Exception(ex.Message, ex)<br>}<br>finally<br>{<br>ctx.Close()<br>}<br>return result<br>}<br>#endregion"

            divBusinessLayer.InnerHtml = resultBusinessLayer
        End Sub

        Private Sub btnGenerateView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateView.Click
            Dim lstColumns As List(Of SysColumns) = BusinessLayer.GetSysColumnsList("object_ID = " + cboView.SelectedValue)

            Dim tableName As String = txtViewName.Text
            Dim oldTableName As String = cboView.SelectedItem.Text
            Dim listPK As List(Of String) = BusinessLayer.GetSysColumnsPKList(tableName)

            Dim listMember As String = ""
            Dim listField As String = ""
            For Each col As SysColumns In lstColumns

                listMember += String.Format("private {0} _{1};<br>", col.Type, col.Name)

                listField += String.Format("[Column(Name = ""{0}"", DataType = ""{1}"")]<br>", col.Name, col.Type)
                listField += String.Format("public {1} {0}<br>{{<br>get {{ return _{0}; }}<br>set {{ _{0} = value; }}<br>}}<br>", col.Name, col.Type)

            Next

            Dim result As String = ""
            result = String.Format("#region {0}<br>[Serializable]<br>[Table(Name = ""{1}"")]<br>public class {0}<br>{{<br>", tableName, oldTableName)
            result += listMember + "<br>"
            result += listField
            result += "}<br>#endregion"

            divResult.InnerHtml = result




            Dim resultBusinessLayer As String = ""
            resultBusinessLayer = String.Format("#region {0}<br>", tableName)

            resultBusinessLayer += String.Format("public static List < {0} > Get{0}List(string filterExpression)<br>{{<br>", tableName)
            resultBusinessLayer += String.Format("List < {0} > result = new List < {0} >();<br>", tableName)
            resultBusinessLayer += "IDbContext ctx = DbFactory.Configure();<br>try<br>{<br>"
            resultBusinessLayer += String.Format("DbHelper helper = new DbHelper(typeof({0}));<br>ctx.CommandText = helper.Select(filterExpression);<br>", tableName)
            resultBusinessLayer += "using (IDataReader reader = DaoBase.GetDataReader(ctx))<br>while (reader.Read() )<br>"
            resultBusinessLayer += String.Format("result.Add(({0})helper.IDataReaderToObject(reader, new {0}()));<br>", tableName)
            resultBusinessLayer += "}<br>catch (Exception ex)<br>{<br>throw new Exception(ex.Message, ex);<br>}<br>finally<br>{<br>ctx.Close();<br>}<br>return result;<br>}<br>#endregion"

            divBusinessLayer.InnerHtml = resultBusinessLayer
        End Sub
    End Class
End Namespace
