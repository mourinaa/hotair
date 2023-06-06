<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="ReportWalletCards.aspx.cs" Inherits="ReportWalletCards" Title="Untitled Page" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
Wallet Card Kits
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table cellpadding="1" cellspacing="2" width="1000px">
        <tr>
            <td valign="top" align="right">
               Transaction Start Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtStartDate" Width="72px" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar"  CausesValidation="false" />
                <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtStartDate" PopupButtonID="Image1" Format="dd/MM/yyyy" />
            </td>
            <td valign="top" align="right">
                Transaction End Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtEndDate" Width="72px" />
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" CausesValidation="false"/>
                <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtEndDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy" />
            </td>
            <td valign="top" align="right">
                Request Type:
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddlRequestType" runat="server">
                <asp:ListItem Selected ="True" Value="0" Text="Return Unprocessed Items - View Only"></asp:ListItem>
                <asp:ListItem Value="-1" Text="Return All Items - View Only"></asp:ListItem>
                <asp:ListItem Value="1" Text="Process Items and Return Information"></asp:ListItem>
                </asp:DropDownList>
            </td>

            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6" valign="top" align="center">
                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="special" OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 10px">
                &nbsp;</td>
        </tr>
    </table>
<%--    
    <table width="1000px" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td colspan="3" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="ReportWalletCardList" />
            </td>
        </tr>
    </table>
    <table width="1000px" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td colspan="3" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl2" runat="server" ReportName="ReportWalletCards" />
            </td>
        </tr>
    </table>
--%>
    <div>
        <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="ReportWalletCards" />
    </div>

    <div>
        <uc1:ReportViewerControl ID="ReportViewerControl2" runat="server" ReportName="ReportWalletCards" />
    </div>
</asp:Content>


