
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Trend.aspx.cs" Inherits="Trend" Title="Trend List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Trend List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TrendDataSource"
				DataKeyNames="WholesalerId, CustomerId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Trend.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="CompanyId" HeaderText="Company Id" SortExpression="[CompanyID]"  />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]" ReadOnly />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]" ReadOnly />
				<asp:BoundField DataField="SalesPersonId" HeaderText="Sales Person Id" SortExpression="[SalesPersonID]"  />
				<asp:BoundField DataField="RetailCurrency" HeaderText="Retail Currency" SortExpression="[RetailCurrency]"  />
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]"  />
				<asp:BoundField DataField="TotalRevenueMonth01" HeaderText="Total Revenue Month01" SortExpression="[TotalRevenueMonth01]"  />
				<asp:BoundField DataField="TotalRevenueMonth02" HeaderText="Total Revenue Month02" SortExpression="[TotalRevenueMonth02]"  />
				<asp:BoundField DataField="TotalRevenueMonth03" HeaderText="Total Revenue Month03" SortExpression="[TotalRevenueMonth03]"  />
				<asp:BoundField DataField="TotalRevenueMonth04" HeaderText="Total Revenue Month04" SortExpression="[TotalRevenueMonth04]"  />
				<asp:BoundField DataField="TotalRevenueMonth05" HeaderText="Total Revenue Month05" SortExpression="[TotalRevenueMonth05]"  />
				<asp:BoundField DataField="TotalRevenueMonth06" HeaderText="Total Revenue Month06" SortExpression="[TotalRevenueMonth06]"  />
				<asp:BoundField DataField="TotalRevenueMonth07" HeaderText="Total Revenue Month07" SortExpression="[TotalRevenueMonth07]"  />
				<asp:BoundField DataField="TotalRevenueMonth08" HeaderText="Total Revenue Month08" SortExpression="[TotalRevenueMonth08]"  />
				<asp:BoundField DataField="TotalRevenueMonth09" HeaderText="Total Revenue Month09" SortExpression="[TotalRevenueMonth09]"  />
				<asp:BoundField DataField="TotalRevenueMonth10" HeaderText="Total Revenue Month10" SortExpression="[TotalRevenueMonth10]"  />
				<asp:BoundField DataField="TotalRevenueMonth11" HeaderText="Total Revenue Month11" SortExpression="[TotalRevenueMonth11]"  />
				<asp:BoundField DataField="TotalRevenueMonth12" HeaderText="Total Revenue Month12" SortExpression="[TotalRevenueMonth12]"  />
				<asp:BoundField DataField="YearCategory" HeaderText="Year Category" SortExpression="[YearCategory]"  />
				<asp:BoundField DataField="StartDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Start Date" SortExpression="[StartDate]"  />
				<asp:BoundField DataField="EndDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="End Date" SortExpression="[EndDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Trend Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTrend" OnClientClick="javascript:location.href='TrendEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:TrendDataSource ID="TrendDataSource" runat="server"
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
		</data:TrendDataSource>
	    		
</asp:Content>



