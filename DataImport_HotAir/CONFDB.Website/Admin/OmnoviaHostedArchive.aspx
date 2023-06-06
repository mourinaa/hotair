
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="OmnoviaHostedArchive.aspx.cs" Inherits="OmnoviaHostedArchive" Title="OmnoviaHostedArchive List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Omnovia Hosted Archive List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="OmnoviaHostedArchiveDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_OmnoviaHostedArchive.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="OmnoviaCustomerId" HeaderText="Omnovia Customer Id" SortExpression="[OmnoviaCustomerID]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="MovieId" HeaderText="Movie Id" SortExpression="[MovieID]"  />
				<asp:BoundField DataField="RoomName" HeaderText="Room Name" SortExpression="[RoomName]"  />
				<asp:BoundField DataField="MovieTitle" HeaderText="Movie Title" SortExpression="[MovieTitle]"  />
				<asp:BoundField DataField="MovieDateAdded" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Movie Date Added" SortExpression="[MovieDateAdded]"  />
				<asp:BoundField DataField="MovieLength" HeaderText="Movie Length" SortExpression="[MovieLength]"  />
				<asp:BoundField DataField="MovieRoomId" HeaderText="Movie Room Id" SortExpression="[MovieRoomID]"  />
				<asp:BoundField DataField="MovieDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Movie Date" SortExpression="[MovieDate]"  />
				<asp:BoundField DataField="CompanyShortLink" HeaderText="Company Short Link" SortExpression="[CompanyShortLink]"  />
				<asp:BoundField DataField="Created" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created" SortExpression="[created]"  />
				<asp:BoundField DataField="HostedLinkExpiryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Hosted Link Expiry Date" SortExpression="[HostedLinkExpiryDate]"  />
				<asp:BoundField DataField="HostedLinkShortened" HeaderText="Hosted Link Shortened" SortExpression="[HostedLinkShortened]"  />
				<asp:BoundField DataField="HostedLinkAlias" HeaderText="Hosted Link Alias" SortExpression="[HostedLinkAlias]"  />
				<asp:BoundField DataField="RecordingDirectory" HeaderText="Recording Directory" SortExpression="[RecordingDirectory]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="HostingPeriod" HeaderText="Hosting Period" SortExpression="[HostingPeriod]"  />
				<asp:BoundField DataField="HostingAutoRenew" HeaderText="Hosting Auto Renew" SortExpression="[HostingAutoRenew]"  />
				<asp:BoundField DataField="Event_Id" HeaderText="Event Id" SortExpression="[Event_ID]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No OmnoviaHostedArchive Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnOmnoviaHostedArchive" OnClientClick="javascript:location.href='OmnoviaHostedArchiveEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:OmnoviaHostedArchiveDataSource ID="OmnoviaHostedArchiveDataSource" runat="server"
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
		</data:OmnoviaHostedArchiveDataSource>
	    		
</asp:Content>



