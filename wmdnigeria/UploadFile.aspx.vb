Imports System.Data

Partial Class UploadFile
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub btnPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        Dim msgtext As String = ""

        Try

            If txtdescription.Text = "" Then
                msgtext = "You have not entered file description"
                Return
            End If

            If txtfilename.Text = "" Then
                msgtext = "You have not entered given filename"
                Return
            End If

            If fdb IsNot Nothing AndAlso fdb.FileName = "" Then
                msgtext = "You have not selected file"
                Return
            End If

            If dllDocType.SelectedIndex <= 0 Then
                msgtext = "You have not selected document type"
                Return
            End If

            Dim f() As String = txtfilename.Text.Split(".")

            Try

                txtfilename.Text = f(0).Trim & IO.Path.GetExtension(fdb.FileName)
                Dim fname As String = ""
                fname = pathdoclink & "generaldoc\" & txtfilename.Text

                If fname = "" Then
                    msgtext = "You have not made appropriate selection"
                    Return
                End If

                If GenTool.HasRows("select sysID from  generaluploadfile where IsISP=0 AND GFilename=" & GenTool.addbackslash(fname)) = True Then
                    msgtext = "Please change the name of this file because it is already in our systen"
                    Return
                End If

                fdb.SaveAs(fname)

            Catch ex As Exception
                msgtext = "The system couldn't save this file, please check you file name, remove all special characters"
                GenTool.GrabError(ex.Message, "btnPreview_Click-managelots")
				'msgtext = ex.message
                Return
            End Try


            If msgtext <> "" Then Return

            If IsDate(txtDateIssued.Text) = False Then
                txtDateIssued.Text = "0000-00-00"
            Else
                Dim cdateExport As Date = CDate(txtDateIssued.Text)
                txtDateIssued.Text = cdateExport.Year.ToString & "-" & cdateExport.Month.ToString & "-" & cdateExport.Day.ToString
            End If

            Dim sql = "Insert into generaluploadfile(OFilename,GFilename,Description,CompID,UDate,UTime,Document_Type,Month_Export) Values (" & _
            GenTool.addbackslash(fdb.FileName) & "," & GenTool.addbackslash(txtfilename.Text) & "," & GenTool.addbackslash(txtdescription.Text) & _
            "," & Val(Session("ID")) & ",now(),now()," & GenTool.addbackslash(dllDocType.Text) & "," & GenTool.addbackslash(txtDateIssued.Text) & ")"

            ' Response.Write(sql)

            If GenTool.ExecuteDatabase(sql) = True Then
                txtfilename.Text = ""
                txtdescription.Text = ""

                filldata("")
                msgtext = "Record Saved Successfully"
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPreview_Click-UploadFile")
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Private Sub filldata(ByVal w As String)
        Try
            Dim sql As String = "select OFilename as 'Orginal Filename',GFilename as 'Given Filename',Description,Document_Type as Doc_Type,if(date_format(Month_Export,'%d-%m-%Y')<>'00-00-0000',date_format(Month_Export,'%M-%Y'),'00-0000') as ExportMonth,date_format(UDate,'%d-%m-%Y') as Date,DATE_FORMAT(UTime, '%h:%i:%S %p') as Time from generaluploadfile where CompID=" & Val(Session("ID")) & " " & w

        Dim ds As DataSet = GenTool.DataSetData(sql)
        grd.DataSource = ds.Tables(0)
        grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "UploadFile-filldata")
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        filldata("")
    End Sub

    Protected Sub dllDocType_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles dllDocType.SelectedIndexChanged
        If dllDocType.SelectedIndex <= 2 Then
            txtDateIssued.Visible = True
            lblfilepath0.Visible = True
        Else
            txtDateIssued.Visible = False
            lblfilepath0.Visible = False
        End If
    End Sub

    Protected Sub grd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grd.PageIndexChanging
        grd.PageIndex = e.NewPageIndex
        filldata("")
    End Sub
End Class
