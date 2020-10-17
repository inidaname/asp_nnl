Imports System.Data

Partial Class quiz
    Inherits System.Web.UI.Page

    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Property dsQuestion As DataSet
        Get
            Return CType(Session("dsQuestion"), DataSet)
        End Get
        Set(ByVal value As DataSet)
            Session("dsQuestion") = value
        End Set
    End Property

    Property CorrectQuestion As Integer
        Get
            Return CType(Session("CorrectQuestion"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("CorrectQuestion") = value
        End Set
    End Property

    Property QuestionAnswered As Integer
        Get
            Return CType(Session("QuestionAnswered"), Integer)
        End Get
        Set(ByVal value As Integer)
            Session("QuestionAnswered") = value
        End Set
    End Property

    Private Function checkscore(ByVal fs As Integer) As String
        Dim Response As String
        With dsQuestion.Tables(0).Rows(QuestionAnswered)
            fs = .Item(5).ToString

            Select Case Val(fs)
                Case 1 And opt1.Checked
                    CorrectQuestion = +1
                    Response = "Correct Answer!"

                Case 2 And opt2.Checked
                    CorrectQuestion = +1
                    Response = "Correct Answer!"

                Case 3 And opt3.Checked
                    CorrectQuestion = +1
                    Response = "Correct Answer!"


                Case 4 And opt4.Checked
                    CorrectQuestion = +1
                    Response = "Correct Answer!"
                Case Else
                    Response = "Wrong Answer!"
            End Select
            Return Response
        End With
    End Function

    Protected Sub txtNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNext.Click
        Try
            Try
                Dim f As String = checkscore(Val(dsQuestion.Tables(0).Rows(QuestionAnswered).Item(5).ToString))
                MessageBox.Show(UpdatePanel1, f)
            Catch ex As Exception
            End Try

afresh:     QuestionAnswered += 1

            If QuestionAnswered >= dsQuestion.Tables(0).Rows.Count Then
                MessageBox.Show(UpdatePanel1, "This mark the end of this test, Score :  " & CorrectQuestion & "/" & dsQuestion.Tables(0).Rows.Count & ". You may start test again")
                QuestionAnswered = 0
                lblResult.Text = "This mark the end of this test, Score :  " & CorrectQuestion & "/" & dsQuestion.Tables(0).Rows.Count & ". You may start test again"
            Else

                lblResult.Text = "Question " & QuestionAnswered & " Of " & dsQuestion.Tables(0).Rows.Count

                With dsQuestion.Tables(0).Rows(QuestionAnswered)
                    lblQuestion.Text = .Item(0).ToString
                    opt1.Text = .Item(1).ToString
                    opt2.Text = .Item(2).ToString
                    opt3.Text = .Item(3).ToString
                    opt4.Text = .Item(4).ToString
                End With


            End If

        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        If IsPostBack = False Then
            dsQuestion = GenTool.DataSetData("select Question,A_A,A_B,A_C,A_D,A_O from quitsetup")
            Try
                lblResult.Text = "Question 1 Of " & dsQuestion.Tables(0).Rows.Count
                QuestionAnswered = 0
                With dsQuestion.Tables(0).Rows(QuestionAnswered)
                    lblQuestion.Text = .Item(0).ToString
                    opt1.Text = .Item(1).ToString
                    opt2.Text = .Item(2).ToString
                    opt3.Text = .Item(3).ToString
                    opt4.Text = .Item(4).ToString
                End With

            Catch ex As Exception
                lblResult.Text = "No Quiz Found for the moment,please try again later"
                txtNext.Visible = False
                lblResult0.Visible = False
                opt1.Visible = False
                opt2.Visible = False
                opt3.Visible = False
                opt4.Visible = False
            End Try
        End If
    End Sub
End Class
