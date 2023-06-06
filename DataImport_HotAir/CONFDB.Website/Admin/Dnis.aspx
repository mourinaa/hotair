
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Dnis.aspx.cs" Inherits="Dnis" Title="Dnis List" %>
<%@ Register Src="CustomControls/DNISGridWS.ascx" TagName="DNISGridWS" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Dnis List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <uc1:DNISGridWS ID="DNISGridWS1" runat="server" />
	</ContentTemplate>
	</asp:UpdatePanel>	
	    		
</asp:Content>



