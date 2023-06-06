
<%@ Page Language="C#" Theme="Default" MasterPageFile="~/MasterPages/admin.master" AutoEventWireup="true"  CodeFile="Wholesaler.aspx.cs" Inherits="Wholesaler" Title="Wholesaler List" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">Wholesaler List</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<data:GridViewSearchPanel ID="GridViewSearchPanel1" runat="server" GridViewControlID="GridView1" PersistenceMethod="Session" />
		<br />
		<data:EntityGridView ID="GridView1" runat="server"			
				AutoGenerateColumns="False"					
				OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
				DataSourceID="WholesalerDataSource"
				DataKeyNames="Id"
				AllowMultiColumnSorting="false"
				DefaultSortColumnName="" 
				DefaultSortDirection="Ascending"	
				ExcelExportFileName="Export_Wholesaler.xls"  		
			>
			<Columns>
				<asp:CommandField ShowSelectButton="True" ShowEditButton="True" />				
				<asp:BoundField DataField="Id" HeaderText="Id" SortExpression="[ID]" ReadOnly />
				<asp:BoundField DataField="CompanyName" HeaderText="Company Name" SortExpression="[CompanyName]"  />
				<asp:BoundField DataField="CompanyShortName" HeaderText="Company Short Name" SortExpression="[CompanyShortName]"  />
				<asp:BoundField DataField="RetailPriCustomerNumber" HeaderText="Retail Pri Customer Number" SortExpression="[RetailPriCustomerNumber]"  />
				<asp:BoundField DataField="RetailPriCustomerNumberLikeExp" HeaderText="Retail Pri Customer Number Like Exp" SortExpression="[RetailPriCustomerNumberLIKEExp]"  />
				<asp:BoundField DataField="DefaultModCodeLength" HeaderText="Default Mod Code Length" SortExpression="[DefaultModCodeLength]"  />
				<asp:BoundField DataField="DefaultPassCodeLength" HeaderText="Default Pass Code Length" SortExpression="[DefaultPassCodeLength]"  />
				<asp:BoundField DataField="DefaultPasswordLength" HeaderText="Default Password Length" SortExpression="[DefaultPasswordLength]"  />
				<data:BoundRadioButtonField DataField="DefaultCapsOk" HeaderText="Default Caps Ok" SortExpression="[DefaultCapsOK]"  />
				<asp:BoundField DataField="ModeratorTxt" HeaderText="Moderator Txt" SortExpression="[ModeratorTxt]"  />
				<asp:BoundField DataField="ParticipantTxt" HeaderText="Participant Txt" SortExpression="[ParticipantTxt]"  />
				<data:BoundRadioButtonField DataField="Enabled" HeaderText="Enabled" SortExpression="[Enabled]"  />
				<asp:BoundField DataField="CustomerNumberExceptionList" HeaderText="Customer Number Exception List" SortExpression="[CustomerNumberExceptionList]"  />
				<asp:BoundField DataField="WebProductProviderName" HeaderText="Web Product Provider Name" SortExpression="[WebProductProviderName]"  />
				<asp:BoundField DataField="WebProductProviderBranding" HeaderText="Web Product Provider Branding" SortExpression="[WebProductProviderBranding]"  />
				<asp:BoundField DataField="WebSecProductProvider" HeaderText="Web Sec Product Provider" SortExpression="[WebSecProductProvider]"  />
				<data:HyperLinkField HeaderText="Currency Id" DataNavigateUrlFormatString="CurrencyEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="CurrencyIdSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingWholesalerId" HeaderText="Billing Wholesaler Id" SortExpression="[BillingWholesalerID]"  />
				<asp:BoundField DataField="BillingCustomerNumber" HeaderText="Billing Customer Number" SortExpression="[BillingCustomerNumber]"  />
				<data:HyperLinkField HeaderText="Taxable Id" DataNavigateUrlFormatString="TaxableEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="TaxableIdSource" DataTextField="Name" />
				<asp:BoundField DataField="WebSiteUrl" HeaderText="Web Site Url" SortExpression="[WebSiteURL]"  />
				<asp:BoundField DataField="AdminSiteUrl" HeaderText="Admin Site Url" SortExpression="[AdminSiteURL]"  />
				<asp:BoundField DataField="AdminSiteIp" HeaderText="Admin Site Ip" SortExpression="[AdminSiteIP]"  />
				<asp:BoundField DataField="SelfServeUrl" HeaderText="Self Serve Url" SortExpression="[SelfServeURL]"  />
				<asp:BoundField DataField="SelfServeIp" HeaderText="Self Serve Ip" SortExpression="[SelfServeIP]"  />
				<asp:BoundField DataField="WebConferencingUrl" HeaderText="Web Conferencing Url" SortExpression="[WebConferencingURL]"  />
				<asp:BoundField DataField="WebConferencingIp" HeaderText="Web Conferencing Ip" SortExpression="[WebConferencingIP]"  />
				<asp:BoundField DataField="SupportEmail" HeaderText="Support Email" SortExpression="[SupportEmail]"  />
				<asp:BoundField DataField="SupportPhoneNumber" HeaderText="Support Phone Number" SortExpression="[SupportPhoneNumber]"  />
				<data:BoundRadioButtonField DataField="DoRetailBilling" HeaderText="Do Retail Billing" SortExpression="[DoRetailBilling]"  />
				<asp:BoundField DataField="CommissionLockDate" DataFormatString="{0:d}" HtmlEncode="False" HeaderText="Commission Lock Date" SortExpression="[CommissionLockDate]"  />
				<asp:BoundField DataField="PortalId" HeaderText="Portal Id" SortExpression="[PortalID]"  />
				<asp:BoundField DataField="BillingAddress1" HeaderText="Billing Address1" SortExpression="[BillingAddress1]"  />
				<asp:BoundField DataField="BillingAddress2" HeaderText="Billing Address2" SortExpression="[BillingAddress2]"  />
				<asp:BoundField DataField="BillingCity" HeaderText="Billing City" SortExpression="[BillingCity]"  />
				<data:HyperLinkField HeaderText="Billing Country" DataNavigateUrlFormatString="CountryEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingCountrySource" DataTextField="Description" />
				<data:HyperLinkField HeaderText="Billing Region" DataNavigateUrlFormatString="StateEdit.aspx?Id={0}" DataNavigateUrlFields="Id" DataContainer="BillingRegionSource" DataTextField="LongName" />
				<asp:BoundField DataField="BillingPostalCode" HeaderText="Billing Postal Code" SortExpression="[BillingPostalCode]"  />
			</Columns>
			<EmptyDataTemplate>
				<b>No Wholesaler Found!</b>
			</EmptyDataTemplate>
		</data:EntityGridView>
		<br />
		<asp:Button runat="server" ID="btnWholesaler" OnClientClick="javascript:location.href='WholesalerEdit.aspx'; return false;" Text="Add New" Visible="false"></asp:Button>
	</ContentTemplate>
	</asp:UpdatePanel>	
		<data:WholesalerDataSource ID="WholesalerDataSource" runat="server"
			SelectMethod="GetPaged"
			EnablePaging="True"
			EnableSorting="True"
			EnableDeepLoad="True"
			>
			<DeepLoadProperties Method="IncludeChildren" Recursive="False">
	            <Types>
					<data:WholesalerProperty Name="Taxable"/> 
					<data:WholesalerProperty Name="Currency"/> 
					<data:WholesalerProperty Name="Country"/> 
					<data:WholesalerProperty Name="State"/> 
					<%--<data:WholesalerProperty Name="EmailTemplatesCollection" />--%>
					<%--<data:WholesalerProperty Name="LanguageIdLanguageCollection_From_IrWholesaler" />--%>
					<%--<data:WholesalerProperty Name="VerticalCollection" />--%>
					<%--<data:WholesalerProperty Name="CustomerTransactionCollection" />--%>
					<%--<data:WholesalerProperty Name="CommissionRuleCollection" />--%>
					<%--<data:WholesalerProperty Name="CommissionCollection" />--%>
					<%--<data:WholesalerProperty Name="DepartmentCollection" />--%>
					<%--<data:WholesalerProperty Name="RatedCdrCollection" />--%>
					<%--<data:WholesalerProperty Name="Wholesaler_ProductCollection" />--%>
					<%--<data:WholesalerProperty Name="ProductRateValueCollection" />--%>
					<%--<data:WholesalerProperty Name="DnisCollection" />--%>
					<%--<data:WholesalerProperty Name="CustomerCollection" />--%>
					<%--<data:WholesalerProperty Name="CommissionAdjustmentCollection" />--%>
					<%--<data:WholesalerProperty Name="IrWholesalerCollection" />--%>
					<%--<data:WholesalerProperty Name="LeadCollection" />--%>
					<%--<data:WholesalerProperty Name="SalesPersonCollection" />--%>
					<%--<data:WholesalerProperty Name="CustomerDocumentCollection" />--%>
					<%--<data:WholesalerProperty Name="CompanyCollection" />--%>
					<%--<data:WholesalerProperty Name="TicketCollection" />--%>
				</Types>
			</DeepLoadProperties>
			<Parameters>
				<data:CustomParameter Name="WhereClause" Value="" ConvertEmptyStringToNull="false" />
				<data:CustomParameter Name="OrderByClause" Value="" ConvertEmptyStringToNull="false" />
				<asp:ControlParameter Name="PageIndex" ControlID="GridView1" PropertyName="PageIndex" Type="Int32" />
				<asp:ControlParameter Name="PageSize" ControlID="GridView1" PropertyName="PageSize" Type="Int32" />
				<data:CustomParameter Name="RecordCount" Value="0" Type="Int32" />
			</Parameters>
		</data:WholesalerDataSource>
	    		
</asp:Content>



