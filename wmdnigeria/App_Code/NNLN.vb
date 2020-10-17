Imports Microsoft.VisualBasic
Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Imports System.Xml

Public Class NNLN
    Inherits smsXMobile.smsXMobile


    Public Sub fillDropDownBox(ByRef cDropDown As dropDownFiller)
        Try
            Dim ds As DataSet
            If HasDatasetRecords(cDropDown.dsDB) = False Then
                ds = DataSetData(cDropDown.SQL)
                cDropDown.dsDB = ds
            Else
                ds = cDropDown.dsDB
            End If

            If String.IsNullOrEmpty(cDropDown.fieldname) = False AndAlso String.IsNullOrEmpty(cDropDown.uniqueName) = False Then
                cDropDown.ddlDown.DataValueField = cDropDown.uniqueName
                cDropDown.ddlDown.DataTextField = cDropDown.fieldname
            ElseIf String.IsNullOrEmpty(cDropDown.fieldname) Then
                cDropDown.ddlDown.DataValueField = cDropDown.fieldname
            End If
            cDropDown.ddlDown.DataSource = ds.Tables(0)
            cDropDown.ddlDown.DataBind()

            If cDropDown.NoDefaultValue = False Then
                If String.IsNullOrEmpty(cDropDown.defaultValue) = True Then
                    cDropDown.ddlDown.Items.Insert(0, "None")
                Else
                    cDropDown.ddlDown.Items.Insert(0, cDropDown.defaultValue)
                End If
            End If

        Catch ex As Exception
        End Try
    End Sub


    Public Function ImportExcelXLS(FileName As String, hasHeaders As Boolean) As DataSet
        Dim HDR As String = If(hasHeaders, "Yes", "No")
        Dim strConn As String
        If FileName.Substring(FileName.LastIndexOf("."c)).ToLower() = ".xlsx" Then
            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & FileName & ";Extended Properties=""Excel 12.0;HDR=" & HDR & ";IMEX=0"""
        Else
            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & FileName & ";Extended Properties=""Excel 8.0;HDR=" & HDR & ";IMEX=0"""
        End If

        Dim output As New DataSet()

        Using conn As New OleDbConnection(strConn)
            conn.Open()

            Dim schemaTable As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

            For Each schemaRow As DataRow In schemaTable.Rows
                Dim sheet As String = schemaRow("TABLE_NAME").ToString()

                If Not sheet.EndsWith("_") Then
                    Try
                        Dim cmd As New OleDbCommand("SELECT * FROM [" & sheet & "]", conn)
                        cmd.CommandType = CommandType.Text

                        Dim outputTable As New DataTable(sheet)
                        output.Tables.Add(outputTable)
                        Dim h As New OleDbDataAdapter(cmd)
                        h.Fill(outputTable)

                    Catch ex As Exception
                        Throw New Exception(ex.Message + String.Format("Sheet:{0}.File:F{1}", sheet, FileName), ex)
                    End Try
                End If
            Next
        End Using
        Return output
    End Function

    Public Function checkPhotoExtension(ByVal extName As String) As Boolean
        Try
            extName = LCase(extName)
            Dim accFn() As String = ".xls,.xlsx".Split(",")
            Return accFn.Contains(extName)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Convert2Word(ByVal number As String) As String
        Dim st As New Number2Words
        Return st.ConvertNow(number)
    End Function


    Public Function HasDatasetAnyRecord(ByVal ds As DataSet) As Boolean
        Try
            If ds Is Nothing OrElse ds.Tables.Count < 1 OrElse ds.Tables(0).Rows.Count < 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function getWebLink(ByVal bc As Web.HttpRequest) As String
        Try
            Return "http://".Trim & (bc.Url.Host & bc.ApplicationPath).Trim
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Sub PostPayment(ByVal pg As Page, ByVal postData As String)
        Try

            Dim request As System.Net.WebRequest = System.Net.WebRequest.Create("https://skyecipg.skyebankng.com:5443/MerchantServices/MakePayment.aspx")
            request.Method = "POST"

            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
        Catch ex As Exception
            MessageBox.Show(pg, ex.Message)
        End Try
    End Sub

    Public Sub DoOnlinePayment(ByVal pg As Page, ByVal amount As String, ByVal orderId As String, ByVal Narration As String, ByVal email As String)
        Try

            pg.Response.Clear()

            Dim sb = New StringBuilder()
            sb.Append("<html>")
            sb.AppendFormat("<body onload='document.forms[""form""].submit()'>")
            sb.AppendFormat("<form name='form' action='{0}' method='post'>", "https://skyecipg.skyebankng.com:5443/MerchantServices/MakePayment.aspx")
            sb.AppendFormat("<input type='hidden' name='sessionId' value='{0}'>", "000")

            sb.AppendFormat("<input type='hidden' name='mercId' value='{0}'>", "08641")

            'sb.AppendFormat("<input type='hidden' name='currCode' value='{0}'>", "560")

            sb.AppendFormat("<input type='hidden' name='amt' value='{0}'>", amount)
            sb.AppendFormat("<input type='hidden' name='orderId' value='{0}'>", orderId)

            sb.AppendFormat("<input type='hidden' name='prod' value='{0}'>", Narration)

            sb.AppendFormat("<input type='hidden' name='email' value='{0}'>", email)

            sb.AppendFormat("<input type='hidden' name='mercProductAmts' value='{0}'>", "004=300.00,005=400.00")

            sb.Append("</form>")
            sb.Append("</body>")
            sb.Append("</html>")

            pg.Response.Write(sb.ToString())

            pg.Response.End()

        Catch ex As Exception

        End Try
    End Sub

    Public Function getStatusBar(ByVal pg As Page, ByVal iret As Boolean) As String

        Dim hV As String = ""
        Dim imgV As String = "thirty.png"
        If String.IsNullOrEmpty(pg.Session("ID")) = True OrElse HasRows("select sysID from deviceregistration where AccountID=" & Val(pg.Session("ID"))) = False Then
            imgV = "thirty.png"

        ElseIf HasRows("select sysID from deviceregistration where NoDelete=0 AND AccountID=" & Val(pg.Session("ID"))) = False Then
            imgV = "hundered.png"
        ElseIf HasRows("select sysID from deviceregistration where AccountID=" & Val(pg.Session("ID"))) = True Then
            imgV = "seventy.png"
        End If

        If iret = True Then
            hV = "<div  style='height :30px' align='center' id='item_right'><strong></strong><img  alt='Statusbar' src='images/" & imgV & "'/></div>"
        Else
            hV = "<div style='height :30px' align='center'><strong></strong><img  alt='Statusbar' src='images/" & imgV & "'/></div>"
        End If
        Return hV

    End Function

    Public Function getUserLoggedIn(ByVal username As String) As String
        Dim sd As String
        sd = "<div  style='font-family: Calibri; width :70%; font-size: medium; font-weight: bold; color: #993333' align='right'>WELCOME " & username & " !</div>"
        Return sd
    End Function

    Public Function getFillCompany(ByVal companyID As String) As DataSet
        Return DataSetData("select companyName,streetAddress,cityID,LGAID,StateID,POBOX,companyEmail,companywebsite from companyregistration where sysID=" & Val(companyID))
    End Function

    Public Sub FormHistory(ByVal Message As String, ByVal IpAddres As String, Optional ByVal UserID As Int32 = 0, Optional ByVal companyID As Int32 = 0)
        Try
            Dim sd As String = "Insert into audit(RegDate,RegTime,UserID,companyID,Message,ipAddress) values(now(),now()," & UserID & "," & companyID & _
                "," & addbackslash(Message) & "," & addbackslash(IpAddres) & ") "
            ExecuteDatabase(sd)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SendFinancialMail(ByVal header As String, ByVal orderID As String, ByVal companyName As String, ByVal Amount As String, ByVal Narration As String, ByVal subject As String, ByVal email As String, ByVal payStatus As String, Optional ByVal welcome As String = "", Optional ByVal footer As String = "")

        Dim fs As String = getBody(header, orderID, companyName, Amount, Narration, payStatus, , )
        If welcome <> "" AndAlso footer <> "" Then
            fs = getBody(header, orderID, companyName, Amount, Narration, payStatus, welcome, footer)
        ElseIf welcome <> "" Then
            fs = getBody(header, orderID, companyName, Amount, Narration, payStatus, welcome)
        ElseIf footer <> "" Then
            fs = getBody(header, orderID, companyName, Amount, Narration, payStatus, , footer)
        End If

        sendmail(email, fs, subject)
    End Sub

    Public Sub getNextdsFrontPage()
        Try



            If HasDatasetAnyRecord(dsfrontpagemain) = False Then

                Dim ar As New ArrayList
                Dim km As Integer = 1
                Dim gs As Integer

                Do While km <= 4
                    Randomize()
                    Dim dh As New Random()
                    gs = dh.Next(0, dsfrontpagemain.Tables(0).Rows.Count)
                    If gs >= dsfrontpagemain.Tables(0).Rows.Count Then gs = dsfrontpagemain.Tables(0).Rows.Count - 1

                    Dim vv As String = "sysID=" & dsfrontpagemain.Tables(0).Rows(gs).Item("sysID").ToString

                    If ar.Contains(vv) = False Then
                        ar.Add(vv)
                        km += 1

                    End If

                Loop

                Dim sd As String = ""
                Dim fs As Integer = 1

                For k As Integer = 0 To ar.Count - 1

                    If sd = "" Then
                        sd = ar(k).ToString
                    Else
                        sd &= " OR " & ar(k).ToString
                    End If

                Next

                dsfrontpagemainFs4 = getFromDataset(dsfrontpagemain, sd)

            Else
                getFrontPagemain()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Function saveDs2DB(ByVal smsDataset As DataSet, ByVal tblName As String, ByVal uniqueID As String, ByVal field2Aviod As String, ByVal IsDevice As Boolean) As String
        Dim Result As String = ""
        Try

            Dim SQL As String = ""

            If smsDataset Is Nothing Then Return ""

            If String.IsNullOrEmpty(field2Aviod) = True Then field2Aviod = ""

            Dim ColName, SQLValue, FinalSQL, Cvalue, FNUpdate, QsampleUpdate, WClause, rTransCode As String
            rTransCode = ""

            For k As Int16 = 0 To smsDataset.Tables.Count - 1

                ColName = ""

                For M As Int16 = 0 To smsDataset.Tables(k).Columns.Count - 1

                    If smsDataset.Tables(k).Columns(M).ColumnName.ToLower <> field2Aviod.ToLower Then

                        If ColName = "" Then
                            ColName = smsDataset.Tables(k).Columns(M).ColumnName
                        Else
                            ColName &= "," & smsDataset.Tables(k).Columns(M).ColumnName
                        End If

                    End If

                Next

                For l As Long = 0 To smsDataset.Tables(k).Rows.Count - 1

                    QsampleUpdate = ""
                    SQLValue = ""

                    If IsDevice = True Then
                        If HasDatasetAnyRecord(dsFeeTableAll) = True Then
                            getFeeTable()
                        End If

                        Dim feeID As String = smsDataset.Tables(k).Rows(l).Item("feeID").ToString
                        Dim fAmount As String = Val(getRowItemInds(dsFeeTableAll, "amount", "sysID", feeID))
                        smsDataset.Tables(k).Rows(l).Item("deviceAmount") = fAmount

                    End If

                    For M As Int16 = 0 To smsDataset.Tables(k).Columns.Count - 1

                        If smsDataset.Tables(k).Columns(M).ColumnName.ToLower <> field2Aviod.ToLower Then

                            Cvalue = IIf((smsDataset.Tables(k).Rows(l).IsNull(M)) = True, "", smsDataset.Tables(k).Rows(l).Item(M))

                            If SQLValue = "" Then
                                SQLValue = GetTypeValue(smsDataset.Tables(k).Columns(M).DataType.Name, Cvalue)
                            Else
                                SQLValue &= "," & GetTypeValue(smsDataset.Tables(k).Columns(M).DataType.Name, Cvalue)
                            End If

                            FNUpdate = smsDataset.Tables(k).Columns(M).ColumnName

                            If QsampleUpdate = "" Then
                                QsampleUpdate = FNUpdate & "=" & GetTypeValue(smsDataset.Tables(k).Columns(M).DataType.Name, Cvalue)
                            Else
                                QsampleUpdate &= "," & FNUpdate & "=" & GetTypeValue(smsDataset.Tables(k).Columns(M).DataType.Name, Cvalue)
                            End If

                        End If
                    Next

                    Dim SysID As String = ""

                    SysID = IIf((smsDataset.Tables(k).Rows(l).IsNull(uniqueID)) = True, "", smsDataset.Tables(k).Rows(l).Item(uniqueID))

                    WClause = uniqueID & "=" & addbackslash(SysID)

                    SQL = "Select " & uniqueID & " from " & tblName & " where " & WClause

                    Dim IsUpdate As Boolean

                    If HasRows(SQL) = False Then
                        FinalSQL = "Insert Into " & tblName & " (" & ColName & ") VALUES (" & SQLValue & ")"
                        IsUpdate = True
                    Else
                        FinalSQL = "Update " & tblName & " SET " & QsampleUpdate & " Where " & WClause
                        IsUpdate = False
                    End If

                    If ExecuteDatabase(FinalSQL) = True Then

                        If IsDevice = True AndAlso IsUpdate = True Then
                            Dim Narration As String = "INSTRUMENT REGISTRATION FEE"
                            Dim orderID As String = Strings.Left(GenerateUniqueCode() & GenerateRNDCode(), 10)

                            Dim sdSQL As String = "Insert into paymentsheet(companyID,amountDue,narration,paymentName,OrderId,TransCode) values(" & _
                             Val(smsDataset.Tables(k).Rows(l).Item("AccountID").ToString) & "," & Val(smsDataset.Tables(k).Rows(l).Item("deviceAmount").ToString) & ",'Instrument Registration'," & addbackslash(smsDataset.Tables(k).Rows(l).Item("companyName").ToString) & "," & _
                             addbackslash(orderID) & "," & addbackslash(SysID) & ")"

                            ExecuteDatabase(sdSQL)

                            Dim ApplyForCertificate As Boolean = Val(smsDataset.Tables(k).Rows(l).Item("ApplyForCertificate").ToString)
                            Dim ApplyForVerificationCert As Boolean = Val(smsDataset.Tables(k).Rows(l).Item("ApplyForVerificationCert").ToString)

                            If ApplyForCertificate = True OrElse ApplyForVerificationCert = True Then
                                Narration = "INSTRUMENT REGISTRATION FEE<br><a href='http://www.nnlnigeria.com/documents/Pattern Approval Application.pdf'> Click To download Pattern Approval Document.</a><br> Please fill this document properly and return back to us. Thank you."
                            End If

                            SendFinancialMail("INSTRUMENT REGISTRATION INVOICE", orderID, smsDataset.Tables(k).Rows(l).Item("companyName").ToString, smsDataset.Tables(k).Rows(l).Item("deviceAmount").ToString, Narration, "INSTRUMENT REGISTRATION NEW", smsDataset.Tables(k).Rows(l).Item("companyEmail").ToString, "PENDING")

                        End If

                        Result = rTransCode
                        If rTransCode = "" Then
                            rTransCode = SysID
                        Else
                            rTransCode &= "," & SysID
                        End If
                        Result = rTransCode
                    End If

                Next

            Next

            Return Result

        Catch ex As Exception
            Return Result
        End Try
    End Function

    Private Sub sendmail(ByVal email As String, ByVal body As String, ByVal subject As String)
        Try
            Dim cBlast As New MailContents
            cBlast.AttarchFiles = ""
            cBlast.BodyM = body
            cBlast.IsBodyHtml = True
            cBlast.mailbcc = Nothing
            cBlast.mailcc = New Net.Mail.MailAddress("accounts@wmdnigeria.com")
            cBlast.mailfrom = New Net.Mail.MailAddress("accounts@wmdnigeria.com")
            cBlast.mailto = New Net.Mail.MailAddress(email)
            cBlast.Subject = subject
            SendnMailBox(cBlast)

        Catch ex As Exception
        End Try
    End Sub

    Public Function getTR(ByVal desc As String, ByVal filename As String, ByVal folder As String, Optional ByVal extraData As String = "") As String
        Dim sValue As String

        sValue = "<tr>" & _
        "<td>" & _
        "&nbsp;</td>" & _
        "<td>" & _
            "&nbsp;</td>" & _
       " <td>" & _
           " &nbsp;</td>" & _
       " <td align='center' style='width: 600px;font-family:  Courier; font-size: small;color:green'>" & _
        desc & "</td>" & _
        "<td align='left' style='font-family: calibri; font-size: small; font-weight: normal; font-style: bold; font-variant: normal;width: 300px; color:Black'>"

        If filename = "#" Then
            sValue &= "<a href='#'></a>" & "</td>"
        Else

            Dim gk As New Page

            Dim dg As String = pathdoclink & folder & "\" & filename

            If IO.File.Exists(dg) = True Then
                sValue &= "<a href='" & docLink & folder & "/" & filename & "'>" & filename & " | " & extraData & "</a>" & "</td>"
            Else
                sValue &= "<a href='#'>The File Is Not Longer Available</a>" & "</td>"
            End If

        End If

        sValue &= "<td>" & _
         "&nbsp;</td>" & _
       " <td>" & _
            "&nbsp;</td>" & _
        "<td>" & _
            "&nbsp;</td>" & _
         "</tr>"

        Return sValue

    End Function

    Public Function getPhotoGallery(ByVal image As String, ByVal header As String) As String
        Dim sd As String

        sd = "<tr>" & _
           " <td>" & _
              "  &nbsp;</td>" & _
           " <td>" & _
             "   &nbsp;</td>" & _
         "   <td>" & _
             "   &nbsp;</td>" & _
           " <td>" & _
           "     &nbsp;</td>" & _
           " <td align='center'>" & _
        IIf(image = "", "<div style='width:90%'>" & header & "</div>", "<img alt='no photo' src='" & docLink & "photogallery/" & image & "' width='60%' height='400px' align='center' />") & _
        "    </td>" & _
          "  <td>" & _
           "     &nbsp;</td>" & _
           " <td>" & _
            "    &nbsp;</td>" & _
            "<td>" & _
             "   &nbsp;</td>" & _
            "<td>" & _
             "   &nbsp;</td>"

        If header <> "" Then
            sd &= "       </tr>" & _
          " <tr>" & _
           "    <td colspan='9'>" & _
          " <hr/>" & _
            "   </td>" & _
           "</tr>"
        End If

        Return sd

    End Function

    Public Function getWhereSQL(ByVal contrl As Control, ByRef search As String, ByVal useWilcard As Boolean) As String

        Dim xtxt As Control
        For Each xtxt In contrl.Controls
            If TypeOf xtxt Is TextBox Then
                Dim txt As TextBox = CType(xtxt, TextBox)

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")

                    If search = "" Then
                        If txt.Text.Trim <> "" Then

                            If useWilcard = True Then
                                search = f(0) & " like " & addbackslash(txt.Text, , useWilcard)
                            Else
                                search = f(0) & "=" & addbackslash(txt.Text)
                            End If

                        End If
                    Else

                        If txt.Text.Trim <> "" Then
                            search &= " AND " & f(0) & "=" & addbackslash(txt.Text, , useWilcard)
                        End If
                    End If

                End If
            End If

            If TypeOf xtxt Is DropDownList Then
                Dim cbo As DropDownList = CType(xtxt, DropDownList)

                If cbo.ValidationGroup <> "" Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    Dim ffValues As String = cbo.Text

                    If cbo.SelectedIndex > 0 Then

                        If f.Length = 3 Then
                            ffValues = cbo.SelectedItem.Value
                        Else
                            ffValues = cbo.SelectedItem.Text
                        End If

                    End If

                    If f(0) <> "" AndAlso cbo.SelectedIndex > 0 Then

                        If search = "" Then

                            If ffValues.Trim <> "" Then
                                If useWilcard = True Then
                                    search = f(0) & " like " & addbackslash(ffValues, , useWilcard)
                                Else
                                    search = f(0) & "=" & addbackslash(ffValues)
                                End If

                            End If
                        Else

                            If ffValues.Trim <> "" Then
                                If useWilcard = True Then
                                    search &= " AND " & f(0) & " like " & addbackslash(ffValues, , useWilcard)
                                Else
                                    search &= " AND " & f(0) & "=" & addbackslash(ffValues)
                                End If

                            End If

                        End If

                    End If


                End If
            End If

        Next

        Return ""

    End Function

    Public Function generateSQL(ByVal contrl As Control, ByRef FN As String, ByRef FV As String, ByRef FUpdate As String, Optional DonotProcess As String = "", Optional IsTooTipContainingData As Boolean = False) As String
        Dim fM() As String = DonotProcess.Split(";")
        Dim xtxt As Control
        For Each xtxt In contrl.Controls

            If TypeOf xtxt Is CheckBox Then
                Dim txt As CheckBox = CType(xtxt, CheckBox)
                If txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 AndAlso txt.Checked = False Then
                        Return f(1)
                    End If
                End If
               
                If txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = IIf(txt.Checked = True, "1", "0")
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & IIf(txt.Checked = True, "1", "0")
                            FUpdate &= "," & f(0) & "=" & IIf(txt.Checked = True, "1", "0")
                        End If
                    End If
                End If
            End If

            If TypeOf xtxt Is RadioButton Then
                Dim txt As RadioButton = CType(xtxt, RadioButton)
                If txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 AndAlso txt.Checked = False Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = IIf(txt.Checked = True, "1", "0")
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & IIf(txt.Checked = True, "1", "0")
                            FUpdate &= "," & f(0) & "=" & IIf(txt.Checked = True, "1", "0")
                        End If
                    End If
                End If
            End If


            If TypeOf xtxt Is TextBox Then
                Dim txt As TextBox = CType(xtxt, TextBox)
                If txt.Text.Trim = "" AndAlso txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" AndAlso fM.Contains(txt.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(txt.Text)
                            If String.IsNullOrEmpty(txt.ToolTip) = False Then
                                FUpdate = txt.ToolTip & "--" & FN & "=" & FV
                            Else
                                FUpdate = FN & "=" & FV
                            End If

                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(txt.Text)
                            If String.IsNullOrEmpty(txt.ToolTip) = False Then
                                FUpdate &= txt.ToolTip & "--" & f(0) & "=" & addbackslash(txt.Text)
                            Else
                                FUpdate &= "," & f(0) & "=" & addbackslash(txt.Text)
                            End If

                        End If
                    End If
                End If
            End If


            If TypeOf xtxt Is DropDownList Then
                Dim cbo As DropDownList = CType(xtxt, DropDownList)
                If cbo.SelectedIndex <= 0 AndAlso fM.Contains(cbo.ValidationGroup.Split("|").ToArray(0).Trim) = False Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If cbo.ValidationGroup <> "" AndAlso fM.Contains(cbo.ValidationGroup.Split("|").ToArray(0)) = False Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    Dim ffValues As String = cbo.Text

                    If f.Length = 3 Then
                        ffValues = cbo.SelectedItem.Value
                    Else
                        ffValues = cbo.SelectedItem.Text
                    End If

                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(ffValues)
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(ffValues)
                            FUpdate &= "," & f(0) & "=" & addbackslash(ffValues)
                        End If
                    End If

                End If
            End If

            If xtxt.HasControls = True Then
                Dim f As String = generateSQL(xtxt, FN, FV, FUpdate, DonotProcess, IsTooTipContainingData)
                If String.IsNullOrEmpty(f) = False Then Return f
            End If
        Next

        Return ""

    End Function

    Public Function checkControl(ByVal contrl As Control, ByRef FN As String, ByRef FV As String, ByRef FUpdate As String) As String

        Dim xtxt As Control
        For Each xtxt In contrl.Controls

            If TypeOf xtxt Is CheckBox Then
                Dim txt As CheckBox = CType(xtxt, CheckBox)
                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 AndAlso txt.Checked = False Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = IIf(txt.Checked = True, "1", "0")
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & IIf(txt.Checked = True, "1", "0")
                            FUpdate &= "," & f(0) & "=" & IIf(txt.Checked = True, "1", "0")
                        End If
                    End If
                End If
            End If

            'If TypeOf xtxt Is RadioButton Then
            '    Dim txt As RadioButton = CType(xtxt, RadioButton)
            '    If txt.ValidationGroup <> "" Then
            '        Dim f() As String = txt.ValidationGroup.Split("|")
            '        If f.Length > 1 AndAlso txt.Checked = False Then
            '            Return f(1)
            '        End If
            '    End If

            '    If txt.ValidationGroup <> "" Then
            '        Dim f() As String = txt.ValidationGroup.Split("|")
            '        If f(0) <> "" Then
            '            If FN = "" Then
            '                FN = f(0)
            '                FV = IIf(txt.Checked = True, "1", "0")
            '                FUpdate = FN & "=" & FV
            '            Else
            '                FN &= "," & f(0)
            '                FV &= "," & IIf(txt.Checked = True, "1", "0")
            '                FUpdate &= "," & f(0) & "=" & IIf(txt.Checked = True, "1", "0")
            '            End If
            '        End If
            '    End If
            'End If


            If TypeOf xtxt Is TextBox Then
                Dim txt As TextBox = CType(xtxt, TextBox)
                If txt.Text.Trim = "" AndAlso txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If txt.ValidationGroup <> "" Then
                    Dim f() As String = txt.ValidationGroup.Split("|")
                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(txt.Text)
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(txt.Text)
                            FUpdate &= "," & f(0) & "=" & addbackslash(txt.Text)
                        End If
                    End If
                End If
            End If


            If TypeOf xtxt Is DropDownList Then
                Dim cbo As DropDownList = CType(xtxt, DropDownList)
                If cbo.SelectedIndex <= 0 Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    If f.Length > 1 Then
                        Return f(1)
                    End If
                End If

                If cbo.ValidationGroup <> "" Then
                    Dim f() As String = cbo.ValidationGroup.Split("|")
                    Dim ffValues As String = cbo.Text

                    If f.Length = 3 Then
                        ffValues = cbo.SelectedItem.Value
                    Else
                        ffValues = cbo.SelectedItem.Text
                    End If

                    If f(0) <> "" Then
                        If FN = "" Then
                            FN = f(0)
                            FV = addbackslash(ffValues)
                            FUpdate = FN & "=" & FV
                        Else
                            FN &= "," & f(0)
                            FV &= "," & addbackslash(ffValues)
                            FUpdate &= "," & f(0) & "=" & addbackslash(ffValues)
                        End If
                    End If

                End If
            End If

        Next

        Return ""

    End Function

    Public Sub resetFont(ByVal obj As Object, ByVal fontname As String, ByVal fontsize As Int16)
        Try
            Dim ctn As New System.Web.UI.Control

            For Each ctn In obj.Controls

                If TypeOf ctn Is System.Web.UI.WebControls.TextBox Then
                    Dim txt As TextBox = CType(ctn, TextBox)

                    If txt.ValidationGroup <> "" Then
                        txt.Font.Name = fontname
                        txt.Font.Size = fontsize
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.DropDownList Then
                    Dim cbod As DropDownList = CType(ctn, DropDownList)

                    If cbod.ValidationGroup <> "" Then
                        cbod.Font.Name = fontname
                        cbod.Font.Size = fontsize
                    End If

                End If

            Next

        Catch ex As Exception
        End Try
    End Sub

    Public Sub resetform(ByVal obj As Object, Optional ByVal ds As DataSet = Nothing)

        Dim ctn As New System.Web.UI.Control

        For Each ctn In obj.Controls

            Try
                If TypeOf ctn Is System.Web.UI.WebControls.TextBox Then
                    Dim txt As TextBox = CType(ctn, TextBox)

                    If ds IsNot Nothing Then
                        txt.Text = getValueSystem(ds, txt.ValidationGroup)
                        If txt.TextMode = TextBoxMode.Password Then
                            txt.Attributes.Add("value", txt.Text)
                        End If
                    Else
                        txt.Text = ""
                        If txt.TextMode = TextBoxMode.Password Then
                            txt.Attributes.Add("value", "")
                        End If
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.DropDownList Then
                    Dim cbod As DropDownList = CType(ctn, DropDownList)

                    If ds IsNot Nothing Then
                        cbod.SelectedIndex = getddlindexvalue(cbod, getValueSystem(ds, cbod.ValidationGroup))
                    Else

                        If cbod.Items.Count > 0 Then
                            cbod.SelectedIndex = 0
                        Else
                            cbod.Text = ""
                        End If
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.CheckBox Then
                    Dim chk As CheckBox = CType(ctn, CheckBox)

                    If ds IsNot Nothing Then
                        Dim f As String = getValueSystem(ds, chk.ValidationGroup)

                        If Val(f) > 0 Then
                            chk.Checked = True
                        Else
                            chk.Checked = False
                        End If
                    Else
                        chk.Checked = False
                    End If

                End If

                If TypeOf ctn Is System.Web.UI.WebControls.RadioButton Then
                    Dim chk As RadioButton = CType(ctn, RadioButton)

                    If ds IsNot Nothing Then
                        Dim f As String = getValueSystem(ds, chk.ValidationGroup)

                        If Val(f) > 0 Then
                            chk.Checked = True
                        Else
                            chk.Checked = False
                        End If
                    Else
                        chk.Checked = False
                    End If

                End If
            Catch ex As Exception

            End Try
        Next


    End Sub

    Public Function SendnMailBox(ByVal cBlast As MailContents) As Boolean
        Return SendMailDirect("mail.nnlnigeria.com", "sales@nnlnigeria.com", "nnl_2013_1234_nnl_7", cBlast.BodyM, cBlast.Subject, Net.Mail.DeliveryNotificationOptions.OnSuccess, Net.Mail.MailPriority.Normal, _
           cBlast.mailto, cBlast.mailfrom, cBlast.AttarchFiles, cBlast.mailbcc, cBlast.mailcc, cBlast.IsBodyHtml, cBlast.enableSSL)
    End Function

    Public Function getSummation(ByVal grd As GridView, ByVal colNumber As Int16) As String
        Dim sum As Single = 0
        Try
            For j As Long = 0 To grd.Rows.Count - 1
                sum += Val(grd.Rows(j).Cells(colNumber).Text)
            Next
        Catch ex As Exception
        End Try
        Return sum
    End Function

    Public Function getRowItemInds(ByVal ds As DataSet, ByVal rfield As String, ByVal sfield As String, ByVal svalue As String, Optional ByVal tblname As String = "") As String
        Try
            If String.IsNullOrEmpty(tblname) = True Then

                For k As Long = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
                        Dim sResult As String = .Item(sfield).ToString.Trim.ToLower
                        If sResult = svalue.Trim.ToLower Then
                            Return .Item(rfield)
                        End If
                    End With
                Next

            Else
                For k As Long = 0 To ds.Tables(tblname).Rows.Count - 1
                    With ds.Tables(tblname).Rows(k)
                        Dim sResult As String = .Item(sfield).ToString.Trim.ToLower
                        If sResult = svalue.Trim.ToLower Then
                            Return .Item(rfield)
                        End If
                    End With
                Next

            End If

            Return ""
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function getValueSystem(ByVal ds As DataSet, ByVal xms As String) As String
        Dim fValues As String = ""
        Try

            If xms <> "" Then

                Dim f() As String = xms.Split("|")
                Dim ffValues As String = ""

                Try

                    If f.Length = 3 Then

                        'If Val(f(2)) = 1 Then
                        '    fValues
                        'ElseIf Val(f(2)) = 2 Then

                        'ElseIf Val(f(2)) = 3 Then

                        'End If
                    Else
                        fValues = ds.Tables(0).Rows(0).Item(f(0))
                    End If

                Catch ex As Exception
                End Try

            End If

            Return fValues
        Catch ex As Exception
            Return fValues
        End Try
    End Function

    Private Function getBody(ByVal header As String, ByVal orderID As String, ByVal companyName As String, ByVal amount As String, ByVal Narration As String, ByVal payStatus As String, Optional ByVal Welcome As String = "Transaction Notification", Optional ByVal Footer As String = "You can login to view your invoice current status on our <a href='http://www.weightsandmeasuresnigeria.com/invioces.aspx'>website</a> <br> This is a confidential information,please discard it if it is recieved in error.") As String
        Return "<html>" & _
"<head>" & _
"    <title></title>" & _
"    <style type ='text/css'> " & _
"	body {" & _
"	   margin : 0px 0px 0px 0px;" & _
"	background:  white url('img/background4.png') repeat-x top left;" & _
"		}" & _
"    a.main_links {" & _
"      color: #5c5c5c;" & _
"      font-size: 11px;" & _
"      font-family: Verdana, Arial;" & _
"      margin: 0px 0px 0px 0px;" & _
"      font-weight: normal;" & _
"      }" & _
" " & _
"      a.main_links:hover {" & _
"      color: #333333 !important;" & _
"	  text-decoration: none;" & _
"      }" & _
"      " & _
"      toptoolbar" & _
"      {" & _
"      	margin: 0; padding: 0; background: #6895ab url('img/navbarbackground.png') repeat-x; font-size: 70%; width: 100%; border-top: 1px solid #40738b; position: relative; color: #333; float: left; clear: both;" & _
"      }" & _
"      " & _
"      .zebraeven { background-color: #fefefe; }" & _
"      .zebraodd  { background-color: #f7f5e7; }" & _
"      .datesub { PADDING-TOP: 6px; PADDING-BOTTOM: 6px; }" & _
"" & _
"    .datecontainer { FONT: 28px Trebuchet MS, Calibri, Verdana, Arial, Helvetica; padding-top: 3px; }" & _
"" & _
"    .boxcontainer { margin: 16px 0 16px 0; padding: 10px; BACKGROUND: #F2F2EB; -moz-border-radius: 12px 12px 0 0; -webkit-border-radius: 12px 12px 0 0;  border-radius: 12px 12px 0 0; }" & _
"" & _
"    .boxcontainerlabel { font-family: Candara, Trebuchet MS, Verdana, Calibri, Helvetica, sans-serif; font-size: 22px; font-weight: bold; color: #4e4e4e; margin-bottom: 8px; TEXT-SHADOW: 0 1px 0 rgba(255, 255, 255, 0.85); }" & _
"" & _
"    .boxcontainercontent { border: 2px SOLID #e2e2d6; background: white; padding: 10px; font-size: 12px;}" & _
"" & _
"    .boxcontainercontenttight { border: 2px SOLID #e2e2d6; background: white; font-size: 12px; }" & _
"" & _
"    .zebraeven { background-color: #fefefe; }" & _
"    .zebraodd  { background-color: #f7f5e7; }" & _
"    .redtext { COLOR: red; }" & _
"    .graytext { COLOR: #333333; }" & _
"" & _
"    .hlineheader { width: 100%; margin: 0; padding: 0; white-space: nowrap; color: #277dca; font-family: Candara, Trebuchet MS, Verdana, Calibri, Helvetica, Georgia,serif; text-decoration: none; font-size: 14px; font-weight: none; }" & _
"    .hlineheader th { margin: 0; padding: 0 8px 0 0; }" & _
"    .hlineheader td { font-size: 50%; margin: 0; padding: 0; }" & _
"    td.hlinelower { border-top: 1px solid #ececec; width: 100%; }" & _
"    .hlinegray { color: #626262 !important; }" & _
"" & _
"" & _
".subcontent { padding: 4px 0px 4px 4px; }" & _
".captchaholder { padding: 4px 0 4px 0; }" & _
"" & _
" toptoolbar               { margin: 0; padding: 0; background: #6895ab url('img/navbarbackground.png') repeat-x; font-size: 70%; width: 100%; border-top: 1px solid #40738b; position: relative; color: #333; float: left; clear: both; }" & _
" toptoolbar a             { color: white; font-weight: bold; font-family: 'trebuchet ms', verdana, helvetica, sans-serif; font-size: 16px; text-decoration: none; text-shadow:0 1px 0 rgba(0, 0, 0, 0.6); }" & _
" toptoolbarrightarea      { float: right; display: inline-block; margin-top: 0.2em; margin-right: 0.4em; height: 100%; }" & _
" toptoolbarrightareainset { display: inline-block; }" & _
" toptoolbar select        { border: 1px solid #cdc2ab; font-family: verdana, tahoma, sans-serif; font-size: 1em; margin: 5px 5px 0 0; }" & _
" toptoolbarlinklist { margin: 0; padding: 0; }" & _
" toptoolbarlinklist ul         {  }" & _
" toptoolbarlinklist li         { list-style-type: none; display: inline-block; float: left; margin: 0.2em 0 0 .8em; padding: 0; clear: none; }" & _
" toptoolbarlinklist li:hover   { background: url('img/topbarhoverarrow.png') no-repeat bottom center transparent; }" & _
" toptoolbarlinklist li.current { background: url('img/topbarcurrentarrow.png') no-repeat bottom center transparent; }	" & _
"" & _
".leftnavboxcontent         { border: 1px solid #cdc6b6; }" & _
".leftnavboxcontent a       { display: block; text-decoration: none; color: black; font-family: Verdana, Tahoma, sans-serif; font-size: 11px; border-bottom: 1px solid #f5f5f5; text-indent: 20px; padding: 0.375em; background-image: url('img/icon_folderyellow.gif'); background-repeat: no-repeat; background-position: 0.375em 0.25em; line-height: 140%; }" & _
".leftnavboxcontent a:hover { background-color: #fff8e9; color: #476ca4; }" & _
".searchboxcontainer { border: 4px SOLID rgba(204, 204, 204, 0.6); -moz-border-radius: 6px; -webkit-border-radius: 6px; border-radius: 6px; }" & _
".searchbox { border: 1px SOLID #cccccc; }" & _
".searchbuttoncontainer { float: right; height: 35px; vertical-align: top; }" & _
".searchbutton { -moz-border-radius: 7px 7px 7px 7px; -webkit-border-radius: 7px 7px 7px 7px; border-radius: 7px 7px 7px 7px; background: #7bc17a; color: white !important; display: inline-block; font-size: 11px; font-weight: bold; padding: 6px 12px 6px 12px; text-decoration: none; text-shadow: 1px 1px 1px rgba(0, 0, 0, 0.2); margin: 4px 5px 0px 0px; CURSOR: pointer; }" & _
".searchbutton:hover { background: #88cc85; color: white !important; }" & _
".searchbutton span { background: URL(img/searchpointer.png); display: inline; float: right; margin: 1px 0 0 5px; height: 13px; width: 12px; }" & _
".searchinputcontainer { height: 35px; outline: none; display: inline-block; width: 80%; }" & _
".searchquery { width: 100%; margin: 1px 0 0 0; background: url(img/icon_search.png) no-repeat 8px 6px; padding: 5px 6px 7px 30px; border: 0px; color: #d5d5d5; font-size: 18px; font-family: 'Lucida Grande','Helvetica Neue',Helvetica,Arial,Verdana,sans-serif; height: 20px; }" & _
".searchqueryactive { color: #666666 !important; }" & _
"" & _
"    .style1" & _
"    {" & _
"        width: 282px;" & _
"    }" & _
"    .style2" & _
"    {" & _
"        width: 137px;" & _
"    }" & _
"" & _
"    .style3" & _
"    {" & _
"        width: 90px;" & _
"    }" & _
"" & _
"    .style4" & _
"    {" & _
"        width: 137px;" & _
"        height: 32px;" & _
"    }" & _
"    .style5" & _
"    {" & _
"        width: 90px;" & _
"        height: 32px;" & _
"    }" & _
"" & _
"    .style9" & _
"    {" & _
"    }" & _
"    .style10" & _
"    {" & _
"        width: 678px;" & _
"        height: 162px;" & _
"    }" & _
"" & _
"    .style11" & _
"    {" & _
"        width: 164px;" & _
"    }" & _
"" & _
"    .style12" & _
"    {" & _
"        width: 734px;" & _
"    }" & _
"" & _
"    </style>" & _
"</head>" & _
"<body>" & _
"    <form id='form1' runat='server'>" & _
"    <center>" & _
"    <div class='boxcontainer' style='width:50%' >" & _
"        <div class='boxcontainerlabel'>" & _
"            " & header & "</div>" & _
"        <div id='renderpower' class='boxcontainercontent'>" & _
"            <table class='hlineheader'>" & _
"                <tr>" & _
"                    <th nowrap rowspan='2'>" & _
"                        General Information</th>" & _
"                    <td>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td class='hlinelower'>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"            </table>" & _
"            <table border='0' cellpadding='4' cellspacing='1' width='100%'>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle' width='200'>" & _
"                        Order ID/Invoice ID</td>" & _
"                    <td align='left'>" & _
"                        " & orderID & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        COMPANY NAME</td>" & _
"                    <td align='left'>" & _
"                        " & companyName & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        AMOUNT</td>" & _
"                    <td align='left'>" & _
"                        " & amount & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' class='zebraodd' valign='middle'>" & _
"                        PAYMENT STATUS</td>" & _
"                    <td align='left'>" & _
"                        " & payStatus & "</td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"            <table class='hlineheader'>" & _
"                <tr>" & _
"                    <th nowrap rowspan='2'>" & _
"                        " & Welcome & "!</th>" & _
"                    <td>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td class='hlinelower'>" & _
"                        &nbsp;</td>" & _
"                </tr>" & _
"            </table>" & _
"            <table border='0' cellpadding='4' cellspacing='1' width='100%'>" & _
"                <tr>" & _
"                    <td align='left' valign='top' colspan='2'>" & _
"                       " & Narration & "</td>" & _
"                </tr>" & _
"                <tr>" & _
"                    <td align='left' valign='top' colspan='2'>" & _
"              <strong>" & Footer & "</strong></td>" & _
"                </tr>" & _
"            </table>" & _
"            <br />" & _
"        </div>" & _
"        </center>" & _
"    </form>" & _
"</body>" & _
"</html>"

    End Function

End Class

Public Class MailContents
    Dim _mailto As Net.Mail.MailAddress
    Dim _mailfrom As Net.Mail.MailAddress
    Dim _mailcc As Net.Mail.MailAddress
    Dim _mailbcc As Net.Mail.MailAddress
    Dim _Subject As String
    Dim _AttarchFiles As String
    Dim _IsBodyHtml As Boolean
    Dim _Body As String
    Dim _enableSSL As Boolean

    Property enableSSL As Boolean
        Get
            Return _enableSSL
        End Get
        Set(ByVal value As Boolean)
            _enableSSL = value
        End Set
    End Property

    Property Subject As String
        Get
            Return _Subject
        End Get
        Set(ByVal value As String)
            _Subject = value
        End Set
    End Property

    Property AttarchFiles As String
        Get
            Return _AttarchFiles
        End Get
        Set(ByVal value As String)
            _AttarchFiles = value
        End Set
    End Property

    Property BodyM As String
        Get
            Return _Body
        End Get
        Set(ByVal value As String)
            _Body = value
        End Set
    End Property


    Property mailto As Net.Mail.MailAddress
        Get
            Return _mailto
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailto = value
        End Set
    End Property

    Property mailfrom As Net.Mail.MailAddress
        Get
            Return _mailfrom
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailfrom = value
        End Set
    End Property

    Property mailcc As Net.Mail.MailAddress
        Get
            Return _mailcc
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailcc = value
        End Set
    End Property

    Property mailbcc As Net.Mail.MailAddress
        Get
            Return _mailbcc
        End Get
        Set(ByVal value As Net.Mail.MailAddress)
            _mailbcc = value
        End Set
    End Property

    Property IsBodyHtml As Boolean
        Get
            Return _IsBodyHtml
        End Get
        Set(ByVal value As Boolean)
            _IsBodyHtml = value
        End Set
    End Property
End Class

Public Class StaticTemplate

    Dim _btnSave As Button
    Dim _btnDelete As Button
    Dim _btnReset As Button

    Dim _txtObjectName As TextBox
    Dim _txtObjectID As TextBox

    Dim _btnSaveExtenter As AjaxControlToolkit.ConfirmButtonExtender
    Dim _btnDeleteExtenter As AjaxControlToolkit.ConfirmButtonExtender
    Dim _btnResetExtenter As AjaxControlToolkit.ConfirmButtonExtender

    Dim _lblTotalResult As Label
    Dim _SQLData As String
    Dim _grdView As GridView

    Dim _fieldName As String
    Dim _tableName As String
    Dim _errorMsg As String
    Dim _tabObject As AjaxControlToolkit.TabPanel

    Property tabObject As AjaxControlToolkit.TabPanel
        Get
            Return _tabObject
        End Get
        Set(ByVal value As AjaxControlToolkit.TabPanel)
            _tabObject = value
        End Set
    End Property

    Property grdView As GridView
        Get
            Return _grdView
        End Get
        Set(ByVal value As GridView)
            _grdView = value
        End Set
    End Property

    Property btnSave As Button
        Get
            Return _btnSave
        End Get
        Set(ByVal value As Button)
            _btnSave = value
        End Set
    End Property

    Property btnDelete As Button
        Get
            Return _btnDelete
        End Get
        Set(ByVal value As Button)
            _btnDelete = value
        End Set
    End Property

    Property btnReset As Button
        Get
            Return _btnReset
        End Get
        Set(ByVal value As Button)
            _btnReset = value
        End Set
    End Property

    Property txtObjectName As TextBox
        Get
            Return _txtObjectName
        End Get
        Set(ByVal value As TextBox)
            _txtObjectName = value
        End Set
    End Property

    Property txtObjectID As TextBox
        Get
            Return _txtObjectID
        End Get
        Set(ByVal value As TextBox)
            _txtObjectID = value
        End Set
    End Property

    Property btnSaveExtenter As AjaxControlToolkit.ConfirmButtonExtender
        Get
            Return _btnSaveExtenter
        End Get
        Set(ByVal value As AjaxControlToolkit.ConfirmButtonExtender)
            _btnSaveExtenter = value
        End Set
    End Property

    Property btnDeleteExtenter As AjaxControlToolkit.ConfirmButtonExtender
        Get
            Return _btnDeleteExtenter
        End Get
        Set(ByVal value As AjaxControlToolkit.ConfirmButtonExtender)
            _btnDeleteExtenter = value
        End Set
    End Property

    Property btnResetExtenter As AjaxControlToolkit.ConfirmButtonExtender
        Get
            Return _btnResetExtenter
        End Get
        Set(ByVal value As AjaxControlToolkit.ConfirmButtonExtender)
            _btnResetExtenter = value
        End Set
    End Property

    Property lblTotalResult As Label
        Get
            Return _lblTotalResult
        End Get
        Set(ByVal value As Label)
            _lblTotalResult = value
        End Set
    End Property

    Property SQLData As String
        Get
            Return _SQLData
        End Get
        Set(ByVal value As String)
            _SQLData = value
        End Set
    End Property

    Property fieldName As String
        Get
            Return _fieldName
        End Get
        Set(ByVal value As String)
            _fieldName = value
        End Set
    End Property

    Property tableName As String
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value
        End Set
    End Property

    Property errorMsg As String
        Get
            Return _errorMsg
        End Get
        Set(ByVal value As String)
            _errorMsg = value
        End Set
    End Property

End Class

Public Class systemDBUsers
    Dim _sysid As Int32
    Dim _username As String
    Dim _userpwd As String
    Dim _companyname As String
    Dim _surname As String
    Dim _firstname As String
    Dim _othernames As String
    Dim _phone As String
    Dim _email As String
    Dim _contacaddress As String
    Dim _securityquestion As String
    Dim _securityanswer As String
    Dim _sysadminright As Boolean
    Dim _operatorright As Boolean
    Dim _systemmonitorright As Boolean
    Dim _recordstatus As Boolean
    Dim _reportright As Boolean
    Dim _staticdataright As Boolean
    Dim _companymgtright As Boolean
    Dim _monitoroperatoronlyright As Boolean
    Dim _auditright As Boolean
    Dim _approveexportimport As Boolean
    Dim _inspectexportimport As Boolean
    Dim _endorseexportimport As Boolean
    Dim _recommendexportimport As Boolean
    Dim _dataimportright As Boolean
    Dim _devicemdgtright As Boolean
    Dim _billtable As Boolean
    Dim _regdate As Date
    Dim _regdatemodify As Date
    Dim _isisp As Boolean
    Dim _setmainpage As Boolean
    Dim _managelot As Boolean
    Dim _downloadcenter As Boolean
    Dim _isclient As Boolean
    Dim _offlineversion As Int32
    Dim _uploadphotogallery As Boolean
    Dim _archiveright As Boolean
    Dim _quizright As Boolean
    Dim _carrearright As Boolean
    Dim _emailright As Boolean
    Dim _otherdocright As Boolean
    Dim _exportdatareturns As Boolean
    Dim _piaexportdatareturns As Boolean
    Dim _accountsreport As Boolean
    Dim _admregistration As Boolean
    Dim _ExportAlertright As Boolean

    Property sysid() As Int32
        Get
            Return _sysid
        End Get
        Set(ByVal value As Int32)
            _sysid = Value
        End Set
    End Property

    Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = Value
        End Set
    End Property

    Property userpwd() As String
        Get
            Return _userpwd
        End Get
        Set(ByVal value As String)
            _userpwd = Value
        End Set
    End Property

    Property companyname() As String
        Get
            Return _companyname
        End Get
        Set(ByVal value As String)
            _companyname = Value
        End Set
    End Property

    Property surname() As String
        Get
            Return _surname
        End Get
        Set(ByVal value As String)
            _surname = Value
        End Set
    End Property

    Property firstname() As String
        Get
            Return _firstname
        End Get
        Set(ByVal value As String)
            _firstname = Value
        End Set
    End Property

    Property othernames() As String
        Get
            Return _othernames
        End Get
        Set(ByVal value As String)
            _othernames = Value
        End Set
    End Property

    Property phone() As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = Value
        End Set
    End Property

    Property email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = Value
        End Set
    End Property

    Property contacaddress() As String
        Get
            Return _contacaddress
        End Get
        Set(ByVal value As String)
            _contacaddress = Value
        End Set
    End Property

    Property securityquestion() As String
        Get
            Return _securityquestion
        End Get
        Set(ByVal value As String)
            _securityquestion = Value
        End Set
    End Property

    Property securityanswer() As String
        Get
            Return _securityanswer
        End Get
        Set(ByVal value As String)
            _securityanswer = Value
        End Set
    End Property

    Property sysadminright() As Boolean
        Get
            Return _sysadminright
        End Get
        Set(ByVal value As Boolean)
            _sysadminright = Value
        End Set
    End Property

    Property operatorright() As Boolean
        Get
            Return _operatorright
        End Get
        Set(ByVal value As Boolean)
            _operatorright = Value
        End Set
    End Property

    Property systemmonitorright() As Boolean
        Get
            Return _systemmonitorright
        End Get
        Set(ByVal value As Boolean)
            _systemmonitorright = Value
        End Set
    End Property

    Property recordstatus() As Boolean
        Get
            Return _recordstatus
        End Get
        Set(ByVal value As Boolean)
            _recordstatus = Value
        End Set
    End Property

    Property reportright() As Boolean
        Get
            Return _reportright
        End Get
        Set(ByVal value As Boolean)
            _reportright = Value
        End Set
    End Property

    Property staticdataright() As Boolean
        Get
            Return _staticdataright
        End Get
        Set(ByVal value As Boolean)
            _staticdataright = Value
        End Set
    End Property

    Property companymgtright() As Boolean
        Get
            Return _companymgtright
        End Get
        Set(ByVal value As Boolean)
            _companymgtright = Value
        End Set
    End Property

    Property monitoroperatoronlyright() As Boolean
        Get
            Return _monitoroperatoronlyright
        End Get
        Set(ByVal value As Boolean)
            _monitoroperatoronlyright = Value
        End Set
    End Property

    Property auditright() As Boolean
        Get
            Return _auditright
        End Get
        Set(ByVal value As Boolean)
            _auditright = Value
        End Set
    End Property

    Property approveexportimport() As Boolean
        Get
            Return _approveexportimport
        End Get
        Set(ByVal value As Boolean)
            _approveexportimport = Value
        End Set
    End Property

    Property inspectexportimport() As Boolean
        Get
            Return _inspectexportimport
        End Get
        Set(ByVal value As Boolean)
            _inspectexportimport = Value
        End Set
    End Property

    Property endorseexportimport() As Boolean
        Get
            Return _endorseexportimport
        End Get
        Set(ByVal value As Boolean)
            _endorseexportimport = Value
        End Set
    End Property

    Property recommendexportimport() As Boolean
        Get
            Return _recommendexportimport
        End Get
        Set(ByVal value As Boolean)
            _recommendexportimport = Value
        End Set
    End Property

    Property dataimportright() As Boolean
        Get
            Return _dataimportright
        End Get
        Set(ByVal value As Boolean)
            _dataimportright = Value
        End Set
    End Property

    Property devicemdgtright() As Boolean
        Get
            Return _devicemdgtright
        End Get
        Set(ByVal value As Boolean)
            _devicemdgtright = Value
        End Set
    End Property

    Property billtable() As Boolean
        Get
            Return _billtable
        End Get
        Set(ByVal value As Boolean)
            _billtable = Value
        End Set
    End Property

    Property regdate() As Date
        Get
            Return _regdate
        End Get
        Set(ByVal value As Date)
            _regdate = Value
        End Set
    End Property

    Property regdatemodify() As Date
        Get
            Return _regdatemodify
        End Get
        Set(ByVal value As Date)
            _regdatemodify = Value
        End Set
    End Property

    Property isisp() As Boolean
        Get
            Return _isisp
        End Get
        Set(ByVal value As Boolean)
            _isisp = Value
        End Set
    End Property

    Property setmainpage() As Boolean
        Get
            Return _setmainpage
        End Get
        Set(ByVal value As Boolean)
            _setmainpage = Value
        End Set
    End Property

    Property managelot() As Boolean
        Get
            Return _managelot
        End Get
        Set(ByVal value As Boolean)
            _managelot = Value
        End Set
    End Property

    Property downloadcenter() As Boolean
        Get
            Return _downloadcenter
        End Get
        Set(ByVal value As Boolean)
            _downloadcenter = Value
        End Set
    End Property

    Property isclient() As Boolean
        Get
            Return _isclient
        End Get
        Set(ByVal value As Boolean)
            _isclient = Value
        End Set
    End Property

    Property offlineversion() As Int32
        Get
            Return _offlineversion
        End Get
        Set(ByVal value As Int32)
            _offlineversion = Value
        End Set
    End Property

    Property uploadphotogallery() As Boolean
        Get
            Return _uploadphotogallery
        End Get
        Set(ByVal value As Boolean)
            _uploadphotogallery = Value
        End Set
    End Property

    Property archiveright() As Boolean
        Get
            Return _archiveright
        End Get
        Set(ByVal value As Boolean)
            _archiveright = Value
        End Set
    End Property

    Property quizright() As Boolean
        Get
            Return _quizright
        End Get
        Set(ByVal value As Boolean)
            _quizright = Value
        End Set
    End Property

    Property carrearright() As Boolean
        Get
            Return _carrearright
        End Get
        Set(ByVal value As Boolean)
            _carrearright = Value
        End Set
    End Property

    Property emailright() As Boolean
        Get
            Return _emailright
        End Get
        Set(ByVal value As Boolean)
            _emailright = Value
        End Set
    End Property

    Property otherdocright() As Boolean
        Get
            Return _otherdocright
        End Get
        Set(ByVal value As Boolean)
            _otherdocright = Value
        End Set
    End Property

    Property exportdatareturns() As Boolean
        Get
            Return _exportdatareturns
        End Get
        Set(ByVal value As Boolean)
            _exportdatareturns = Value
        End Set
    End Property

    Property piaexportdatareturns() As Boolean
        Get
            Return _piaexportdatareturns
        End Get
        Set(ByVal value As Boolean)
            _piaexportdatareturns = Value
        End Set
    End Property

    Property accountsreport() As Boolean
        Get
            Return _accountsreport
        End Get
        Set(ByVal value As Boolean)
            _accountsreport = Value
        End Set
    End Property

    Property admregistration() As Boolean
        Get
            Return _admregistration
        End Get
        Set(ByVal value As Boolean)
            _admregistration = Value
        End Set
    End Property


    Property ExportAlertright() As Boolean
        Get
            Return _ExportAlertright
        End Get
        Set(ByVal value As Boolean)
            _ExportAlertright = value
        End Set
    End Property


End Class