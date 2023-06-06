
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ProductRate.aspx.cs" Inherits="ProductRate" Title="ProductRate List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product Rate List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductRateDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="[DisplayOrder]" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ProductRate.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Type" DataNavigateUrlFormatString="ProductRateTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Interval" DataNavigateUrlFormatString="ProductRateIntervalEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIntervalIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Taxable" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountryIdSource" DataTextField="Description" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]"  />
				<asp:BoundField DataField="MinimumTimeBeforeChargedSec" HeaderText="Minimum Time Before Charged Sec" SortExpression="[MinimumTimeBeforeChargedSec]"  />
				<data:HyperLinkField HeaderText="Rating Type" DataNavigateUrlFormatString="RatingTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RatingTypeIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No ProductRate Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProductRate" OnClientClick="javascript:location.href='ProductRateEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ProductRateDataSource ID="ProductRateDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductRateProperty Name="Country"/> 
					<data:ProductRateProperty Name="RatingType"/> 
					<data:ProductRateProperty Name="Taxable"/> 
					<data:ProductRateProperty Name="ProductRateType"/> 
					<data:ProductRateProperty Name="ProductRateInterval"/> 
					<data:ProductRateProperty Name="Product"/> 
					<%--<data:ProductRateProperty Name="ProductRateValueCollection" />--%>
					<%--<data:ProductRateProperty Name="CommissionCollection" />--%>
					<%--<data:ProductRateProperty Name="AccessType_ProductRateCollection" />--%>
					<%--<data:ProductRateProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductRateDataSource>
	    		
</asp:Content>



