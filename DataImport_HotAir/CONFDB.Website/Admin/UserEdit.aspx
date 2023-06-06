<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="UserEdit.aspx.cs" Inherits="UserEdit" Title="User Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">User - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="UserId" runat="server" DataSourceID="UserDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/UserFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>User not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Submit" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:UserDataSource ID="UserDataSource" runat="server"
			SelectMethod="GetByUserId"
		>
			<Parameters>
				<asp:QueryStringParameter Name="UserId" QueryStringField="UserId" Type="String" />

			</Parameters>
		</data:UserDataSource>
		
		<br />

		<asp:Panel ID="ModeratorPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="ModeratorImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Moderator Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="ModeratorLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="ModeratorPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewModerator" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewModerator_SelectedIndexChanged"			 			 
			DataSourceID="ModeratorDataSource1"
			DataKeyNames="Id"
			AllowMultiColumnSorting="false"
			DefaultSortColumnName="" 
			DefaultSortDirection="Ascending"	
			ExcelExportFileName="Export_Moderator.xls"  		
			Visible='<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>'	
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" />
				<asp:BoundField DataField="WholesalerId" HeaderText="Wholesaler Id" SortExpression="[WholesalerID]" />				
				<data:HyperLinkField HeaderText="Customer Id" DataNavigateUrlFormatString="CustomerEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CustomerIdSource" DataTextField="PriCustomerNumber" />
				<asp:BoundField DataField="PriCustomerNumber" HeaderText="Pri Customer Number" SortExpression="[PriCustomerNumber]" />				
				<asp:BoundField DataField="SecCustomerNumber" HeaderText="Sec Customer Number" SortExpression="[SecCustomerNumber]" />				
				<asp:BoundField DataField="ExternalModeratorNumber" HeaderText="External Moderator Number" SortExpression="[ExternalModeratorNumber]" />				
				<asp:BoundField DataField="ModeratorCode" HeaderText="Moderator Code" SortExpression="[ModeratorCode]" />				
				<asp:BoundField DataField="PassCode" HeaderText="Pass Code" SortExpression="[PassCode]" />				
				<asp:BoundField DataField="Description" HeaderText="Description" SortExpression="[Description]" />				
				<data:HyperLinkField HeaderText="Department Id" DataNavigateUrlFormatString="DepartmentEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="DepartmentIdSource" DataTextField="Name" />
				<asp:BoundField DataField="ModifiedBy" HeaderText="Modified By" SortExpression="[ModifiedBy]" />				
				<asp:BoundField DataField="CreatedDate" HeaderText="Created Date" SortExpression="[CreatedDate]" />				
				<asp:BoundField DataField="LastModified" HeaderText="Last Modified" SortExpression="[LastModified]" />				
				<asp:BoundField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]" />				
				<asp:BoundField DataField="UniqueModeratorId" HeaderText="Unique Moderator Id" SortExpression="[UniqueModeratorID]" />				
				<data:HyperLinkField HeaderText="User Id" DataNavigateUrlFormatString="UserEdit.aspx?UserId={0}" DataNavigateUrlFields="UserId" DataContainer="UserIdSource" DataTextField="Username" />
				<asp:BoundField DataField="WebMeetingId" HeaderText="Web Meeting Id" SortExpression="[WebMeetingID]" />				
			</Columns>
			<EmptyDataTemplate>
				<b>No Moderator Found! </b>
				<asp:HyperLink runat="server" ID="hypModerator" NavigateUrl="~/admin/ModeratorEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:ModeratorDataSource ID="ModeratorDataSource1" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:ModeratorProperty Name="Department"/> 
					<data:ModeratorProperty Name="Customer"/> 
					<data:ModeratorProperty Name="User"/> 
					<%--<data:ModeratorProperty Name="Moderator_FeatureCollection" />--%>
					<%--<data:ModeratorProperty Name="WelcomeKitRequestCollection" />--%>
					<%--<data:ModeratorProperty Name="BridgeRequestCollection" />--%>
					<%--<data:ModeratorProperty Name="Moderator_DnisCollection" />--%>
					<%--<data:ModeratorProperty Name="BridgeQueueCollection" />--%>
					<%--<data:ModeratorProperty Name="RatedCdrCollection" />--%>
					<%--<data:ModeratorProperty Name="TicketCollection" />--%>
					<%--<data:ModeratorProperty Name="DnisidDnisCollection_From_Moderator_Dnis" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:ModeratorFilter  Column="UserId" QueryStringField="UserId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:ModeratorDataSource>		
		
		<br />
		</asp:Panel>
		<asp:Panel ID="CustomerPanel2" runat="server" CssClass="collapsePanelHeader"> 
			<div style="padding:5px; cursor: pointer; vertical-align: middle;">
				<div style="float: left; vertical-align: middle;"><asp:Image ID="CustomerImage" runat="server" ImageUrl="~/images/expand_blue.jpg"/></div>
				<div style="float: left; padding-left: 5px;font-weight:bold;">Customer Details</div>
				<div style="float: left; margin-left: 20px;"><asp:Label ID="CustomerLabel" runat="server" /></div>
			</div>
		</asp:Panel>	
		<asp:Panel ID="CustomerPanel1" runat="server" CssClass="collapsePanel" Height="0">
		<data:EntityGridView ID="GridViewCustomer" runat="server"
			AutoGenerateColumns="False"					
			OnSelectedIndexChanged="GridViewCustomer_SelectedIndexChanged"			 			 
			DataSourceID="CustomerDataSource2"
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
			</Columns>
			<EmptyDataTemplate>
				<b>No Customer Found! </b>
				<asp:HyperLink runat="server" ID="hypCustomer" NavigateUrl="~/admin/CustomerEdit.aspx">Add New</asp:HyperLink>
			</EmptyDataTemplate>
		</data:EntityGridView>					
		
		<data:CustomerDataSource ID="CustomerDataSource2" runat="server" SelectMethod="Find"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:CustomerProperty Name="Company"/> 
					<data:CustomerProperty Name="Currency"/> 
					<data:CustomerProperty Name="Country"/> 
					<data:CustomerProperty Name="State"/> 
					<data:CustomerProperty Name="User"/> 
					<data:CustomerProperty Name="SalesPerson"/> 
					<data:CustomerProperty Name="Taxable"/> 
					<data:CustomerProperty Name="Vertical"/> 
					<data:CustomerProperty Name="Wholesaler"/> 
					<%--<data:CustomerProperty Name="TicketCollection" />--%>
					<%--<data:CustomerProperty Name="CustomerDocumentCollection" />--%>
					<%--<data:CustomerProperty Name="ProductRateValueCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionRuleCollection" />--%>
					<%--<data:CustomerProperty Name="CustomerTransactionCollection" />--%>
					<%--<data:CustomerProperty Name="ParticipantListCollection" />--%>
					<%--<data:CustomerProperty Name="DepartmentCollection" />--%>
					<%--<data:CustomerProperty Name="Customer_DnisCollection" />--%>
					<%--<data:CustomerProperty Name="DnisidDnisCollection_From_Customer_Dnis" />--%>
					<%--<data:CustomerProperty Name="Customer_FeatureCollection" />--%>
					<%--<data:CustomerProperty Name="CommissionCollection" />--%>
					<%--<data:CustomerProperty Name="ModeratorCollection" />--%>
				</Types>
			</DeepLoadProperties>
			
		    <Parameters>
				<data:SqlParameter Name="Parameters">
					<Filters>
						<data:CustomerFilter  Column="UserId" QueryStringField="UserId" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeModerator" runat="Server" TargetControlID="ModeratorPanel1"
            ExpandControlID="ModeratorPanel2" CollapseControlID="ModeratorPanel2" Collapsed="True"
            TextLabelID="ModeratorLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="ModeratorImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>

<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer" runat="Server" TargetControlID="CustomerPanel1"
            ExpandControlID="CustomerPanel2" CollapseControlID="CustomerPanel2" Collapsed="True"
            TextLabelID="CustomerLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

