<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CompanyLeadTrackingEdit.aspx.cs" Inherits="CompanyLeadTrackingEdit" Title="CompanyLeadTracking Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Company Lead Tracking - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CompanyLeadTrackingDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CompanyLeadTrackingFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CompanyLeadTrackingFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CompanyLeadTracking not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CompanyLeadTrackingDataSource ID="CompanyLeadTrackingDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:CompanyLeadTrackingDataSource>
		
		<br />

		<asp:Panel ID="CompanyLeadTrackingNotesPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CompanyLeadTrackingNotesImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Company Lead Tracking Notes Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CompanyLeadTrackingNotesLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CompanyLeadTrackingNotesPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCompanyLeadTrackingNotes" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCompanyLeadTrackingNotes_SelectedIndexChanged"			 			 
			DataSourceID="CompanyLeadTrackingNotesDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CompanyLeadTrackingNotes.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Company Lead Tracking Id" DataNavigateUrlFormatString="CompanyLeadTrackingEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyLeadTrackingIdSource" DataTextField="ProjectedRevenue" />
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]" />				
				<asp:BoundField DataField="OldValues" HeaderText="Old Values" SortExpression="[OldValues]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Company Lead Tracking Notes Found! </b>
				<asp:HyperLink runat="server" ID="hypCompanyLeadTrackingNotes" NavigateUrl="~/admin/CompanyLeadTrackingNotesEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CompanyLeadTrackingNotesDataSource ID="CompanyLeadTrackingNotesDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyLeadTrackingNotesProperty Name="CompanyLeadTracking"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CompanyLeadTrackingNotesFilter  Column="CompanyLeadTrackingId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CompanyLeadTrackingNotesDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCompanyLeadTrackingNotes" runat="Server" TargetControlID="CompanyLeadTrackingNotesPanel1"
            ExpandControlID="CompanyLeadTrackingNotesPanel2" CollapseControlID="CompanyLeadTrackingNotesPanel2" Collapsed="True"
            TextLabelID="CompanyLeadTrackingNotesLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CompanyLeadTrackingNotesImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

