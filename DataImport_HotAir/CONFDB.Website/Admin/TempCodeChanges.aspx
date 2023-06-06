
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TempCodeChanges.aspx.cs" Inherits="TempCodeChanges" Title="TempCodeChanges List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Temp Code Changes List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="TempCodeChangesDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_TempCodeChanges.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<asp:BoundField DataField="OrigModCode" HeaderText="Orig Mod Code" SortExpression="[OrigModCode]"  />
				<asp:BoundField DataField="OrigPassCode" HeaderText="Orig Pass Code" SortExpression="[OrigPassCode]"  />
				<asp:BoundField DataField="ExpectedOrigModCode" HeaderText="Expected Orig Mod Code" SortExpression="[ExpectedOrigModCode]"  />
				<asp:BoundField DataField="ExpectedOrigPassCode" HeaderText="Expected Orig Pass Code" SortExpression="[ExpectedOrigPassCode]"  />
				<asp:BoundField DataField="NewModCode" HeaderText="New Mod Code" SortExpression="[NewModCode]"  />
				<asp:BoundField DataField="NewPassCode" HeaderText="New Pass Code" SortExpression="[NewPassCode]"  />
				<asp:BoundField DataField="AppliedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Applied Date" SortExpression="[AppliedDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No TempCodeChanges Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnTempCodeChanges" OnClientClick="javascript:location.href='TempCodeChangesEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:TempCodeChangesDataSource ID="TempCodeChangesDataSource" runat="server"
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
		</data:TempCodeChangesDataSource>
	    		
</asp:Content>



