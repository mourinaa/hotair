<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Moderator_DnisEdit.aspx.cs" Inherits="Moderator_DnisEdit" Title="Moderator_Dnis Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Moderator Dnis - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Dnisid, ModeratorId" runat="server" DataSourceID="Moderator_DnisDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Moderator_DnisFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/Moderator_DnisFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Moderator_Dnis not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:Moderator_DnisDataSource ID="Moderator_DnisDataSource" runat="server"
			SelectMethod="GetByDnisidModeratorId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Dnisid" QueryStringField="Dnisid" Type="String" />
<asp:QueryStringParameter Name="ModeratorId" QueryStringField="ModeratorId" Type="String" />

			</Parameters>
		</data:Moderator_DnisDataSource>
		
		<br />


</asp:Content>

