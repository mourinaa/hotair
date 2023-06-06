<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="ExtensionTypeCategoryEdit.aspx.cs" Inherits="ExtensionTypeCategoryEdit" Title="ExtensionTypeCategory Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Extension Type Category - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="ExtensionTypeCategoryDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ExtensionTypeCategoryFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/ExtensionTypeCategoryFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>ExtensionTypeCategory not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:ExtensionTypeCategoryDataSource ID="ExtensionTypeCategoryDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:ExtensionTypeCategoryDataSource>
		
		<br />

		<asp:Panel ID="ExtensionTypePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ExtensionTypeImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Extension Type Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ExtensionTypeLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ExtensionTypePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewExtensionType" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewExtensionType_SelectedIndexChanged"			 			 
			DataSourceID="ExtensionTypeDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ExtensionType.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<data:HyperLinkField HeaderText="Extension Type Category Id" DataNavigateUrlFormatString="ExtensionTypeCategoryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ExtensionTypeCategoryIdSource" DataTextField="CategoryName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Extension Type Found! </b>
				<asp:HyperLink runat="server" ID="hypExtensionType" NavigateUrl="~/admin/ExtensionTypeEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ExtensionTypeDataSource ID="ExtensionTypeDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ExtensionTypeProperty Name="ExtensionTypeCategory"/> 
					<%--<data:ExtensionTypeProperty Name="SystemExtensionLabelCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ExtensionTypeFilter  Column="ExtensionTypeCategoryId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ExtensionTypeDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeExtensionType" runat="Server" TargetControlID="ExtensionTypePanel1"
            ExpandControlID="ExtensionTypePanel2" CollapseControlID="ExtensionTypePanel2" Collapsed="True"
            TextLabelID="ExtensionTypeLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ExtensionTypeImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

