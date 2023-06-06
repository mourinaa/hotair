<%@ Control Language="C#" ClassName="ProductFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataProductTypeId" runat="server" Text="Product Type Id:" AssociatedControlID="dataProductTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataProductTypeId" DataSourceID="ProductTypeIdProductTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductTypeId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:ProductTypeDataSource ID="ProductTypeIdProductTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayNameAlt" runat="server" Text="Display Name Alt:" AssociatedControlID="dataDisplayNameAlt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayNameAlt" Text='<%# Bind("DisplayNameAlt") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescriptionAlt" runat="server" Text="Description Alt:" AssociatedControlID="dataDescriptionAlt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescriptionAlt" Text='<%# Bind("DescriptionAlt") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultOption" runat="server" Text="Default Option:" AssociatedControlID="dataDefaultOption" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataDefaultOption" SelectedValue='<%# Bind("DefaultOption") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataSupportsExternalProvisioning" runat="server" Text="Supports External Provisioning:" AssociatedControlID="dataSupportsExternalProvisioning" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataSupportsExternalProvisioning" SelectedValue='<%# Bind("SupportsExternalProvisioning") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


