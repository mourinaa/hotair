<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Customer_DnisEdit.aspx.cs" Inherits="Customer_DnisEdit" Title="Customer_Dnis Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Dnis - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Dnisid, CustomerId" runat="server" DataSourceID="Customer_DnisDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Customer_DnisFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Customer_DnisFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Customer_Dnis not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:Customer_DnisDataSource ID="Customer_DnisDataSource" runat="server"
			SelectMethod="GetByDnisidCustomerId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Dnisid" QueryStringField="Dnisid" Type="String" />
<asp:QueryStringParameter Name="CustomerId" QueryStringField="CustomerId" Type="String" />

			</Parameters>
		</data:Customer_DnisDataSource>
		
		<br />


</asp:Content>

