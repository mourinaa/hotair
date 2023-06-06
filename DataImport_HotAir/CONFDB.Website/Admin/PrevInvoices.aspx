
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="PrevInvoices.aspx.cs" Inherits="PrevInvoices" Title="PrevInvoices List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Prev Invoices List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="PrevInvoicesDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_PrevInvoices.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]"  />
				<asp:BoundField DataField="PrevBal" HeaderText="Prev Bal" SortExpression="[PrevBal]"  />
				<asp:BoundField DataField="PrevPerStart" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Prev Per Start" SortExpression="[PrevPerStart]"  />
				<asp:BoundField DataField="PrevPerEnd" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Prev Per End" SortExpression="[PrevPerEnd]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No PrevInvoices Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnPrevInvoices" OnClientClick="javascript:location.href='PrevInvoicesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:PrevInvoicesDataSource ID="PrevInvoicesDataSource" runat="server"
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
		</data:PrevInvoicesDataSource>
	    		
</asp:Content>



