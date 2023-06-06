<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="TaxableEdit.aspx.cs" Inherits="TaxableEdit" Title="Taxable Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Taxable - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="TaxableDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TaxableFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/TaxableFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>Taxable not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:TaxableDataSource ID="TaxableDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:TaxableDataSource>
		
		<br />

		<asp:Panel ID="ProductRatePanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ProductRateImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Product Rate Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ProductRateLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ProductRatePanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewProductRate" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewProductRate_SelectedIndexChanged"			 			 
			DataSourceID="ProductRateDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_ProductRate.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Product Id" DataNavigateUrlFormatString="ProductEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Type Id" DataNavigateUrlFormatString="ProductRateTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateTypeIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Product Rate Interval Id" DataNavigateUrlFormatString="ProductRateIntervalEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="ProductRateIntervalIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Taxable Id" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<data:HyperLinkField HeaderText="Country Id" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CountryIdSource" DataTextField="Description" />
				<asp:BoundField DataField="Name" HeaderText="Name" SortExpression="[Name]" />				
				<asp:BoundField DataField="DisplayName" HeaderText="Display Name" SortExpression="[DisplayName]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="DisplayOrder" HeaderText="Display Order" SortExpression="[DisplayOrder]" />				
				<asp:BoundField DataField="MinimumTimeBeforeChargedSec" HeaderText="Minimum Time Before Charged Sec" SortExpression="[MinimumTimeBeforeChargedSec]" />				
				<data:HyperLinkField HeaderText="Rating Type Id" DataNavigateUrlFormatString="RatingTypeEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="RatingTypeIdSource" DataTextField="Name" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Product Rate Found! </b>
				<asp:HyperLink runat="server" ID="hypProductRate" NavigateUrl="~/admin/ProductRateEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ProductRateDataSource ID="ProductRateDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ProductRateProperty Name="Country"/> 
					<data:ProductRateProperty Name="RatingType"/> 
					<data:ProductRateProperty Name="Product"/> 
					<data:ProductRateProperty Name="ProductRateInterval"/> 
					<data:ProductRateProperty Name="ProductRateType"/> 
					<data:ProductRateProperty Name="Taxable"/> 
					<%--<data:ProductRateProperty Name="ProductRateValueCollection" />--%>
					<%--<data:ProductRateProperty Name="AccessType_ProductRateCollection" />--%>
					<%--<data:ProductRateProperty Name="CustomerTransactionCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ProductRateFilter  Column="TaxableId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ProductRateDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="WholesalerPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="WholesalerImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Wholesaler Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="WholesalerLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="WholesalerPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewWholesaler" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewWholesaler_SelectedIndexChanged"			 			 
			DataSourceID="WholesalerDataSource2"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Wholesaler.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]" />				
				<asp:BoundField DataField="CompanyShortName" HeaderText="Company Short Name" SortExpression="[CompanyShortName]" />				
				<asp:BoundField DataField="RetailPriCustomerNumber" HeaderText="Retail Pri Customer Number" SortExpression="[RetailPriCustomerNumber]" />				
				<asp:BoundField DataField="RetailPriCustomerNumberLikeExp" HeaderText="Retail Pri Customer Number Like Exp" SortExpression="[RetailPriCustomerNumberLIKEExp]" />				
				<asp:BoundField DataField="DefaultModCodeLength" HeaderText="Default Mod Code Length" SortExpression="[DefaultModCodeLength]" />				
				<asp:BoundField DataField="DefaultPassCodeLength" HeaderText="Default Pass Code Length" SortExpression="[DefaultPassCodeLength]" />				
				<asp:BoundField DataField="DefaultPasswordLength" HeaderText="Default Password Length" SortExpression="[DefaultPasswordLength]" />				
				<asp:BoundField DataField="DefaultCapsOk" HeaderText="Default Caps Ok" SortExpression="[DefaultCapsOK]" />				
				<asp:BoundField DataField="ModeratorTxt" HeaderText="Moderator Txt" SortExpression="[ModeratorTxt]" />				
				<asp:BoundField DataField="ParticipantTxt" HeaderText="Participant Txt" SortExpression="[ParticipantTxt]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="CustomerNumberExceptionList" HeaderText="Customer Number Exception List" SortExpression="[CustomerNumberExceptionList]" />				
				<asp:BoundField DataField="WebProductProviderName" HeaderText="Web Product Provider Name" SortExpression="[WebProductProviderName]" />				
				<asp:BoundField DataField="WebProductProviderBranding" HeaderText="Web Product Provider Branding" SortExpression="[WebProductProviderBranding]" />				
				<asp:BoundField DataField="WebSecProductProvider" HeaderText="Web Sec Product Provider" SortExpression="[WebSecProductProvider]" />				
				<data:HyperLinkField HeaderText="Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CurrencyIdSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingWholesalerId" HeaderText="Billing Wholesaler Id" SortExpression="[BillingWholesalerID]" />				
				<asp:BoundField DataField="BillingCustomerNumber" HeaderText="Billing Customer Number" SortExpression="[BillingCustomerNumber]" />				
				<data:HyperLinkField HeaderText="Taxable Id" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WebSiteUrl" HeaderText="Web Site Url" SortExpression="[WebSiteURL]" />				
				<asp:BoundField DataField="AdminSiteUrl" HeaderText="Admin Site Url" SortExpression="[AdminSiteURL]" />				
				<asp:BoundField DataField="AdminSiteIp" HeaderText="Admin Site Ip" SortExpression="[AdminSiteIP]" />				
				<asp:BoundField DataField="SelfServeUrl" HeaderText="Self Serve Url" SortExpression="[SelfServeURL]" />				
				<asp:BoundField DataField="SelfServeIp" HeaderText="Self Serve Ip" SortExpression="[SelfServeIP]" />				
				<asp:BoundField DataField="WebConferencingUrl" HeaderText="Web Conferencing Url" SortExpression="[WebConferencingURL]" />				
				<asp:BoundField DataField="WebConferencingIp" HeaderText="Web Conferencing Ip" SortExpression="[WebConferencingIP]" />				
				<asp:BoundField DataField="SupportEmail" HeaderText="Support Email" SortExpression="[SupportEmail]" />				
				<asp:BoundField DataField="SupportPhoneNumber" HeaderText="Support Phone Number" SortExpression="[SupportPhoneNumber]" />				
				<asp:BoundField DataField="DoRetailBilling" HeaderText="Do Retail Billing" SortExpression="[DoRetailBilling]" />				
				<asp:BoundField DataField="CommissionLockDate" HeaderText="Commission Lock Date" SortExpression="[CommissionLockDate]" />				
				<asp:BoundField DataField="PortalId" HeaderText="Portal Id" SortExpression="[PortalID]" />				
				<asp:BoundField DataField="BillingAddress1" HeaderText="Billing Address1" SortExpression="[BillingAddress1]" />				
				<asp:BoundField DataField="BillingAddress2" HeaderText="Billing Address2" SortExpression="[BillingAddress2]" />				
				<asp:BoundField DataField="BillingCity" HeaderText="Billing City" SortExpression="[BillingCity]" />				
				<data:HyperLinkField HeaderText="Billing Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Billing Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingPostalCode" HeaderText="Billing Postal Code" SortExpression="[BillingPostalCode]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler Found! </b>
				<asp:HyperLink runat="server" ID="hypWholesaler" NavigateUrl="~/admin/WholesalerEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:WholesalerDataSource ID="WholesalerDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WholesalerProperty Name="Currency"/> 
					<data:WholesalerProperty Name="Country"/> 
					<data:WholesalerProperty Name="State"/> 
					<data:WholesalerProperty Name="Taxable"/> 
					<%--<data:WholesalerProperty Name="VerticalCollection" />--%>
					<%--<data:WholesalerProperty Name="LanguageIdLanguageCollection_From_IrWholesaler" />--%>
					<%--<data:WholesalerProperty Name="CustomerTransactionCollection" />--%>
					<%--<data:WholesalerProperty Name="CustomerDocumentCollection" />--%>
					<%--<data:WholesalerProperty Name="CommissionCustomerCollection" />--%>
					<%--<data:WholesalerProperty Name="CommissionCollection" />--%>
					<%--<data:WholesalerProperty Name="EmailTemplateCollection" />--%>
					<%--<data:WholesalerProperty Name="RatedCdrCollection" />--%>
					<%--<data:WholesalerProperty Name="Wholesaler_ProductCollection" />--%>
					<%--<data:WholesalerProperty Name="AccountManagerCollection" />--%>
					<%--<data:WholesalerProperty Name="ProductRateValueCollection" />--%>
					<%--<data:WholesalerProperty Name="DnisCollection" />--%>
					<%--<data:WholesalerProperty Name="CustomerCollection" />--%>
					<%--<data:WholesalerProperty Name="IrWholesalerCollection" />--%>
					<%--<data:WholesalerProperty Name="LeadCollection" />--%>
					<%--<data:WholesalerProperty Name="SalesPersonCollection" />--%>
					<%--<data:WholesalerProperty Name="DepartmentCollection" />--%>
					<%--<data:WholesalerProperty Name="CompanyCollection" />--%>
					<%--<data:WholesalerProperty Name="TicketCollection" />--%>
					<%--<data:WholesalerProperty Name="MarketingServiceCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:WholesalerFilter  Column="TaxableId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:WholesalerDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="CustomerPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;">Customer Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomer" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDataSource3"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Customer.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<data:HyperLinkField HeaderText="Wholesaler Id" DataNavigateUrlFormatString="WholesalerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="WholesalerIdSource" DataTextField="CompanyName" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<asp:BoundField DataField="ExternalCustomerNumber" HeaderText="External Customer Number" SortExpression="[ExternalCustomerNumber]" />				
				<asp:BoundField DataField="PrimaryContactName" HeaderText="Primary Contact Name" SortExpression="[PrimaryContactName]" />				
				<asp:BoundField DataField="PrimaryContactPhoneNumber" HeaderText="Primary Contact Phone Number" SortExpression="[PrimaryContactPhoneNumber]" />				
				<asp:BoundField DataField="PrimaryContactEmailAddress" HeaderText="Primary Contact Email Address" SortExpression="[PrimaryContactEmailAddress]" />				
				<asp:BoundField DataField="PrimaryContactAddress1" HeaderText="Primary Contact Address1" SortExpression="[PrimaryContactAddress1]" />				
				<asp:BoundField DataField="PrimaryContactAddress2" HeaderText="Primary Contact Address2" SortExpression="[PrimaryContactAddress2]" />				
				<asp:BoundField DataField="PrimaryContactCity" HeaderText="Primary Contact City" SortExpression="[PrimaryContactCity]" />				
				<data:HyperLinkField HeaderText="Primary Contact Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PrimaryContactCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Primary Contact Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="PrimaryContactRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="PrimaryContactPostalCode" HeaderText="Primary Contact Postal Code" SortExpression="[PrimaryContactPostalCode]" />				
				<asp:BoundField DataField="PrimaryContactFaxNumber" HeaderText="Primary Contact Fax Number" SortExpression="[PrimaryContactFaxNumber]" />				
				<asp:BoundField DataField="BillingContactName" HeaderText="Billing Contact Name" SortExpression="[BillingContactName]" />				
				<asp:BoundField DataField="BillingContactPhoneNumber" HeaderText="Billing Contact Phone Number" SortExpression="[BillingContactPhoneNumber]" />				
				<asp:BoundField DataField="BillingContactEmailAddress" HeaderText="Billing Contact Email Address" SortExpression="[BillingContactEmailAddress]" />				
				<asp:BoundField DataField="BillingContactAddress1" HeaderText="Billing Contact Address1" SortExpression="[BillingContactAddress1]" />				
				<asp:BoundField DataField="BillingContactAddress2" HeaderText="Billing Contact Address2" SortExpression="[BillingContactAddress2]" />				
				<asp:BoundField DataField="BillingContactCity" HeaderText="Billing Contact City" SortExpression="[BillingContactCity]" />				
				<data:HyperLinkField HeaderText="Billing Contact Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingContactCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Billing Contact Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingContactRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingContactPostalCode" HeaderText="Billing Contact Postal Code" SortExpression="[BillingContactPostalCode]" />				
				<asp:BoundField DataField="BillingContactFaxNumber" HeaderText="Billing Contact Fax Number" SortExpression="[BillingContactFaxNumber]" />				
				<asp:BoundField DataField="WebsiteUrl" HeaderText="Website Url" SortExpression="[WebsiteURL]" />				
				<data:HyperLinkField HeaderText="Sales Person Id" DataNavigateUrlFormatString="SalesPersonEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="SalesPersonIdSource" DataTextField="FullName" />
				<data:HyperLinkField HeaderText="Vertical Id" DataNavigateUrlFormatString="VerticalEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="VerticalIdSource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Company Id" DataNavigateUrlFormatString="CompanyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CompanyIdSource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CurrencyIdSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingPeriodCutoff" HeaderText="Billing Period Cutoff" SortExpression="[BillingPeriodCutoff]" />				
				<data:HyperLinkField HeaderText="Taxable Id" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<asp:BoundField DataField="CreditCardNameOnCard" HeaderText="Credit Card Name On Card" SortExpression="[CreditCardNameOnCard]" />				
				<asp:BoundField DataField="CreditCardNumber" HeaderText="Credit Card Number" SortExpression="[CreditCardNumber]" />				
				<asp:BoundField DataField="CreditCardExp" HeaderText="Credit Card Exp" SortExpression="[CreditCardExp]" />				
				<asp:BoundField DataField="CreditCardVerCode" HeaderText="Credit Card Ver Code" SortExpression="[CreditCardVerCode]" />				
				<asp:BoundField DataField="CreditCardTypeName" HeaderText="Credit Card Type Name" SortExpression="[CreditCardTypeName]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />				
				<asp:BoundField DataField="UniqueCustomerId" HeaderText="Unique Customer Id" SortExpression="[UniqueCustomerID]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username" />
				<asp:BoundField DataField="WebGroupId" HeaderText="Web Group Id" SortExpression="[WebGroupID]" />				
				<data:HyperLinkField HeaderText="Account Manager Id" DataNavigateUrlFormatString="AccountManagerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="AccountManagerIdSource" DataTextField="FullName" />
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomer" NavigateUrl="~/admin/CustomerEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDataSource ID="CustomerDataSource3" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerProperty Name="User"/> 
					<data:CustomerProperty Name="Company"/> 
					<data:CustomerProperty Name="Currency"/> 
					<data:CustomerProperty Name="AccountManager"/> 
					<data:CustomerProperty Name="Country"/> 
					<data:CustomerProperty Name="State"/> 
					<data:CustomerProperty Name="SalesPerson"/> 
					<data:CustomerProperty Name="Taxable"/> 
					<data:CustomerProperty Name="Vertical"/> 
					<data:CustomerProperty Name="Wholesaler"/> 
					<%--<data:CustomerProperty Name="CustomerDocumentCollection" />--%>
					<%--<data:CustomerProperty Name="ProductRateValueCollection" />--%>
					<%--<data:CustomerProperty Name="Customer_FeatureCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionCustomerCollection" />--%>
					<%--<data:CustomerProperty Name="CustomerTransactionCollection" />--%>
					<%--<data:CustomerProperty Name="ParticipantListCollection" />--%>
					<%--<data:CustomerProperty Name="DepartmentCollection" />--%>
					<%--<data:CustomerProperty Name="Customer_DnisCollection" />--%>
					<%--<data:CustomerProperty Name="InvoiceSummaryCollection" />--%>
					<%--<data:CustomerProperty Name="DnisidDnisCollection_From_Customer_Dnis" />--%>
					<%--<data:CustomerProperty Name="TicketCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionCollection" />--%>
					<%--<data:CustomerProperty Name="EventManagerCollection" />--%>
					<%--<data:CustomerProperty Name="ModeratorCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerFilter  Column="TaxableId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeProductRate" runat="Server" TargetControlID="ProductRatePanel1"
            ExpandControlID="ProductRatePanel2" CollapseControlID="ProductRatePanel2" Collapsed="True"
            TextLabelID="ProductRateLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ProductRateImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeWholesaler" runat="Server" TargetControlID="WholesalerPanel1"
            ExpandControlID="WholesalerPanel2" CollapseControlID="WholesalerPanel2" Collapsed="True"
            TextLabelID="WholesalerLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="WholesalerImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer" runat="Server" TargetControlID="CustomerPanel1"
            ExpandControlID="CustomerPanel2" CollapseControlID="CustomerPanel2" Collapsed="True"
            TextLabelID="CustomerLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

