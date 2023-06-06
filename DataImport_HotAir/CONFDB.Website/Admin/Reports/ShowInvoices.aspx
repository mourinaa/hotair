<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"
    CodeFile="ShowInvoices.aspx.cs" Inherits="Invoices" Title="Redback Invoice" %>

<%@ Register Src="~/Admin/CustomControls/ReportViewerControl.ascx" TagName="ReportViewerControl"
    TagPrefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    Invoices
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:UpdatePanel ID="UpdatePanelInvoices" runat="server" UpdateMode="Conditional">
        <ContentTemplate>--%>
            <table cellpadding="1" cellspacing="2" align="center" width="">
                <tr>
                    <td valign="top" align="right">
                        Choose an Invoice:
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlInvoices" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td valign="top" align="right">
                        Invoice Delivery Method:
                    </td>
                    <td valign="top">
                        <asp:DropDownList ID="ddlInvoiceDeliveryMethod" runat="server" DataMember="ID" DataTextField="DisplayName">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="top" align="center">
                        <asp:LinkButton ID="btnSubmit" runat="server" CssClass="special" OnClick="btnSubmit_Click">Submit</asp:LinkButton>
                        <br />
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" valign="top" align="center">
<%--                        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelInvoices"
                            DynamicLayout="false" DisplayAfter="1">
                            <ProgressTemplate>
                                <div class="">
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/progress.gif" />
                                    Please Wait...
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>--%>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" align="center">
                <tr>
                    <td colspan="3" valign="top" align="center">
                        <uc1:ReportViewerControl ID="ReportViewerControl1" runat="server" ReportName="InvoiceForCustomer" />
                    </td>
                </tr>
            </table>
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
