<%@ Control Language="C#" ClassName="StateFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataId" runat="server" Text="Id:" AssociatedControlID="dataId" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataId" Text='<%# Bind("Id") %>' MaxLength="3"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataId" runat="server" Display="Dynamic" ControlToValidate="dataId" ErrorMessage="Required"></asp:RequiredFieldValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataCountryId" runat="server" Text="Country Id:" AssociatedControlID="dataCountryId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCountryId" DataSourceID="CountryIdCountryDataSource" DataTextField="Description" DataValueField="Id" SelectedValue='<%# Bind("CountryId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CountryDataSource ID="CountryIdCountryDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLongName" runat="server" Text="Long Name:" AssociatedControlID="dataLongName" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLongName" Text='<%# Bind("LongName") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFederalTax" runat="server" Text="Federal Tax:" AssociatedControlID="dataFederalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFederalTax" Text='<%# Bind("FederalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataFederalTax" runat="server" Display="Dynamic" ControlToValidate="dataFederalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalTax" runat="server" Text="Local Tax:" AssociatedControlID="dataLocalTax" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataLocalTax" Text='<%# Bind("LocalTax") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataLocalTax" runat="server" Display="Dynamic" ControlToValidate="dataLocalTax" ErrorMessage="Invalid value" MaximumValue="999999999" MinimumValue="-999999999" Type="Double"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox><asp:RangeValidator ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Invalid value" MaximumValue="32767" MinimumValue="-32768" Type="Integer"></asp:RangeValidator>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataLocalOnFederalTax" runat="server" Text="Local On Federal Tax:" AssociatedControlID="dataLocalOnFederalTax" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataLocalOnFederalTax" SelectedValue='<%# Bind("LocalOnFederalTax") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


