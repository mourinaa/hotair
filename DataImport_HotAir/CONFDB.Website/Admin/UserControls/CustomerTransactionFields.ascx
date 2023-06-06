<%@ Control Language="C#" ClassName="CustomerTransactionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataCustomerTransactionTypeId" runat="server" Text="Customer Transaction Type Id:" AssociatedControlID="dataCustomerTransactionTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerTransactionTypeId" DataSourceID="CustomerTransactionTypeIdCustomerTransactionTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CustomerTransactionTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerTransactionTypeDataSource ID="CustomerTransactionTypeIdCustomerTransactionTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTransactionDescription" runat="server" Text="Transaction Description:" AssociatedControlID="dataTransactionDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionDescription" Text='<%# Bind("TransactionDescription") %>' MaxLength="100"></asp:TextBox>
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
					<asp:TextBox runat="server" ID="dataTransactionAmount" Text='<%# Bind("TransactionAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTransactionAmount" runat="server" Display="Dynamic" ControlToValidate="dataTransactionAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataTransactionTotal" runat="server" Text="Transaction Total:" AssociatedControlID="dataTransactionTotal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTransactionTotal" Text='<%# Bind("TransactionTotal") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTransactionTotal" runat="server" Display="Dynamic" ControlToValidate="dataTransactionTotal" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerBalance" runat="server" Text="Customer Balance:" AssociatedControlID="dataCustomerBalance" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerBalance" Text='<%# Bind("CustomerBalance") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCustomerBalance" runat="server" Display="Dynamic" ControlToValidate="dataCustomerBalance" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesaler_ProductId" runat="server" Text="Wholesaler Product Id:" AssociatedControlID="dataWholesaler_ProductId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesaler_ProductId" DataSourceID="Wholesaler_ProductIdWholesaler_ProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("Wholesaler_ProductId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:Wholesaler_ProductDataSource ID="Wholesaler_ProductIdWholesaler_ProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate Id:" AssociatedControlID="dataProductRateId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductRateId" DataSourceID="ProductRateIdProductRateDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductRateId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:ProductRateDataSource ID="ProductRateIdProductRateDataSource" runat="server" SelectMethod="GetAll"  />
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
        <td class="literal"><asp:Label ID="lbldataPostedDate" runat="server" Text="Posted Date:" AssociatedControlID="dataPostedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostedDate" Text='<%# Bind("PostedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPostedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataPostedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataPostedDate" id="calext_dataPostedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataPostedDate" runat="server" Display="Dynamic" ControlToValidate="dataPostedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
        <td class="literal"><asp:Label ID="lbldataPostedToInvoice" runat="server" Text="Posted To Invoice:" AssociatedControlID="dataPostedToInvoice" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataPostedToInvoice" SelectedValue='<%# Bind("PostedToInvoice") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPostedToInvoiceDate" runat="server" Text="Posted To Invoice Date:" AssociatedControlID="dataPostedToInvoiceDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPostedToInvoiceDate" Text='<%# Bind("PostedToInvoiceDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPostedToInvoiceDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataPostedToInvoiceDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataPostedToInvoiceDate" id="calext_dataPostedToInvoiceDate" />
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


