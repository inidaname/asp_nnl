<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="stateOffices.aspx.vb" Inherits="stateOffices" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" 
                style="font-family: Calibri; font-size: x-large; font-weight: bold">
                &nbsp;Weight And Measure State Office Addresses
                &nbsp;
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
<center>
    
<%  
    Dim GenTool As NNLN = xsmsCentralToolx.SetTool
    Dim ds As DataSet = GenTool.DataSetData("select sysID,StateName from statecontacts")
    
    If GenTool.HasDatasetAnyRecord(ds) = False Then
        For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(k)
                
            
    %>
    <div>
    <% 
        Dim sd As String = "<a href='" & docLink & "stateOfficesView.aspx?id=" & .Item(0).ToString & "' style='font-family: calibri; font-size: large'>" & k + 1 & ". " & .Item(1).ToString
        Response.Write(sd)
        
        %>
     </div>
     <hr />
     <%      End With
         Next
            End If%>
</center>

 <table style="width: 100%;">
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td>
            &nbsp;
        </td>
    </tr>
</table>

</asp:Content>

