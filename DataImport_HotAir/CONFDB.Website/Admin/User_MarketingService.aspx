
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="User_MarketingService.aspx.cs" Inherits="User_MarketingService" Title="User_MarketingService List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User Marketing Service List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="User_MarketingServiceDataSource"
				DataKeyNames="MarketingServiceId, UserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_User_MarketingService.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username" />
				<data:HyperLinkField HeaderText="Marketing Service Id" DataNavigateUrlFormatString="MarketingServiceEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="MarketingServiceIdSource" DataTextField="Name" />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<asp:BoundField DataField="LastModifiedBy" HeaderText="Last Modified By" SortExpression="[LastModifiedBy]"  />
				<asp:BoundField DataField="LastContactDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Contact Date" SortExpression="[LastContactDate]"  />
				<asp:BoundField DataField="NextContactDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Next Contact Date" SortExpression="[NextContactDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No User_MarketingService Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnUser_MarketingService" OnClientClick="javascript:location.href='User_MarketingServiceEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:User_MarketingServiceDataSource ID="User_MarketingServiceDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:User_MarketingServiceProperty Name="User"/> 
					<data:User_MarketingServiceProperty Name="MarketingService"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:User_MarketingServiceDataSource>
	    		
</asp:Content>



