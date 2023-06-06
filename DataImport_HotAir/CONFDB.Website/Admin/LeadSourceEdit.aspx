<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LeadSourceEdit.aspx.cs" Inherits="LeadSourceEdit" Title="LeadSource Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Lead Source - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="LeadSourceDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LeadSourceFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LeadSourceFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>LeadSource not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LeadSourceDataSource ID="LeadSourceDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:LeadSourceDataSource>
		
		<br />

		<asp:Panel ID="CompanyLeadTrackingPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CompanyLeadTrackingImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Company Lead Tracking Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CompanyLeadTrackingLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CompanyLeadTrackingPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCompanyLeadTracking" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCompanyLeadTracking_SelectedIndexChanged"			 			 
			DataSourceID="CompanyLeadTrackingDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CompanyLeadTracking.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Company Info Id" DataNavigateUrlFormatString="CompanyInfoEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyInfoIdSource" DataTextField="LeadId" />
				<asp:BoundField DataField="ProjectedRevenue" HeaderText="Projected Revenue" SortExpression="[ProjectedRevenue]" />				
				<data:HyperLinkField HeaderText="Lead Product Id" DataNavigateUrlFormatString="LeadProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Source Id" DataNavigateUrlFormatString="LeadSourceEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadSourceIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Stage Id" DataNavigateUrlFormatString="LeadStageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadStageIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ExpectedCloseDate" HeaderText="Expected Close Date" SortExpression="[ExpectedCloseDate]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
				<data:HyperLinkField HeaderText="Lead Period Id" DataNavigateUrlFormatString="LeadPeriodEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadPeriodIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Lead Churn Reason Id" DataNavigateUrlFormatString="LeadChurnReasonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LeadChurnReasonIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Company Lead Tracking Found! </b>
				<asp:HyperLink runat="server" ID="hypCompanyLeadTracking" NavigateUrl="~/admin/CompanyLeadTrackingEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CompanyLeadTrackingDataSource ID="CompanyLeadTrackingDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CompanyLeadTrackingProperty Name="LeadPeriod"/> 
					<data:CompanyLeadTrackingProperty Name="CompanyInfo"/> 
					<data:CompanyLeadTrackingProperty Name="LeadSource"/> 
					<data:CompanyLeadTrackingProperty Name="LeadChurnReason"/> 
					<data:CompanyLeadTrackingProperty Name="LeadProduct"/> 
					<data:CompanyLeadTrackingProperty Name="LeadStage"/> 
					<%--<data:CompanyLeadTrackingProperty Name="CompanyLeadTrackingNotesCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CompanyLeadTrackingFilter  Column="LeadSourceId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CompanyLeadTrackingDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCompanyLeadTracking" runat="Server" TargetControlID="CompanyLeadTrackingPanel1"
            ExpandControlID="CompanyLeadTrackingPanel2" CollapseControlID="CompanyLeadTrackingPanel2" Collapsed="True"
            TextLabelID="CompanyLeadTrackingLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CompanyLeadTrackingImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

