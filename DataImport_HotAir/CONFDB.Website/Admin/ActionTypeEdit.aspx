<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ActionTypeEdit.aspx.cs" Inherits="ActionTypeEdit" Title="ActionType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Action Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ActionTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ActionTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ActionTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ActionType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ActionTypeDataSource ID="ActionTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ActionTypeDataSource>
		
		<br />

		<asp:Panel ID="ActionPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ActionImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Action Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ActionLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ActionPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewAction" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewAction_SelectedIndexChanged"			 			 
			DataSourceID="ActionDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Action.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="DateTimeStamp" HeaderText="Date Time Stamp" SortExpression="[DateTimeStamp]" />				
				<data:HyperLinkField HeaderText="Action Type Id" DataNavigateUrlFormatString="ActionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ActionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ActionFrom" HeaderText="Action From" SortExpression="[ActionFrom]" />				
				<asp:BoundField DataField="ExtraInfo" HeaderText="Extra Info" SortExpression="[ExtraInfo]" />				
				<asp:BoundField DataField="ProcessedFlag" HeaderText="Processed Flag" SortExpression="[ProcessedFlag]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Action Found! </b>
				<asp:HyperLink runat="server" ID="hypAction" NavigateUrl="~/admin/ActionEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ActionDataSource ID="ActionDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ActionProperty Name="ActionType"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ActionFilter  Column="ActionTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ActionDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeAction" runat="Server" TargetControlID="ActionPanel1"
            ExpandControlID="ActionPanel2" CollapseControlID="ActionPanel2" Collapsed="True"
            TextLabelID="ActionLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ActionImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

