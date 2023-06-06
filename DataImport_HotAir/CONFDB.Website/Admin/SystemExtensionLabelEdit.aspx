<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="SystemExtensionLabelEdit.aspx.cs" Inherits="SystemExtensionLabelEdit" Title="SystemExtensionLabel Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">System Extension Label - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="SystemExtensionLabelDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SystemExtensionLabelFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/SystemExtensionLabelFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>SystemExtensionLabel not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:SystemExtensionLabelDataSource ID="SystemExtensionLabelDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:SystemExtensionLabelDataSource>
		
		<br />

		<asp:Panel ID="SystemExtensionPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="SystemExtensionImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">System Extension Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="SystemExtensionLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="SystemExtensionPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewSystemExtension" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewSystemExtension_SelectedIndexChanged"			 			 
			DataSourceID="SystemExtensionDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_SystemExtension.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="TableId" HeaderText="Table Id" SortExpression="[TableID]" />				
				<asp:BoundField DataField="ReferenceValue" HeaderText="Reference Value" SortExpression="[ReferenceValue]" />				
				<data:HyperLinkField HeaderText="System Extension Label Id" DataNavigateUrlFormatString="SystemExtensionLabelEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SystemExtensionLabelIdSource" DataTextField="CustomerId" />
			</Columns>
			<EmptyDataTemplate>
				<b>No System Extension Found! </b>
				<asp:HyperLink runat="server" ID="hypSystemExtension" NavigateUrl="~/admin/SystemExtensionEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:SystemExtensionDataSource ID="SystemExtensionDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:SystemExtensionProperty Name="SystemExtensionLabel"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:SystemExtensionFilter  Column="SystemExtensionLabelId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:SystemExtensionDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeSystemExtension" runat="Server" TargetControlID="SystemExtensionPanel1"
            ExpandControlID="SystemExtensionPanel2" CollapseControlID="SystemExtensionPanel2" Collapsed="True"
            TextLabelID="SystemExtensionLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="SystemExtensionImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

