<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ParticipantListEdit.aspx.cs" Inherits="ParticipantListEdit" Title="ParticipantList Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Participant List - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ParticipantListDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ParticipantListFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ParticipantListFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ParticipantList not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ParticipantListDataSource ID="ParticipantListDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ParticipantListDataSource>
		
		<br />

		<asp:Panel ID="ParticipantPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ParticipantImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Participant Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ParticipantLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ParticipantPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewParticipant" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewParticipant_SelectedIndexChanged"			 			 
			DataSourceID="ParticipantDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Participant.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Participant List Id" DataNavigateUrlFormatString="ParticipantListEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ParticipantListIdSource" DataTextField="Name" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />				
				<asp:BoundField DataField="EmailAddress" HeaderText="Email Address" SortExpression="[EmailAddress]" />				
				<asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" SortExpression="[PhoneNumber]" />				
				<asp:BoundField DataField="Pin" HeaderText="Pin" SortExpression="[PIN]" />				
				<asp:BoundField DataField="UserName" HeaderText="User Name" SortExpression="[UserName]" />				
				<asp:BoundField DataField="Password" HeaderText="Password" SortExpression="[Password]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Participant Found! </b>
				<asp:HyperLink runat="server" ID="hypParticipant" NavigateUrl="~/admin/ParticipantEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ParticipantDataSource ID="ParticipantDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ParticipantProperty Name="ParticipantList"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ParticipantFilter  Column="ParticipantListId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ParticipantDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeParticipant" runat="Server" TargetControlID="ParticipantPanel1"
            ExpandControlID="ParticipantPanel2" CollapseControlID="ParticipantPanel2" Collapsed="True"
            TextLabelID="ParticipantLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ParticipantImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

