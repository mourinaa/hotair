<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AdminSiteNotesEdit.aspx.cs" Inherits="AdminSiteNotesEdit" Title="AdminSiteNotes Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Admin Site Notes - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="AdminSiteNotesDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminSiteNotesFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AdminSiteNotesFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AdminSiteNotes not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AdminSiteNotesDataSource ID="AdminSiteNotesDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:AdminSiteNotesDataSource>
		
		<br />

		<asp:Panel ID="AdminSiteNotesHistoryPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="AdminSiteNotesHistoryImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Admin Site Notes History Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="AdminSiteNotesHistoryLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="AdminSiteNotesHistoryPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewAdminSiteNotesHistory" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewAdminSiteNotesHistory_SelectedIndexChanged"			 			 
			DataSourceID="AdminSiteNotesHistoryDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_AdminSiteNotesHistory.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Admin Site Notes Id" DataNavigateUrlFormatString="AdminSiteNotesEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AdminSiteNotesIdSource" DataTextField="CustomerId" />
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]" />				
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Admin Site Notes History Found! </b>
				<asp:HyperLink runat="server" ID="hypAdminSiteNotesHistory" NavigateUrl="~/admin/AdminSiteNotesHistoryEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:AdminSiteNotesHistoryDataSource ID="AdminSiteNotesHistoryDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:AdminSiteNotesHistoryProperty Name="AdminSiteNotes"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:AdminSiteNotesHistoryFilter  Column="AdminSiteNotesId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:AdminSiteNotesHistoryDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeAdminSiteNotesHistory" runat="Server" TargetControlID="AdminSiteNotesHistoryPanel1"
            ExpandControlID="AdminSiteNotesHistoryPanel2" CollapseControlID="AdminSiteNotesHistoryPanel2" Collapsed="True"
            TextLabelID="AdminSiteNotesHistoryLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="AdminSiteNotesHistoryImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

