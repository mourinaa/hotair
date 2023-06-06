
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductRateValue.aspx.cs" Inherits="ProductRateValue" Title="ProductRateValue List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Rate Value List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductRateValueDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductRateValue.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />		
				<%--<data:HyperLinkField HeaderText="Product" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />--%>
				<data:HyperLinkField HeaderText="Product Rate Id" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
				<asp:BoundField DataField="SellRate" HeaderText="Sell Rate" SortExpression=""  />
				<data:HyperLinkField HeaderText="Sell Rate Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SellRateCurrencyIdSource" DataTextField="LongName" />
				<asp:BoundField DataField="BuyRate" HeaderText="Buy Rate" SortExpression=""  />
				<data:HyperLinkField HeaderText="Buy Rate Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BuyRateCurrencyIdSource" DataTextField="LongName" />
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression=""  />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression=""  />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductRateValue Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductRateValue" OnClientClick="javascript:location.href='ProductRateValueEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ProductRateValueDataSource ID="ProductRateValueDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True" onselecting="ProductRateValueDataSource_Selecting" 
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="false">
	            <Types>
					<data:ProductRateValueProperty Name="Currency"/> 
					<data:ProductRateValueProperty Name="ProductRate"/> 
					<data:ProductRateValueProperty Name="Wholesaler"/> 
					<data:ProductRateValueProperty Name="Customer"/>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="DefaultOption=1" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="ProductRateId" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductRateValueDataSource>
	    		
</asp:Content>



