<%@ Control Language="C#" ClassName="GlPostingTypeFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataMultiplier" runat="server" Text="Multiplier:" AssociatedControlID="dataMultiplier" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataMultiplier" Text='<%# Bind("Multiplier") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataMultiplier" runat="server" Display="Dynamic" ControlToValidate="dataMultiplier" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataMultiplier" runat="server" Display="Dynamic" ControlToValidate="dataMultiplier" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCalculateTax" runat="server" Text="Calculate Tax:" AssociatedControlID="dataCalculateTax" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCalculateTax" SelectedValue='<%# Bind("CalculateTax") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


