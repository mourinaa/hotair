<%@ Control Language="C#" ClassName="CommissionFields" %>

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
        <td class="literal"><asp:Label ID="lbldataSalesPersonId" runat="server" Text="Sales Person Id:" AssociatedControlID="dataSalesPersonId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesPersonId" DataSourceID="SalesPersonIdSalesPersonDataSource" DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesPersonId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:SalesPersonDataSource ID="SalesPersonIdSalesPersonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBilledDate" runat="server" Text="Billed Date:" AssociatedControlID="dataBilledDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBilledDate" Text='<%# Bind("BilledDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBilledDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataBilledDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataBilledDate" id="calext_dataBilledDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalCredits" runat="server" Text="Total Credits:" AssociatedControlID="dataTotalCredits" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalCredits" Text='<%# Bind("TotalCredits") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalCredits" runat="server" Display="Dynamic" ControlToValidate="dataTotalCredits" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
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
        <td class="literal"><asp:Label ID="lbldataTotalAmount" runat="server" Text="Total Amount:" AssociatedControlID="dataTotalAmount" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalAmount" Text='<%# Bind("TotalAmount") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalAmount" runat="server" Display="Dynamic" ControlToValidate="dataTotalAmount" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCommissionRate" runat="server" Text="Commission Rate:" AssociatedControlID="dataCommissionRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCommissionRate" Text='<%# Bind("CommissionRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataCommissionRate" runat="server" Display="Dynamic" ControlToValidate="dataCommissionRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalCommission" runat="server" Text="Total Commission:" AssociatedControlID="dataTotalCommission" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalCommission" Text='<%# Bind("TotalCommission") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalCommission" runat="server" Display="Dynamic" ControlToValidate="dataTotalCommission" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrencyId" runat="server" Text="Currency Id:" AssociatedControlID="dataCurrencyId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCurrencyId" DataSourceID="CurrencyIdCurrencyDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("CurrencyId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="CurrencyIdCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


