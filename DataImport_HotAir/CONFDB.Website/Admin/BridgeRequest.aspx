
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BridgeRequest.aspx.cs" Inherits="BridgeRequest" Title="BridgeRequest List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bridge Request List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="BridgeRequestDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_BridgeRequest.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="TransTimeStamp" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Trans Time Stamp" SortExpression="[TransTimeStamp]"  />
				<asp:BoundField DataField="ProcessFlag" HeaderText="Process Flag" SortExpression="[ProcessFlag]"  />
				<data:HyperLinkField HeaderText="Bridge Request Type Id" DataNavigateUrlFormatString="BridgeRequestTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeRequestTypeIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No BridgeRequest Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnBridgeRequest" OnClientClick="javascript:location.href='BridgeRequestEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:BridgeRequestDataSource ID="BridgeRequestDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BridgeRequestProperty Name="Moderator"/> 
					<data:BridgeRequestProperty Name="BridgeRequestType"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:BridgeRequestDataSource>
	    		
</asp:Content>



