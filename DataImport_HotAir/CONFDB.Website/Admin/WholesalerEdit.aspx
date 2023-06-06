<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="WholesalerEdit.aspx.cs" Inherits="WholesalerEdit" Title="Wholesaler Edit" %>
<%--<%@ Register Src="~/Admin/CustomControls/cmdBack.ascx" TagName="cmdBack" TagPrefix="uc1" %>--%>
<%@ Register Src="~/Admin/CustomControls/DNISGridWS.ascx" TagName="DNISGridWS" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/ProductRatesWS.ascx" TagName="ProductRatesWS" TagPrefix="uc1" %>
<%@ Register Src="~/Admin/CustomControls/FeaturesWS.ascx" TagName="FeaturesWS" TagPrefix="uc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Wholesaler - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="WholesalerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/WholesalerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/WholesalerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Wholesaler not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                <%--<uc1:cmdBack id="CmdBack1" runat="server" Text="Back" CssClass="" />--%>
				
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:WholesalerDataSource ID="WholesalerDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<%--<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />--%>
                <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
			</Parameters>
		</data:WholesalerDataSource>
		
		<br />
		<asp:Panel ID="DnisPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="DnisImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Dnis Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="DnisLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="DnisPanel1" runat="server" CssClass="collapsePanel" Height="0">
            <uc1:DNISGridWS id="DNISGridWS1" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
		<br />
		</asp:Panel>

		<asp:Panel ID="Wholesaler_ProductPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="Wholesaler_ProductImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Product Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="Wholesaler_ProductLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="Wholesaler_ProductPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewWholesaler_Product" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewWholesaler_Product_SelectedIndexChanged"			 			 
			DataSourceID="Wholesaler_ProductDataSource10"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Wholesaler_Product.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Wholesaler" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayNameAlt" HeaderText="Display Name Alt" SortExpression="[DisplayNameAlt]" />				
				<asp:BoundField DataField="DescriptionAlt" HeaderText="Description Alt" SortExpression="[DescriptionAlt]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler Product Found! </b>
				<asp:HyperLink runat="server" ID="hypWholesaler_Product" NavigateUrl="~/admin/Wholesaler_ProductEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:Wholesaler_ProductDataSource ID="Wholesaler_ProductDataSource10" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:Wholesaler_ProductProperty Name="Wholesaler"/> 
					<data:Wholesaler_ProductProperty Name="Product"/> 
					<%--<data:Wholesaler_ProductProperty Name="Wholesaler_Product_FeatureCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:Wholesaler_ProductFilter  Column="WholesalerId" QueryStringField="Id"/> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:Wholesaler_ProductDataSource>		

		<br />
		</asp:Panel>

		<asp:Panel ID="ProductRateValuePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ProductRateValueImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Product Rate Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ProductRateValueLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ProductRateValuePanel1" runat="server" CssClass="collapsePanel" Height="0">
		
            <uc1:ProductRatesWS ID="ucProductRatesWS" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
	
		<br />
		</asp:Panel>

		<asp:Panel ID="FeaturesPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="FeaturesImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Feature Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="FeaturesLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="FeaturesPanel1" runat="server" CssClass="collapsePanel" Height="0">
            <uc1:FeaturesWS id="ucFeaturesWS" runat="server" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>' />
		<br />
		</asp:Panel>

		<asp:Panel ID="EmailTemplatePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="EmailTemplateImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Email Templates Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="EmailTemplateLabel" runat="server" /></div>
			</div>
		</asp:Panel>
        <asp:Panel ID="EmailTemplatePanel1" runat="server" CssClass="collapsePanel" Height="0">
            <asp:UpdatePanel ID="UpdatePanelEmailTemplate" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanelEmailTemplate"
                        DynamicLayout="true" DisplayAfter="1">
                        <ProgressTemplate>
                            <div class="">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/progress.gif" />
                                Please Wait...
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <data:EntityGridView ID="GridViewEmailTemplate" runat="server" AutoGenerateColumns="False"
                        OnSelectedIndexChanged="GridViewEmailTemplate_SelectedIndexChanged" DataSourceID="EmailTemplateDataSource2"
                        DataKeyNames="Id" AllowMultiColumnSorting="false" DefaultSortColumnName="" DefaultSortDirection="Ascending"
                        ExcelExportFileName="Export_EmailTemplate.xls" Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'>
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" ShowEditButton="True" />
                            <data:HyperLinkField HeaderText="Wholesaler" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
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
                            <asp:BoundField DataField="AttachmentFileName" HeaderText="Attachment File Name"
                                SortExpression="[AttachmentFileName]" />
                            <asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />
                            <asp:BoundField DataField="EmailTemplateContentTypeId" HeaderText="Email Template Content Type"
                                SortExpression="[EmailTemplateContentTypeID]" />
                            <asp:BoundField DataField="EmailTemplateGroupId" HeaderText="Email Template Group"
                                SortExpression="[EmailTemplateGroupID]" />
                            <data:HyperLinkField HeaderText="Call Flow" DataNavigateUrlFormatString="CallFlowEdit.aspx?Id={0}"
                                DataNavigateUrlFields="Id" DataContainer="CallFlowIdSource" DataTextField="Name" />
                            <data:HyperLinkField HeaderText="Language" DataNavigateUrlFormatString="LanguageEdit.aspx?Id={0}"
                                DataNavigateUrlFields="Id" DataContainer="LanguageIdSource" DataTextField="DisplayName" />
                        </Columns>
                        <EmptyDataTemplate>
                            <b>No Email Templates Found! </b>
                            <asp:HyperLink runat="server" ID="hypEmailTemplate" NavigateUrl="~/admin/EmailTemplateEdit.aspx">Add New</asp:HyperLink>
                        </EmptyDataTemplate>
                    </data:EntityGridView>
                    <data:EmailTemplateDataSource ID="EmailTemplateDataSource2" runat="server" SelectMethod="Find"
                        EnableDeepLoad="True">
                        <DeepLoadProperties Method="IncludeChildren" Recursive="False">
                            <Types>
                                <data:EmailTemplateProperty Name="Language" />
                                <data:EmailTemplateProperty Name="CallFlow" />
                                <data:EmailTemplateProperty Name="Wholesaler" />
                            </Types>
                        </DeepLoadProperties>
                        <Parameters>
                            <data:SqlParameter Name="Parameters">
                                <Filters>
                                    <data:EmailTemplateFilter Column="WholesalerId" QueryStringField="Id" />
                                </Filters>
                            </data:SqlParameter>
                            <data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
                        </Parameters>
                    </data:EmailTemplateDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </asp:Panel>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeEmailTemplate" runat="Server" TargetControlID="EmailTemplatePanel1"
            ExpandControlID="EmailTemplatePanel2" CollapseControlID="EmailTemplatePanel2" Collapsed="True"
            TextLabelID="EmailTemplateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="EmailTemplateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeWholesaler_Product" runat="Server" TargetControlID="Wholesaler_ProductPanel1"
            ExpandControlID="Wholesaler_ProductPanel2" CollapseControlID="Wholesaler_ProductPanel2" Collapsed="True"
            TextLabelID="Wholesaler_ProductLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="Wholesaler_ProductImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRateValue" runat="Server" TargetControlID="ProductRateValuePanel1"
            ExpandControlID="ProductRateValuePanel2" CollapseControlID="ProductRateValuePanel2" Collapsed="True"
            TextLabelID="ProductRateValueLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ProductRateValueImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeDnis" runat="Server" TargetControlID="DnisPanel1"
            ExpandControlID="DnisPanel2" CollapseControlID="DnisPanel2" Collapsed="True"
            TextLabelID="DnisLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="DnisImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeFeatures" runat="Server" TargetControlID="FeaturesPanel1"
            ExpandControlID="FeaturesPanel2" CollapseControlID="FeaturesPanel2" Collapsed="True"
            TextLabelID="FeaturesLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="FeaturesImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

</asp:Content>

