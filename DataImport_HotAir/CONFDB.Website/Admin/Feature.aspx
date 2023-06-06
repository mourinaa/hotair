
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Feature.aspx.cs" Inherits="Feature" Title="Feature List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Feature List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="FeatureDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Feature.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" />
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name"/>
				<asp:BoundField DataField="Description" HeaderText="Description" />
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" />
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" />
				<data:BoundRadioButtonField DataField="DefaultOption" HeaderText="Default Option" />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" />
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]"  />
				<data:BoundRadioButtonField DataField="DisplayOnlyToCustomer" HeaderText="Display Only To Customer" SortExpression="[DisplayOnlyToCustomer]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Feature Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnFeature" OnClientClick="javascript:location.href='FeatureEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:FeatureDataSource ID="FeatureDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:FeatureProperty Name="Product"/> 
					<%--<data:FeatureProperty Name="Wholesaler_Product_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="Customer_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="Moderator_FeatureCollection" />--%>
					<%--<data:FeatureProperty Name="FeatureOptionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="ProductID, DisplayOrder ASC" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:FeatureDataSource>
	    		
</asp:Content>



