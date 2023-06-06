<%@ Control Language="C#" ClassName="SystemExtensionLabelFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataCustomerId" Text='<%# Bind("CustomerId") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataCustomerId" runat="server" Display="Dynamic" ControlToValidate="dataCustomerId" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExtensionTypeId" runat="server" Text="Extension Type Id:" AssociatedControlID="dataExtensionTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataExtensionTypeId" DataSourceID="ExtensionTypeIdExtensionTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ExtensionTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ExtensionTypeDataSource ID="ExtensionTypeIdExtensionTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataExtensionTypeLabel" runat="server" Text="Extension Type Label:" AssociatedControlID="dataExtensionTypeLabel" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataExtensionTypeLabel" Text='<%# Bind("ExtensionTypeLabel") %>' MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataExtensionTypeLabel" runat="server" Display="Dynamic" ControlToValidate="dataExtensionTypeLabel" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerCanView" runat="server" Text="Customer Can View:" AssociatedControlID="dataCustomerCanView" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCustomerCanView" SelectedValue='<%# Bind("CustomerCanView") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorCanView" runat="server" Text="Moderator Can View:" AssociatedControlID="dataModeratorCanView" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataModeratorCanView" SelectedValue='<%# Bind("ModeratorCanView") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerCanEdit" runat="server" Text="Customer Can Edit:" AssociatedControlID="dataCustomerCanEdit" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataCustomerCanEdit" SelectedValue='<%# Bind("CustomerCanEdit") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataModeratorCanEdit" runat="server" Text="Moderator Can Edit:" AssociatedControlID="dataModeratorCanEdit" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataModeratorCanEdit" SelectedValue='<%# Bind("ModeratorCanEdit") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


