
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Wholesaler_Product_Feature.aspx.cs" Inherits="Wholesaler_Product_Feature" Title="Wholesaler_Product_Feature List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Wholesaler Product Feature List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="Wholesaler_Product_FeatureDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Wholesaler_Product_Feature.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Product Id" DataNavigateUrlFormatString="Wholesaler_ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="Wholesaler_ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Feature Id" DataNavigateUrlFormatString="FeatureEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Feature Option Id" DataNavigateUrlFormatString="FeatureOptionEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FeatureOptionIdSource" DataTextField="Name" />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<asp:BoundField DataField="FeatureOptionValue" HeaderText="Feature Option Value" SortExpression="[FeatureOptionValue]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler_Product_Feature Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWholesaler_Product_Feature" OnClientClick="javascript:location.href='Wholesaler_Product_FeatureEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:Wholesaler_Product_FeatureDataSource ID="Wholesaler_Product_FeatureDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Wholesaler_Product_FeatureProperty Name="Feature"/> 
					<data:Wholesaler_Product_FeatureProperty Name="FeatureOption"/> 
					<data:Wholesaler_Product_FeatureProperty Name="Wholesaler_Product"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:Wholesaler_Product_FeatureDataSource>
	    		
</asp:Content>



