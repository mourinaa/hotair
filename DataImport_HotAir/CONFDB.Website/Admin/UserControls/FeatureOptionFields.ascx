<%@ Control Language="C#" ClassName="FeatureOptionFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureId" runat="server" Text="Feature Id:" AssociatedControlID="dataFeatureId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFeatureId" DataSourceID="FeatureIdFeatureDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FeatureId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:FeatureDataSource ID="FeatureIdFeatureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
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
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayNameAlt" runat="server" Text="Display Name Alt:" AssociatedControlID="dataDisplayNameAlt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayNameAlt" Text='<%# Bind("DisplayNameAlt") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescriptionAlt" runat="server" Text="Description Alt:" AssociatedControlID="dataDescriptionAlt" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescriptionAlt" Text='<%# Bind("DescriptionAlt") %>'  TextMode="MultiLine"  Width="250px" Rows="5"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataValue" runat="server" Text="Value:" AssociatedControlID="dataValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataValue" Text='<%# Bind("Value") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataValue" runat="server" Display="Dynamic" ControlToValidate="dataValue" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDefaultOption" runat="server" Text="Default Option:" AssociatedControlID="dataDefaultOption" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataDefaultOption" SelectedValue='<%# Bind("DefaultOption") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureOptionTypeId" runat="server" Text="Feature Option Type Id:" AssociatedControlID="dataFeatureOptionTypeId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFeatureOptionTypeId" DataSourceID="FeatureOptionTypeIdFeatureOptionTypeDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FeatureOptionTypeId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:FeatureOptionTypeDataSource ID="FeatureOptionTypeIdFeatureOptionTypeDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataRegularExpression" runat="server" Text="Regular Expression:" AssociatedControlID="dataRegularExpression" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataRegularExpression" Text='<%# Bind("RegularExpression") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


