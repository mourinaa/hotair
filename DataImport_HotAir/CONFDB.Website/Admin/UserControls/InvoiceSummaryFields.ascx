<%@ Control Language="C#" ClassName="InvoiceSummaryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataStartDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataStartDate" id="calext_dataStartDate" /><asp:RequiredFieldValidator ID="ReqVal_dataStartDate" runat="server" Display="Dynamic" ControlToValidate="dataStartDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEndDate" runat="server" Text="End Date:" AssociatedControlID="dataEndDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEndDate" Text='<%# Bind("EndDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataEndDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataEndDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataEndDate" id="calext_dataEndDate" /><asp:RequiredFieldValidator ID="ReqVal_dataEndDate" runat="server" Display="Dynamic" ControlToValidate="dataEndDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
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
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPriCustomerNumber" runat="server" Display="Dynamic" ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInvoiceNumber" runat="server" Text="Invoice Number:" AssociatedControlID="dataInvoiceNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInvoiceNumber" Text='<%# Bind("InvoiceNumber") %>' MaxLength="30"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataInvoiceNumber" runat="server" Display="Dynamic" ControlToValidate="dataInvoiceNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAmountOfLastBill" runat="server" Text="Amount Of Last Bill:" AssociatedControlID="dataAmountOfLastBill" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAmountOfLastBill" Text='<%# Bind("AmountOfLastBill") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAmountOfLastBill" runat="server" Display="Dynamic" ControlToValidate="dataAmountOfLastBill" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPayment1" runat="server" Text="Payment1:" AssociatedControlID="dataPayment1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPayment1" Text='<%# Bind("Payment1") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPayment1" runat="server" Display="Dynamic" ControlToValidate="dataPayment1" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalCredits" runat="server" Text="Total Credits:" AssociatedControlID="dataTotalCredits" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalCredits" Text='<%# Bind("TotalCredits") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalCredits" runat="server" Display="Dynamic" ControlToValidate="dataTotalCredits" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalLatePaymentCharges" runat="server" Text="Total Late Payment Charges:" AssociatedControlID="dataTotalLatePaymentCharges" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalLatePaymentCharges" Text='<%# Bind("TotalLatePaymentCharges") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalLatePaymentCharges" runat="server" Display="Dynamic" ControlToValidate="dataTotalLatePaymentCharges" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBalForward" runat="server" Text="Bal Forward:" AssociatedControlID="dataBalForward" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBalForward" Text='<%# Bind("BalForward") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBalForward" runat="server" Display="Dynamic" ControlToValidate="dataBalForward" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductCharges" runat="server" Text="Product Charges:" AssociatedControlID="dataProductCharges" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductCharges" Text='<%# Bind("ProductCharges") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataProductCharges" runat="server" Display="Dynamic" ControlToValidate="dataProductCharges" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMiscCharges" runat="server" Text="Misc Charges:" AssociatedControlID="dataMiscCharges" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMiscCharges" Text='<%# Bind("MiscCharges") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMiscCharges" runat="server" Display="Dynamic" ControlToValidate="dataMiscCharges" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataTotalCurrent" runat="server" Text="Total Current:" AssociatedControlID="dataTotalCurrent" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalCurrent" Text='<%# Bind("TotalCurrent") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalCurrent" runat="server" Display="Dynamic" ControlToValidate="dataTotalCurrent" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBalanceForward" runat="server" Text="Balance Forward:" AssociatedControlID="dataBalanceForward" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBalanceForward" Text='<%# Bind("BalanceForward") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataBalanceForward" runat="server" Display="Dynamic" ControlToValidate="dataBalanceForward" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataInvoiceDate" runat="server" Text="Invoice Date:" AssociatedControlID="dataInvoiceDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataInvoiceDate" Text='<%# Bind("InvoiceDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataInvoiceDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataInvoiceDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataInvoiceDate" id="calext_dataInvoiceDate" /><asp:RequiredFieldValidator ID="ReqVal_dataInvoiceDate" runat="server" Display="Dynamic" ControlToValidate="dataInvoiceDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDueDate" runat="server" Text="Due Date:" AssociatedControlID="dataDueDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDueDate" Text='<%# Bind("DueDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDueDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataDueDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataDueDate" id="calext_dataDueDate" /><asp:RequiredFieldValidator ID="ReqVal_dataDueDate" runat="server" Display="Dynamic" ControlToValidate="dataDueDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency Id:" AssociatedControlID="dataCurrencyId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCurrencyId" Text='<%# Bind("CurrencyId") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCurrencyId" runat="server" Display="Dynamic" ControlToValidate="dataCurrencyId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalFreeCredits" runat="server" Text="Total Free Credits:" AssociatedControlID="dataTotalFreeCredits" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalFreeCredits" Text='<%# Bind("TotalFreeCredits") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalFreeCredits" runat="server" Display="Dynamic" ControlToValidate="dataTotalFreeCredits" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesaler_ProductId" runat="server" Text="Wholesaler Product Id:" AssociatedControlID="dataWholesaler_ProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesaler_ProductId" Text='<%# Bind("Wholesaler_ProductId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWholesaler_ProductId" runat="server" Display="Dynamic" ControlToValidate="dataWholesaler_ProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBpayCustomerRefNumber" runat="server" Text="Bpay Customer Ref Number:" AssociatedControlID="dataBpayCustomerRefNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBpayCustomerRefNumber" Text='<%# Bind("BpayCustomerRefNumber") %>' MaxLength="30"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


