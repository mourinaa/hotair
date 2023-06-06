<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="RecordingEdit.aspx.cs" Inherits="RecordingEdit" Title="Recording Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Recording - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="RecordingDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RecordingFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/RecordingFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Recording not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:RecordingDataSource ID="RecordingDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:RecordingDataSource>
		
		<br />

		<asp:Panel ID="RecordingParticipantUsagePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="RecordingParticipantUsageImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Recording Participant Usage Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="RecordingParticipantUsageLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="RecordingParticipantUsagePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewRecordingParticipantUsage" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewRecordingParticipantUsage_SelectedIndexChanged"			 			 
			DataSourceID="RecordingParticipantUsageDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_RecordingParticipantUsage.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Recording Id" DataNavigateUrlFormatString="RecordingEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RecordingIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="ParticipantName" HeaderText="Participant Name" SortExpression="[ParticipantName]" />				
				<asp:BoundField DataField="ParticipantCompanyName" HeaderText="Participant Company Name" SortExpression="[ParticipantCompanyName]" />				
				<asp:BoundField DataField="ParticipantEmail" HeaderText="Participant Email" SortExpression="[ParticipantEmail]" />				
				<asp:BoundField DataField="DownloadDate" HeaderText="Download Date" SortExpression="[DownloadDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Recording Participant Usage Found! </b>
				<asp:HyperLink runat="server" ID="hypRecordingParticipantUsage" NavigateUrl="~/admin/RecordingParticipantUsageEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:RecordingParticipantUsageDataSource ID="RecordingParticipantUsageDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:RecordingParticipantUsageProperty Name="Recording"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:RecordingParticipantUsageFilter  Column="RecordingId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:RecordingParticipantUsageDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeRecordingParticipantUsage" runat="Server" TargetControlID="RecordingParticipantUsagePanel1"
            ExpandControlID="RecordingParticipantUsagePanel2" CollapseControlID="RecordingParticipantUsagePanel2" Collapsed="True"
            TextLabelID="RecordingParticipantUsageLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="RecordingParticipantUsageImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

