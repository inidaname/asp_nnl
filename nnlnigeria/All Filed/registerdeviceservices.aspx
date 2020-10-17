<%@ Page Language="VB" AutoEventWireup="false" MasterPageFile="~/companynoheader.master" CodeFile="registerdeviceservices.aspx.vb" Inherits="registerdevice" %>

<%@ Import Namespace="System.Data" %>

 <%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>

<div id="item1">
    	 
    	<div class="item_title">&nbsp;&nbsp;&nbsp; Registration Application Form (W002)</div>
    	<div>
	                         <br /><br /><br />
                       
	                         <center >
        	                    <img src="images/coatofarm.jpg" alt ="" />
        	                    <br />
                               <h1> <strong > FEDERAL MINISTRY OF INDUSTRY,TRADE AND INVESTMENT</strong></h1><br />
                                 <h3>  WEIGHTS AND MEASURES DEPARTMENT</h3> 
                                   <h3> Old Secretariat Area I, Garki Abuja</h3>
                                   <br />
                               <h1> <strong >   INSTRUMENT SERVICES REGISTRATION</strong></h1>
                            </center> 	
                            <hr />
      <center>

    <div style="width : 75%"  id="main-menu" >

         <asp:UpdatePanel ID="UpdatePanel1" runat ="server" >
            <ContentTemplate >
              

        <div class="item_title"><asp:Label ID="lblMsg" runat="server" ForeColor="#FF3300"></asp:Label></div>

                <div  id="item2">
                   <asp:Panel ID="MainRegForm" runat="server">
                  
                    <asp:Panel ID="Panel2" runat="server">
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" colspan="5">
                                    <div class="item_title">
                                        &nbsp;&nbsp;&nbsp;REGISTERED INSTRUMENT SERVICE FEE (<asp:Label ID="lblAmount" runat="server"></asp:Label>
                                        )&nbsp;&nbsp;
                                    </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 126px">
                                    <asp:Label ID="Label29" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Instrument:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboInstrument" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ValidationGroup="DID|Invalid Instrument Name|1" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 129px">
                                    <asp:Label ID="Label7" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Service Category:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboFeeSubGroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="feeIDSubGroup|Invalid Scale Sub-Group|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 126px">
                                    <asp:Label ID="Label28" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Service Group:"></asp:Label>
                                </td>
                                <td class="style41">
                                    <asp:DropDownList ID="cboFeegroup" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" ValidationGroup="feeIDGroup|Invalid Scale Group|1" 
                                        Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style40" style="width: 129px">
                                    <asp:Label ID="Label21" runat="server" Font-Names="Calibri" Font-Size="Small" 
                                        Text="Select Service"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="cboMrange" runat="server" AutoPostBack="True" 
                                        Font-Names="Calibri" Font-Size="Small" 
                                        ValidationGroup="feeID|Invalid Service Name|1" Width="204px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                                   <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 126px">
                                    <asp:TextBox ID="txtAccountID" runat="server" Width="40px" 
                                        ValidationGroup="AccountID" Visible="False"></asp:TextBox>
                                </td>
                                <td align="center" class="style41">
                                    <asp:TextBox ID="txtTransCode" runat="server" Width="40px" 
                                        ValidationGroup="TransCode" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtIsDbService" runat="server" Width="30px" 
                                        ValidationGroup="IsdbService" Visible="False">1</asp:TextBox>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 129px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 126px">
                                    <asp:TextBox ID="txtamount" runat="server" Width="30px" 
                                        ValidationGroup="deviceAmount" Visible="False"></asp:TextBox>
                                    <asp:TextBox ID="txtserialNumber" runat="server" ValidationGroup="serialNumber" 
                                        Visible="False" Width="30px"></asp:TextBox>
                                    <asp:TextBox ID="txtbarCode" runat="server" ValidationGroup="barCode" 
                                        Visible="False" Width="30px"></asp:TextBox>
                                </td>
                                <td align="center" class="style41">
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="False" />
                                    <cc1:ConfirmButtonExtender ID="btnDelete_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to DELETE this Instrument" Enabled="True" 
                                        TargetControlID="btnDelete">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="left" class="style40" style="width: 129px">
                                    <asp:Button ID="btnPreview" runat="server" style="height: 26px" Text="Submit" />
                                    <cc1:ConfirmButtonExtender ID="btnPreview_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want SAVE this record?" Enabled="True" 
                                        TargetControlID="btnPreview">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel/Reset" />
                                    <cc1:ConfirmButtonExtender ID="btncancel_ConfirmButtonExtender" runat="server" 
                                        ConfirmOnFormSubmit="True" 
                                        ConfirmText="Are you sure you want to CANCEL/RESET this form?" Enabled="True" 
                                        TargetControlID="btncancel">
                                    </cc1:ConfirmButtonExtender>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style39" style="width: 126px">
                                    &nbsp;</td>
                                <td align="right" class="style41">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td align="center" class="style40" style="width: 129px">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                  </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server">
                   
            
                  
                  <center >
                   <asp:UpdateProgress ID="updProgress" runat="server" 
                                 AssociatedUpdatePanelID="UpdatePanel1">
                                 <ProgressTemplate>

                                 <div  > 
                                     <img alt="progress"  height="50px"  width="50px" src="images/sa/glossy-3d-blue-hourglass-icon.png" /> </div>
                                 <div   style="font-family: calibri; font-size: small; color : red" >System 
                                     Processing your request please wait...</div>  
                                   
                                 </ProgressTemplate>
                             </asp:UpdateProgress>
                    </center>
                  
             </asp:Panel>

                   <asp:Panel ID="Panel3" runat="server" BackColor ="Gainsboro" >
                       <table style="width:100%;" cellspacing="1" cellpadding="0">

                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5" >
                                    <div class="item_title">&nbsp;&nbsp;&nbsp;SELECTED SERVICES (<asp:Label 
                                            ID="lblTotal" runat="server"></asp:Label>
                                        )&nbsp;&nbsp; </div>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td style="background-color:#99A6B4" colspan="5">
                                    <asp:Button ID="BTNPAY" runat="server" Text="MAKE PAYMENT" />
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="style38">
                                    </td>
                                <td class="style33" align="center" colspan="5" rowspan="2">
                                    <asp:GridView ID="grd" runat="server" AllowPaging="True" BackColor="White" 
                                        BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="2" 
                                        CellSpacing="2" EmptyDataText="NO REGISTERED INSTRUMENT" 
                                        EnableModelValidation="True" Font-Names="Calibri" Font-Size="Small" 
                                        GridLines="Vertical" ShowFooter="True" Width="100%" PageSize="20">
                                        <AlternatingRowStyle BackColor="#DCDCDC" />
                                        <Columns>
                                            <asp:CommandField HeaderText="Select" SelectText="Edit" 
                                                ShowSelectButton="True" />
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
                                <td class="style38">
                                    </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td class="style5">
                                    &nbsp;</td>
                                <td class="style23">
                                    &nbsp;</td>
                                <td class="style22">
                                    &nbsp;</td>
                                <td class="style8">
                                    &nbsp;</td>
                                <td class="style31">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>

                </div>

   </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnPreview" EventName="Click" />
             </Triggers>
                </asp:UpdatePanel>


    </div>

     </center>
</div>

        
</div>
    
</asp:Content>
 