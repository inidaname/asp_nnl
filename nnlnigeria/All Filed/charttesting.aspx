<%@ Page Language="VB" AutoEventWireup="false" CodeFile="charttesting.aspx.vb" Inherits="charttesting" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Chart ID="Chart1" runat="server"  
            Height="469px" Width="612px">
            <Series>
                <asp:Series Name="Series1" YValuesPerPoint="2" ChartType="Bar" MarkerSize="0" 
                    XValueMember="Faults" YValueMembers="Count">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                    <AxisX Interval="1">
                    </AxisX>
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    </div>
    </form>
</body>
</html>
