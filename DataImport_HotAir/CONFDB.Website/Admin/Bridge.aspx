
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Bridge.aspx.cs" Inherits="Bridge" Title="Bridge List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bridge List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="BridgeDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Bridge.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]"  />
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]"  />
				<asp:BoundField DataField="IpAddress" HeaderText="Ip Address" SortExpression="[IPAddress]"  />
				<asp:BoundField DataField="WebRequestSecurityToken" HeaderText="Web Request Security Token" SortExpression="[WebRequestSecurityToken]"  />
				<asp:BoundField DataField="WebRequestApiurl" HeaderText="Web Request Apiurl" SortExpression="[WebRequestAPIURL]"  />
				<asp:BoundField DataField="WebRequestMethod" HeaderText="Web Request Method" SortExpression="[WebRequestMethod]"  />
				<asp:BoundField DataField="WebRequestContentType" HeaderText="Web Request Content Type" SortExpression="[WebRequestContentType]"  />
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]"  />
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]"  />
				<data:HyperLinkField HeaderText="Bridge Type Id" DataNavigateUrlFormatString="BridgeTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DbConnectionString" HeaderText="Db Connection String" SortExpression="[DBConnectionString]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Bridge Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBridge" OnClientClick="javascript:location.href='BridgeEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:BridgeDataSource ID="BridgeDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BridgeProperty Name="BridgeType"/> 
					<%--<data:BridgeProperty Name="BridgeQueueCollection" />--%>
					<%--<data:BridgeProperty Name="RatedCdrCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:BridgeDataSource>
	    		
</asp:Content>



