<%@ Page Title="" Language="VB" MasterPageFile="~/companypage.master" AutoEventWireup="false" CodeFile="Careers.aspx.vb" Inherits="Careers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 
        <div   id="item_right" style="border-width: thin; border-style: outset; width:99%;"> 

        <%
            Dim GenTool As NNLN = xsmsCentralToolx.SetTool
            Dim mainData As String = GenTool.getSingleValue("select carrears from carrears")
            
            If String.IsNullOrEmpty(mainData) = True Then
                mainData = "<br><p align='center' style='color:green;font-family: calibri; font-size: medium' <strong>NO VACANCY AVAILABLE AT THE MOMENT</strong></p><br>"
            End If
            
            Response.Write(mainData)
                 
            %>
        
        </div> 
 
 
</asp:Content>

