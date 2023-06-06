
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="WelcomeKitRequest.aspx.cs" Inherits="WelcomeKitRequest" Title="WelcomeKitRequest List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Welcome Kit Request List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="WelcomeKitRequestDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_WelcomeKitRequest.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]"  />
				<asp:BoundField DataField="RequestedBy" HeaderText="Requested By" SortExpression="[RequestedBy]"  />
				<asp:BoundField DataField="LastModifiedBy" HeaderText="Last Modified By" SortExpression="[LastModifiedBy]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<data:BoundRadioButtonField DataField="RequestProcessed" HeaderText="Request Processed" SortExpression="[RequestProcessed]"  />
				<asp:BoundField DataField="RequestCompletedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Request Completed Date" SortExpression="[RequestCompletedDate]"  />
				<asp:BoundField DataField="RequestCompletedBy" HeaderText="Request Completed By" SortExpression="[RequestCompletedBy]"  />
				<asp:BoundField DataField="BilledDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Billed Date" SortExpression="[BilledDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No WelcomeKitRequest Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWelcomeKitRequest" OnClientClick="javascript:location.href='WelcomeKitRequestEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:WelcomeKitRequestDataSource ID="WelcomeKitRequestDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WelcomeKitRequestProperty Name="Moderator"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:WelcomeKitRequestDataSource>
	    		
</asp:Content>



