<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="GlPostingTypeEdit.aspx.cs" Inherits="GlPostingTypeEdit" Title="GlPostingType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Gl Posting Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="GlPostingTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/GlPostingTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/GlPostingTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>GlPostingType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:GlPostingTypeDataSource ID="GlPostingTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:GlPostingTypeDataSource>
		
		<br />

		<asp:Panel ID="CustomerTransactionTypePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerTransactionTypeImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Customer Transaction Type Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerTransactionTypeLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerTransactionTypePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomerTransactionType" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomerTransactionType_SelectedIndexChanged"			 			 
			DataSourceID="CustomerTransactionTypeDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CustomerTransactionType.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<data:HyperLinkField HeaderText="Gl Posting Type Id" DataNavigateUrlFormatString="GlPostingTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="GlPostingTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ActionValue" HeaderText="Action Value" SortExpression="[ActionValue]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="Visible" HeaderText="Visible" SortExpression="[Visible]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Transaction Type Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomerTransactionType" NavigateUrl="~/admin/CustomerTransactionTypeEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerTransactionTypeDataSource ID="CustomerTransactionTypeDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerTransactionTypeProperty Name="GlPostingType"/> 
					<%--<data:CustomerTransactionTypeProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerTransactionTypeFilter  Column="GlPostingTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerTransactionTypeDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerTransactionType" runat="Server" TargetControlID="CustomerTransactionTypePanel1"
            ExpandControlID="CustomerTransactionTypePanel2" CollapseControlID="CustomerTransactionTypePanel2" Collapsed="True"
            TextLabelID="CustomerTransactionTypeLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerTransactionTypeImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

