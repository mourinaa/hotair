
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="InvoiceCharges.aspx.cs" Inherits="InvoiceCharges" Title="InvoiceCharges List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Invoice Charges List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="InvoiceChargesDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_InvoiceCharges.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<asp:BoundField DataField="CustomerTransactionTypeId" HeaderText="Customer Transaction Type Id" SortExpression="[CustomerTransactionTypeID]"  />
				<asp:BoundField DataField="TransactionDescription" HeaderText="Transaction Description" SortExpression="[TransactionDescription]"  />
				<asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Transaction Date" SortExpression="[TransactionDate]"  />
				<asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="[TransactionAmount]"  />
				<asp:BoundField DataField="LocalTaxRate" HeaderText="Local Tax Rate" SortExpression="[LocalTaxRate]"  />
				<asp:BoundField DataField="FederalTaxRate" HeaderText="Federal Tax Rate" SortExpression="[FederalTaxRate]"  />
				<asp:BoundField DataField="LocalTaxAmount" HeaderText="Local Tax Amount" SortExpression="[LocalTaxAmount]"  />
				<asp:BoundField DataField="FederalTaxAmount" HeaderText="Federal Tax Amount" SortExpression="[FederalTaxAmount]"  />
				<asp:BoundField DataField="TransactionTotal" HeaderText="Transaction Total" SortExpression="[TransactionTotal]"  />
				<asp:BoundField DataField="Wholesaler_ProductId" HeaderText="Wholesaler Product Id" SortExpression="[Wholesaler_ProductID]"  />
				<asp:BoundField DataField="ProductRateId" HeaderText="Product Rate Id" SortExpression="[ProductRateID]"  />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]"  />
				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression="[SellRate]"  />
				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression="[BuyRate]"  />
				<asp:BoundField DataField="WsTransactionAmount" HeaderText="Ws Transaction Amount" SortExpression="[WSTransactionAmount]"  />
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="ElapsedTimeSeconds" HeaderText="Elapsed Time Seconds" SortExpression="[ElapsedTimeSeconds]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No InvoiceCharges Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnInvoiceCharges" OnClientClick="javascript:location.href='InvoiceChargesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:InvoiceChargesDataSource ID="InvoiceChargesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
		>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:InvoiceChargesDataSource>
	    		
</asp:Content>



