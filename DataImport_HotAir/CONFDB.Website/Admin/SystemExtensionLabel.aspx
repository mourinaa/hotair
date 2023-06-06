
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SystemExtensionLabel.aspx.cs" Inherits="SystemExtensionLabel" Title="SystemExtensionLabel List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">System Extension Label List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SystemExtensionLabelDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SystemExtensionLabel.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]"  />
				<data:HyperLinkField HeaderText="Extension Type Id" DataNavigateUrlFormatString="ExtensionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ExtensionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ExtensionTypeLabel" HeaderText="Extension Type Label" SortExpression="[ExtensionTypeLabel]"  />
				<data:BoundRadioButtonField DataField="CustomerCanView" HeaderText="Customer Can View" SortExpression="[CustomerCanView]"  />
				<data:BoundRadioButtonField DataField="ModeratorCanView" HeaderText="Moderator Can View" SortExpression="[ModeratorCanView]"  />
				<data:BoundRadioButtonField DataField="CustomerCanEdit" HeaderText="Customer Can Edit" SortExpression="[CustomerCanEdit]"  />
				<data:BoundRadioButtonField DataField="ModeratorCanEdit" HeaderText="Moderator Can Edit" SortExpression="[ModeratorCanEdit]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SystemExtensionLabel Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSystemExtensionLabel" OnClientClick="javascript:location.href='SystemExtensionLabelEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:SystemExtensionLabelDataSource ID="SystemExtensionLabelDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SystemExtensionLabelProperty Name="ExtensionType"/> 
					<%--<data:SystemExtensionLabelProperty Name="SystemExtensionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:SystemExtensionLabelDataSource>
	    		
</asp:Content>



