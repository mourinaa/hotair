<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="QuickBooksExport.aspx.cs" Inherits="QuickBooksExport" Title="" %>
<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl" TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    QuickBooks Export
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
                <asp:LinkButton ID="btnExportQBInvoice" runat="server" CssClass="special" OnClick="btnExportQBInvoice_Click">Export QB Invoice</asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnExportQBPayments" runat="server" CssClass="special" OnClick="btnExportQBPayments_Click">Export QB Payments</asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnExportQBCredits" runat="server" CssClass="special" OnClick="btnExportQBCredits_Click">Export QB Credits</asp:LinkButton>
                <br />
                <asp:LinkButton ID="btnExportQBPaymentReversals" runat="server" CssClass="special" OnClick="btnExportQBPaymentReversals_Click">Export QB Payment Reversals</asp:LinkButton>

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
