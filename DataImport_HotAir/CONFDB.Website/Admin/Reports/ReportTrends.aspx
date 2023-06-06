<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeFile="ReportTrends.aspx.cs" Inherits="ReportTrends" Title="Untitled Page" %>

<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Trends Report - Revenue trend/forcasting for 12 months (may not match invoices)
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" width="800px">
        <tr>
            <td valign="top" align="right">
                Sales Person:
            </td>
            <td valign="top">
                <data:EntityDropDownList Width="305px" runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource"
                    DataTextField="FullName" DataValueField="Id" AppendNullItem="true" Required="false"
                    NullItemText="All" ErrorText="Required" />
                <data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server"
                    SelectMethod="GetPaged">
                    <Parameters>
                        <data:CustomParameter Name="OrderBy" Value="FullName" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:SalesPersonDataSource>
            </td>
        </tr>
        <tr>
            <td colspan="2" valign="top" align="center">
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
        <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="CommissionReport" />
    </div>
</asp:Content>
