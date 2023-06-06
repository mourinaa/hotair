<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TicketProductEdit.aspx.cs" Inherits="TicketProductEdit" Title="TicketProduct Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Ticket Product - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="TicketProductDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TicketProductFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TicketProductFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>TicketProduct not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TicketProductDataSource ID="TicketProductDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:TicketProductDataSource>
		
		<br />

		<asp:Panel ID="TicketPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="TicketImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Ticket Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="TicketLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="TicketPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewTicket" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewTicket_SelectedIndexChanged"			 			 
			DataSourceID="TicketDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Ticket.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Title" HeaderText="Title" SortExpression="[Title]" />				
				<asp:BoundField DataField="IssueDescription" HeaderText="Issue Description" SortExpression="[IssueDescription]" />				
				<asp:BoundField DataField="ClientContactInfo" HeaderText="Client Contact Info" SortExpression="[ClientContactInfo]" />				
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<data:HyperLinkField HeaderText="Status Id" DataNavigateUrlFormatString="TicketStatusEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="StatusIdSource" DataTextField="Abbreviation" />
				<asp:BoundField DataField="ResolutionText" HeaderText="Resolution Text" SortExpression="[ResolutionText]" />				
				<data:HyperLinkField HeaderText="Ticket Priority Id" DataNavigateUrlFormatString="TicketPriorityEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketPriorityIdSource" DataTextField="Name" />
				<asp:BoundField DataField="CreatedByUserId" HeaderText="Created By User Id" SortExpression="[CreatedByUserID]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="AssignedToUserId" HeaderText="Assigned To User Id" SortExpression="[AssignedToUserID]" />				
				<asp:BoundField DataField="AssignedDate" HeaderText="Assigned Date" SortExpression="[AssignedDate]" />				
				<asp:BoundField DataField="FixedByUserId" HeaderText="Fixed By User Id" SortExpression="[FixedByUserID]" />				
				<asp:BoundField DataField="FixedDate" HeaderText="Fixed Date" SortExpression="[FixedDate]" />				
				<asp:BoundField DataField="ClosedByUserId" HeaderText="Closed By User Id" SortExpression="[ClosedByUserID]" />				
				<asp:BoundField DataField="ClosedDate" HeaderText="Closed Date" SortExpression="[ClosedDate]" />				
				<data:HyperLinkField HeaderText="Ticket Product Id" DataNavigateUrlFormatString="TicketProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Ticket Category Id" DataNavigateUrlFormatString="TicketCategoryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TicketCategoryIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DuplicateTicketId" HeaderText="Duplicate Ticket Id" SortExpression="[DuplicateTicketID]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Ticket Found! </b>
				<asp:HyperLink runat="server" ID="hypTicket" NavigateUrl="~/admin/TicketEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:TicketDataSource ID="TicketDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:TicketProperty Name="Customer"/> 
					<data:TicketProperty Name="Wholesaler"/> 
					<data:TicketProperty Name="TicketProduct"/> 
					<data:TicketProperty Name="TicketStatus"/> 
					<data:TicketProperty Name="TicketPriority"/> 
					<data:TicketProperty Name="TicketCategory"/> 
					<data:TicketProperty Name="Moderator"/> 
					<%--<data:TicketProperty Name="TicketStatusHistory" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:TicketFilter  Column="TicketProductId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:TicketDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeTicket" runat="Server" TargetControlID="TicketPanel1"
            ExpandControlID="TicketPanel2" CollapseControlID="TicketPanel2" Collapsed="True"
            TextLabelID="TicketLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="TicketImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

