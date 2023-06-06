
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Product.aspx.cs" Inherits="Product" Title="Product List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Product List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ProductDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Product.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" ShowDeleteButton="False" />				
				<data:HyperLinkField HeaderText="Product Type Id" DataNavigateUrlFormatString="ProductTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" SortExpression="[DisplayNameAlt]"  />
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" SortExpression="[DescriptionAlt]"  />
				<data:BoundRadioButtonField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]"  />
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]"  />
				<data:BoundRadioButtonField DataField="SupportsExternalProvisioning" HeaderText="Supports External Provisioning" SortExpression="[SupportsExternalProvisioning]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnProduct" OnClientClick="javascript:location.href='ProductEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ProductDataSource ID="ProductDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductProperty Name="ProductType"/> 
					<%--<data:ProductProperty Name="Wholesaler_ProductCollection" />--%>
					<%--<data:ProductProperty Name="ProductRateCollection" />--%>
					<%--<data:ProductProperty Name="FeatureCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="DisplayOrder" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ProductDataSource>
	    		
</asp:Content>



