
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TempExistingCodes.aspx.cs" Inherits="TempExistingCodes" Title="TempExistingCodes List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Temp Existing Codes List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TempExistingCodesDataSource"
				DataKeyNames="Codes"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TempExistingCodes.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Codes" HeaderText="Codes" SortExpression="[Codes]" ReadOnly />
				<data:BoundRadioButtonField DataField="NewCode" HeaderText="New Code" SortExpression="[NewCode]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<asp:BoundField DataField="Location" HeaderText="Location" SortExpression="[Location]"  />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TempExistingCodes Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTempExistingCodes" OnClientClick="javascript:location.href='TempExistingCodesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:TempExistingCodesDataSource ID="TempExistingCodesDataSource" runat="server"
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
		</data:TempExistingCodesDataSource>
	    		
</asp:Content>



