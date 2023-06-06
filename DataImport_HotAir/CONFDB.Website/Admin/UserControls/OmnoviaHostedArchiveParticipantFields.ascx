<%@ Control Language="C#" ClassName="OmnoviaHostedArchiveParticipantFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataHostedArchiveId" runat="server" Text="Hosted Archive Id:" AssociatedControlID="dataHostedArchiveId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataHostedArchiveId" Text='<%# Bind("HostedArchiveId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataHostedArchiveId" runat="server" Display="Dynamic" ControlToValidate="dataHostedArchiveId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataHostedArchiveId" runat="server" Display="Dynamic" ControlToValidate="dataHostedArchiveId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstname" runat="server" Text="Firstname:" AssociatedControlID="dataFirstname" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstname" Text='<%# Bind("Firstname") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLastname" runat="server" Text="Lastname:" AssociatedControlID="dataLastname" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLastname" Text='<%# Bind("Lastname") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCompany" runat="server" Text="Company:" AssociatedControlID="dataCompany" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCompany" Text='<%# Bind("Company") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEmail" runat="server" Text="Email:" AssociatedControlID="dataEmail" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataEmail" Text='<%# Bind("Email") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCreated" runat="server" Text="Created:" AssociatedControlID="dataCreated" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCreated" Text='<%# Bind("Created", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataCreated" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataCreated" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataCreated" id="calext_dataCreated" />
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


