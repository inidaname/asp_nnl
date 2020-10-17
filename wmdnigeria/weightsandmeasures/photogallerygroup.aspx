<%@ Page Title="Photo gallery" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="photogallerygroup.aspx.vb" Inherits="photogallery" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
 <div style="font-family: 'Courier New', Courier, monospace; font-size: medium; color: red; font-weight: bold;" >
 
 <%
     Dim GenTool As NNLN = xsmsCentralToolx.SetTool
     Try
         
         Dim ds As DataSet = GenTool.DataSetData("select sysID,groupname from  photogallerygroup where Status=1 AND GStatus=0")
                        
         For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
             With ds.Tables(0).Rows(k)
                 Dim dsValue As String = "&nbsp;&nbsp;<a href='photogallery.aspx?gid=" & .Item(0).ToString & "'><span style='color: #333399'>" & .Item(1).ToString & "</span></a><br/>"
                 Response.Write(dsValue)
             End With
         Next
         
     Catch ex As Exception
     End Try
     
%>

<hr />
 </div>


     
</asp:Content>
 


