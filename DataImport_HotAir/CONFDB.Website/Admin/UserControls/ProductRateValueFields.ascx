<%@ Control Language="C#" ClassName="ProductRateValueFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate Id:" AssociatedControlID="dataProductRateId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductRateId" DataSourceID="ProductRateIdProductRateDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductRateId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductRateDataSource ID="ProductRateIdProductRateDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSellRate" runat="server" Text="Sell Rate:" AssociatedControlID="dataSellRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSellRate" Text='<%# Bind("SellRate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSellRate" runat="server" Display="Dynamic" ControlToValidate="dataSellRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataSellRate" runat="server" Display="Dynamic" ControlToValidate="dataSellRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSellRateCurrencyId" runat="server" Text="Sell Rate Currency Id:" AssociatedControlID="dataSellRateCurrencyId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSellRateCurrencyId" DataSourceID="SellRateCurrencyIdCurrencyDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("SellRateCurrencyId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="SellRateCurrencyIdCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBuyRate" runat="server" Text="Buy Rate:" AssociatedControlID="dataBuyRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBuyRate" Text='<%# Bind("BuyRate") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataBuyRate" runat="server" Display="Dynamic" ControlToValidate="dataBuyRate" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataBuyRate" runat="server" Display="Dynamic" ControlToValidate="dataBuyRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataBuyRateCurrencyId" runat="server" Text="Buy Rate Currency Id:" AssociatedControlID="dataBuyRateCurrencyId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataBuyRateCurrencyId" DataSourceID="BuyRateCurrencyIdCurrencyDataSource" DataTextField="LongName" DataValueField="Id" SelectedValue='<%# Bind("BuyRateCurrencyId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CurrencyDataSource ID="BuyRateCurrencyIdCurrencyDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultOption" runat="server" Text="Default Option:" AssociatedControlID="dataDefaultOption" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDefaultOption" Text='<%# Bind("DefaultOption") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDefaultOption" runat="server" Display="Dynamic" ControlToValidate="dataDefaultOption" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDefaultOption" runat="server" Display="Dynamic" ControlToValidate="dataDefaultOption" ErrorMessage="Invalid value" MaximumValue="255" MinimumValue="0" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataStartDate" runat="server" Text="Start Date:" AssociatedControlID="dataStartDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataStartDate" Text='<%# Bind("StartDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataStartDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataStartDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataStartDate" id="calext_dataStartDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


