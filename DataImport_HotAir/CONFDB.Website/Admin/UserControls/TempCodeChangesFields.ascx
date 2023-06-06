<%@ Control Language="C#" ClassName="TempCodeChangesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="10"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataPriCustomerNumber" runat="server" Display="Dynamic" ControlToValidate="dataPriCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecCustomerNumber" Text='<%# Bind("SecCustomerNumber") %>' MaxLength="6"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataSecCustomerNumber" runat="server" Display="Dynamic" ControlToValidate="dataSecCustomerNumber" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrigModCode" runat="server" Text="Orig Mod Code:" AssociatedControlID="dataOrigModCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrigModCode" Text='<%# Bind("OrigModCode") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOrigModCode" runat="server" Display="Dynamic" ControlToValidate="dataOrigModCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataOrigPassCode" runat="server" Text="Orig Pass Code:" AssociatedControlID="dataOrigPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataOrigPassCode" Text='<%# Bind("OrigPassCode") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataOrigPassCode" runat="server" Display="Dynamic" ControlToValidate="dataOrigPassCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpectedOrigModCode" runat="server" Text="Expected Orig Mod Code:" AssociatedControlID="dataExpectedOrigModCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpectedOrigModCode" Text='<%# Bind("ExpectedOrigModCode") %>' MaxLength="8"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExpectedOrigPassCode" runat="server" Text="Expected Orig Pass Code:" AssociatedControlID="dataExpectedOrigPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExpectedOrigPassCode" Text='<%# Bind("ExpectedOrigPassCode") %>' MaxLength="8"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewModCode" runat="server" Text="New Mod Code:" AssociatedControlID="dataNewModCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNewModCode" Text='<%# Bind("NewModCode") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNewModCode" runat="server" Display="Dynamic" ControlToValidate="dataNewModCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewPassCode" runat="server" Text="New Pass Code:" AssociatedControlID="dataNewPassCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataNewPassCode" Text='<%# Bind("NewPassCode") %>' MaxLength="8"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataNewPassCode" runat="server" Display="Dynamic" ControlToValidate="dataNewPassCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAppliedDate" runat="server" Text="Applied Date:" AssociatedControlID="dataAppliedDate" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAppliedDate" Text='<%# Bind("AppliedDate", "{0:d}") %>' MaxLength="10"></asp:TextBox><asp:ImageButton ID="cal_dataAppliedDate" runat="server" SkinID="CalendarImageButton" OnClientClick="javascript:return false;" /><ajaxToolkit:CalendarExtender runat="server" TargetControlID="dataAppliedDate" CssClass="ajaxToolkit-CalendarExtender" Format="MM/dd/yyyy" PopupButtonID="cal_dataAppliedDate" id="calext_dataAppliedDate" /><asp:RequiredFieldValidator ID="ReqVal_dataAppliedDate" runat="server" Display="Dynamic" ControlToValidate="dataAppliedDate" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


