
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AccessType_ProductRate.aspx.cs" Inherits="AccessType_ProductRate" Title="AccessType_ProductRate List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Access Type Product Rate List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
	DON'T Use as not useful since it is a Many-To-Many relationship. Use AccessType_ProductRateEdit.aspx.
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AccessType_ProductRateDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AccessType_ProductRate.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Access Type" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate" DataNavigateUrlFormatString="ProductRateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No AccessType_ProductRate Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAccessType_ProductRate" OnClientClick="javascript:location.href='AccessType_ProductRateEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:AccessType_ProductRateDataSource ID="AccessType_ProductRateDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AccessType_ProductRateProperty Name="AccessType"/> 
					<data:AccessType_ProductRateProperty Name="ProductRate"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:AccessType_ProductRateDataSource>
	    		
</asp:Content>



