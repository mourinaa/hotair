
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AverageRates.aspx.cs" Inherits="AverageRates" Title="AverageRates List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Average Rates List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="AverageRatesDataSource"
				DataKeyNames="UsageMonth, ProductRateId, WholesalerId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_AverageRates.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="UsageMonth" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Usage Month" SortExpression="[UsageMonth]" ReadOnly />
				<asp:BoundField DataField="ProductRateId" HeaderText="Product Rate Id" SortExpression="[ProductRateID]" ReadOnly />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]" ReadOnly />
				<asp:BoundField DataField="MedianRetailRate" HeaderText="Median Retail Rate" SortExpression="[MedianRetailRate]"  />
				<asp:BoundField DataField="AverageRetailRate" HeaderText="Average Retail Rate" SortExpression="[AverageRetailRate]"  />
				<asp:BoundField DataField="WeightedAverageRetailRate" HeaderText="Weighted Average Retail Rate" SortExpression="[WeightedAverageRetailRate]"  />
				<asp:BoundField DataField="MedianWsRate" HeaderText="Median Ws Rate" SortExpression="[MedianWSRate]"  />
				<asp:BoundField DataField="AverageWsRate" HeaderText="Average Ws Rate" SortExpression="[AverageWSRate]"  />
				<asp:BoundField DataField="WeightedAverageWsRate" HeaderText="Weighted Average Ws Rate" SortExpression="[WeightedAverageWSRate]"  />
				<asp:BoundField DataField="UsageSeconds" HeaderText="Usage Seconds" SortExpression="[UsageSeconds]"  />
				<asp:BoundField DataField="UsageQuantity" HeaderText="Usage Quantity" SortExpression="[UsageQuantity]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No AverageRates Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAverageRates" OnClientClick="javascript:location.href='AverageRatesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:AverageRatesDataSource ID="AverageRatesDataSource" runat="server"
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
		</data:AverageRatesDataSource>
	    		
</asp:Content>



