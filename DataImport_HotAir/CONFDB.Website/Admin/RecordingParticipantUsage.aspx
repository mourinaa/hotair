
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="RecordingParticipantUsage.aspx.cs" Inherits="RecordingParticipantUsage" Title="RecordingParticipantUsage List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Recording Participant Usage List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="RecordingParticipantUsageDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_RecordingParticipantUsage.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<data:HyperLinkField HeaderText="Recording Id" DataNavigateUrlFormatString="RecordingEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RecordingIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" SortExpression="[ParticipantName]"  />
				<asp:BoundField DataField="ParticipantCompanyName" HeaderText="Participant Company Name" SortExpression="[ParticipantCompanyName]"  />
				<asp:BoundField DataField="ParticipantEmail" HeaderText="Participant Email" SortExpression="[ParticipantEmail]"  />
				<asp:BoundField DataField="DownloadDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Download Date" SortExpression="[DownloadDate]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No RecordingParticipantUsage Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnRecordingParticipantUsage" OnClientClick="javascript:location.href='RecordingParticipantUsageEdit.aspx'; return false;" Text="Add New"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:RecordingParticipantUsageDataSource ID="RecordingParticipantUsageDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:RecordingParticipantUsageProperty Name="Recording"/> 
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:RecordingParticipantUsageDataSource>
	    		
</asp:Content>



