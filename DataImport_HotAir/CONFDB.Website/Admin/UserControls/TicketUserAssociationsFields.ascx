<%@ Control Language="C#" ClassName="TicketUserAssociationsFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserId" Text='<%# Bind("UserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataTicketUserId" runat="server" Text="Ticket User Id:" AssociatedControlID="dataTicketUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataTicketUserId" Text='<%# Bind("TicketUserId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataTicketUserId" runat="server" Display="Dynamic" ControlToValidate="dataTicketUserId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataTicketUserId" runat="server" Display="Dynamic" ControlToValidate="dataTicketUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


