
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Moderator.aspx.cs" Inherits="Moderator" Title="Moderator List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Moderator List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session">
            <FieldsToExclude>
                <data:Field Value="WholesalerID" />
                <data:Field Value="RoleID" />
                <data:Field Value="CharityID" />
                <data:Field Value="SalesPersonID" />
                <data:Field Value="UserID" />
                <data:Field Value="CustomerID" />
            </FieldsToExclude>
		</data:GridViewSearchPanel>
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="UserDataSource"
				DataKeyNames="UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_User.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="False" />
				<asp:BoundField DataField="CompanyName" HeaderText="Company" SortExpression="[CompanyName]"  />
				<asp:BoundField DataField="AdminName" HeaderText="Admin Name" SortExpression="[AdminName]"  />
				<asp:BoundField DataField="ModeratorName" HeaderText="Moderator Name" SortExpression="[ModeratorName]"  />
				<asp:BoundField DataField="WebLoginName" HeaderText="Web Login Name" SortExpression="[WebLoginName]"  />
				<asp:BoundField DataField="WebLoginPassword" HeaderText="Web Login Password" SortExpression="[WebLoginPassword]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="[Address1]"  />
				<asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="[Address2]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]"  />
				<asp:BoundField DataField="Country" HeaderText="Country" SortExpression="[Country]"  />
				<asp:BoundField DataField="Telephone" HeaderText="Telephone Number" SortExpression="[Telephone]"  />
				<asp:BoundField DataField="CharityName" HeaderText="Charity" SortExpression="[CharityName]"  />
				<asp:BoundField DataField="SalesPerson" HeaderText="Sales Person" SortExpression="[SalesPerson]"  />

			</Columns>
			<EmptyDataTemplate>
				<b>No User Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button Visible="false" runat="server" ID="btnUser" OnClientClick="javascript:location.href='UserEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:Vw_ModeratorList_AdminSiteDataSource ID="UserDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:Vw_ModeratorList_AdminSiteDataSource>
	    		
</asp:Content>



