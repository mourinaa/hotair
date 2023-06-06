<%@ Control Language="C#" ClassName="ConferencingSummaryFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataBilledDate" runat="server" Text="Billed Date:" AssociatedControlID="dataBilledDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataBilledDate" Text='<%# Bind("BilledDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataBilledDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataBilledDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataBilledDate" id="calext_dataBilledDate" /><asp:RequiredFieldValidator ID="ReqVal_dataBilledDate" runat="server" Display="Dynamic" ControlToValidate="dataBilledDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductId" runat="server" Text="Product Id:" AssociatedControlID="dataProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataProductId" Text='<%# Bind("ProductId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataProductId" runat="server" Display="Dynamic" ControlToValidate="dataProductId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataProductId" runat="server" Display="Dynamic" ControlToValidate="dataProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCurrency" runat="server" Text="Currency:" AssociatedControlID="dataCurrency" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCurrency" Text='<%# Bind("Currency") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCurrency" runat="server" Display="Dynamic" ControlToValidate="dataCurrency" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalSeconds" runat="server" Text="Local Seconds:" AssociatedControlID="dataLocalSeconds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalSeconds" Text='<%# Bind("LocalSeconds") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLocalSeconds" runat="server" Display="Dynamic" ControlToValidate="dataLocalSeconds" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLocalSeconds" runat="server" Display="Dynamic" ControlToValidate="dataLocalSeconds" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLdSeconds" runat="server" Text="Ld Seconds:" AssociatedControlID="dataLdSeconds" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLdSeconds" Text='<%# Bind("LdSeconds") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataLdSeconds" runat="server" Display="Dynamic" ControlToValidate="dataLdSeconds" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataLdSeconds" runat="server" Display="Dynamic" ControlToValidate="dataLdSeconds" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalBridge" runat="server" Text="Total Bridge:" AssociatedControlID="dataTotalBridge" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalBridge" Text='<%# Bind("TotalBridge") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalBridge" runat="server" Display="Dynamic" ControlToValidate="dataTotalBridge" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalLd" runat="server" Text="Total Ld:" AssociatedControlID="dataTotalLd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalLd" Text='<%# Bind("TotalLd") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalLd" runat="server" Display="Dynamic" ControlToValidate="dataTotalLd" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTotalMiscellaneous" runat="server" Text="Total Miscellaneous:" AssociatedControlID="dataTotalMiscellaneous" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTotalMiscellaneous" Text='<%# Bind("TotalMiscellaneous") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataTotalMiscellaneous" runat="server" Display="Dynamic" ControlToValidate="dataTotalMiscellaneous" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


