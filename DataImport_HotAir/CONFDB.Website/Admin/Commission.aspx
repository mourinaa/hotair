
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Commission.aspx.cs" Inherits="Commission" Title="Commission List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Commission List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="CommissionDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Commission.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesPersonIdSource" DataTextField="FullName" />
				<asp:BoundField DataField="BilledDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Billed Date" SortExpression="[BilledDate]"  />
				<asp:BoundField DataField="TotalCredits" HeaderText="Total Credits" SortExpression="[TotalCredits]"  />
				<asp:BoundField DataField="ProductCharges" HeaderText="Product Charges" SortExpression="[ProductCharges]"  />
				<asp:BoundField DataField="MiscCharges" HeaderText="Misc Charges" SortExpression="[MiscCharges]"  />
				<asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" SortExpression="[TotalAmount]"  />
				<asp:BoundField DataField="CommissionRate" HeaderText="Commission Rate" SortExpression="[CommissionRate]"  />
				<asp:BoundField DataField="TotalCommission" HeaderText="Total Commission" SortExpression="[TotalCommission]"  />
				<data:HyperLinkField HeaderText="Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CurrencyIdSource" DataTextField="LongName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Commission Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnCommission" OnClientClick="javascript:location.href='CommissionEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:CommissionDataSource ID="CommissionDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CommissionProperty Name="Currency"/> 
					<data:CommissionProperty Name="SalesPerson"/> 
					<data:CommissionProperty Name="Wholesaler"/> 
					<data:CommissionProperty Name="Customer"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:CommissionDataSource>
	    		
</asp:Content>



