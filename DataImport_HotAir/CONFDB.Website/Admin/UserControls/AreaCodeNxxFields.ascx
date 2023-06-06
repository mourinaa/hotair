<%@ Control Language="C#" ClassName="AreaCodeNxxFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataAreaCode" runat="server" Text="Area Code:" AssociatedControlID="dataAreaCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataAreaCode" Text='<%# Bind("AreaCode") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataAreaCode" runat="server" Display="Dynamic" ControlToValidate="dataAreaCode" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocation1" runat="server" Text="Location1:" AssociatedControlID="dataLocation1" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocation1" Text='<%# Bind("Location1") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocation2" runat="server" Text="Location2:" AssociatedControlID="dataLocation2" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocation2" Text='<%# Bind("Location2") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataIsoCountryCode" runat="server" Text="Iso Country Code:" AssociatedControlID="dataIsoCountryCode" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataIsoCountryCode" Text='<%# Bind("IsoCountryCode") %>' MaxLength="3"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


