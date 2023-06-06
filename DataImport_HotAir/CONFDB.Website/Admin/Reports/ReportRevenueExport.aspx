<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeFile="ReportRevenueExport.aspx.cs" Inherits="ReportRevenueExport" Title="Untitled Page" %>

<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Revenue Report Export
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" width="1000px">
        <tr>
            <td valign="top" align="right">
                Sales Person:
            </td>
            <td valign="top">
                <data:EntityDropDownList Width="205px" runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                    DataTextField="FullName" DataValueField="Id" AppendNullItem="true" Required="false"
                    NullItemText="All" ErrorText="Required" />
                <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                    SelectMethod="GetPaged">
                    <Parameters>
                        <data:CustomParameter Name="OrderBy" Value="FullName" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:SalesPersonDataSource>
            </td>
            <td valign="top" align="right">
                Start Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtStartDate" Width="72px" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" CausesValidation="false" />
                <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtStartDate" PopupButtonID="Image1" Format="dd/MM/yyyy" />
            </td>
            <td valign="top" align="right">
                End Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtEndDate" Width="72px" />
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/Images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" CausesValidation="false" />
                <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtEndDate" PopupButtonID="ImageButton1" Format="dd/MM/yyyy" />
            </td>
            <td valign="top" align="right">
                <strong>OR</strong>
            </td>
            <td valign="top" align="right">
                Invoice Date:
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddlInvoices" runat="server">
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
    <div>
        <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="RevenueReportExport" />
    </div>
</asp:Content>
