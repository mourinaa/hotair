<%@ Control Language="C#" ClassName="AverageRatesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUsageMonth" runat="server" Text="Usage Month:" AssociatedControlID="dataUsageMonth" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUsageMonth" Text='<%# Bind("UsageMonth", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataUsageMonth" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataUsageMonth" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataUsageMonth" id="calext_dataUsageMonth" /><asp:RequiredFieldValidator ID="ReqVal_dataUsageMonth" runat="server" Display="Dynamic" ControlToValidate="dataUsageMonth" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate Id:" AssociatedControlID="dataProductRateId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductRateId" Text='<%# Bind("ProductRateId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataProductRateId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProductRateId" runat="server" Display="Dynamic" ControlToValidate="dataProductRateId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataWholesalerId" runat="server" Display="Dynamic" ControlToValidate="dataWholesalerId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMedianRetailRate" runat="server" Text="Median Retail Rate:" AssociatedControlID="dataMedianRetailRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMedianRetailRate" Text='<%# Bind("MedianRetailRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMedianRetailRate" runat="server" Display="Dynamic" ControlToValidate="dataMedianRetailRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAverageRetailRate" runat="server" Text="Average Retail Rate:" AssociatedControlID="dataAverageRetailRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAverageRetailRate" Text='<%# Bind("AverageRetailRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAverageRetailRate" runat="server" Display="Dynamic" ControlToValidate="dataAverageRetailRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeightedAverageRetailRate" runat="server" Text="Weighted Average Retail Rate:" AssociatedControlID="dataWeightedAverageRetailRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeightedAverageRetailRate" Text='<%# Bind("WeightedAverageRetailRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWeightedAverageRetailRate" runat="server" Display="Dynamic" ControlToValidate="dataWeightedAverageRetailRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMedianWsRate" runat="server" Text="Median Ws Rate:" AssociatedControlID="dataMedianWsRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMedianWsRate" Text='<%# Bind("MedianWsRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataMedianWsRate" runat="server" Display="Dynamic" ControlToValidate="dataMedianWsRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAverageWsRate" runat="server" Text="Average Ws Rate:" AssociatedControlID="dataAverageWsRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAverageWsRate" Text='<%# Bind("AverageWsRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataAverageWsRate" runat="server" Display="Dynamic" ControlToValidate="dataAverageWsRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWeightedAverageWsRate" runat="server" Text="Weighted Average Ws Rate:" AssociatedControlID="dataWeightedAverageWsRate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWeightedAverageWsRate" Text='<%# Bind("WeightedAverageWsRate") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataWeightedAverageWsRate" runat="server" Display="Dynamic" ControlToValidate="dataWeightedAverageWsRate" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUsageSeconds" runat="server" Text="Usage Seconds:" AssociatedControlID="dataUsageSeconds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUsageSeconds" Text='<%# Bind("UsageSeconds") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUsageSeconds" runat="server" Display="Dynamic" ControlToValidate="dataUsageSeconds" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUsageSeconds" runat="server" Display="Dynamic" ControlToValidate="dataUsageSeconds" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUsageQuantity" runat="server" Text="Usage Quantity:" AssociatedControlID="dataUsageQuantity" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUsageQuantity" Text='<%# Bind("UsageQuantity") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUsageQuantity" runat="server" Display="Dynamic" ControlToValidate="dataUsageQuantity" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUsageQuantity" runat="server" Display="Dynamic" ControlToValidate="dataUsageQuantity" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


