Imports System.Data

Partial Class exportappdetails
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnPreview_Click(sender As Object, e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Try

            Dim dbStore As New ArrayList
            Dim dsmain As DataSet = CType(Session("dsMainx"), DataSet)
            If GenTool.HasDatasetRecords(dsmain) = False Then
                Return
            End If

            Dim orderID As String = ""

            For k As Int32 = 0 To dsmain.Tables(0).Rows.Count - 1
                With dsmain.Tables(0).Rows(k)

                    Dim FN As String = Session("FN") & ",exportpermitName,exporterName,productnameforcast,periodCoveredFrom,periodCoveredTo,Measure,quantity,exportPort,amtPerBarrelUS,TotalamtUS,finalQuantity"
                    Dim FV As String = Session("FV") & "," & GenTool.addbackslash(.Item("Permit Name").ToString) & "," & GenTool.addbackslash(.Item("Exporter Name").ToString) & "," & GenTool.addbackslash(.Item("Product Description").ToString) & _
                    "," & GenTool.addbackslash(.Item("Period Covered From").ToString) & "," & GenTool.addbackslash(.Item("Period Covered To").ToString) & "," & GenTool.addbackslash(.Item("Measure").ToString) & "," & Val(.Item("Quantity").ToString) & _
                    "," & GenTool.addbackslash(.Item("Export Port").ToString) & "," & Val(.Item("Amt/Barrel").ToString) & "," & Val(.Item("F.O.B Value(USD)").ToString) & "," & Val(.Item("Calc. Qty").ToString)

                    Dim sql = "Insert into exportpermit(" & FN & ") Values (" & FV & ")"
                    dbStore.Add(sql)


                    orderID = Strings.Left(GenTool.GenerateUniqueCode & GenTool.GenerateRNDCode, 10)
                    sql = "Insert into paymentsheet(companyID,amountDue,narration,paymentName,OrderId,TransCode) values(" & _
                    Val(Session("ID")) & "," & Val(.Item("F.O.B Value(USD)").ToString) & ",'Export Permit Application'," & GenTool.addbackslash(Session("cname")) & "," & _
                    GenTool.addbackslash(orderID) & "," & GenTool.addbackslash(Request.QueryString("txtTransCode")) & ")"
                    dbStore.Add(sql)

                End With
            Next

            If GenTool.ExecuteBulkSQL(dbStore) = True Then

                sendmail(Request.QueryString("txtemail"))
                sendmail1(Request.QueryString("txtemail"))
                msgtext = "Record created successfully"

                Try
                    Session("Msg") = "Your Export Permit Fee = "
                    Session("Amt2pay") = "$" & Format(Val(Request.QueryString("txtAmtUS")), "0,0.0000")
                    Response.Redirect("thankyouep.aspx")
                Catch ex As Exception
                End Try
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If
        Catch ex As Exception
        Finally
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Private Sub sendmail(Optional ByVal email As String = "")
        Try
            Dim streetAddress As String = ""
            Dim City As String = ""

            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Dim sd As String = "select streetAddress,(select city from tblcity where tblcity.sysID=cityID limit 1) as City from companyregistration where sysID=" & Val(Session("ID"))
            Dim dbStore As DataSet = GenTool.DataSetData(sd)

            If GenTool.HasDatasetRecords(dbStore) = True Then
                streetAddress = dbStore.Tables(0).Rows(0).Item(0).ToString
                City = dbStore.Tables(0).Rows(0).Item(1).ToString
                dbStore.Dispose()
            End If
            Dim NameofApplicant As String, PermitQuarter As String, ProducName As String, Quatity As String, FOBValue As String, ModeofExport As String, PortofExport As String, NameofExporter As String, PeriodCovered As String

            Dim dsmain As DataSet = CType(Session("dsMainx"), DataSet)
            If GenTool.HasDatasetRecords(dsmain) = False Then
                Return
            End If

            For k As Int32 = 0 To dsmain.Tables(0).Rows.Count - 1
                With dsmain.Tables(0).Rows(k)
                    NameofApplicant = Session("cname")
                    PermitQuarter = .Item("Permit Name").ToString
                    ProducName = .Item("Product Description").ToString
                    Quatity = .Item("Quantity").ToString
                    FOBValue = .Item("F.O.B Value(USD)").ToString
                    ModeofExport = ""
                    PortofExport = .Item("Export Port").ToString
                    NameofExporter = .Item("Exporter Name").ToString
                    PeriodCovered = .Item("Period Covered From").ToString & " - " & .Item("Period Covered To").ToString

                End With

                Dim cBlast As New MailContents
                cBlast.AttarchFiles = ""
                cBlast.BodyM = getBody(streetAddress, City, NameofApplicant, PermitQuarter, ProducName, Quatity, FOBValue, ModeofExport, PortofExport, NameofExporter, PeriodCovered)
                cBlast.IsBodyHtml = True
                cBlast.mailbcc = Nothing
                cBlast.mailcc = New Net.Mail.MailAddress("operations@wmdnigeria.com")
                cBlast.mailfrom = New Net.Mail.MailAddress("operations@wmdnigeria.com")
                cBlast.mailto = New Net.Mail.MailAddress(email)
                cBlast.Subject = "Export Permit Details"
                GenTool.SendnMailBox(cBlast)

            Next

        Catch ex As Exception
        End Try
    End Sub

    Private Sub sendmail1(Optional ByVal email As String = "")
        Try
            Dim Cname As String = ""

            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Dim sd As String = "select companyName from companyregistration where sysID=" & Val(Session("ID"))
            Dim dbStore As DataSet = GenTool.DataSetData(sd)

            If GenTool.HasDatasetRecords(dbStore) = True Then
                Cname = dbStore.Tables(0).Rows(0).Item(0).ToString
                dbStore.Dispose()
            End If

            Dim dsmain As DataSet = CType(Session("dsMainx"), DataSet)
            If GenTool.HasDatasetRecords(dsmain) = False Then
                Return
            End If

            Dim FOBAmount As Double, PeriodCovered As String, Quantity As String, Amount As String, ProductName As String
            For k As Int32 = 0 To dsmain.Tables(0).Rows.Count - 1
                Dim cBlast As New MailContents
                cBlast.AttarchFiles = ""

                With dsmain.Tables(0).Rows(k)
                    Amount = .Item("Amt/Barrel").ToString
                    ProductName = .Item("Product Description").ToString
                    Quantity = .Item("Quantity").ToString
                    FOBAmount = Val(.Item("F.O.B Value(USD)").ToString)
                    PeriodCovered = .Item("Period Covered From").ToString & " - " & .Item("Period Covered To").ToString
                    cBlast.BodyM = getBody1(Cname, FOBAmount, PeriodCovered, Quantity, Amount, ProductName)
                End With

                cBlast.IsBodyHtml = True
                cBlast.mailbcc = Nothing
                cBlast.mailcc = New Net.Mail.MailAddress("operations@wmdnigeria.com")
                cBlast.mailfrom = New Net.Mail.MailAddress("operations@wmdnigeria.com")
                cBlast.mailto = New Net.Mail.MailAddress(email)
                cBlast.Subject = "Export Permit Invioce"
                GenTool.SendnMailBox(cBlast)
            Next

        Catch ex As Exception
        End Try
    End Sub


    Function getBody(streetAddress As String, City As String, NameofApplicant As String, PermitQuarter As String, ProducName As String, Quatity As String, FOBValue As String, ModeofExport As String, PortofExport As String, NameofExporter As String, PeriodCovered As String) As String
        Return "</html><head>" & _
                  "    <style type ='text/css'> " & _
            "@charset 'utf-8';" & _
"BODY {" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-family: 'Century Gothic';" & _
"	font-size: 11px;" & _
"	color:#000;" & _
"	background:none" & _
"	}" & _
"img { " & _
"	border:0px;" & _
"	padding:0px;" & _
"	margin:0px;" & _
"}" & _
"a { text-decoration:none; color:#666" & _
"}" & _
"#page{ " & _
"	width:927px;" & _
"	height:686px; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"	font-weight:bold;" & _
"}" & _
"#page2{ " & _
"	width:448px;" & _
"	height:568px; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"}" & _
"#row1{" & _
"	width:100%;" & _
"	height:68px;" & _
"	border-bottom:1px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row2{" & _
"	width:96%;" & _
"	height:25px;" & _
"	border-bottom:1px #000 solid;" & _
"	font-weight:bold;" & _
"	font-size:21px;" & _
"	color:#000;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 40px;" & _
"}" & _
"#row3{" & _
"	width:96%;" & _
"	height:21px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:-2px 0 0 0;" & _
"	padding:0px 0px 0px 40px;" & _
"	display:inline-block;" & _
"	font-family:System;" & _
"	font-size:10px" & _
"}" & _
"#row4{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:2px #000 solid" & _
"}" & _
"#row5{" & _
"	width:100%;" & _
"	height:62px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	background:#C2D697" & _
"}" & _
"#row6{" & _
"	width:100%;" & _
"	height:22px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block" & _
"}" & _
"#row7{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:1px #000 solid" & _
"}" & _
"#row8{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border:0;" & _
"	display:inline-block;" & _
"}" & _
"#row9{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block;" & _
"}" & _
"#row10{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row11{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"}" & _
"#row12{" & _
"	width:100%;" & _
"	height:39px;" & _
"	border-bottom:1px #000 solid;" & _
"	border-top:1px #000 solid;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row13{" & _
"	width:100%;" & _
"	height:59px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row14{" & _
"	width:100%;" & _
"	height:38px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:center;" & _
"	background:#C2D697" & _
"}" & _
"#row15{" & _
"	width:99%;" & _
"	height:88px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:justify;" & _
"	padding:6px 5px" & _
"}" & _
"#row16{" & _
"	width:99%;" & _
"	height:22px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:8px 5px;" & _
"	background:url(" & docLink & "invoice/images/foot.jpg) 0px 0px repeat-x" & _
"}" & _
"#row17{" & _
"	width:100%;" & _
"	height:74px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"}" & _
"#row18{" & _
"	width:100%;" & _
"	height:97px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	line-height:20px" & _
"}" & _
"#row19{" & _
"	width:100%;" & _
"	height:24px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:22px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	background:#D8E5BA" & _
"}" & _
"#row20{" & _
"	width:100%;" & _
"	height:257px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"	border-bottom:2px #000 solid;" & _
"	display:inline-block;" & _
"	background:#D8E5BA" & _
"}" & _
"#row21{" & _
"	width:98%;" & _
"	height:63px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:17px 4px;" & _
"	background:#C2D69B" & _
"}" & _
"#col1{" & _
"	width:149px;" & _
"	height:21px;" & _
"	float:left;" & _
"}" & _
"#col2{" & _
"	width:105px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col3{" & _
"	width:166px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col4{" & _
"	width:261px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col5{" & _
"	width:137px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col6{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	font-size:13px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	text-align:left" & _
"}" & _
"#col7{" & _
"	width:687px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col8{" & _
"	width:294px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:right;" & _
"	font-size:15px" & _
"}" & _
"#col9{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col10{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col11{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:left" & _
"}" & _
"#col12{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col13{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col14{" & _
"	width:294px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:2px #000 solid;" & _
"}" & _
"#col15{" & _
"	width:425px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col16{" & _
"	width:154px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col17{" & _
"	width:245px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col18{" & _
"	width:100px;" & _
"	height:20px;" & _
"	float:left;" & _
"}" & _
"#col19{" & _
"	width:150px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col20{" & _
"	width:106px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col21{" & _
"	width:430px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col22{" & _
"	width:137px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col23{" & _
"	width:100px;" & _
"	height:29px;" & _
"	float:left;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col24{" & _
"	width:150px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col25{" & _
"	width:106px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col26{" & _
"	width:430px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col27{" & _
"	width:137px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col28{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col29{" & _
"	width:826px;" & _
"	height:60px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"	display:inline-block" & _
"}" & _
"#col30{" & _
"	width:101px;" & _
"	height:62px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col31{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	border-left:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	background:#00CCFF" & _
"}" & _
"#col32{" & _
"	width:826px;" & _
"	height:16px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"}" & _
"#col33{" & _
"	width:126px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col34{" & _
"	width:559px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:center;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"	border-top:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	border-left:1px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col35{" & _
"	width:139px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col36{" & _
"	width:448px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"}" & _
"#col37{" & _
"	width:193px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:1px 4px 0 0;" & _
"}" & _
"#col38{" & _
"	width:251px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"	border-bottom:1px #D6D7DB solid;" & _
"	background:#fff" & _
"}" & _
"" & _
"    </style>" & _
"</head>" & _
"        <body>" & _
"" & _
"<div align='center'>" & _
"<div id='page2'>" & _
"<div id='row17'><img src='" & docLink & "invoice/images/logo2.jpg' /></div>" & _
"<div id='row18'><strong>FEDERAL REPUBLIC OF NIGERIA<br />" & _
"FEDERAL MINISTRY OF INDUSTRY, TRADE & INVESTMENT<br /></strong>" & _
"DEPARTMENT OF COMMODITIES AND PRODUCTS INSPECTORATES<br />" & _
"Old Secretariat Complex, Area 1, Garki Abuja, Nigeria<br />" & _
"        </div>" & _
"        <div id='row19'>EXPORT PERMIT APPLICATION DETAILS</div>" & _
"           <div id='row20'>" & _
"        	<div id='col36'>&nbsp;</div>" & _
"        	<div id='col37'>Name of Applicant:</div><div id='col38'>" & NameofApplicant & "</div>" & _
"        	<div id='col37'>Address in Nigeria:</div><div id='col38'>" & streetAddress & "</div>" & _
"        	<div id='col37'>City:</div><div id='col38'>" & City & "</div>" & _
"        	<div id='col37'>Permit Quarter:</div><div id='col38'>" & PermitQuarter & "</div>" & _
"        	<div id='col37'>Product Description:</div><div id='col38'>" & ProducName & "</div>" & _
"        	<div id='col37'>Export Quantity (bbl):</div><div id='col38'>" & Quatity & "</div>" & _
"        	<div id='col37'>F.O.B Value (USD):</div><div id='col38'>" & FOBValue & "</div>" & _
"        	<div id='col37'>Mode of Export:</div><div id='col38'>" & ModeofExport & "</div>" & _
"        	<div id='col37'>Port of Export:</div><div id='col38'>" & PortofExport & "</div>" & _
"        	<div id='col37'>Period Covered:</div><div id='col38'>" & PeriodCovered & "</div>" & _
"        	<div id='col37'>Name of Exporter:</div><div id='col38'>" & NameofExporter & "</div>" & _
"        </div>" & _
"        <div id='row21'>We acknowledge that the making of any false statement or concealment of any " & _
"material fact connection with this application may result in imprisonment or" & _
" fine, or both and denial, in whole or in part, of participation in Nigeria Oil & Gas Exports.</div>" & _
"<center>" & _
"   <br />" & _
"" & _
"    <br />" & _
"    <br />" & _
"    <br />" & _
"        </center>" & _
"" & _
"</div>" & _
"         <div id='Div1'>   <br />" & _
"    <br />" & _
"    <br /> </div>" & _
"    </div>" & _
"" & _
"</body>" & _
"</html>   "


    End Function


    Function getBody1(CompanyName As String, FOBAmount As Double, PeriodCovered As String, Quantity As String, Amount As String, ProductName As String) As String

        Dim FOB004 As Double = FOBAmount * 0.0004
        Dim SubTotal As Double = FOB004
        Dim Vat As Double = SubTotal * (5 / 100)
        Dim GrandTotal As Double = Format(SubTotal + Vat, "0,0.00")

        Return "</html><head>" & _
            "    <style type ='text/css'> " & _
            "@charset 'utf-8';" & _
"BODY {" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-family: 'Century Gothic';" & _
"	font-size: 11px;" & _
"	color:#000;" & _
"	background:none" & _
"	}" & _
"img { " & _
"	border:0px;" & _
"	padding:0px;" & _
"	margin:0px;" & _
"}" & _
"a { text-decoration:none; color:#666" & _
"}" & _
"#page{ " & _
"	width:927px;" & _
"	height:686px; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"	font-weight:bold;" & _
"}" & _
"#page2{ " & _
"	width:448px;" & _
"	height:568px; " & _
"	display:inline-block;" & _
"	padding: 0px;" & _
"	margin: 54px 0 0px 0;" & _
"	text-align:left;" & _
"	border:5px solid #000;" & _
"}" & _
"#row1{" & _
"	width:100%;" & _
"	height:68px;" & _
"	border-bottom:1px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row2{" & _
"	width:96%;" & _
"	height:25px;" & _
"	border-bottom:1px #000 solid;" & _
"	font-weight:bold;" & _
"	font-size:21px;" & _
"	color:#000;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 40px;" & _
"}" & _
"#row3{" & _
"	width:96%;" & _
"	height:21px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:-2px 0 0 0;" & _
"	padding:0px 0px 0px 40px;" & _
"	display:inline-block;" & _
"	font-family:System;" & _
"	font-size:10px" & _
"}" & _
"#row4{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:2px #000 solid" & _
"}" & _
"#row5{" & _
"	width:100%;" & _
"	height:62px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	background:#C2D697" & _
"}" & _
"#row6{" & _
"	width:100%;" & _
"	height:22px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block" & _
"}" & _
"#row7{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border-bottom:1px #000 solid" & _
"}" & _
"#row8{" & _
"	width:100%;" & _
"	height:20px;" & _
"	border:0;" & _
"	display:inline-block;" & _
"}" & _
"#row9{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	text-align:center;" & _
"	margin:0;" & _
"	padding:0px 0px 0px 0px;" & _
"	display:inline-block;" & _
"}" & _
"#row10{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row11{" & _
"	width:100%;" & _
"	height:19px;" & _
"	border-bottom:1px #000 solid;" & _
"	background:none;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"}" & _
"#row12{" & _
"	width:100%;" & _
"	height:39px;" & _
"	border-bottom:1px #000 solid;" & _
"	border-top:1px #000 solid;" & _
"	font-size:12px;" & _
"	text-align:center;" & _
"	background:#C4DAF1" & _
"}" & _
"#row13{" & _
"	width:100%;" & _
"	height:59px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"}" & _
"#row14{" & _
"	width:100%;" & _
"	height:38px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:center;" & _
"	background:#C2D697" & _
"}" & _
"#row15{" & _
"	width:99%;" & _
"	height:88px;" & _
"	border-bottom:2px #000 solid;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:13px;" & _
"	text-align:justify;" & _
"	padding:6px 5px" & _
"}" & _
"#row16{" & _
"	width:99%;" & _
"	height:22px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:8px 5px;" & _
"	background:url(" & docLink & "invoice/images/foot.jpg) 0px 0px repeat-x" & _
"}" & _
"#row17{" & _
"	width:100%;" & _
"	height:74px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"}" & _
"#row18{" & _
"	width:100%;" & _
"	height:97px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:14px;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	line-height:20px" & _
"}" & _
"#row19{" & _
"	width:100%;" & _
"	height:24px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:22px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:2px 0px;" & _
"	border-bottom:5px #000 solid;" & _
"	background:#D8E5BA" & _
"}" & _
"#row20{" & _
"	width:100%;" & _
"	height:257px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:0px 0px;" & _
"	border-bottom:2px #000 solid;" & _
"	display:inline-block;" & _
"	background:#D8E5BA" & _
"}" & _
"#row21{" & _
"	width:98%;" & _
"	height:63px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	font-size:12px;" & _
"	font-weight:bold;" & _
"	text-align:center;" & _
"	padding:17px 4px;" & _
"	background:#C2D69B" & _
"}" & _
"#col1{" & _
"	width:149px;" & _
"	height:21px;" & _
"	float:left;" & _
"}" & _
"#col2{" & _
"	width:105px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col3{" & _
"	width:166px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col4{" & _
"	width:261px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col5{" & _
"	width:137px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col6{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-top:2px #000 solid;" & _
"	font-size:13px;" & _
"	margin:0;" & _
"	padding:0;" & _
"	text-align:left" & _
"}" & _
"#col7{" & _
"	width:687px;" & _
"	height:18px;" & _
"	float:left;" & _
"}" & _
"#col8{" & _
"	width:294px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:right;" & _
"	font-size:15px" & _
"}" & _
"#col9{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col10{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-bottom:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col11{" & _
"	width:100px;" & _
"	height:18px;" & _
"	float:left;" & _
"	text-align:left" & _
"}" & _
"#col12{" & _
"	width:128px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	border-left:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col13{" & _
"	width:399px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-top:2px #000 solid;" & _
"	border-right:2px #000 solid;" & _
"	font-size:13px;" & _
"	text-align:right" & _
"}" & _
"#col14{" & _
"	width:294px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:2px #000 solid;" & _
"}" & _
"#col15{" & _
"	width:425px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col16{" & _
"	width:154px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col17{" & _
"	width:245px;" & _
"	height:20px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col18{" & _
"	width:100px;" & _
"	height:20px;" & _
"	float:left;" & _
"}" & _
"#col19{" & _
"	width:150px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col20{" & _
"	width:106px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col21{" & _
"	width:430px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col22{" & _
"	width:137px;" & _
"	height:29px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col23{" & _
"	width:100px;" & _
"	height:29px;" & _
"	float:left;" & _
"	margin:0;" & _
"	padding:10px 0 0 0;" & _
"}" & _
"#col24{" & _
"	width:150px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col25{" & _
"	width:106px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col26{" & _
"	width:430px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col27{" & _
"	width:137px;" & _
"	height:19px;" & _
"	float:left;" & _
"	border-right:1px #000 solid;" & _
"	margin:0;" & _
"}" & _
"#col28{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col29{" & _
"	width:826px;" & _
"	height:60px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"	display:inline-block" & _
"}" & _
"#col30{" & _
"	width:101px;" & _
"	height:62px;" & _
"	float:left;" & _
"	margin:0;" & _
"}" & _
"#col31{" & _
"	width:100px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	border-left:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	background:#00CCFF" & _
"}" & _
"#col32{" & _
"	width:826px;" & _
"	height:16px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:12px;" & _
"}" & _
"#col33{" & _
"	width:126px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col34{" & _
"	width:559px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:center;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"	border-top:1px #000 solid;" & _
"	border-bottom:1px #000 solid;" & _
"	border-left:1px #000 solid;" & _
"	border-right:1px #000 solid;" & _
"}" & _
"#col35{" & _
"	width:139px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	font-size:14px;" & _
"	padding:5px 0 0 0;" & _
"}" & _
"#col36{" & _
"	width:448px;" & _
"	height:17px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"}" & _
"#col37{" & _
"	width:193px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:1px 4px 0 0;" & _
"}" & _
"#col38{" & _
"	width:251px;" & _
"	height:19px;" & _
"	float:left;" & _
"	margin:0;" & _
"	text-align:right;" & _
"	padding:0 0 0 0;" & _
"	border-bottom:1px #D6D7DB solid;" & _
"	background:#fff" & _
"}" & _
"" & _
            "    </style>" & _
"</head>" & _
"<body>" & _
"<div align='center'>" & _
"	<div id='page'>" & _
"    	<div id='row1'><img src='" & docLink & "invoice/images/logo.jpg' /></div>" & _
"    	<div id='row2'>FEDERAL MINISTRY OF INDUSTRY, TRADE AND INVESTMENT</div>" & _
"    	<div id='row3'>Old Secretariat Complex, Area 1, Garki Abuja, Nigeria</div>" & _
"    	<div id='row3'>&nbsp;</div>" & _
"    	<div id='row6'>" & _
"        	<div id='col1'>&nbsp;</div>" & _
"        	<div id='col2'>Date:</div>" & _
"        	<div id='col3'>" & Now.Day & "/" & Now.Month & "/" & Now.Year & "</div>" & _
"        	<div id='col4'>&nbsp;</div>" & _
"        	<div id='col5'>CURRENCY:</div>" & _
"        	<div id='col6'>US DOLLARS</div>" & _
"        </div>" & _
"    	<div id='row7'>&nbsp;</div>" & _
"    	<div id='row4'>" & _
"        	<div id='col7'>&nbsp;</div>" & _
"        	<div id='col5'>Price Per Barrel:</div>" & _
"        	<div id='col6'>" & Amount & "</div>" & _
"        </div>" & _
"    	<div id='row5'>" & _
"        	<div id='row8'>" & _
"        		<div id='col8'>To:&nbsp;&nbsp;</div>" & _
"        		<div id='col9'>Name of Company:</div>" & _
"        		<div id='col10'>" & CompanyName & "</div>" & _
"        		<div id='col11'>&nbsp;</div>" & _
"            </div>" & _
"        	<div id='row8'>" & _
"        		<div id='col14'>&nbsp;&nbsp;</div>" & _
"            </div>" & _
"        	<div id='row8'>" & _
"        		<div id='col8'>&nbsp;&nbsp;</div>" & _
"        		<div id='col12'>Contact Person:</div>" & _
"        		<div id='col13'>" & Request.QueryString("txtfullname") & "</div>" & _
"        		<div id='col11'>&nbsp;</div>" & _
"            </div>" & _
"        </div>" & _
"    	<div id='row9'>&nbsp;</div>" & _
"    	<div id='row10'>" & _
"  			<div id='col15'>Weights and Measures Operations</div>" & _
"  			<div id='col16'>Monitoring Fee Category</div>" & _
"        	<div id='col17'>Payment Terms</div>" & _
"        	<div id='col18'>Period Covered</div>" & _
"        </div>" & _
"    	<div id='row11'>" & _
"  			<div id='col15'>Export Terminal Metering Facilities Monitoring</div>" & _
"  			<div id='col16'>Q3</div>" & _
"        	<div id='col17'>Due upon receipt of Application</div>" & _
"        	<div id='col18'>" & PeriodCovered & "</div>" & _
"        </div>" & _
"    	<div id='row8'>&nbsp;</div>" & _
"    	<div id='row12'>" & _
"        	<div id='col19'>Quality (bbls) Crude Oil</div>" & _
"        	<div id='col20'>FOB Value $</div>" & _
"        	<div id='col21'>Name of Terminal</div>" & _
"        	<div id='col22'>Legal metrology Fees</div>" & _
"        	<div id='col23'>Total $</div>" & _
"        </div>" & _
"    	<div id='row11'>" & _
"        	<div id='col24'>" & Quantity & "</div>" & _
"        	<div id='col25'>" & FOBAmount & " </div>" & _
"        	<div id='col26'>" & ProductName & "</div>" & _
"        	<div id='col27'>0.0004 of FOB Value</div>" & _
"        	<div id='col28'>" & FOB004 & "</div>" & _
"        </div>" & _
"    	<div id='row11'>" & _
"        	<div id='col24'>&nbsp;</div>" & _
"        	<div id='col25'>&nbsp;</div>" & _
"        	<div id='col26'>  </div>" & _
"        	<div id='col27'>&nbsp;</div>" & _
"        	<div id='col28'>&nbsp;</div>" & _
"        </div>" & _
"    	<div id='row11'>" & _
"        	<div id='col24'>&nbsp;</div>" & _
"        	<div id='col25'>&nbsp;</div>" & _
"        	<div id='col26'>&nbsp;</div>" & _
"        	<div id='col27'>&nbsp;</div>" & _
"        	<div id='col28'>&nbsp;</div>" & _
"        </div>" & _
"    	<div id='row13'>" & _
"        	<div id='col29'>" & _
"            	<div id='col32'>Subtotal&nbsp;</div>" & _
"            	<div id='col33'>Amount in words&nbsp;&nbsp;</div>" & _
"            	<div id='col34'>" & GenTool.Convert2Word(GrandTotal) & " </div>" & _
"            	<div id='col35'>VAT (5%)</div>" & _
"            	<div id='col32'><strong><font  size='2.5' >Total Bill<font></strong></div>" & _
"            </div>" & _
"            <div id='col30'>" & _
"            	<div id='col31'>" & SubTotal & "</div>" & _
"            	<div id='col31'>" & Vat & "</div>" & _
"				<div id='col31'>" & GrandTotal & "</div>" & _
"            </div>" & _
"        </div>" & _
"    	<div id='row14'>Make all cheques payable to: Federal Ministry of Industry, Trade and Investmentt<br />" & _
"Unity Bank Plc; Account No. 0023847675; Sort Code: 215082334</div>" & _
"    	<div id='row15'>Upon settlement of this bill a receipt will be issued to your company and monitoring of metering equipment in your terminal will be carried out by " & _
"the Weights and Measures Department during liftings and other operations involving metering infrastructure used for export in your terminal. Non- " & _
"payment of the Weights and Measures staturatory fees is contrary to the Weights and Measures (Legal Metrology and Related Services) Regulations," & _
" 2012 of 13th April 2012 and Weights and Measures (Replacement of Fifth Schedule) Order 2012 as contained in the Federal Republic of NIgeria" & _
"		</div>" & _
"        <div id='row16'>E-Mail to: <font color='#FFFFFF'>metrology@wmdnigeria.com</font></div>" & _
"    </div>" & _
"</div>" & _
"</body> " & _
"</html>       "

    End Function

    Protected Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            Dim dsmain As DataSet = CType(Session("dsMainx"), DataSet)
            grd.DataSource = dsmain.Tables(0)
            grd.DataBind()
        Catch ex As Exception
        End Try
    End Sub
End Class
