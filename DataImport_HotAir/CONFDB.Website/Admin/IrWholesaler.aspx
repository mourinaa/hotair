
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="IrWholesaler.aspx.cs" Inherits="IrWholesaler" Title="IrWholesaler List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ir Wholesaler List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="IrWholesalerDataSource"
				DataKeyNames="WholesalerId, LanguageId"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_IrWholesaler.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Language Id" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
				<asp:BoundField DataField="IrCustomerId" HeaderText="Ir Customer Id" SortExpression="[IRCustomerID]"  />
				<asp:BoundField DataField="LocalDnis" HeaderText="Local Dnis" SortExpression="[LocalDNIS]"  />
				<asp:BoundField DataField="LocalDialNumber" HeaderText="Local Dial Number" SortExpression="[LocalDialNumber]"  />
				<asp:BoundField DataField="LocalAccessType" HeaderText="Local Access Type" SortExpression="[LocalAccessType]"  />
				<asp:BoundField DataField="TollFreeDnis" HeaderText="Toll Free Dnis" SortExpression="[TollFreeDNIS]"  />
				<asp:BoundField DataField="TollFreeDialNumber" HeaderText="Toll Free Dial Number" SortExpression="[TollFreeDialNumber]"  />
				<asp:BoundField DataField="TollFreeAccessType" HeaderText="Toll Free Access Type" SortExpression="[TollFreeAccessType]"  />
				<asp:BoundField DataField="InstantReplayUrl" HeaderText="Instant Replay Url" SortExpression="[InstantReplayURL]"  />
				<asp:BoundField DataField="StorageDuration" HeaderText="Storage Duration" SortExpression="[StorageDuration]"  />
				<asp:BoundField DataField="InstantReplayLoginUrl" HeaderText="Instant Replay Login Url" SortExpression="[InstantReplayLoginURL]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No IrWholesaler Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnIrWholesaler" OnClientClick="javascript:location.href='IrWholesalerEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:IrWholesalerDataSource ID="IrWholesalerDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:IrWholesalerProperty Name="Wholesaler"/> 
					<data:IrWholesalerProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:IrWholesalerDataSource>
	    		
</asp:Content>



