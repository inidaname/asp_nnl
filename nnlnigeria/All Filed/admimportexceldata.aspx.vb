Imports System.Data

Partial Class admimportexceldata
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
   
        If IsPostBack = False Then
            lblaction.Text = " Company Name : " & Session("xcname") & " >>> Permit Name : " & Session("xcexportname")
 
        End If
    End Sub

    Private Function checkPhotoExtension(ByVal extName As String, Optional ByVal isExcelFile As Boolean = True) As Boolean
        Try
            extName = LCase(extName)
            Dim cc As New ArrayList
            cc.AddRange(".xls,.xlsx".Split(","))
            Return cc.Contains(extName)
        Catch ex As Exception
            Return False
        End Try

    End Function

    Property StoreFilePath() As String
        Get
            Return Session("StoreFilePath")
        End Get
        Set(ByVal value As String)
            Session("StoreFilePath") = value
        End Set
    End Property

    Property myData As DataSet
        Get
            Return CType(Session("MyData"), DataSet)
        End Get
        Set(ByVal value As DataSet)
            Session("MyData") = value
        End Set
    End Property

    Function checkData(ByVal ds As DataSet) As Boolean
        If ds.Tables(0).Columns.Count <> 14 Then
            MessageBox.Show(Me, "Your Excel columns must be 14 columns,please look at the excel sheet sample")
            Return False
        End If

        Return True
    End Function

    Sub getBalance()
        Try

 
        Dim ds As DataSet = GenTool.DataSetData("select TotalamtUS-amtUsedUS,TotalAmtNig-amtUsedNGN from exportpermit where sysID=" & Val(Session("cexportID")))
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                txtBalNGN.Text = Format(Val(.Item(1).ToString), "0,0.00")
                txtBalUS.Text = Format(Val(.Item(0).ToString), "0,0.00")
            End With
            End If

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnViewExcel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewExcel.Click
        Dim myDataset As DataSet = Nothing
        Try


            myDataset = GenTool.readexcel2dataset(StoreFilePath, "Sheet1")
            If checkData(myDataset) = False Then Return

            myData = myDataset

            grdExcel.DataSource = myDataset.Tables(0)
            grdExcel.DataBind()

            getBalance()

            Dim ProcedUS As Single = 0.0
            Dim procedNGN As Single = 0.0


            For k As Int32 = 0 To myDataset.Tables(0).Rows.Count - 1
                With myDataset.Tables(0).Rows(k)

                    ProcedUS += Val(.Item(9))
                    procedNGN += Val(.Item(10))

                End With

            Next

            txtNGN.Text = Format(procedNGN, "0,0.00")
            txtUS.Text = Format(ProcedUS, "0,0.00")

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "Importdata.aspx")
        Finally
            If IO.File.Exists(StoreFilePath) = True Then
                IO.File.Delete(StoreFilePath)
                'StoreFilePath = ""
            End If
        End Try
 

    End Sub

    Protected Sub uploadTextFile_UploadedComplete(ByVal sender As Object, ByVal e As AjaxControlToolkit.AsyncFileUploadEventArgs) Handles uploadTextFile.UploadedComplete
        Try
            If uploadTextFile.HasFile = True Then
                Dim Ok As Boolean = checkPhotoExtension(IO.Path.GetExtension(uploadTextFile.FileName))
                If Ok = False Then
                    MessageBox.Show(Me, "Only excel file format is supported")
                    Return
                End If

                Dim formNo As String = GenTool.GenerateRNDCode(True, True)

                Dim fn As String = formNo & IO.Path.GetExtension(uploadTextFile.FileName)

                If StoreFilePath = "" Then
                    StoreFilePath = pathdoclink & "myfiles" & "\" & fn
                End If

                uploadTextFile.SaveAs(StoreFilePath)

            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btnSample_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSample.Click
        Try
            Dim sbody As String = docLink & "body/NNLDataReturnSample.xlsx"
            Response.Redirect(sbody)
        Catch ex As Exception
        End Try
    End Sub


    Protected Sub grdExcel_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles grdExcel.PageIndexChanging
        grdExcel.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MsgText As String = ""

        Try
            Dim BalNGN As Single = txtBalNGN.Text.Replace(",", "")
            Dim procedNGN As Single = txtNGN.Text.Replace(",", "")

            If procedNGN > BalNGN Then
                MsgText = "You dont have enough credit for this transaction"
                Return
            End If

            Dim FN As String = "insert into exportdatareturn(ImportName,CompanyID, exportPermitID, cargoName, Vessel,liftingCode, API, BSW, NetBarrel, NetTons, Destination, ProceedUS,ProceedNGN,  PricePerBarrel, consignor, stream) Values ( " & GenTool.addbackslash(txtGivenName.Text) & "," & Val(Session("xcID")) & "," & Val(Session("cexportID"))
            Dim FV As String = ""

            Dim sf As New ArrayList

            For k As Int32 = 0 To myData.Tables(0).Rows.Count - 1
                FV = ""

                For j As Int16 = 1 To 13

                    With myData.Tables(0).Rows(k)

                        FV &= "," & GenTool.addbackslash(.Item(j))

                    End With

                Next

                sf.Add(FN & FV & ")")

            Next

            If GenTool.ExecuteBulkSQL(sf) = True Then
                MsgText = txtGivenName.Text & " Saved successfully"
                
                Try
                    Response.Redirect("admexportpermit.aspx")
                Catch ex As Exception
                End Try
            Else
                MsgText = txtGivenName.Text & " Saved was not successful"
            End If
        Catch ex As Exception
            MsgText = txtGivenName.Text & " Saved was not successful"
        Finally
            MessageBox.Show(Me, MsgText)
        End Try
    End Sub
End Class
