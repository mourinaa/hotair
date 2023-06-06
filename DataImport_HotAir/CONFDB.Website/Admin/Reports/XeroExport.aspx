<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="XeroExport.aspx.cs" Inherits="XeroExport" Title="" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Xero Export
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="1" cellspacing="2" align="center" width="100%">
        <tr>  
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
            <td  colspan="3" valign="top" align="center">         
                <asp:LinkButton ID="btnExportInvoice" runat="server" CssClass="special" OnClick="btnExportXeroInvoice_Click">Export Xero Invoices</asp:LinkButton>

                <br />
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>           
        </tr>
        <tr><td style="height: 10px">&nbsp;</td></tr>
    </table>  
   
    <table width="100%" cellpadding="0" cellspacing="0" align="center" >
        <tr>
            <td colspan="3" valign="top" align="center">
                <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="QuickBooksExport"  />
            </td>
        </tr>
    </table>
   
</asp:Content>
