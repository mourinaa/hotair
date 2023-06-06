
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CustomerTransaction.aspx.cs" Inherits="CustomerTransaction" Title="CustomerTransaction List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Customer Transaction List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CustomerTransactionDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_CustomerTransaction.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<data:HyperLinkField HeaderText="Customer Transaction Type Id" DataNavigateUrlFormatString="CustomerTransactionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerTransactionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="TransactionDescription" HeaderText="Transaction Description" SortExpression="[TransactionDescription]"  />
				<asp:BoundField DataField="TransactionDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Transaction Date" SortExpression="[TransactionDate]"  />
				<asp:BoundField DataField="TransactionAmount" HeaderText="Transaction Amount" SortExpression="[TransactionAmount]"  />
				<asp:BoundField DataField="LocalTaxRate" HeaderText="Local Tax Rate" SortExpression="[LocalTaxRate]"  />
				<asp:BoundField DataField="FederalTaxRate" HeaderText="Federal Tax Rate" SortExpression="[FederalTaxRate]"  />
				<asp:BoundField DataField="LocalTaxAmount" HeaderText="Local Tax Amount" SortExpression="[LocalTaxAmount]"  />
				<asp:BoundField DataField="FederalTaxAmount" HeaderText="Federal Tax Amount" SortExpression="[FederalTaxAmount]"  />
				<asp:BoundField DataField="TransactionTotal" HeaderText="Transaction Total" SortExpression="[TransactionTotal]"  />
				<asp:BoundField DataField="CustomerBalance" HeaderText="Customer Balance" SortExpression="[CustomerBalance]"  />
				<data:HyperLinkField HeaderText="Wholesaler Product Id" DataNavigateUrlFormatString="Wholesaler_ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="Wholesaler_ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Id" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="[Quantity]"  />
				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression="[SellRate]"  />
				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression="[BuyRate]"  />
				<asp:BoundField DataField="WsTransactionAmount" HeaderText="Ws Transaction Amount" SortExpression="[WSTransactionAmount]"  />
				<asp:BoundField DataField="ReferenceNumber" HeaderText="Reference Number" SortExpression="[ReferenceNumber]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="PostedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Posted Date" SortExpression="[PostedDate]"  />
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<data:BoundRadioButtonField DataField="PostedToInvoice" HeaderText="Posted To Invoice" SortExpression="[PostedToInvoice]"  />
				<asp:BoundField DataField="PostedToInvoiceDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Posted To Invoice Date" SortExpression="[PostedToInvoiceDate]"  />
				<asp:BoundField DataField="ElapsedTimeSeconds" HeaderText="Elapsed Time Seconds" SortExpression="[ElapsedTimeSeconds]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No CustomerTransaction Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCustomerTransaction" OnClientClick="javascript:location.href='CustomerTransactionEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CustomerTransactionDataSource ID="CustomerTransactionDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerTransactionProperty Name="CustomerTransactionType"/> 
					<data:CustomerTransactionProperty Name="ProductRate"/> 
					<data:CustomerTransactionProperty Name="Wholesaler_Product"/> 
					<data:CustomerTransactionProperty Name="Wholesaler"/> 
					<data:CustomerTransactionProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CustomerTransactionDataSource>
	    		
</asp:Content>



