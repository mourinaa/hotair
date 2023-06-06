
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ConferencingSummary.aspx.cs" Inherits="ConferencingSummary" Title="ConferencingSummary List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Conferencing Summary List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ConferencingSummaryDataSource"
				DataKeyNames="BilledDate, ProductId, Currency"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_ConferencingSummary.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="BilledDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Billed Date" SortExpression="[BilledDate]" ReadOnly />
				<asp:BoundField DataField="ProductId" HeaderText="Product Id" SortExpression="[ProductID]" ReadOnly />
				<asp:BoundField DataField="Currency" HeaderText="Currency" SortExpression="[Currency]" ReadOnly />
				<asp:BoundField DataField="LocalSeconds" HeaderText="Local Seconds" SortExpression="[LocalSeconds]"  />
				<asp:BoundField DataField="LdSeconds" HeaderText="Ld Seconds" SortExpression="[LDSeconds]"  />
				<asp:BoundField DataField="TotalBridge" HeaderText="Total Bridge" SortExpression="[TotalBridge]"  />
				<asp:BoundField DataField="TotalLd" HeaderText="Total Ld" SortExpression="[TotalLD]"  />
				<asp:BoundField DataField="TotalMiscellaneous" HeaderText="Total Miscellaneous" SortExpression="[TotalMiscellaneous]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No ConferencingSummary Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnConferencingSummary" OnClientClick="javascript:location.href='ConferencingSummaryEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ConferencingSummaryDataSource ID="ConferencingSummaryDataSource" runat="server"
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
		</data:ConferencingSummaryDataSource>
	    		
</asp:Content>



