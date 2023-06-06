<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TempTotalDollarsSpentEdit.aspx.cs" Inherits="TempTotalDollarsSpentEdit" Title="TempTotalDollarsSpent Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Temp Total Dollars Spent - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id123" runat="server" DataSourceID="TempTotalDollarsSpentDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TempTotalDollarsSpentFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TempTotalDollarsSpentFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>TempTotalDollarsSpent not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TempTotalDollarsSpentDataSource ID="TempTotalDollarsSpentDataSource" runat="server"
			SelectMethod="GetById123"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id123" QueryStringField="Id123" Type="String" />

			</Parameters>
		</data:TempTotalDollarsSpentDataSource>
		
		<br />

		

</asp:Content>

