<%@ Control Language="C#" ClassName="ModeratorXtimeUserFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorId" runat="server" Text="Moderator Id:" AssociatedControlID="dataModeratorId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataModeratorId" Text='<%# Bind("ModeratorId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataModeratorId" runat="server" Display="Dynamic" ControlToValidate="dataModeratorId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstCallDate" runat="server" Text="First Call Date:" AssociatedControlID="dataFirstCallDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstCallDate" Text='<%# Bind("FirstCallDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataFirstCallDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataFirstCallDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataFirstCallDate" id="calext_dataFirstCallDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstCallProductId" runat="server" Text="First Call Product Id:" AssociatedControlID="dataFirstCallProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstCallProductId" Text='<%# Bind("FirstCallProductId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFirstCallProductId" runat="server" Display="Dynamic" ControlToValidate="dataFirstCallProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFirstCallNotes" runat="server" Text="First Call Notes:" AssociatedControlID="dataFirstCallNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFirstCallNotes" Text='<%# Bind("FirstCallNotes") %>' MaxLength="128"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThirdCallDate" runat="server" Text="Third Call Date:" AssociatedControlID="dataThirdCallDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThirdCallDate" Text='<%# Bind("ThirdCallDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataThirdCallDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataThirdCallDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataThirdCallDate" id="calext_dataThirdCallDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThirdCallProductId" runat="server" Text="Third Call Product Id:" AssociatedControlID="dataThirdCallProductId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThirdCallProductId" Text='<%# Bind("ThirdCallProductId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataThirdCallProductId" runat="server" Display="Dynamic" ControlToValidate="dataThirdCallProductId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataThirdCallNotes" runat="server" Text="Third Call Notes:" AssociatedControlID="dataThirdCallNotes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataThirdCallNotes" Text='<%# Bind("ThirdCallNotes") %>' MaxLength="128"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecondCallDate" runat="server" Text="Second Call Date:" AssociatedControlID="dataSecondCallDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecondCallDate" Text='<%# Bind("SecondCallDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataSecondCallDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataSecondCallDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataSecondCallDate" id="calext_dataSecondCallDate" />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataUserId" runat="server" Text="User Id:" AssociatedControlID="dataUserId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataUserId" Text='<%# Bind("UserId") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataUserId" runat="server" Display="Dynamic" ControlToValidate="dataUserId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


