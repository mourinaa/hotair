<%@ Control Language="C#" ClassName="BillableLegsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:HiddenField runat="server" id="dataId" Value='<%# Bind("Id") %>'></asp:HiddenField>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataConferenceId" runat="server" Text="Conference Id:" AssociatedControlID="dataConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataConferenceId" Text='<%# Bind("ConferenceId") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataConferenceId" runat="server" Display="Dynamic" ControlToValidate="dataConferenceId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorCode" runat="server" Text="Moderator Code:" AssociatedControlID="dataModeratorCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorCode" Text='<%# Bind("ModeratorCode") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataModeratorCode" runat="server" Display="Dynamic" ControlToValidate="dataModeratorCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPassCode" runat="server" Text="Pass Code:" AssociatedControlID="dataPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPassCode" Text='<%# Bind("PassCode") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPassCode" runat="server" Display="Dynamic" ControlToValidate="dataPassCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorName" runat="server" Text="Moderator Name:" AssociatedControlID="dataModeratorName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorName" Text='<%# Bind("ModeratorName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModerator" runat="server" Text="Moderator:" AssociatedControlID="dataModerator" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModerator" Text='<%# Bind("Moderator") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataModerator" runat="server" Display="Dynamic" ControlToValidate="dataModerator" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataModerator" runat="server" Display="Dynamic" ControlToValidate="dataModerator" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExternalCustomerNumber" runat="server" Text="External Customer Number:" AssociatedControlID="dataExternalCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExternalCustomerNumber" Text='<%# Bind("ExternalCustomerNumber") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExternalModeratorNumber" runat="server" Text="External Moderator Number:" AssociatedControlID="dataExternalModeratorNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExternalModeratorNumber" Text='<%# Bind("ExternalModeratorNumber") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReferenceNumber" runat="server" Text="Reference Number:" AssociatedControlID="dataReferenceNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReferenceNumber" Text='<%# Bind("ReferenceNumber") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartTime" runat="server" Text="Start Time:" AssociatedControlID="dataStartTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartTime" Text='<%# Bind("StartTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataStartTime" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataStartTime" id="calext_dataStartTime" /><asp:RequiredFieldValidator ID="ReqVal_dataStartTime" runat="server" Display="Dynamic" ControlToValidate="dataStartTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndTime" runat="server" Text="End Time:" AssociatedControlID="dataEndTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndTime" Text='<%# Bind("EndTime", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndTime" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataEndTime" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataEndTime" id="calext_dataEndTime" /><asp:RequiredFieldValidator ID="ReqVal_dataEndTime" runat="server" Display="Dynamic" ControlToValidate="dataEndTime" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataElapsedTime" runat="server" Text="Elapsed Time:" AssociatedControlID="dataElapsedTime" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataElapsedTime" Text='<%# Bind("ElapsedTime") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataElapsedTime" runat="server" Display="Dynamic" ControlToValidate="dataElapsedTime" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataElapsedTime" runat="server" Display="Dynamic" ControlToValidate="dataElapsedTime" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBridgeId" runat="server" Text="Bridge Id:" AssociatedControlID="dataBridgeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBridgeId" Text='<%# Bind("BridgeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBridgeId" runat="server" Display="Dynamic" ControlToValidate="dataBridgeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBridgeId" runat="server" Display="Dynamic" ControlToValidate="dataBridgeId" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueConferenceId" runat="server" Text="Unique Conference Id:" AssociatedControlID="dataUniqueConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUniqueConferenceId" Text='<%# Bind("UniqueConferenceId") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAuxiliaryConferenceId" runat="server" Text="Auxiliary Conference Id:" AssociatedControlID="dataAuxiliaryConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAuxiliaryConferenceId" Text='<%# Bind("AuxiliaryConferenceId") %>' MaxLength="40"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDnis" runat="server" Text="Dnis:" AssociatedControlID="dataDnis" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDnis" Text='<%# Bind("Dnis") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDialNumber" runat="server" Text="Dial Number:" AssociatedControlID="dataDialNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDialNumber" Text='<%# Bind("DialNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAni" runat="server" Text="Ani:" AssociatedControlID="dataAni" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAni" Text='<%# Bind("Ani") %>' MaxLength="36"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataParticipantName" runat="server" Text="Participant Name:" AssociatedControlID="dataParticipantName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataParticipantName" Text='<%# Bind("ParticipantName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDestination" runat="server" Text="Destination:" AssociatedControlID="dataDestination" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDestination" Text='<%# Bind("Destination") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAccessTypeId" runat="server" Text="Access Type Id:" AssociatedControlID="dataAccessTypeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAccessTypeId" Text='<%# Bind("AccessTypeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAccessTypeId" runat="server" Display="Dynamic" ControlToValidate="dataAccessTypeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAccessTypeId" runat="server" Display="Dynamic" ControlToValidate="dataAccessTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataConnectProductRateId" runat="server" Text="Connect Product Rate Id:" AssociatedControlID="dataConnectProductRateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataConnectProductRateId" Text='<%# Bind("ConnectProductRateId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataConnectProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataConnectProductRateId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataConnectProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataConnectProductRateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBridgeProductRateId" runat="server" Text="Bridge Product Rate Id:" AssociatedControlID="dataBridgeProductRateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBridgeProductRateId" Text='<%# Bind("BridgeProductRateId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBridgeProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataBridgeProductRateId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBridgeProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataBridgeProductRateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLdProductRateId" runat="server" Text="Ld Product Rate Id:" AssociatedControlID="dataLdProductRateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLdProductRateId" Text='<%# Bind("LdProductRateId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLdProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataLdProductRateId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLdProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataLdProductRateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateTaxableValue" runat="server" Text="Product Rate Taxable Value:" AssociatedControlID="dataProductRateTaxableValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductRateTaxableValue" Text='<%# Bind("ProductRateTaxableValue") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProductRateTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataProductRateTaxableValue" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProductRateTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataProductRateTaxableValue" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerTaxableValue" runat="server" Text="Customer Taxable Value:" AssociatedControlID="dataCustomerTaxableValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerTaxableValue" Text='<%# Bind("CustomerTaxableValue") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataCustomerTaxableValue" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataCustomerTaxableValue" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTaxableValue" runat="server" Text="Ws Taxable Value:" AssociatedControlID="dataWsTaxableValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTaxableValue" Text='<%# Bind("WsTaxableValue") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWsTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataWsTaxableValue" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataWsTaxableValue" runat="server" Display="Dynamic" ControlToValidate="dataWsTaxableValue" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailConnectCharge" runat="server" Text="Retail Connect Charge:" AssociatedControlID="dataRetailConnectCharge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailConnectCharge" Text='<%# Bind("RetailConnectCharge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailConnectCharge" runat="server" Display="Dynamic" ControlToValidate="dataRetailConnectCharge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailBridgeRate" runat="server" Text="Retail Bridge Rate:" AssociatedControlID="dataRetailBridgeRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailBridgeRate" Text='<%# Bind("RetailBridgeRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailBridgeRate" runat="server" Display="Dynamic" ControlToValidate="dataRetailBridgeRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailLdRate" runat="server" Text="Retail Ld Rate:" AssociatedControlID="dataRetailLdRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailLdRate" Text='<%# Bind("RetailLdRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailLdRate" runat="server" Display="Dynamic" ControlToValidate="dataRetailLdRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailCurrency" runat="server" Text="Retail Currency:" AssociatedControlID="dataRetailCurrency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailCurrency" Text='<%# Bind("RetailCurrency") %>' MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailBillingInterval" runat="server" Text="Retail Billing Interval:" AssociatedControlID="dataRetailBillingInterval" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailBillingInterval" Text='<%# Bind("RetailBillingInterval") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataRetailBillingInterval" runat="server" Display="Dynamic" ControlToValidate="dataRetailBillingInterval" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataRetailBillingInterval" runat="server" Display="Dynamic" ControlToValidate="dataRetailBillingInterval" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailTotalConnectCharge" runat="server" Text="Retail Total Connect Charge:" AssociatedControlID="dataRetailTotalConnectCharge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailTotalConnectCharge" Text='<%# Bind("RetailTotalConnectCharge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailTotalConnectCharge" runat="server" Display="Dynamic" ControlToValidate="dataRetailTotalConnectCharge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailTotalBridge" runat="server" Text="Retail Total Bridge:" AssociatedControlID="dataRetailTotalBridge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailTotalBridge" Text='<%# Bind("RetailTotalBridge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailTotalBridge" runat="server" Display="Dynamic" ControlToValidate="dataRetailTotalBridge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailTotalLd" runat="server" Text="Retail Total Ld:" AssociatedControlID="dataRetailTotalLd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailTotalLd" Text='<%# Bind("RetailTotalLd") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailTotalLd" runat="server" Display="Dynamic" ControlToValidate="dataRetailTotalLd" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailTotal" runat="server" Text="Retail Total:" AssociatedControlID="dataRetailTotal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailTotal" Text='<%# Bind("RetailTotal") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailTotal" runat="server" Display="Dynamic" ControlToValidate="dataRetailTotal" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailLocalTaxRate" runat="server" Text="Retail Local Tax Rate:" AssociatedControlID="dataRetailLocalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailLocalTaxRate" Text='<%# Bind("RetailLocalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailLocalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataRetailLocalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailFederalTaxRate" runat="server" Text="Retail Federal Tax Rate:" AssociatedControlID="dataRetailFederalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailFederalTaxRate" Text='<%# Bind("RetailFederalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailFederalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataRetailFederalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailLocalTax" runat="server" Text="Retail Local Tax:" AssociatedControlID="dataRetailLocalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailLocalTax" Text='<%# Bind("RetailLocalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailLocalTax" runat="server" Display="Dynamic" ControlToValidate="dataRetailLocalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailFederalTax" runat="server" Text="Retail Federal Tax:" AssociatedControlID="dataRetailFederalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailFederalTax" Text='<%# Bind("RetailFederalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailFederalTax" runat="server" Display="Dynamic" ControlToValidate="dataRetailFederalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRetailTotalTax" runat="server" Text="Retail Total Tax:" AssociatedControlID="dataRetailTotalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRetailTotalTax" Text='<%# Bind("RetailTotalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataRetailTotalTax" runat="server" Display="Dynamic" ControlToValidate="dataRetailTotalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsConnectCharge" runat="server" Text="Ws Connect Charge:" AssociatedControlID="dataWsConnectCharge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsConnectCharge" Text='<%# Bind("WsConnectCharge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsConnectCharge" runat="server" Display="Dynamic" ControlToValidate="dataWsConnectCharge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsBridgeRate" runat="server" Text="Ws Bridge Rate:" AssociatedControlID="dataWsBridgeRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsBridgeRate" Text='<%# Bind("WsBridgeRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsBridgeRate" runat="server" Display="Dynamic" ControlToValidate="dataWsBridgeRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsldRate" runat="server" Text="Wsld Rate:" AssociatedControlID="dataWsldRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsldRate" Text='<%# Bind("WsldRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsldRate" runat="server" Display="Dynamic" ControlToValidate="dataWsldRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsCurrency" runat="server" Text="Ws Currency:" AssociatedControlID="dataWsCurrency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsCurrency" Text='<%# Bind("WsCurrency") %>' MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsBillingInterval" runat="server" Text="Ws Billing Interval:" AssociatedControlID="dataWsBillingInterval" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsBillingInterval" Text='<%# Bind("WsBillingInterval") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWsBillingInterval" runat="server" Display="Dynamic" ControlToValidate="dataWsBillingInterval" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataWsBillingInterval" runat="server" Display="Dynamic" ControlToValidate="dataWsBillingInterval" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTotalConnectCharge" runat="server" Text="Ws Total Connect Charge:" AssociatedControlID="dataWsTotalConnectCharge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTotalConnectCharge" Text='<%# Bind("WsTotalConnectCharge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTotalConnectCharge" runat="server" Display="Dynamic" ControlToValidate="dataWsTotalConnectCharge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTotalBridge" runat="server" Text="Ws Total Bridge:" AssociatedControlID="dataWsTotalBridge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTotalBridge" Text='<%# Bind("WsTotalBridge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTotalBridge" runat="server" Display="Dynamic" ControlToValidate="dataWsTotalBridge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTotalLd" runat="server" Text="Ws Total Ld:" AssociatedControlID="dataWsTotalLd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTotalLd" Text='<%# Bind("WsTotalLd") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTotalLd" runat="server" Display="Dynamic" ControlToValidate="dataWsTotalLd" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTotal" runat="server" Text="Ws Total:" AssociatedControlID="dataWsTotal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTotal" Text='<%# Bind("WsTotal") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTotal" runat="server" Display="Dynamic" ControlToValidate="dataWsTotal" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsLocalTaxRate" runat="server" Text="Ws Local Tax Rate:" AssociatedControlID="dataWsLocalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsLocalTaxRate" Text='<%# Bind("WsLocalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsLocalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataWsLocalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsFederalTaxRate" runat="server" Text="Ws Federal Tax Rate:" AssociatedControlID="dataWsFederalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsFederalTaxRate" Text='<%# Bind("WsFederalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsFederalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataWsFederalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsLocalTax" runat="server" Text="Ws Local Tax:" AssociatedControlID="dataWsLocalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsLocalTax" Text='<%# Bind("WsLocalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsLocalTax" runat="server" Display="Dynamic" ControlToValidate="dataWsLocalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsFederalTax" runat="server" Text="Ws Federal Tax:" AssociatedControlID="dataWsFederalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsFederalTax" Text='<%# Bind("WsFederalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsFederalTax" runat="server" Display="Dynamic" ControlToValidate="dataWsFederalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTotalTax" runat="server" Text="Ws Total Tax:" AssociatedControlID="dataWsTotalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTotalTax" Text='<%# Bind("WsTotalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTotalTax" runat="server" Display="Dynamic" ControlToValidate="dataWsTotalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBillingStatus" runat="server" Text="Billing Status:" AssociatedControlID="dataBillingStatus" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBillingStatus" Text='<%# Bind("BillingStatus") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBillingStatus" runat="server" Display="Dynamic" ControlToValidate="dataBillingStatus" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBilledDate" runat="server" Text="Billed Date:" AssociatedControlID="dataBilledDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBilledDate" Text='<%# Bind("BilledDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBilledDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataBilledDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataBilledDate" id="calext_dataBilledDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProcessedDate" runat="server" Text="Processed Date:" AssociatedControlID="dataProcessedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProcessedDate" Text='<%# Bind("ProcessedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataProcessedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataProcessedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataProcessedDate" id="calext_dataProcessedDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRatedToZero" runat="server" Text="Rated To Zero:" AssociatedControlID="dataRatedToZero" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataRatedToZero" SelectedValue='<%# Bind("RatedToZero") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductName" runat="server" Text="Product Name:" AssociatedControlID="dataProductName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductName" Text='<%# Bind("ProductName") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductNameAlt" runat="server" Text="Product Name Alt:" AssociatedControlID="dataProductNameAlt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductNameAlt" Text='<%# Bind("ProductNameAlt") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


