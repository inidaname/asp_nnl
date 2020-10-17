<%@ Page Title="Photo gallery" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="photogallery.aspx.vb" Inherits="photogallery" %>

<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <%
         If String.IsNullOrEmpty(Request("gid")) = True Then
             Try
                 Response.Redirect("Default.aspx")
             Catch ex As Exception
             End Try
         End If
         %>

    <table style="width:100%;">
        <tr>
            <td colspan="9">
                <div class="item_title" align="center">
                    &nbsp;&nbsp;&nbsp; PHOTO GALLERY</div>
            </td>
        </tr>
          <tr>
            <td>
                &nbsp;</td>
            <td>
                 &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <%
            
            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Dim ds As DataSet = GenTool.DataSetData("select photosysname,Message from photogallery where Status=1 AND GroupID=" & Val(Request("gid")))
            If GenTool.HasDatasetAnyRecord(ds) = True Then
                Session("noresponse") = "No Photo Found"
            Else
                Session("noresponse") = ""
                For k As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    With ds.Tables(0).Rows(k)
            
                        Response.Write(GenTool.getPhotoGallery(.Item(0).ToString, ""))
                        Response.Write(GenTool.getPhotoGallery("", .Item(1).ToString))
                    
                    End With
                Next

            End If
            
          
        %>

           <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td align ="center" >
              <% Response.Write(Session("noresponse"))%><br /> </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>

        </table>
  <br />
  <br />
     <center>  <a href="photogallerygroup.aspx"><strong>Back To Photo Gallery Group</strong></a> </center>
</asp:Content>
 


