
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerTransactionImport.aspx.cs" Inherits="CustomerTransactionImport" Title="CustomerTransactionImport List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Transaction Import List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerTransactionImportDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CustomerTransactionImport.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Transaction Date" SortExpression="[TransactionDate]"  />
				<asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="[TransactionAmount]"  />
				<asp:BoundField DataField="TransactionDescription" HeaderText="Transaction Description" SortExpression="[TransactionDescription]"  />
				<asp:BoundField DataField="CustomerTransactionTypeId" HeaderText="Customer Transaction Type Id" SortExpression="[CustomerTransactionTypeID]"  />
				<asp:BoundField DataField="Wholesaler_ProductId" HeaderText="Wholesaler Product Id" SortExpression="[Wholesaler_ProductID]"  />
				<asp:BoundField DataField="ProductRateId" HeaderText="Product Rate Id" SortExpression="[ProductRateID]"  />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]"  />
				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression="[SellRate]"  />
				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression="[BuyRate]"  />
				<asp:BoundField DataField="WsTransactionAmount" HeaderText="Ws Transaction Amount" SortExpression="[WSTransactionAmount]"  />
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<data:BoundRadioButtonField DataField="PostedToCustTrans" HeaderText="Posted To Cust Trans" SortExpression="[PostedToCustTrans]"  />
				<asp:BoundField DataField="PostedToCustTransDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Posted To Cust Trans Date" SortExpression="[PostedToCustTransDate]"  />
				<asp:BoundField DataField="ImportType" HeaderText="Import Type" SortExpression="[ImportType]"  />
				<asp:BoundField DataField="ErrorCodesId" HeaderText="Error Codes Id" SortExpression="[ErrorCodesID]"  />
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="LocalTaxRate" HeaderText="Local Tax Rate" SortExpression="[LocalTaxRate]"  />
				<asp:BoundField DataField="FederalTaxRate" HeaderText="Federal Tax Rate" SortExpression="[FederalTaxRate]"  />
				<asp:BoundField DataField="LocalTaxAmount" HeaderText="Local Tax Amount" SortExpression="[LocalTaxAmount]"  />
				<asp:BoundField DataField="FederalTaxAmount" HeaderText="Federal Tax Amount" SortExpression="[FederalTaxAmount]"  />
				<asp:BoundField DataField="ElapsedTimeSeconds" HeaderText="Elapsed Time Seconds" SortExpression="[ElapsedTimeSeconds]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CustomerTransactionImport Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCustomerTransactionImport" OnClientClick="javascript:location.href='CustomerTransactionImportEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CustomerTransactionImportDataSource ID="CustomerTransactionImportDataSource" runat="server"
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
		</data:CustomerTransactionImportDataSource>
	    		
</asp:Content>



