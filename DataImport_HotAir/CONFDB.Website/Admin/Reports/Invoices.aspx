<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="Invoices.aspx.cs" Inherits="Invoices" Title="Redback Invoice" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Invoices
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" align="center" width="100%">
        <tr>  
            <td valign="top" align="right">
                Customer Admin:
            </td>
            <td valign="top">
                <data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerListDataSource1"
                    DataTextField="DDLDescription" DataValueField="Id" AppendNullItem="true" Required="true"
                    NullItemText="< Please Choose ...>" ErrorText="Required" 
                    AutoPostBack="true" OnSelectedIndexChanged="dataCustomerId_SelectedIndexChanged" />
                <data:Vw_CustomerListDataSource ID="CustomerListDataSource1" runat="server" SelectMethod="Get">
                    <Parameters>
                        <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="WholesalerID" Type="string">
                        </data:SqlParameter>
                        <data:CustomParameter Name="OrderBy" Value="CompanyName,PriCustomerNumber" ConvertEmptyStringToNull="false" />
                    </Parameters>
                </data:Vw_CustomerListDataSource>
            </td>
            <td valign="top" align="right">
                Choose an Invoice:
            </td>
            <td valign="top">    
                <asp:DropDownList ID="ddlInvoices" runat="server">
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
 
        <tr>
            <td  colspan="4" valign="top" align="center">         
                <asp:LinkButton ID="btnSubmit" runat="server" CssClass="special" OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>           
        </tr>
        <tr><td style="height: 10px">&nbsp;</td></tr>
    </table>  
   
    <table width="100%" cellpadding="0" cellspacing="0" align="center" >
        <tr>
            <td colspan="" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="InvoiceForCustomer" />
            </td>
        </tr>
    </table>
   
</asp:Content>
