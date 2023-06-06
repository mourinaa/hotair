<%@ Control Language="C#" ClassName="PrevInvoicesFields" %>

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
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrevBal" runat="server" Text="Prev Bal:" AssociatedControlID="dataPrevBal" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrevBal" Text='<%# Bind("PrevBal") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataPrevBal" runat="server" Display="Dynamic" ControlToValidate="dataPrevBal" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrevPerStart" runat="server" Text="Prev Per Start:" AssociatedControlID="dataPrevPerStart" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrevPerStart" Text='<%# Bind("PrevPerStart", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPrevPerStart" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataPrevPerStart" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataPrevPerStart" id="calext_dataPrevPerStart" /><asp:RequiredFieldValidator ID="ReqVal_dataPrevPerStart" runat="server" Display="Dynamic" ControlToValidate="dataPrevPerStart" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPrevPerEnd" runat="server" Text="Prev Per End:" AssociatedControlID="dataPrevPerEnd" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPrevPerEnd" Text='<%# Bind("PrevPerEnd", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataPrevPerEnd" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataPrevPerEnd" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataPrevPerEnd" id="calext_dataPrevPerEnd" /><asp:RequiredFieldValidator ID="ReqVal_dataPrevPerEnd" runat="server" Display="Dynamic" ControlToValidate="dataPrevPerEnd" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


