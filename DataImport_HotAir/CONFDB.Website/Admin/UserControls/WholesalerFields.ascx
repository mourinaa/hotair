<%@ Control Language="C#" ClassName="WholesalerFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataId" Text='<%# Bind("Id") %>' MaxLength="10" ReadOnly="true"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyName" runat="server" Text="Company Name:" AssociatedControlID="dataCompanyName" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataCompanyName" Text='<%# Bind("CompanyName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompanyShortName" runat="server" Text="Company Short Name:" AssociatedControlID="dataCompanyShortName" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataCompanyShortName" Text='<%# Bind("CompanyShortName") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailPriCustomerNumber" runat="server" Text="Retail Pri Customer Number:" AssociatedControlID="dataRetailPriCustomerNumber" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataRetailPriCustomerNumber" Text='<%# Bind("RetailPriCustomerNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailPriCustomerNumberLikeExp" runat="server" Text="Retail Pri Customer Number Like Exp:" AssociatedControlID="dataRetailPriCustomerNumberLikeExp" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataRetailPriCustomerNumberLikeExp" Text='<%# Bind("RetailPriCustomerNumberLikeExp") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultModCodeLength" runat="server" Text="Default Mod Code Length:" AssociatedControlID="dataDefaultModCodeLength" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataDefaultModCodeLength" Text='<%# Bind("DefaultModCodeLength") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDefaultModCodeLength" runat="server" Display="Dynamic" ControlToValidate="dataDefaultModCodeLength" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultPassCodeLength" runat="server" Text="Default Pass Code Length:" AssociatedControlID="dataDefaultPassCodeLength" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataDefaultPassCodeLength" Text='<%# Bind("DefaultPassCodeLength") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDefaultPassCodeLength" runat="server" Display="Dynamic" ControlToValidate="dataDefaultPassCodeLength" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultPasswordLength" runat="server" Text="Default Password Length:" AssociatedControlID="dataDefaultPasswordLength" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataDefaultPasswordLength" Text='<%# Bind("DefaultPasswordLength") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDefaultPasswordLength" runat="server" Display="Dynamic" ControlToValidate="dataDefaultPasswordLength" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultCapsOk" runat="server" Text="Default Caps Ok:" AssociatedControlID="dataDefaultCapsOk" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataDefaultCapsOk" SelectedValue='<%# Bind("DefaultCapsOk") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorTxt" runat="server" Text="Moderator Txt:" AssociatedControlID="dataModeratorTxt" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataModeratorTxt" Text='<%# Bind("ModeratorTxt") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataParticipantTxt" runat="server" Text="Participant Txt:" AssociatedControlID="dataParticipantTxt" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataParticipantTxt" Text='<%# Bind("ParticipantTxt") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
<%--			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerNumberExceptionList" runat="server" Text="Customer Number Exception List:" AssociatedControlID="dataCustomerNumberExceptionList" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataCustomerNumberExceptionList" Text='<%# Bind("CustomerNumberExceptionList") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
--%>
        <td class="literal"><asp:Label ID="lbldataWebProductProviderName" runat="server" Text="Web Product Provider Name:" AssociatedControlID="dataWebProductProviderName" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebProductProviderName" Text='<%# Bind("WebProductProviderName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebProductProviderBranding" runat="server" Text="Web Product Provider Branding:" AssociatedControlID="dataWebProductProviderBranding" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebProductProviderBranding" Text='<%# Bind("WebProductProviderBranding") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebSecProductProvider" runat="server" Text="Web Sec Product Provider:" AssociatedControlID="dataWebSecProductProvider" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebSecProductProvider" Text='<%# Bind("WebSecProductProvider") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency Id:" AssociatedControlID="dataCurrencyId" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataCurrencyId" DataSourceID="CurrencyIdCurrencyDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("CurrencyId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CurrencyDataSource ID="CurrencyIdCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingWholesalerId" runat="server" Text="Billing Wholesaler Id:" AssociatedControlID="dataBillingWholesalerId" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingWholesalerId" Text='<%# Bind("BillingWholesalerId") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingCustomerNumber" runat="server" Text="Billing Customer Number:" AssociatedControlID="dataBillingCustomerNumber" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingCustomerNumber" Text='<%# Bind("BillingCustomerNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTaxableId" runat="server" Text="Taxable Id:" AssociatedControlID="dataTaxableId" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataTaxableId" DataSourceID="TaxableIdTaxableDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("TaxableId") %>' AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:TaxableDataSource ID="TaxableIdTaxableDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebSiteUrl" runat="server" Text="Web Site Url:" AssociatedControlID="dataWebSiteUrl" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebSiteUrl" Text='<%# Bind("WebSiteUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdminSiteUrl" runat="server" Text="Admin Site Url:" AssociatedControlID="dataAdminSiteUrl" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataAdminSiteUrl" Text='<%# Bind("AdminSiteUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAdminSiteIp" runat="server" Text="Admin Site Ip:" AssociatedControlID="dataAdminSiteIp" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataAdminSiteIp" Text='<%# Bind("AdminSiteIp") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSelfServeUrl" runat="server" Text="Self Serve Url:" AssociatedControlID="dataSelfServeUrl" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataSelfServeUrl" Text='<%# Bind("SelfServeUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSelfServeIp" runat="server" Text="Self Serve Ip:" AssociatedControlID="dataSelfServeIp" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataSelfServeIp" Text='<%# Bind("SelfServeIp") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebConferencingUrl" runat="server" Text="Web Conferencing Url:" AssociatedControlID="dataWebConferencingUrl" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebConferencingUrl" Text='<%# Bind("WebConferencingUrl") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWebConferencingIp" runat="server" Text="Web Conferencing Ip:" AssociatedControlID="dataWebConferencingIp" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataWebConferencingIp" Text='<%# Bind("WebConferencingIp") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSupportEmail" runat="server" Text="Support Email:" AssociatedControlID="dataSupportEmail" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataSupportEmail" Text='<%# Bind("SupportEmail") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSupportPhoneNumber" runat="server" Text="Support Phone Number:" AssociatedControlID="dataSupportPhoneNumber" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataSupportPhoneNumber" Text='<%# Bind("SupportPhoneNumber") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDoRetailBilling" runat="server" Text="Do Retail Billing:" AssociatedControlID="dataDoRetailBilling" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataDoRetailBilling" SelectedValue='<%# Bind("DoRetailBilling") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCommissionLockDate" runat="server" Text="Commission Lock Date:" AssociatedControlID="dataCommissionLockDate" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataCommissionLockDate" Text='<%# Bind("CommissionLockDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCommissionLockDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCommissionLockDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCommissionLockDate" id="calext_dataCommissionLockDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPortalId" runat="server" Text="Portal Id:" AssociatedControlID="dataPortalId" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataPortalId" Text='<%# Bind("PortalId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPortalId" runat="server" Display="Dynamic" ControlToValidate="dataPortalId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingAddress1" runat="server" Text="Billing Address1:" AssociatedControlID="dataBillingAddress1" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingAddress1" Text='<%# Bind("BillingAddress1") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingAddress2" runat="server" Text="Billing Address2:" AssociatedControlID="dataBillingAddress2" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingAddress2" Text='<%# Bind("BillingAddress2") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingCity" runat="server" Text="Billing City:" AssociatedControlID="dataBillingCity" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingCity" Text='<%# Bind("BillingCity") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingCountry" runat="server" Text="Billing Country:" AssociatedControlID="dataBillingCountry" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataBillingCountry" DataSourceID="BillingCountryCountryDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("BillingCountry") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CountryDataSource ID="BillingCountryCountryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingRegion" runat="server" Text="Billing Region:" AssociatedControlID="dataBillingRegion" /></td>
        <td>
					<data:EntityDropDownList Width="305px" runat="server" ID="dataBillingRegion" DataSourceID="BillingRegionStateDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("BillingRegion") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:StateDataSource ID="BillingRegionStateDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingPostalCode" runat="server" Text="Billing Postal Code:" AssociatedControlID="dataBillingPostalCode" /></td>
        <td>
					<asp:TextBox Width="300px" runat="server" ID="dataBillingPostalCode" Text='<%# Bind("BillingPostalCode") %>' MaxLength="20"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


