<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="BridgeRequestTypeEdit.aspx.cs" Inherits="BridgeRequestTypeEdit" Title="BridgeRequestType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Bridge Request Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="BridgeRequestTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeRequestTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/BridgeRequestTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>BridgeRequestType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:BridgeRequestTypeDataSource ID="BridgeRequestTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:BridgeRequestTypeDataSource>
		
		<br />

		<asp:Panel ID="BridgeRequestPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="BridgeRequestImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Bridge Request Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="BridgeRequestLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="BridgeRequestPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewBridgeRequest" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewBridgeRequest_SelectedIndexChanged"			 			 
			DataSourceID="BridgeRequestDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_BridgeRequest.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Moderator Id" DataNavigateUrlFormatString="ModeratorEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ModeratorIdSource" DataTextField="WholesalerId" />
				<asp:BoundField DataField="TransTimeStamp" HeaderText="Trans Time Stamp" SortExpression="[TransTimeStamp]" />				
				<asp:BoundField DataField="ProcessFlag" HeaderText="Process Flag" SortExpression="[ProcessFlag]" />				
				<data:HyperLinkField HeaderText="Bridge Request Type Id" DataNavigateUrlFormatString="BridgeRequestTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BridgeRequestTypeIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Bridge Request Found! </b>
				<asp:HyperLink runat="server" ID="hypBridgeRequest" NavigateUrl="~/admin/BridgeRequestEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:BridgeRequestDataSource ID="BridgeRequestDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:BridgeRequestProperty Name="Moderator"/> 
					<data:BridgeRequestProperty Name="BridgeRequestType"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:BridgeRequestFilter  Column="BridgeRequestTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:BridgeRequestDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeBridgeRequest" runat="Server" TargetControlID="BridgeRequestPanel1"
            ExpandControlID="BridgeRequestPanel2" CollapseControlID="BridgeRequestPanel2" Collapsed="True"
            TextLabelID="BridgeRequestLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="BridgeRequestImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

