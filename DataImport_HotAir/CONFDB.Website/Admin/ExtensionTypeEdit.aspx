<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ExtensionTypeEdit.aspx.cs" Inherits="ExtensionTypeEdit" Title="ExtensionType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Extension Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ExtensionTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ExtensionTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ExtensionTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ExtensionType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ExtensionTypeDataSource ID="ExtensionTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ExtensionTypeDataSource>
		
		<br />

		<asp:Panel ID="SystemExtensionLabelPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="SystemExtensionLabelImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">System Extension Label Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="SystemExtensionLabelLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="SystemExtensionLabelPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewSystemExtensionLabel" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewSystemExtensionLabel_SelectedIndexChanged"			 			 
			DataSourceID="SystemExtensionLabelDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SystemExtensionLabel.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CustomerId" HeaderText="Customer Id" SortExpression="[CustomerID]" />				
				<data:HyperLinkField HeaderText="Extension Type Id" DataNavigateUrlFormatString="ExtensionTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ExtensionTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ExtensionTypeLabel" HeaderText="Extension Type Label" SortExpression="[ExtensionTypeLabel]" />				
				<asp:BoundField DataField="CustomerCanView" HeaderText="Customer Can View" SortExpression="[CustomerCanView]" />				
				<asp:BoundField DataField="ModeratorCanView" HeaderText="Moderator Can View" SortExpression="[ModeratorCanView]" />				
				<asp:BoundField DataField="CustomerCanEdit" HeaderText="Customer Can Edit" SortExpression="[CustomerCanEdit]" />				
				<asp:BoundField DataField="ModeratorCanEdit" HeaderText="Moderator Can Edit" SortExpression="[ModeratorCanEdit]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No System Extension Label Found! </b>
				<asp:HyperLink runat="server" ID="hypSystemExtensionLabel" NavigateUrl="~/admin/SystemExtensionLabelEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SystemExtensionLabelDataSource ID="SystemExtensionLabelDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SystemExtensionLabelProperty Name="ExtensionType"/> 
					<%--<data:SystemExtensionLabelProperty Name="SystemExtensionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SystemExtensionLabelFilter  Column="ExtensionTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SystemExtensionLabelDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeSystemExtensionLabel" runat="Server" TargetControlID="SystemExtensionLabelPanel1"
            ExpandControlID="SystemExtensionLabelPanel2" CollapseControlID="SystemExtensionLabelPanel2" Collapsed="True"
            TextLabelID="SystemExtensionLabelLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="SystemExtensionLabelImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

