﻿
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TicketUserAssociations.aspx.cs" Inherits="TicketUserAssociations" Title="TicketUserAssociations List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ticket User Associations List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TicketUserAssociationsDataSource"
				DataKeyNames="UserId, TicketUserId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TicketUserAssociations.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="UserId" HeaderText="User Id" SortExpression="[UserID]" ReadOnly />
				<asp:BoundField DataField="TicketUserId" HeaderText="Ticket User Id" SortExpression="[TicketUserID]" ReadOnly />
			</Columns>
			<EmptyDataTemplate>
				<b>No TicketUserAssociations Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTicketUserAssociations" OnClientClick="javascript:location.href='TicketUserAssociationsEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:TicketUserAssociationsDataSource ID="TicketUserAssociationsDataSource" runat="server"
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
		</data:TicketUserAssociationsDataSource>
	    		
</asp:Content>



