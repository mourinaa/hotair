<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="ReportCustomerTransactionList.aspx.cs" Inherits="ReportCustomerTransactionList" Title="Customer Transaction List" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Customer Transaction List
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" width="100%">
        <tr>
            <td valign="top" align="right">
                Customer Admin:
            </td>
            <td valign="top">
                <data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerListDataSource1"
                    DataTextField="DDLDescription" DataValueField="Id" AppendNullItem="true" Required="true"
                    NullItemText="< Please Choose ...>" ErrorText="Required" />
                <data:Vw_CustomerListDataSource ID="CustomerListDataSource1" runat="server" SelectMethod="Get">
                    <Parameters>
                        <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID"
                            Type="string">
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:Vw_CustomerListDataSource>
            </td>
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
    <table width="100%" cellpadding="0" cellspacing="0" align="center">
        <tr>
            <td colspan="3" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="CustomerTransactionList" />
            </td>
        </tr>
    </table>
</asp:Content>
