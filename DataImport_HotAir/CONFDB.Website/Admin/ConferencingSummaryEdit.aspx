<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ConferencingSummaryEdit.aspx.cs" Inherits="ConferencingSummaryEdit" Title="ConferencingSummary Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Conferencing Summary - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="BilledDate, ProductId, Currency" runat="server" DataSourceID="ConferencingSummaryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ConferencingSummaryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ConferencingSummaryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ConferencingSummary not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ConferencingSummaryDataSource ID="ConferencingSummaryDataSource" runat="server"
			SelectMethod="GetByBilledDateProductIdCurrency"
		>
			<Parameters>
				<asp:QueryStringParameter Name="BilledDate" QueryStringField="BilledDate" Type="String" />
<asp:QueryStringParameter Name="ProductId" QueryStringField="ProductId" Type="String" />
<asp:QueryStringParameter Name="Currency" QueryStringField="Currency" Type="String" />

			</Parameters>
		</data:ConferencingSummaryDataSource>
		
		<br />


</asp:Content>

