
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Action.aspx.cs" Inherits="Action" Title="Action List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Action List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="ActionDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Action.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="DateTimeStamp" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Date Time Stamp" SortExpression="[DateTimeStamp]"  />
				<data:HyperLinkField HeaderText="Action Type Id" DataNavigateUrlFormatString="ActionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ActionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ActionFrom" HeaderText="Action From" SortExpression="[ActionFrom]"  />
				<asp:BoundField DataField="ExtraInfo" HeaderText="Extra Info" SortExpression="[ExtraInfo]"  />
				<asp:BoundField DataField="ProcessedFlag" HeaderText="Processed Flag" SortExpression="[ProcessedFlag]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Action Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnAction" OnClientClick="javascript:location.href='ActionEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:ActionDataSource ID="ActionDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ActionProperty Name="ActionType"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:ActionDataSource>
	    		
</asp:Content>



