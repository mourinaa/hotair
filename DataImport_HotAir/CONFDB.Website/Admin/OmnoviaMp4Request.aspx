
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="OmnoviaMp4Request.aspx.cs" Inherits="OmnoviaMp4Request" Title="OmnoviaMp4Request List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Omnovia Mp4 Request List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="OmnoviaMp4RequestDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_OmnoviaMp4Request.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="HostedId" HeaderText="Hosted Id" SortExpression="[HostedID]"  />
				<asp:BoundField DataField="RequestedBy" HeaderText="Requested By" SortExpression="[RequestedBy]"  />
				<asp:BoundField DataField="EstimatedTime" HeaderText="Estimated Time" SortExpression="[EstimatedTime]"  />
				<asp:BoundField DataField="ExtraInfo" HeaderText="Extra Info" SortExpression="[ExtraInfo]"  />
				<asp:BoundField DataField="OmnoviaHostedUrl" HeaderText="Omnovia Hosted Url" SortExpression="[OmnoviaHostedURL]"  />
				<asp:BoundField DataField="RedbackHostedUrl" HeaderText="Redback Hosted Url" SortExpression="[RedbackHostedURL]"  />
				<asp:BoundField DataField="OmnoviaHostedUrlExpiryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Omnovia Hosted Url Expiry Date" SortExpression="[OmnoviaHostedURLExpiryDate]"  />
				<asp:BoundField DataField="Created" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created" SortExpression="[created]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No OmnoviaMp4Request Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnOmnoviaMp4Request" OnClientClick="javascript:location.href='OmnoviaMp4RequestEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:OmnoviaMp4RequestDataSource ID="OmnoviaMp4RequestDataSource" runat="server"
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
		</data:OmnoviaMp4RequestDataSource>
	    		
</asp:Content>



