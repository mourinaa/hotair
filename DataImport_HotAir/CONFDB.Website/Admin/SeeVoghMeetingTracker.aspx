
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SeeVoghMeetingTracker.aspx.cs" Inherits="SeeVoghMeetingTracker" Title="SeeVoghMeetingTracker List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">See Vogh Meeting Tracker List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="SeeVoghMeetingTrackerDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_SeeVoghMeetingTracker.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="MeetingId" HeaderText="Meeting Id" SortExpression="[MeetingID]"  />
				<asp:BoundField DataField="Status" HeaderText="Status" SortExpression="[Status]"  />
				<asp:BoundField DataField="ModeratorId" HeaderText="Moderator Id" SortExpression="[ModeratorID]"  />
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]"  />
				<data:BoundRadioButtonField DataField="ModeratorJoined" HeaderText="Moderator Joined" SortExpression="[ModeratorJoined]"  />
				<asp:BoundField DataField="MeetingUrl" HeaderText="Meeting Url" SortExpression="[MeetingURL]"  />
				<asp:BoundField DataField="MobileMeetingUrl" HeaderText="Mobile Meeting Url" SortExpression="[MobileMeetingURL]"  />
				<asp:BoundField DataField="CreatedDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date" SortExpression="[CreatedDate]"  />
				<asp:BoundField DataField="LastModified" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Last Modified" SortExpression="[LastModified]"  />

				<asp:templatefield headertext='Notes Preview'>
				<itemtemplate>
					<ajaxToolkit:ModalPopupExtender id='ModalPopupExtender1' runat='server'
						TargetControlID='LinkButton1' 
						PopupControlID='Panel1' 
						OkControlID='Button1'
						BackgroundCssClass='ModalBackground' 
						DynamicControlID='lblPreview'
						DynamicContextKey='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
						DynamicServiceMethod='GetNotesContent' />
					<asp:LinkButton ID='LinkButton1' runat='server' Text='Preview' />
				</itemtemplate>
				</asp:templatefield>
	
				<asp:BoundField DataField="CreatedDateUtc" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Created Date Utc" SortExpression="[CreatedDateUTC]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No SeeVoghMeetingTracker Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnSeeVoghMeetingTracker" OnClientClick="javascript:location.href='SeeVoghMeetingTrackerEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
	<asp:Panel ID="Panel1" runat="server" CssClass="popup" >
	    <h2>Content Preview <asp:Button ID="Button1" runat="server"  Text="Close Preview"/></h2><hr /> 
	    <asp:Label ID='lblPreview' runat="server" ></asp:Label>
	</asp:Panel>
		<data:SeeVoghMeetingTrackerDataSource ID="SeeVoghMeetingTrackerDataSource" runat="server"
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
		</data:SeeVoghMeetingTrackerDataSource>
	    		
</asp:Content>



