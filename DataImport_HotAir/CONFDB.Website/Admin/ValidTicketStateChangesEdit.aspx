<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ValidTicketStateChangesEdit.aspx.cs" Inherits="ValidTicketStateChangesEdit" Title="ValidTicketStateChanges Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Valid Ticket State Changes - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="FromStatusId, ToStatusId" runat="server" DataSourceID="ValidTicketStateChangesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ValidTicketStateChangesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ValidTicketStateChangesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ValidTicketStateChanges not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ValidTicketStateChangesDataSource ID="ValidTicketStateChangesDataSource" runat="server"
			SelectMethod="GetByFromStatusIdToStatusId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="FromStatusId" QueryStringField="FromStatusId" Type="String" />
<asp:QueryStringParameter Name="ToStatusId" QueryStringField="ToStatusId" Type="String" />

			</Parameters>
		</data:ValidTicketStateChangesDataSource>
		
		<br />


</asp:Content>

