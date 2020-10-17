<%@ Page Title="Photo gallery" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="viewarchivegroups.aspx.vb" Inherits="photogallery" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <div style="font-family: 'Courier New', Courier, monospace; font-size: small; color: red; font-weight: bold;" >
 
 <%
     Dim GenTool As NNLN = xsmsCentralToolx.SetTool
     Try
         
         Dim ds As DataSet
         Dim iret As Boolean
         
         If String.IsNullOrEmpty(Request("state")) OrElse Val(Request("state")) = 0 Then
             ds = GenTool.DataSetData("select sysID,groupname from  photogallerygroup where Status=1 AND GStatus=1")
             iret = False
         Else
             ds = GenTool.DataSetData("select sysID,HeaderName,GroupID from frontpagemain where gDesign=1")
             iret=True 
         End If
         
         Dim state As String = Request("state")
         
         For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
             With ds.Tables(0).Rows(k)
                 Dim dsValue As String
                 
                 If iret = false Then
                     dsValue = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='viewarchivegroups.aspx?gid=" & .Item(0).ToString & "&state=1'><span style='color: #333399'>" & .Item(1).ToString & "</span></a><br/>"
                 Else
                     dsValue = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href='frontpagedisplay.aspx?msgid=" & .Item(0).ToString & "&state=1'><span style='color: #333399'>" & .Item(1).ToString & "</span></a><br/>"
                 End If
                 
                 Response.Write(dsValue)
             End With
         Next
         
     Catch ex As Exception
     End Try
     
%>

<hr />
 </div>


     
</asp:Content>
 


