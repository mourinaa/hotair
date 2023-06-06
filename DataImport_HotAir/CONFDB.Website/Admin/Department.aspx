
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Department.aspx.cs" Inherits="Department" Title="Department List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Department List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" 
			OnSearchButtonClicked="GridViewSearchPanel1_SearchButtonClicked" >
		    <FieldsToExclude>
		        <data:Field Value="WholesalerID" />
		        <data:Field Value="ParentID" />
		    </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="DepartmentDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Department.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField Visible="False" HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField Visible="false" DataField="ParentId" HeaderText="Parent Id" SortExpression="[ParentID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Department Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnDepartment" OnClientClick="javascript:location.href='DepartmentEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:DepartmentDataSource ID="DepartmentDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DepartmentProperty Name="Wholesaler"/> 
					<data:DepartmentProperty Name="Customer"/> 
					<%--<data:DepartmentProperty Name="ModeratorCollection" />--%>
					<%--<data:DepartmentProperty Name="MonthlyDepartmentSummaryCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderBy" Value="CustomerID, Name" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:DepartmentDataSource>
	    		
</asp:Content>



