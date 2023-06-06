<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="LanguageEdit.aspx.cs" Inherits="LanguageEdit" Title="Language Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Language - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="LanguageDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguageFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/LanguageFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Language not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:LanguageDataSource ID="LanguageDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:LanguageDataSource>
		
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
						<data:CustomerDocumentFilter  Column="LanguageId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDocumentDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="EmailTemplatePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="EmailTemplateImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Email Template Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="EmailTemplateLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="EmailTemplatePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewEmailTemplate" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewEmailTemplate_SelectedIndexChanged"			 			 
			DataSourceID="EmailTemplateDataSource2"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_EmailTemplate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="SmtpServer" HeaderText="Smtp Server" SortExpression="[SMTPServer]" />				
				<asp:BoundField DataField="SmtpUserName" HeaderText="Smtp User Name" SortExpression="[SMTPUserName]" />				
				<asp:BoundField DataField="SmtpPassword" HeaderText="Smtp Password" SortExpression="[SMTPPassword]" />				
				<asp:BoundField DataField="BaseFileDirectory" HeaderText="Base File Directory" SortExpression="[BaseFileDirectory]" />				
				<asp:BoundField DataField="TemplateName" HeaderText="Template Name" SortExpression="[TemplateName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="FileName" HeaderText="File Name" SortExpression="[FileName]" />				
				<asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="[Subject]" />				
				<asp:BoundField DataField="Sender" HeaderText="Sender" SortExpression="[Sender]" />				
				<asp:BoundField DataField="BccList" HeaderText="Bcc List" SortExpression="[BCCList]" />				
				<asp:BoundField DataField="CcList" HeaderText="Cc List" SortExpression="[CCList]" />				
				<asp:BoundField DataField="SendToContact" HeaderText="Send To Contact" SortExpression="[SendToContact]" />				
				<asp:BoundField DataField="SendToModerator" HeaderText="Send To Moderator" SortExpression="[SendToModerator]" />				
				<asp:BoundField DataField="IncludeAttachment" HeaderText="Include Attachment" SortExpression="[IncludeAttachment]" />				
				<asp:BoundField DataField="AttachmentFileName" HeaderText="Attachment File Name" SortExpression="[AttachmentFileName]" />				
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="EmailTemplateContentTypeId" HeaderText="Email Template Content Type Id" SortExpression="[EmailTemplateContentTypeID]" />				
				<asp:BoundField DataField="EmailTemplateGroupId" HeaderText="Email Template Group Id" SortExpression="[EmailTemplateGroupID]" />				
				<data:HyperLinkField HeaderText="Call Flow Id" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Language Id" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Email Template Found! </b>
				<asp:HyperLink runat="server" ID="hypEmailTemplate" NavigateUrl="~/admin/EmailTemplateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:EmailTemplateDataSource ID="EmailTemplateDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:EmailTemplateProperty Name="CallFlow"/> 
					<data:EmailTemplateProperty Name="Wholesaler"/> 
					<data:EmailTemplateProperty Name="Language"/> 
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:EmailTemplateFilter  Column="LanguageId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmailTemplateDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomerDocument" runat="Server" TargetControlID="CustomerDocumentPanel1"
            ExpandControlID="CustomerDocumentPanel2" CollapseControlID="CustomerDocumentPanel2" Collapsed="True"
            TextLabelID="CustomerDocumentLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerDocumentImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeEmailTemplate" runat="Server" TargetControlID="EmailTemplatePanel1"
            ExpandControlID="EmailTemplatePanel2" CollapseControlID="EmailTemplatePanel2" Collapsed="True"
            TextLabelID="EmailTemplateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="EmailTemplateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

