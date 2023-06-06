<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="CallDetails.aspx.cs" Inherits="calldetails" Title="Redback Conferencing" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Call Details Report
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" align="center">
        <tr>
            <td valign="top" align="right">
                Customer Admin:
            </td>
            <td valign="top">
                <data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerListDataSource1"
                    DataTextField="DDLDescription" DataValueField="Id" AppendNullItem="true" Required="true"
                    NullItemText="< Please Choose ...>" ErrorText="Required" AutoPostBack="true"
                    OnSelectedIndexChanged="dataCustomerId_SelectedIndexChanged" />
                <data:Vw_CustomerListDataSource ID="CustomerListDataSource1" runat="server" SelectMethod="Get">
                    <Parameters>
                        <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID" Type="string">
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:Vw_CustomerListDataSource>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                Choose a Report:
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddlReports" runat="server">
                    <asp:ListItem Value="CDRSUMMARYRPT">Summarized Conference Report</asp:ListItem>
                    <asp:ListItem Value="CDRDETAILRPT">Detailed Conference Report</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                Enter a Start Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtDateFrom" Width="72px" />
                <asp:ImageButton runat="Server" ID="Image1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="calStartDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtDateFrom" PopupButtonID="Image1" Format="dd/MM/yyyy" />
                &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td valign="top" align="right">
                Enter an End Date:
            </td>
            <td valign="top">
                <asp:TextBox runat="server" ID="txtDateTo" Width="72px" />
                <asp:ImageButton runat="Server" ID="ImageButton1" ImageUrl="~/images/Calendar_scheduleHS.png"
                    AlternateText="Click to show calendar" />
                <ajaxToolkit:CalendarExtender ID="calEndDate" runat="server" CssClass="MyCalendar"
                    TargetControlID="txtDateTo" PopupButtonID="ImageButton1" Format="dd/MM/yyyy" />
                &nbsp;&nbsp;
            </td>
        </tr>
<%--        <asp:Panel ID="panelCustomerAdmin" runat="server" Height="50px" Width="125px" Visible="true">
--%>
        <tr>
             <td valign="top" align="right">   
               Choose a Department:
            </td>
            <td valign="top">
            <asp:DropDownList ID="ddlDepts" runat="server">
                </asp:DropDownList>
            </td>         
        </tr>
        <tr>
            <td valign="top" align="right">
                Choose a Moderator:
            </td>
            <td valign="top">
                <asp:DropDownList ID="ddlUsers" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
<%--        </asp:Panel>
--%>
        <tr>
            <td valign="top" align="right">
                Choose a Conference Name:
            </td>
            <td valign="top">
                <asp:TextBox ID="txtMeetingName" runat="server"></asp:TextBox>&nbsp; (Optional)</td>
        </tr>
        <tr>
            <td valign="top" align="right">
                Choose a Reference Number:
            </td>
            <td valign="top">
                <asp:TextBox ID="txtRefNum" runat="server"></asp:TextBox>&nbsp; (Optional)</td>
        </tr>
        <tr>
            <td colspan="3" valign="top" align="center">
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
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td colspan="3" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="CallDetailsForModerator" />
            </td>
        </tr>
    </table>
</asp:Content>
