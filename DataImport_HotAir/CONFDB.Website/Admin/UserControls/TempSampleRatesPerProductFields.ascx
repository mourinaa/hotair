<%@ Control Language="C#" ClassName="TempSampleRatesPerProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataDateInterval" runat="server" Text="Date Interval:" AssociatedControlID="dataDateInterval" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDateInterval" Text='<%# Bind("DateInterval", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataDateInterval" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataDateInterval" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataDateInterval" id="calext_dataDateInterval" /><asp:RequiredFieldValidator ID="ReqVal_dataDateInterval" runat="server" Display="Dynamic" ControlToValidate="dataDateInterval" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNumberOfPorts" runat="server" Text="Number Of Ports:" AssociatedControlID="dataNumberOfPorts" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNumberOfPorts" Text='<%# Bind("NumberOfPorts") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNumberOfPorts" runat="server" Display="Dynamic" ControlToValidate="dataNumberOfPorts" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataNumberOfPorts" runat="server" Display="Dynamic" ControlToValidate="dataNumberOfPorts" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAccessType" runat="server" Text="Access Type:" AssociatedControlID="dataAccessType" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAccessType" Text='<%# Bind("AccessType") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAccessType" runat="server" Display="Dynamic" ControlToValidate="dataAccessType" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataAccessType" runat="server" Display="Dynamic" ControlToValidate="dataAccessType" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataWholesalerId" Text='<%# Bind("WholesalerId") %>' MaxLength="10"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


