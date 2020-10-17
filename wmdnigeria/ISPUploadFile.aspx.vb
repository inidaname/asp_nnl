Imports System.Data

Partial Class ISPUploadFile
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


            Dim f() As String = txtfilename.Text.Split(".")

            Try

                txtfilename.Text = f(0).Trim & IO.Path.GetExtension(fdb.FileName)
                Dim fname As String = ""
                fname = pathdoclink & "ispdoc/" & txtfilename.Text

                If fname = "" Then
                    msgtext = "You have not made appropriate selection"
                    Return
                End If


                If GenTool.HasRows("select sysID from  generaluploadfile where IsISP=1 AND GFilename=" & GenTool.addbackslash(fname)) = True Then
                    msgtext = "Please change the name of this file because it is already in our systen"
                    Return
                End If

                fdb.SaveAs(fname)

            Catch ex As Exception
                msgtext = "The system couldnt save this file,please check you file name, remove all special characters"
                GenTool.GrabError(ex.Message, "btnPreview_Click-ISPUploadFile")
                Return
            End Try


            If msgtext <> "" Then Return

            Dim sql = "Insert into generaluploadfile(OFilename,GFilename,Description,CompID,UDate,UTime,IsISP) Values (" & _
            GenTool.addbackslash(fdb.FileName) & "," & GenTool.addbackslash(txtfilename.Text) & "," & GenTool.addbackslash(txtdescription.Text) & _
            "," & Val(Session("sysID")) & ",now(),now(),1)"

            If GenTool.ExecuteDatabase(sql) = True Then
                txtfilename.Text = ""
                txtdescription.Text = ""

                filldata("")
                msgtext = "Record Saved Successfully"
            Else
                msgtext = "The system was unable to save this record,check your entry and try again,if it continues contact admin"
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "btnPreview_Click-ISPUploadFile")
            lblMsg.Text = ex.Message
        Finally
            lblMsg.Text = msgtext
            If msgtext <> "" Then MessageBox.Show(Me, msgtext)
        End Try
    End Sub

    Private Sub filldata(ByVal w As String)
        Try
            Dim sql As String = "select OFilename as 'Orginal Filename',GFilename as 'Given Filename',Description,date_format(UDate,'%D-%M-%Y') as Date,DATE_FORMAT(UTime, '%h:%i:%S %p') as Time from generaluploadfile where IsISP AND CompID=" & Val(Session("sysID")) & " " & w

            Dim ds As DataSet = GenTool.DataSetData(sql)
            grd.DataSource = ds.Tables(0)
            grd.DataBind()
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "ISPUploadFile-filldata")
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        filldata("")
    End Sub
End Class


