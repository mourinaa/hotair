<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AverageRatesEdit.aspx.cs" Inherits="AverageRatesEdit" Title="AverageRates Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Average Rates - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UsageMonth, ProductRateId, WholesalerId" runat="server" DataSourceID="AverageRatesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AverageRatesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AverageRatesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AverageRates not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AverageRatesDataSource ID="AverageRatesDataSource" runat="server"
			SelectMethod="GetByUsageMonthProductRateIdWholesalerId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UsageMonth" QueryStringField="UsageMonth" Type="String" />
<asp:QueryStringParameter Name="ProductRateId" QueryStringField="ProductRateId" Type="String" />
<asp:QueryStringParameter Name="WholesalerId" QueryStringField="WholesalerId" Type="String" />

			</Parameters>
		</data:AverageRatesDataSource>
		
		<br />


</asp:Content>

