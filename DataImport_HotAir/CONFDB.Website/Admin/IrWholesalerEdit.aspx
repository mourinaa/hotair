<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="IrWholesalerEdit.aspx.cs" Inherits="IrWholesalerEdit" Title="IrWholesaler Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ir Wholesaler - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="WholesalerId, LanguageId" runat="server" DataSourceID="IrWholesalerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/IrWholesalerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/IrWholesalerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>IrWholesaler not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:IrWholesalerDataSource ID="IrWholesalerDataSource" runat="server"
			SelectMethod="GetByWholesalerIdLanguageId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="WholesalerId" QueryStringField="WholesalerId" Type="String" />
<asp:QueryStringParameter Name="LanguageId" QueryStringField="LanguageId" Type="String" />

			</Parameters>
		</data:IrWholesalerDataSource>
		
		<br />


</asp:Content>

