<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="AccountManagerEdit.aspx.cs" Inherits="AccountManagerEdit" Title="AccountManager Edit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Account Manager - Add/Edit</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
		<data:MultiFormView ID="FormView1" DataKeyNames="Id" runat="server" DataSourceID="AccountManagerDataSource">
		
			<EditItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AccountManagerFields.ascx" />
			</EditItemTemplatePaths>
		
			<InsertItemTemplatePaths>
				<data:TemplatePath Path="~/Admin/UserControls/AccountManagerFields.ascx" />
			</InsertItemTemplatePaths>
		
			<EmptyDataTemplate>
				<b>AccountManager not found!</b>
			</EmptyDataTemplate>
			
			<FooterTemplate>
				<asp:Button ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
				<asp:Button ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
				<asp:Button ID="CancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
			</FooterTemplate>

		</data:MultiFormView>
		
		<data:AccountManagerDataSource ID="AccountManagerDataSource" runat="server"
			SelectMethod="GetById"
		>
			<Parameters>
				<asp:QueryStringParameter Name="Id" QueryStringField="Id" Type="String" />

			</Parameters>
		</data:AccountManagerDataSource>
		
		<br />

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
			DataSourceID="CustomerDataSource1"
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
		
		<data:CustomerDataSource ID="CustomerDataSource1" runat="server" SelectMethod="Find"
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
						<data:CustomerFilter  Column="AccountManagerId" QueryStringField="Id" /> 
					</Filters>
				</data:SqlParameter>
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" /> 
		    </Parameters>
		</data:CustomerDataSource>		
		
		<br />
		</asp:Panel>
		
<ajaxToolkit:CollapsiblePanelExtender ID="cpeCustomer" runat="Server" TargetControlID="CustomerPanel1"
            ExpandControlID="CustomerPanel2" CollapseControlID="CustomerPanel2" Collapsed="True"
            TextLabelID="CustomerLabel" ExpandedText="(Hide Details...)" CollapsedText="(Show Details...)"
            ImageControlID="CustomerImage" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
            SuppressPostBack="true"/>


</asp:Content>

