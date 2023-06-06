
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ValidTicketStateChanges.aspx.cs" Inherits="ValidTicketStateChanges" Title="ValidTicketStateChanges List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Valid Ticket State Changes List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ValidTicketStateChangesDataSource"
				DataKeyNames="FromStatusId, ToStatusId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ValidTicketStateChanges.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="From Status Id" DataNavigateUrlFormatString="TicketStatusEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="FromStatusIdSource" DataTextField="Abbreviation" />
				<data:HyperLinkField HeaderText="To Status Id" DataNavigateUrlFormatString="TicketStatusEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ToStatusIdSource" DataTextField="Abbreviation" />
				<asp:BoundField DataField="Reason" HeaderText="Reason" SortExpression="[Reason]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ValidTicketStateChanges Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnValidTicketStateChanges" OnClientClick="javascript:location.href='ValidTicketStateChangesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ValidTicketStateChangesDataSource ID="ValidTicketStateChangesDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ValidTicketStateChangesProperty Name="TicketStatus"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ValidTicketStateChangesDataSource>
	    		
</asp:Content>



