<%@ Control Language="C#" ClassName="TempExistingCodesFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCodes" runat="server" Text="Codes:" AssociatedControlID="dataCodes" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCodes" Text='<%# Bind("Codes") %>' MaxLength="16"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCodes" runat="server" Display="Dynamic" ControlToValidate="dataCodes" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataNewCode" runat="server" Text="New Code:" AssociatedControlID="dataNewCode" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataNewCode" SelectedValue='<%# Bind("NewCode") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataPriCustomerNumber" runat="server" Text="Pri Customer Number:" AssociatedControlID="dataPriCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataPriCustomerNumber" Text='<%# Bind("PriCustomerNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSecCustomerNumber" runat="server" Text="Sec Customer Number:" AssociatedControlID="dataSecCustomerNumber" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataSecCustomerNumber" Text='<%# Bind("SecCustomerNumber") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocation" runat="server" Text="Location:" AssociatedControlID="dataLocation" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocation" Text='<%# Bind("Location") %>' MaxLength="50"></asp:TextBox>
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


