<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="CallFlowEdit.aspx.cs" Inherits="CallFlowEdit" Title="CallFlow Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Call Flow - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="CallFlowDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CallFlowFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/CallFlowFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>CallFlow not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:CallFlowDataSource ID="CallFlowDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:CallFlowDataSource>
		
		<br />

		<asp:Panel ID="DnisPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="DnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Dnis Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="DnisLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="DnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewDnis" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewDnis_SelectedIndexChanged"			 			 
			DataSourceID="DnisDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Dnis.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<data:HyperLinkField HeaderText="Access Type Id" DataNavigateUrlFormatString="AccessTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccessTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Dnis Type Id" DataNavigateUrlFormatString="DnisTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DnisTypeIdSource" DataTextField="Name" />
				<asp:BoundField DataField="DnisNumber" HeaderText="Dnis Number" SortExpression="[DNISNumber]" />				
				<asp:BoundField DataField="DialNumber" HeaderText="Dial Number" SortExpression="[DialNumber]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="DefaultOption" HeaderText="Default Option" SortExpression="[DefaultOption]" />				
				<data:HyperLinkField HeaderText="Call Flow Id" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Prompt Set Id" DataNavigateUrlFormatString="PromptSetEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PromptSetIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Dnis Found! </b>
				<asp:HyperLink runat="server" ID="hypDnis" NavigateUrl="~/admin/DnisEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:DnisDataSource ID="DnisDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:DnisProperty Name="AccessType"/> 
					<data:DnisProperty Name="CallFlow"/> 
					<data:DnisProperty Name="DnisType"/> 
					<data:DnisProperty Name="PromptSet"/> 
					<data:DnisProperty Name="Wholesaler"/> 
					<%--<data:DnisProperty Name="CustomerIdCustomerCollection_From_Customer_Dnis" />--%>
					<%--<data:DnisProperty Name="Moderator_DnisCollection" />--%>
					<%--<data:DnisProperty Name="ModeratorIdModeratorCollection_From_Moderator_Dnis" />--%>
					<%--<data:DnisProperty Name="Customer_DnisCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:DnisFilter  Column="CallFlowId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:DnisDataSource>		
		
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
						<data:EmailTemplateFilter  Column="CallFlowId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:EmailTemplateDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeDnis" runat="Server" TargetControlID="DnisPanel1"
            ExpandControlID="DnisPanel2" CollapseControlID="DnisPanel2" Collapsed="True"
            TextLabelID="DnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="DnisImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeEmailTemplate" runat="Server" TargetControlID="EmailTemplatePanel1"
            ExpandControlID="EmailTemplatePanel2" CollapseControlID="EmailTemplatePanel2" Collapsed="True"
            TextLabelID="EmailTemplateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="EmailTemplateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

