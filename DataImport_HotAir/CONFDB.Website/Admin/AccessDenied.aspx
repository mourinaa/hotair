<%@ Page Language="C#" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true" CodeFile="AccessDenied.aspx.cs" Inherits="Admin_AccessDenied" Title="Untitled Page" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text="Label" CssClass="ErrorMessage">ACCESS DENIED</asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label">You are not authorized to view this page.</asp:Label>
</asp:Content>

