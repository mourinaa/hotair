<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="DocumentTypeEdit.aspx.cs" Inherits="DocumentTypeEdit" Title="DocumentType Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Document Type - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="DocumentTypeDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DocumentTypeFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/DocumentTypeFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>DocumentType not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:DocumentTypeDataSource ID="DocumentTypeDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:DocumentTypeDataSource>
		
		<br />

		<asp:Panel ID="CustomerDocumentPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerDocumentImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Customer Document Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerDocumentLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerDocumentPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomerDocument" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomerDocument_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDocumentDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_CustomerDocument.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="DocumentDate" HeaderText="Document Date" SortExpression="[DocumentDate]" />				
				<data:HyperLinkField HeaderText="Document Type Id" DataNavigateUrlFormatString="DocumentTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DocumentTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="KbSize" HeaderText="Kb Size" SortExpression="[KBSize]" />				
				<asp:BoundField DataField="DocumentDirectory" HeaderText="Document Directory" SortExpression="[DocumentDirectory]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="[Notes]" />				
				<data:HyperLinkField HeaderText="Language Id" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Document Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomerDocument" NavigateUrl="~/admin/CustomerDocumentEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDocumentDataSource ID="CustomerDocumentDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerDocumentProperty Name="Customer"/> 
					<data:CustomerDocumentProperty Name="Wholesaler"/> 
					<data:CustomerDocumentProperty Name="DocumentType"/> 
					<data:CustomerDocumentProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerDocumentFilter  Column="DocumentTypeId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDocumentDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerDocument" runat="Server" TargetControlID="CustomerDocumentPanel1"
            ExpandControlID="CustomerDocumentPanel2" CollapseControlID="CustomerDocumentPanel2" Collapsed="True"
            TextLabelID="CustomerDocumentLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerDocumentImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

