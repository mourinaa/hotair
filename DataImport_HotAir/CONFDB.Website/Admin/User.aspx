
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="User.aspx.cs" Inherits="User" Title="User List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
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
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Username" HeaderText="Username" SortExpression="[Username]"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]"  />
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]"  />
				<asp:BoundField DataField="Email" HeaderText="Email" SortExpression="[Email]"  />
				<asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="[Telephone]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<data:HyperLinkField HeaderText="Company Id" DataNavigateUrlFormatString="CompanyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyIdSource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesPersonIdSource" DataTextField="FullName" />
				<data:HyperLinkField HeaderText="Role Id" DataContainer="RoleIdSource" DataTextField="Name" />
				<data:BoundRadioButtonField DataField="MustChangePassword" HeaderText="Must Change Password" SortExpression="[MustChangePassword]"  />
				<asp:BoundField DataField="Address1" HeaderText="Address1" SortExpression="[Address1]"  />
				<asp:BoundField DataField="Address2" HeaderText="Address2" SortExpression="[Address2]"  />
				<asp:BoundField DataField="City" HeaderText="City" SortExpression="[City]"  />
				<data:HyperLinkField HeaderText="Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="PostalCode" HeaderText="Postal Code" SortExpression="[PostalCode]"  />
				<data:HyperLinkField HeaderText="Charity Id" DataNavigateUrlFormatString="CharityEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CharityIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WebMemberId" HeaderText="Web Member Id" SortExpression="[WebMemberID]"  />
				<asp:BoundField DataField="UserUniqueId" HeaderText="User Unique Id" SortExpression="[UserUniqueID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No User Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUser" OnClientClick="javascript:location.href='UserEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:UserDataSource ID="UserDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:UserProperty Name="Charity"/> 
					<data:UserProperty Name="Country"/> 
					<data:UserProperty Name="Role"/> 
					<data:UserProperty Name="SalesPerson"/> 
					<data:UserProperty Name="State"/> 
					<data:UserProperty Name="Company"/> 
					<%--<data:UserProperty Name="MarketingServiceIdMarketingServiceCollection_From_User_MarketingService" />--%>
					<%--<data:UserProperty Name="ModeratorCollection" />--%>
					<%--<data:UserProperty Name="User_MarketingServiceCollection" />--%>
					<%--<data:UserProperty Name="CustomerCollection" />--%>
					<%--<data:UserProperty Name="EventManagerCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:UserDataSource>
	    		
</asp:Content>



