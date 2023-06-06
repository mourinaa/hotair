
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Recording.aspx.cs" Inherits="Recording" Title="Recording List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Recording List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="RecordingDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Recording.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]"  />
				<asp:BoundField DataField="BridgeId" HeaderText="Bridge Id" SortExpression="[BridgeID]"  />
				<asp:BoundField DataField="RecordingStartTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Recording Start Time" SortExpression="[RecordingStartTime]"  />
				<asp:BoundField DataField="RecordingEndTime" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Recording End Time" SortExpression="[RecordingEndTime]"  />
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]"  />
				<asp:BoundField DataField="PassCode" HeaderText="Pass Code" SortExpression="[PassCode]"  />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]"  />
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]"  />
				<asp:BoundField DataField="RecordingDirectory" HeaderText="Recording Directory" SortExpression="[RecordingDirectory]"  />
				<asp:BoundField DataField="UniqueConferenceId" HeaderText="Unique Conference Id" SortExpression="[UniqueConferenceID]"  />
				<asp:BoundField DataField="ReplayCode" HeaderText="Replay Code" SortExpression="[ReplayCode]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="ProcessFlag" HeaderText="Process Flag" SortExpression="[ProcessFlag]"  />
				<data:BoundRadioButtonField DataField="EmailSent" HeaderText="Email Sent" SortExpression="[EmailSent]"  />
				<asp:BoundField DataField="RpFileNumber" HeaderText="Rp File Number" SortExpression="[RPFileNumber]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]"  />
				<asp:BoundField DataField="Mp3Flag" HeaderText="Mp3 Flag" SortExpression="[Mp3Flag]"  />
				<asp:BoundField DataField="Mp3SizeInKb" HeaderText="Mp3 Size In Kb" SortExpression="[Mp3SizeInKB]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<asp:BoundField DataField="StorageDuration" HeaderText="Storage Duration" SortExpression="[StorageDuration]"  />
				<asp:BoundField DataField="BillingDuration" HeaderText="Billing Duration" SortExpression="[BillingDuration]"  />
				<asp:BoundField DataField="BillingId" HeaderText="Billing Id" SortExpression="[BillingID]"  />
				<asp:BoundField DataField="DurationSec" HeaderText="Duration Sec" SortExpression="[DurationSec]"  />
				<asp:BoundField DataField="AuxiliaryConferenceId" HeaderText="Auxiliary Conference Id" SortExpression="[AuxiliaryConferenceID]"  />
				<asp:BoundField DataField="MediaType" HeaderText="Media Type" SortExpression="[MediaType]"  />
				<asp:BoundField DataField="HostedLinkExpiryDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Hosted Link Expiry Date" SortExpression="[HostedLinkExpiryDate]"  />
				<asp:BoundField DataField="HostedLinkType" HeaderText="Hosted Link Type" SortExpression="[HostedLinkType]"  />
				<asp:BoundField DataField="HostedLinkUrl" HeaderText="Hosted Link Url" SortExpression="[HostedLinkURL]"  />
				<asp:BoundField DataField="ExtendRecordingDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Extend Recording Date" SortExpression="[ExtendRecordingDate]"  />
				<asp:BoundField DataField="RecordingGuid" HeaderText="Recording Guid" SortExpression="[RecordingGuid]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Recording Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRecording" OnClientClick="javascript:location.href='RecordingEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:RecordingDataSource ID="RecordingDataSource" runat="server"
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
		</data:RecordingDataSource>
	    		
</asp:Content>



