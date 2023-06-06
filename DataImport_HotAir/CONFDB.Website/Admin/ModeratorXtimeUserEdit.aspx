<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ModeratorXtimeUserEdit.aspx.cs" Inherits="ModeratorXtimeUserEdit" Title="ModeratorXtimeUser Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Moderator Xtime User - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="ModeratorId" runat="server" DataSourceID="ModeratorXtimeUserDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ModeratorXtimeUserFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ModeratorXtimeUserFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ModeratorXtimeUser not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ModeratorXtimeUserDataSource ID="ModeratorXtimeUserDataSource" runat="server"
			SelectMethod="GetByModeratorId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="ModeratorId" QueryStringField="ModeratorId" Type="String" />

			</Parameters>
		</data:ModeratorXtimeUserDataSource>
		
		<br />

		

</asp:Content>

