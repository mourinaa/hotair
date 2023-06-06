
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="InvoiceSummary.aspx.cs" Inherits="InvoiceSummary" Title="InvoiceSummary List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Invoice Summary List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="InvoiceSummaryDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_InvoiceSummary.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="InvoiceNumber" HeaderText="Invoice Number" SortExpression="[InvoiceNumber]"  />
				<asp:BoundField DataField="AmountOfLastBill" HeaderText="Amount Of Last Bill" SortExpression="[AmountOfLastBill]"  />
				<asp:BoundField DataField="Payment1" HeaderText="Payment1" SortExpression="[Payment1]"  />
				<asp:BoundField DataField="TotalCredits" HeaderText="Total Credits" SortExpression="[TotalCredits]"  />
				<asp:BoundField DataField="TotalLatePaymentCharges" HeaderText="Total Late Payment Charges" SortExpression="[TotalLatePaymentCharges]"  />
				<asp:BoundField DataField="BalForward" HeaderText="Bal Forward" SortExpression="[BalForward]"  />
				<asp:BoundField DataField="ProductCharges" HeaderText="Product Charges" SortExpression="[ProductCharges]"  />
				<asp:BoundField DataField="MiscCharges" HeaderText="Misc Charges" SortExpression="[MiscCharges]"  />
				<asp:BoundField DataField="LocalTaxAmount" HeaderText="Local Tax Amount" SortExpression="[LocalTaxAmount]"  />
				<asp:BoundField DataField="FederalTaxAmount" HeaderText="Federal Tax Amount" SortExpression="[FederalTaxAmount]"  />
				<asp:BoundField DataField="TotalCurrent" HeaderText="Total Current" SortExpression="[TotalCurrent]"  />
				<asp:BoundField DataField="BalanceForward" HeaderText="Balance Forward" SortExpression="[BalanceForward]"  />
				<asp:BoundField DataField="InvoiceDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Invoice Date" SortExpression="[InvoiceDate]"  />
				<asp:BoundField DataField="DueDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Due Date" SortExpression="[DueDate]"  />
				<asp:BoundField DataField="CurrencyId" HeaderText="Currency Id" SortExpression="[CurrencyID]"  />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="TotalFreeCredits" HeaderText="Total Free Credits" SortExpression="[TotalFreeCredits]"  />
				<asp:BoundField DataField="Wholesaler_ProductId" HeaderText="Wholesaler Product Id" SortExpression="[Wholesaler_ProductID]"  />
				<asp:BoundField DataField="BpayCustomerRefNumber" HeaderText="Bpay Customer Ref Number" SortExpression="[BPayCustomerRefNumber]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No InvoiceSummary Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnInvoiceSummary" OnClientClick="javascript:location.href='InvoiceSummaryEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:InvoiceSummaryDataSource ID="InvoiceSummaryDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:InvoiceSummaryProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:InvoiceSummaryDataSource>
	    		
</asp:Content>



