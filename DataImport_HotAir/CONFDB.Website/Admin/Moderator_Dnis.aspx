
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Moderator_Dnis.aspx.cs" Inherits="Moderator_Dnis" Title="Moderator_Dnis List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Moderator Dnis List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="Moderator_DnisDataSource"
				DataKeyNames="Dnisid, ModeratorId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Moderator_Dnis.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Dnisid" DataNavigateUrlFormatString="DnisEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DnisidSource" DataTextField="DnisNumber" />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Moderator_Dnis Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnModerator_Dnis" OnClientClick="javascript:location.href='Moderator_DnisEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:Moderator_DnisDataSource ID="Moderator_DnisDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Moderator_DnisProperty Name="Dnis"/> 
					<data:Moderator_DnisProperty Name="Moderator"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:Moderator_DnisDataSource>
	    		
</asp:Content>



