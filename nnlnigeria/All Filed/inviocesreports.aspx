<%@ Page Title="" Language="VB" MasterPageFile="~/companynoheader.master" AutoEventWireup="false" enableEventValidation="false"  CodeFile="inviocesreports.aspx.vb" Inherits="invioces"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript"  language="text/javascript">

function SelectAllCheckboxes(spanChk)
{
 var oItem = spanChk.children;
 var theBox= (spanChk.type=="checkbox") ?
 spanChk : spanChk.children.item[0];
 xState=theBox.checked;
 elm=theBox.form.elements;
 
 for(i=0;i<elm.length;i++)
  if(elm[i].type=="checkbox" && elm[i].id!=theBox.id)
    {
     if(elm[i].checked!=xState)
       elm[i].click();
    }
 }
 
</script>

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </cc1:ToolkitScriptManager>
     <asp:Panel ID="Panel1" runat="server">

<div id="item1"  runat ="server">
   
      <div class="item_title">&nbsp;&nbsp;&nbsp; Invioces(<asp:Label ID="lblMsg" 
              runat="server"></asp:Label>  
          ) </div>
        <center>
        <div>.</div>
 <div id="Div1" runat ="server" style="font-family: Calibri; font-size: small; font-weight: normal" >
     <asp:DropDownList ID="cboQueryOptions" runat="server">
         <asp:ListItem Selected="True">ANNUAL LICENSING FEE</asp:ListItem>
         <asp:ListItem>PATTERN OF APPROVAL FEE</asp:ListItem>
         <asp:ListItem>CRUDE OIL &amp; GAS  EXPORT MONITORING FEE</asp:ListItem>
     </asp:DropDownList>

&nbsp;<asp:CheckBox ID="chkIncludeDate" runat="server" Text="Include Date" 
         Checked="True" />
 &nbsp;
     <asp:Label ID="Label1" runat="server" Font-Bold="False" Font-Names="Calibri" 
         Font-Size="Small" Text="FROM:"></asp:Label>
     <asp:TextBox ID="txtDPTFrom" runat="server" BorderStyle="Solid" 
         BorderWidth="1px" Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
         Width="80px" Height="20px"></asp:TextBox>

     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" 
      Animated="True" Enabled="True" Format="yyyy-MM-dd" 
           PopupButtonID="childimgbtnCal0" TargetControlID="txtDPTFrom">
     </cc1:CalendarExtender>

     <asp:ImageButton ID="childimgbtnCal0" runat="server" Height="16px" 
         ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />
     &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="False" Font-Names="Calibri" 
         Font-Size="Small" Text="TO:"></asp:Label>
     <asp:TextBox ID="txtDPTTo" runat="server" BorderStyle="Solid" BorderWidth="1px" 
         Font-Bold="False" Font-Names="Calibri" Font-Size="Small" 
         Width="80px" Height="20px"></asp:TextBox>
     <cc1:CalendarExtender ID="CalendarExtender2" runat="server"
      Format="yyyy-MM-dd" PopupButtonID="childimgbtnCal" 
                                        TargetControlID="txtDPTTo">
     </cc1:CalendarExtender>
                                 
     <asp:ImageButton ID="childimgbtnCal" runat="server" Height="16px" 
         ImageUrl="~/img/cal3.png" ValidationGroup="dd" Width="16px" />

 </div>
 <hr />

 <div>
    <asp:Button ID="btnSearch" runat="server" Text="Search Reports" />
 </div>

 <hr />

                  <div>
                      <table style="width: 100%;">
                          <tr>
                              <td>
                                  &nbsp;
                              </td>
                              <td>
                                  <asp:GridView ID="grd" runat="server" BackColor="White" BorderColor="#999999" 
                                      BorderStyle="None" BorderWidth="1px" CellPadding="2" CellSpacing="2" 
                                      EmptyDataText="NO INVOICE" Font-Names="Calibri" 
                                      Font-Size="Small" GridLines="Vertical" PageSize="20" ShowFooter="True" 
                                      Width="100%">
                                      <AlternatingRowStyle BackColor="#DCDCDC" />
                                      <Columns>
                                         <asp:TemplateField>
                                        <HeaderTemplate>
                                            <%--<asp:CheckBox ID="chkhdr" onclick="javascript:SelectAllCheckboxes(this);" runat="server" />--%>
                                             
                                        </HeaderTemplate>

                                          <ItemTemplate>
                                            <%--<asp:CheckBox ID="chkChild"  runat="server" />--%>
                                           </ItemTemplate>
                                        </asp:TemplateField>
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
                                  &nbsp;
                              </td>
                          </tr>
                      </table>
                </div>
         </center>
        
    </div>


    </asp:Panel>
</asp:Content>


