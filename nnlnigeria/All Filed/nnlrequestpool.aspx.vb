Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Reflection

Partial Class nnlrequestpool
    Inherits System.Web.UI.Page
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool

    Enum sDirection As Integer
        CustomerRequest = 1
        PaymentNotification = 2
        None = 0
    End Enum

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            Request.ContentType = "text/xml"
            Dim data As String = New System.IO.StreamReader(Request.InputStream).ReadToEnd()

            Dim fStatus As sDirection = checkDirection(data)

            If fStatus = sDirection.CustomerRequest Then

                Response.ContentType = "text/xml"
                Response.Write(Server.HtmlEncode(getBody(data)))

            ElseIf fStatus = sDirection.PaymentNotification Then
                Dim sStatus As String = 0

                Dim xmldoc As New XmlDataDocument()
                Dim xmlnode As XmlNodeList

                xmldoc = New XmlDataDocument()
                xmldoc.LoadXml(data)

                xmlnode = xmldoc.GetElementsByTagName("Payment")

                Dim PaymentLogId As String = ""
                PaymentLogId = getDataNode(xmlnode(0), "PaymentLogId")

                If goSavePayDirect(data) = True Then
                    sStatus = "0"
                Else
                    sStatus = "1"
                End If

                Dim sdv As String = "<?xml version='1.0' encoding='utf-8' ?>" & _
                    " <PaymentNotificationResponse>" & _
                "    <Payments>" & _
                "        <Payment>" & _
                "            <PaymentLogId>" & PaymentLogId & "</PaymentLogId>" & _
                "            <Status>" & sStatus & "</Status>" & _
                "        </Payment>" & _
                "    </Payments>" & _
                "</PaymentNotificationResponse>"

                Response.ContentType = "text/xml"
                Response.Write(Server.HtmlEncode(sdv))
                'Response.Write(sdv)
            Else

                Response.ContentType = "text/xml"
                Response.Write(Server.HtmlEncode(getBody(data)))
                'Response.Write(getBody(data))
            End If

        Catch ex As Exception
            GenTool.GrabError(ex.Message, "Page_Load(nnlrequestpool.aspx)")
            Response.Write(ex.Message)
        End Try
    End Sub

    Function getBody(Data As String) As String


        Dim xmldoc As New XmlDataDocument()
        Dim xmlnode As XmlNodeList

        xmldoc = New XmlDataDocument()
        xmldoc.LoadXml(Data)

        xmlnode = xmldoc.GetElementsByTagName("CustomerInformationRequest")

        Dim MerchantReference As String = ""
        Dim CustReference As String = ""
        MerchantReference = getDataNode(xmlnode(0), "MerchantReference")
        CustReference = getDataNode(xmlnode(0), "CustReference")
        Dim FirstName As String = ""
        Dim LastName As String = ""
        Dim OtherName As String = ""
        Dim Email As String = ""
        Dim Phone As String = ""
        Dim status As String = "0"
        Dim sql As String = "select companyName,streetAddress,RCNumber,companyEmail,mobilephone from companyregistration where username=" & GenTool.addbackslash(CustReference)
        Dim ds As DataSet = GenTool.DataSetData(sql)
        If GenTool.HasDatasetRecords(ds) = True Then
            With ds.Tables(0).Rows(0)
                FirstName = .Item("companyName").ToString
                LastName = .Item("RCNumber").ToString
                OtherName = .Item("streetAddress").ToString
                Email = .Item("companyEmail").ToString
                Phone = .Item("mobilephone").ToString
            End With
        Else
            status = "1"
        End If

        Dim sdv As String = "<?xml version='1.0' encoding='utf-8' ?>" & _
        " <CustomerInformationResponse>" & _
        "  <MerchantReference>" & MerchantReference & "</MerchantReference >" & _
        "    <Customers>" & _
        "   	<Customer>" & _
        "        <Status>" & status & "</Status>" & _
         "        <CustReference>" & CustReference & "</CustReference>" & _
         "        <FirstName>" & FirstName & "</FirstName>" & _
         "        <LastName>" & LastName & "</LastName>" & _
         "        <OtherName>" & OtherName & "</OtherName>" & _
         "        <Email>" & Email & "</Email>" & _
         "        <Phone>" & Phone & "</Phone> " & _
         "      </Customer>" & _
         "    </Customers>" & _
         "</CustomerInformationResponse>"
        Return sdv
    End Function

    Function checkDirection(sd As String) As sDirection
        Try
            If String.IsNullOrEmpty(sd) = True Then Return sDirection.None

            Dim xmldoc As New XmlDataDocument()
            Dim xmlnode As XmlNodeList

            xmldoc = New XmlDataDocument()
            xmldoc.LoadXml(sd)

            Try
                xmlnode = xmldoc.GetElementsByTagName("Payment")

                If getxmlnodevalue(xmlnode(0)) = "|" Then
                Else
                    Return (sDirection.PaymentNotification)
                End If

            Catch ex As Exception
            End Try

            xmlnode = xmldoc.GetElementsByTagName("CustomerInformationRequest")
            Return sDirection.CustomerRequest
        Catch ex As Exception
            Return sDirection.None
        End Try
    End Function

    Function getDataNode(ByVal objxmlnode As XmlNode, ByVal SValue As String) As String
        For j As Int16 = 0 To objxmlnode.ChildNodes.Count - 1
            If objxmlnode.ChildNodes.Item(j).LocalName.ToLower() = SValue.ToLower Then
                Return objxmlnode.ChildNodes.Item(j).InnerText.Trim()
            End If
        Next
        Return ""
    End Function

    Private Function getxmlnodevalue(ByVal objxmlnode As XmlNode) As String
        Try
            If objxmlnode.ChildNodes.Item(0) IsNot Nothing Then
                Return objxmlnode.ChildNodes.Item(0).InnerText.Trim
            Else
                Return ""
            End If
        Catch ex As Exception
            GenTool.GrabError(ex.Message, "getxmlnodevalue")
            Return "|"
        End Try

    End Function

    Private Function goSavePayDirect(ByVal resultXML As String) As Boolean
        Dim Iret As Boolean
        Try

            Dim xmldoc As New XmlDataDocument()
            Dim xmlnode As XmlNodeList

            xmldoc = New XmlDataDocument()
            xmldoc.LoadXml(resultXML)
            xmlnode = xmldoc.GetElementsByTagName("Payment")
            Dim pDIrect As New pDirect

            Dim t As Type
            t = pDIrect.GetType
            Dim mp As PropertyInfo
            Dim sd As String = ""

            Dim FN As String = ""
            Dim FV As String = ""

            For Each mp In t.GetProperties
                sd = getDataNode(xmlnode(0), mp.Name)
                If mp.Name.ToLower = "Amount".ToLower Then
                    mp.SetValue(pDIrect, Val(sd), Nothing)
                Else
                    mp.SetValue(pDIrect, sd, Nothing)
                End If


                If String.IsNullOrEmpty(FN) = True Then
                    FN = mp.Name
                    FV = GenTool.addbackslash(sd)
                Else
                    FN &= "," & mp.Name
                    FV &= "," & GenTool.addbackslash(sd)
                End If
            Next

            Dim PaymentLogId As String = getDataNode(xmlnode(0), "PaymentLogId")
            Dim sql As String = "select  PaymentLogId  from paydirect where PaymentLogId=" & GenTool.addbackslash(PaymentLogId)
            If GenTool.HasRows(sql) = True Then
                Iret = True
                Return True
            Else
                sql = "Insert into paydirect(" & FN & ") Values (" & FV & ")"
            End If

            Iret = GenTool.ExecuteDatabase(sql)

        Catch ex As Exception
            Iret = False
            GenTool.GrabError(ex.Message, "goSavePayDirect")
        End Try
 
        Return Iret
    End Function

    Public Shared Function FormatXml(ByVal xmlDoc As XmlDocument) As String
        Dim sb As New StringBuilder()

        Using stringWriter As New StringWriter(sb)

            Using xmlTextWriter As New XmlTextWriter(stringWriter)
                xmlTextWriter.Formatting = Formatting.Indented
                xmlDoc.WriteTo(xmlTextWriter)
            End Using
        End Using
        Return sb.ToString()
    End Function
End Class

Public Class pDirect

    Dim _paymentlogid As String
    Dim _custreference As String
    Dim _alternatecustreference As String
    Dim _amount As Double
    Dim _paymentmethod As String
    Dim _paymentreference As String
    Dim _channelname As String
    Dim _location As String
    Dim _isreversal As String
    Dim _paymentdate As String
    Dim _institutionid As String
    Dim _institutionname As String
    Dim _branchname As String
    Dim _bankname As String
    Dim _customername As String
    Dim _othercustomerinfo As String
    Dim _receiptno As String
    Dim _collectionsaccount As String
    Dim _thirdpartycode As String
    Dim _customerphonenumber As String
    Dim _depositorname As String
    Dim _depositslipnumber As String
    Dim _paymentcurrency As String
    Dim _bankcode As String

    Property paymentlogid() As String
        Get
            Return _paymentlogid
        End Get
        Set(ByVal value As String)
            _paymentlogid = value
        End Set
    End Property

    Property custreference() As String
        Get
            Return _custreference
        End Get
        Set(ByVal value As String)
            _custreference = value
        End Set
    End Property

    Property alternatecustreference() As String
        Get
            Return _alternatecustreference
        End Get
        Set(ByVal value As String)
            _alternatecustreference = value
        End Set
    End Property

    Property amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    Property paymentmethod() As String
        Get
            Return _paymentmethod
        End Get
        Set(ByVal value As String)
            _paymentmethod = value
        End Set
    End Property

    Property paymentreference() As String
        Get
            Return _paymentreference
        End Get
        Set(ByVal value As String)
            _paymentreference = value
        End Set
    End Property

    Property channelname() As String
        Get
            Return _channelname
        End Get
        Set(ByVal value As String)
            _channelname = value
        End Set
    End Property

    Property location() As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property

    Property isreversal() As String
        Get
            Return _isreversal
        End Get
        Set(ByVal value As String)
            _isreversal = value
        End Set
    End Property

    Property paymentdate() As String
        Get
            Return _paymentdate
        End Get
        Set(ByVal value As String)
            _paymentdate = value
        End Set
    End Property

    Property institutionid() As String
        Get
            Return _institutionid
        End Get
        Set(ByVal value As String)
            _institutionid = value
        End Set
    End Property

    Property institutionname() As String
        Get
            Return _institutionname
        End Get
        Set(ByVal value As String)
            _institutionname = value
        End Set
    End Property

    Property branchname() As String
        Get
            Return _branchname
        End Get
        Set(ByVal value As String)
            _branchname = value
        End Set
    End Property

    Property bankname() As String
        Get
            Return _bankname
        End Get
        Set(ByVal value As String)
            _bankname = value
        End Set
    End Property

    Property customername() As String
        Get
            Return _customername
        End Get
        Set(ByVal value As String)
            _customername = value
        End Set
    End Property

    Property othercustomerinfo() As String
        Get
            Return _othercustomerinfo
        End Get
        Set(ByVal value As String)
            _othercustomerinfo = value
        End Set
    End Property

    Property receiptno() As String
        Get
            Return _receiptno
        End Get
        Set(ByVal value As String)
            _receiptno = value
        End Set
    End Property

    Property collectionsaccount() As String
        Get
            Return _collectionsaccount
        End Get
        Set(ByVal value As String)
            _collectionsaccount = value
        End Set
    End Property

    Property thirdpartycode() As String
        Get
            Return _thirdpartycode
        End Get
        Set(ByVal value As String)
            _thirdpartycode = value
        End Set
    End Property

    Property customerphonenumber() As String
        Get
            Return _customerphonenumber
        End Get
        Set(ByVal value As String)
            _customerphonenumber = value
        End Set
    End Property

    Property depositorname() As String
        Get
            Return _depositorname
        End Get
        Set(ByVal value As String)
            _depositorname = value
        End Set
    End Property

    Property depositslipnumber() As String
        Get
            Return _depositslipnumber
        End Get
        Set(ByVal value As String)
            _depositslipnumber = value
        End Set
    End Property

    Property paymentcurrency() As String
        Get
            Return _paymentcurrency
        End Get
        Set(ByVal value As String)
            _paymentcurrency = value
        End Set
    End Property

    Property bankcode() As String
        Get
            Return _bankcode
        End Get
        Set(ByVal value As String)
            _bankcode = value
        End Set
    End Property


End Class