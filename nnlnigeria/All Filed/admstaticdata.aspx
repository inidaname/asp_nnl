<%@ Page Title="STATIC DATA" Language="VB" MasterPageFile="~/adminpage.master" AutoEventWireup="false" CodeFile="admstaticdata.aspx.vb" Inherits="admstaticdata" %>

<%@ Import Namespace="System.Data" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

 
<!--start home-->
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1" runat="server"  >
	 
  <div class="item_title">&nbsp;&nbsp;&nbsp; USER ACCOUNT</div>
    	<div>     
  
      <center>

    <div style="width : 95%" id="main-menu">
         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label></div>
                <div id="item2" style="width:96%">

                <asp:Panel ID="Panel1" runat="server">
                </asp:Panel>
                <center>

                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2"  
                        Width="100%" AutoPostBack="True">

                        <cc1:TabPanel ID="TabCountry" runat="server" HeaderText="COUNTRY">
                        
                            <ContentTemplate>

                                <asp:Panel ID="Panel3" runat="server">
                               
                                <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label3" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Country:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCountry" runat="server" Width="204px"></asp:TextBox>
                                            <asp:TextBox ID="txtCountryID" runat="server" Width="30px" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnCountryR" runat="server" Text="RESET" />
                                            <cc1:ConfirmButtonExtender ID="btnCountryR_ConfirmButtonExtender" 
                                                runat="server" ConfirmText="Are you sure you WANT to clear this form" 
                                                Enabled="True" TargetControlID="btnCountryR" ConfirmOnFormSubmit="True">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnCountryS" runat="server" style="height: 26px" Text="SAVE" />
                                            <cc1:ConfirmButtonExtender ID="btnCountryS_ConfirmButtonExtender" 
                                                runat="server" ConfirmText="Are you sure you want SAVE this record" 
                                                Enabled="True" TargetControlID="btnCountryS" ConfirmOnFormSubmit="True">
                                            </cc1:ConfirmButtonExtender>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnCountryD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                            <cc1:ConfirmButtonExtender ID="btnCountryD_ConfirmButtonExtender" 
                                                runat="server" ConfirmText="Are you sure you want to DELETE this record" 
                                                Enabled="True" TargetControlID="btnCountryD" ConfirmOnFormSubmit="True">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblCountryTotalRecords" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdcountry" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                
                                   </asp:Panel>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabState" runat="server" HeaderText="STATE">
                                                     
                            <ContentTemplate>

                            <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label1" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter State:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtState" runat="server" Width="204px"></asp:TextBox>
                                            <asp:TextBox ID="txtStateID" runat="server" Width="30px" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnStateR" runat="server" Text="RESET" />
                                            <cc1:ConfirmButtonExtender ID="RReset_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnStateR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnStateS" runat="server" style="height: 26px" Text="SAVE" />
                                            <cc1:ConfirmButtonExtender ID="btnStateS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                                TargetControlID="btnStateS">
                                            </cc1:ConfirmButtonExtender>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnStateD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                            <cc1:ConfirmButtonExtender ID="btnStateD_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record?" Enabled="True" 
                                                TargetControlID="btnStateD">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblStateTotalRecords" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdstate" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabLGA" runat="server" HeaderText="LGA">
                         
                            <ContentTemplate>

                                     <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label6" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Select State:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="cboLGA" runat="server" AutoPostBack="True" Width="204px"> 
                                            </asp:DropDownList>
                                           
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter LGA:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtLGA" runat="server" Width="204px"></asp:TextBox> 
                                            <asp:TextBox ID="txtLGAID" runat="server" Width="50px" Visible ="False" ></asp:TextBox> </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnLGAR" runat="server" Text="RESET" />
                                              <cc1:ConfirmButtonExtender ID="btnLGAR_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnLGAR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnLGAS" runat="server" style="height: 26px" Text="SAVE" />
                                              <cc1:ConfirmButtonExtender ID="btnLGAS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record" Enabled="True" 
                                                TargetControlID="btnLGAS">
                                            </cc1:ConfirmButtonExtender>

                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnLGAD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                               <cc1:ConfirmButtonExtender ID="btnLGAD_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record" Enabled="True" 
                                                TargetControlID="btnLGAD">
                                            </cc1:ConfirmButtonExtender>
                                        
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblLGA" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdLGA" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
                                            &nbsp;</td>
                                        <td>

                                            &nbsp;<td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabCity" runat="server" HeaderText="CITY">
                        
                            <ContentTemplate>
                                <asp:Panel ID="Panel2" runat="server">
                              
                                 <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label2" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter City:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCity" runat="server" Width="204px"></asp:TextBox>
                                            <asp:TextBox ID="txtCityID" runat="server" Width="30px" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnCityR" runat="server" Text="RESET" />
                                            <cc1:ConfirmButtonExtender ID="btnCityR_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnCityR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnCityS" runat="server" style="height: 26px" Text="SAVE" />
                                            <cc1:ConfirmButtonExtender ID="btnCityS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                                TargetControlID="btnCityS">
                                            </cc1:ConfirmButtonExtender>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnCityD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                            <cc1:ConfirmButtonExtender ID="btnCityD_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record?" Enabled="True" 
                                                TargetControlID="btnCityD">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblCityTotalRecords" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdCity" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%" 
                                                DataMember="90">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                              
                                </asp:Panel>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        
                        <cc1:TabPanel ID="TabFEEMS" runat="server" HeaderText="FEE MAIN SECTION">

                            <ContentTemplate>
                    
                                <asp:Panel ID="Panel4" runat="server">
                               
                                <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 175px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 296px">
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
                                            &nbsp;
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
                                        <td class="style4" align="right" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 175px">
                                            <asp:Label ID="Label4" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Fee Group:"></asp:Label>
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            <asp:TextBox ID="txtFeeMain" runat="server" Width="204px"></asp:TextBox>
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
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
                                        <td align="right" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 175px">
                                            &nbsp;</td>
                                        <td align="left" class="style4" style="width: 296px">
                                            <asp:CheckBox ID="chkFeeGroupService" runat="server" Font-Names="Calibri" 
                                                Font-Size="Medium" Text="Is Service?" ValidationGroup="IsService" />
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
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
                                        <td align="right" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 175px">
                                            &nbsp;</td>
                                        <td align="left" class="style4" style="width: 296px">
                                            <asp:TextBox ID="txtfeemainID" runat="server" Visible="False" Width="30px"></asp:TextBox>
                                            <asp:Label ID="lblTotalFeeMain" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
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
                                        <td align="right" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 175px">
                                            <asp:Button ID="btnFeeMainR" runat="server" Text="RESET" />
                                            <cc1:ConfirmButtonExtender ID="btnFeeMainR_ConfirmButtonExtender" 
                                                runat="server" ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you sure you WANT to CLEAR this form?" Enabled="True" 
                                                TargetControlID="btnFeeMainR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            <asp:Button ID="btnFeeMainS" runat="server" style="height: 26px" Text="SAVE" />
                                            <cc1:ConfirmButtonExtender ID="btnFeeMainS_ConfirmButtonExtender" 
                                                runat="server" ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                                TargetControlID="btnFeeMainS">
                                            </cc1:ConfirmButtonExtender>
                                            <asp:Button ID="btnFeeMainD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                            <cc1:ConfirmButtonExtender ID="btnFeeMainD_ConfirmButtonExtender" 
                                                runat="server" ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you sure you WANT to DELETE this record?" Enabled="True" 
                                                TargetControlID="btnFeeMainD">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                        </td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
                                            &nbsp;</td>
                                        <td align="left">
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
                                        <td align="right" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 175px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td align="right" class="style4" style="width: 296px">
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
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="12">
                                            <asp:GridView ID="grdFeeMainR" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="98%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
                                        </td>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                            &nbsp;</td>
                                        <td align="center">
                                            &nbsp;</td>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 147px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 175px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 296px">
                                            &nbsp;</td>
                                        <td class="style4" style="width: 296px">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>
                                
                                   </asp:Panel>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabFEESUBSEC" runat="server" HeaderText="FEE SUB SECTION">
                                                
                             <ContentTemplate>
                        
                                     <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label8" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Select Fee Group:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboMainFee" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label9" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter FEE Sub Group:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFSS" runat="server" Width="204px"></asp:TextBox> 
                                            <asp:TextBox ID="txtFSSID" runat="server" Width="50px" Visible ="False" ></asp:TextBox> </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnFSR" runat="server" Text="RESET" />
                                              <cc1:ConfirmButtonExtender ID="btnFSR_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnFSR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnFSSS" runat="server" style="height: 26px" Text="SAVE" />
                                              <cc1:ConfirmButtonExtender ID="btnFSSS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record" Enabled="True" 
                                                TargetControlID="btnFSSS">
                                            </cc1:ConfirmButtonExtender>

                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnFSD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                               <cc1:ConfirmButtonExtender ID="btnFSD_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record" Enabled="True" 
                                                TargetControlID="btnFSD">
                                            </cc1:ConfirmButtonExtender>
                                        
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblfsstotal" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdFSS" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="100%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabFEETABLE" runat="server" HeaderText="FEE TABLE">
                     
                            <ContentTemplate>
                            
                                 <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label12" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Select Fee Group:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboFEEGROUP" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>


                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label15" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Select Fee Sub Group:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboFEESUBGROUP" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>


                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label13" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter FEE Name:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFee" runat="server" Width="404px"></asp:TextBox> 
                                            <asp:TextBox ID="txtFeeID" runat="server" Width="50px" Visible ="False" ></asp:TextBox> </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label19" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Main Charge:"></asp:Label>  </td>
                                        <td align="left">
                                            
                                            <asp:TextBox ID="txtFeeAmount" Width="204px" runat="server"></asp:TextBox>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label14" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Calibration Fee:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFEECalibrFee" runat="server" Width="204px"></asp:TextBox> 
                                           
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label16" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Other Charges:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtfeecharges" runat="server" Width="204px"></asp:TextBox> 
                                         
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label17" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Renewal Fee:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFeeRenewal" runat="server" Width="204px"></asp:TextBox> 
                                            
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label18" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Security Deposit:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtFEESD" runat="server" Width="204px"></asp:TextBox> 
                                            
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnFEER" runat="server" Text="RESET" />
                                              <cc1:ConfirmButtonExtender ID="btnFEER_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnFEER">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnFEES" runat="server" style="height: 26px" Text="SAVE" />
                                              <cc1:ConfirmButtonExtender ID="btnFEES_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record" Enabled="True" 
                                                TargetControlID="btnFEES">
                                            </cc1:ConfirmButtonExtender>

                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnFEED" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                               <cc1:ConfirmButtonExtender ID="btnFEED_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record" Enabled="True" 
                                                TargetControlID="btnFEED">
                                            </cc1:ConfirmButtonExtender>
                                        
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblFeeTotalResult" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdFee" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="100%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TabMAINDEVICEG" runat="server" HeaderText="MAIN Instrument GROUP">
                 
                              <ContentTemplate>
                          
                          <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label5" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Main Instrument:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtMD" runat="server" Width="204px"></asp:TextBox>
                                            <asp:TextBox ID="txtMDID" runat="server" Width="30px" Visible="False"></asp:TextBox>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnMDR" runat="server" Text="RESET" />
                                            
                                               <cc1:ConfirmButtonExtender ID="btnMDR_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form?" Enabled="True" 
                                                TargetControlID="btnMDR">
                                            </cc1:ConfirmButtonExtender>

                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnMDS" runat="server" style="height: 26px" Text="SAVE" />
                                               <cc1:ConfirmButtonExtender ID="btnMDS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record?" Enabled="True" 
                                                TargetControlID="btnMDS">
                                            </cc1:ConfirmButtonExtender>
                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnMDD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                                  
                                               <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record?" Enabled="True" 
                                                TargetControlID="btnMDD">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblTotalMDR" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdMD" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TABDEVICECATE" runat="server" HeaderText="INSTRUMENT CATEGORY">

                             <ContentTemplate>
                                
                                <center>
                                <table style="width: 100%;">
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
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
                                        <td class="style4">
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
                                            &nbsp;
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
                                        <td class="style4" align="right">
                                            <asp:Label ID="Label10" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Select Main Instrument Group:"></asp:Label>

                                        </td>
                                        <td align="left">
                                            
                                            <asp:DropDownList ID="cboDevice" runat="server" Width="204px" 
                                                AutoPostBack="True" >
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                             <asp:Label ID="Label11" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                                Text="Enter Instrument Category:"></asp:Label>  </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtDevice" runat="server" Width="204px"></asp:TextBox> 
                                            <asp:TextBox ID="txtDeviceID" runat="server" Width="50px" Visible ="False" ></asp:TextBox> </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            <asp:Button ID="btnDeviceR" runat="server" Text="RESET" />
                                              <cc1:ConfirmButtonExtender ID="btnDeviceR_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to CLEAR this form" Enabled="True" 
                                                TargetControlID="btnDeviceR">
                                            </cc1:ConfirmButtonExtender>
                                        </td>
                                        <td align="left">
                                            &nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnDeviceS" runat="server" style="height: 26px" Text="SAVE" />
                                              <cc1:ConfirmButtonExtender ID="btnDeviceS_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to SAVE this record" Enabled="True" 
                                                TargetControlID="btnDeviceS">
                                            </cc1:ConfirmButtonExtender>

                                            &nbsp;&nbsp;
                                            <asp:Button ID="btnDeviceD" runat="server" style="height: 26px" Text="DELETE" 
                                                Visible="False" />
                                               <cc1:ConfirmButtonExtender ID="btnDeviceD_ConfirmButtonExtender" runat="server" 
                                                ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you SURE you want to DELETE this record" Enabled="True" 
                                                TargetControlID="btnDeviceD">
                                            </cc1:ConfirmButtonExtender>
                                        
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
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
                                        <td align="right" class="style4">
                                            &nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblDeviceCat" runat="server" Font-Bold="True" 
                                                Font-Names="Calibri" Font-Size="Small"></asp:Label>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;
                                        </td>
                                        <td align="center" colspan="11">
                                            <asp:GridView ID="grdDevice" runat="server" AllowPaging="True" BackColor="White" 
                                                BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                                CellSpacing="2" EmptyDataText="NO RECORD FOUND" 
                                                EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                                GridLines="Vertical" PageSize="25" ShowFooter="True" Width="80%">
                                                <AlternatingRowStyle BackColor="Gainsboro" />
                                                <Columns>
                                                    <asp:CommandField HeaderText="Action" SelectText="Edit" 
                                                        ShowSelectButton="True"  />
                                                </Columns>
                                                <EmptyDataRowStyle Font-Names="Agency FB" Font-Size="Small" 
                                                    HorizontalAlign="Center" VerticalAlign="Top" />
                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                <HeaderStyle BackColor="#000084" Font-Bold="True" Font-Names="Calibri" 
                                                    Font-Size="Small" ForeColor="White" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black" HorizontalAlign="Center" 
                                                    VerticalAlign="Top" />
                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                            </asp:GridView>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td class="style4">
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
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </center>

                            </ContentTemplate>

                        </cc1:TabPanel>

                        <cc1:TabPanel ID="TABSETUP" runat="server" HeaderText="SETUP">
    
                             <ContentTemplate >
                            <div>
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
                                            &nbsp;</td>
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
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="center">
                                            <asp:Label ID="Label20" runat="server" Text="Upload Changes"></asp:Label>
                                            <asp:DropDownList ID="dllSetupDate" runat="server">
                                                <asp:ListItem>All Static</asp:ListItem>
                                                <asp:ListItem>Fee Group</asp:ListItem>
                                                <asp:ListItem>Frontpage</asp:ListItem>
                                                <asp:ListItem>Instrument Setup</asp:ListItem>
                                                <asp:ListItem>Setup Addresses</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td align="center">
                                            <asp:ImageButton ID="imgBtnState" runat="server" 
                                                ImageUrl="~/images/sa/Button-Refresh-icon.png" />
                                            <cc1:ConfirmButtonExtender ID="imgBtnState_ConfirmButtonExtender" 
                                                runat="server" ConfirmOnFormSubmit="True" 
                                                ConfirmText="Are you sure you want to UPLOAD/UPDATE the entire changes made to STATIC TABLE?" Enabled="True" 
                                                TargetControlID="imgBtnState">
                                            </cc1:ConfirmButtonExtender>
                                            <br />
                                            Update/Upload All Changes Made To Static Data Table</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </div>
                        </ContentTemplate>

                        </cc1:TabPanel>

                    </cc1:TabContainer>

                    </center>
                </div>
                
   </ContentTemplate>
          
  </asp:UpdatePanel>
    </div>
     </center>
</div>

        
</div>
    

<!--end home-->
</asp:Content>

