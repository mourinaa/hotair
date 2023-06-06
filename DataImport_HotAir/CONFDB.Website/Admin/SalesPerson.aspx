
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SalesPerson.aspx.cs" Inherits="SalesPerson" Title="SalesPerson List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Sales Person List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" 
			OnSearchButtonClicked="GridViewSearchPanel1_SearchButtonClicked" >
		    <FieldsToExclude>
		        <data:Field Value="WholesalerID" />
		        <data:Field Value="SalesManagerID" />
		    </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SalesPersonDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SalesPerson.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField Visible="false" HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="FullName" HeaderText="Full Name" SortExpression="[FullName]"  />
				<asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="[EmailAddress]"  />
				<data:BoundRadioButtonField DataField="ExternalAgent" HeaderText="External Agent" SortExpression="[ExternalAgent]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<data:HyperLinkField Visible="false" HeaderText="Sales Manager Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesManagerIdSource" DataTextField="FullName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No SalesPerson Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSalesPerson" OnClientClick="javascript:location.href='SalesPersonEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:SalesPersonDataSource ID="SalesPersonDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SalesPersonProperty Name="Wholesaler"/> 
					<data:SalesPersonProperty Name="SalesPerson"/> 
					<%--<data:SalesPersonProperty Name="SalesPersonCollection" />--%>
					<%--<data:SalesPersonProperty Name="CommissionCollection" />--%>
					<%--<data:SalesPersonProperty Name="CommissionRuleCollection" />--%>
					<%--<data:SalesPersonProperty Name="LeadCollection" />--%>
					<%--<data:SalesPersonProperty Name="CommissionAdjustmentCollection" />--%>
					<%--<data:SalesPersonProperty Name="CustomerCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="FullName" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SalesPersonDataSource>
	    		
</asp:Content>



