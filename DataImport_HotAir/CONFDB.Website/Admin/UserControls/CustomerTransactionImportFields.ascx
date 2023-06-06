<%@ Control Language="C#" ClassName="CustomerTransactionImportFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecCustomerNumber" Text='<%# Bind("SecCustomerNumber") %>' MaxLength="6"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionDate" runat="server" Text="Transaction Date:" AssociatedControlID="dataTransactionDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionDate" Text='<%# Bind("TransactionDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataTransactionDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataTransactionDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataTransactionDate" id="calext_dataTransactionDate" /><asp:RequiredFieldValidator ID="ReqVal_dataTransactionDate" runat="server" Display="Dynamic" ControlToValidate="dataTransactionDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionAmount" runat="server" Text="Transaction Amount:" AssociatedControlID="dataTransactionAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionAmount" Text='<%# Bind("TransactionAmount") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTransactionAmount" runat="server" Display="Dynamic" ControlToValidate="dataTransactionAmount" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTransactionAmount" runat="server" Display="Dynamic" ControlToValidate="dataTransactionAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionDescription" runat="server" Text="Transaction Description:" AssociatedControlID="dataTransactionDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionDescription" Text='<%# Bind("TransactionDescription") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerTransactionTypeId" runat="server" Text="Customer Transaction Type Id:" AssociatedControlID="dataCustomerTransactionTypeId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerTransactionTypeId" Text='<%# Bind("CustomerTransactionTypeId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerTransactionTypeId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerTransactionTypeId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerTransactionTypeId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerTransactionTypeId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesaler_ProductId" runat="server" Text="Wholesaler Product Id:" AssociatedControlID="dataWholesaler_ProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesaler_ProductId" Text='<%# Bind("Wholesaler_ProductId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWholesaler_ProductId" runat="server" Display="Dynamic" ControlToValidate="dataWholesaler_ProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate Id:" AssociatedControlID="dataProductRateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductRateId" Text='<%# Bind("ProductRateId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataProductRateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataQuantity" runat="server" Text="Quantity:" AssociatedControlID="dataQuantity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataQuantity" Text='<%# Bind("Quantity") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataQuantity" runat="server" Display="Dynamic" ControlToValidate="dataQuantity" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSellRate" runat="server" Text="Sell Rate:" AssociatedControlID="dataSellRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSellRate" Text='<%# Bind("SellRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataSellRate" runat="server" Display="Dynamic" ControlToValidate="dataSellRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBuyRate" runat="server" Text="Buy Rate:" AssociatedControlID="dataBuyRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBuyRate" Text='<%# Bind("BuyRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBuyRate" runat="server" Display="Dynamic" ControlToValidate="dataBuyRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWsTransactionAmount" runat="server" Text="Ws Transaction Amount:" AssociatedControlID="dataWsTransactionAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWsTransactionAmount" Text='<%# Bind("WsTransactionAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWsTransactionAmount" runat="server" Display="Dynamic" ControlToValidate="dataWsTransactionAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModifiedBy" runat="server" Text="Modified By:" AssociatedControlID="dataModifiedBy" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModifiedBy" Text='<%# Bind("ModifiedBy") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreatedDate" runat="server" Text="Created Date:" AssociatedControlID="dataCreatedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreatedDate" Text='<%# Bind("CreatedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreatedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreatedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreatedDate" id="calext_dataCreatedDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostedToCustTrans" runat="server" Text="Posted To Cust Trans:" AssociatedControlID="dataPostedToCustTrans" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPostedToCustTrans" SelectedValue='<%# Bind("PostedToCustTrans") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostedToCustTransDate" runat="server" Text="Posted To Cust Trans Date:" AssociatedControlID="dataPostedToCustTransDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostedToCustTransDate" Text='<%# Bind("PostedToCustTransDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPostedToCustTransDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataPostedToCustTransDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataPostedToCustTransDate" id="calext_dataPostedToCustTransDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataImportType" runat="server" Text="Import Type:" AssociatedControlID="dataImportType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataImportType" Text='<%# Bind("ImportType") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataErrorCodesId" runat="server" Text="Error Codes Id:" AssociatedControlID="dataErrorCodesId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataErrorCodesId" Text='<%# Bind("ErrorCodesId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataErrorCodesId" runat="server" Display="Dynamic" ControlToValidate="dataErrorCodesId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataErrorCodesId" runat="server" Display="Dynamic" ControlToValidate="dataErrorCodesId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataReferenceNumber" runat="server" Text="Reference Number:" AssociatedControlID="dataReferenceNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataReferenceNumber" Text='<%# Bind("ReferenceNumber") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUniqueConferenceId" runat="server" Text="Unique Conference Id:" AssociatedControlID="dataUniqueConferenceId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUniqueConferenceId" Text='<%# Bind("UniqueConferenceId") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalTaxRate" runat="server" Text="Local Tax Rate:" AssociatedControlID="dataLocalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalTaxRate" Text='<%# Bind("LocalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLocalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataLocalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFederalTaxRate" runat="server" Text="Federal Tax Rate:" AssociatedControlID="dataFederalTaxRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFederalTaxRate" Text='<%# Bind("FederalTaxRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFederalTaxRate" runat="server" Display="Dynamic" ControlToValidate="dataFederalTaxRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalTaxAmount" runat="server" Text="Local Tax Amount:" AssociatedControlID="dataLocalTaxAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalTaxAmount" Text='<%# Bind("LocalTaxAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLocalTaxAmount" runat="server" Display="Dynamic" ControlToValidate="dataLocalTaxAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFederalTaxAmount" runat="server" Text="Federal Tax Amount:" AssociatedControlID="dataFederalTaxAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFederalTaxAmount" Text='<%# Bind("FederalTaxAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFederalTaxAmount" runat="server" Display="Dynamic" ControlToValidate="dataFederalTaxAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataElapsedTimeSeconds" runat="server" Text="Elapsed Time Seconds:" AssociatedControlID="dataElapsedTimeSeconds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataElapsedTimeSeconds" Text='<%# Bind("ElapsedTimeSeconds") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataElapsedTimeSeconds" runat="server" Display="Dynamic" ControlToValidate="dataElapsedTimeSeconds" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


