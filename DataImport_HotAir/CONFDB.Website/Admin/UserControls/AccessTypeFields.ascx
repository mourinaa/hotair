<%@ Control Language="C#" ClassName="AccessTypeFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDisplayName" runat="server" Text="Display Name:" AssociatedControlID="dataDisplayName" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDisplayName" Text='<%# Bind("DisplayName") %>'
                        MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataDisplayName"
                            runat="server" Display="Dynamic" ControlToValidate="dataDisplayName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        TextMode="MultiLine" Width="250px" Rows="5"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataValue" runat="server" Text="Value:" AssociatedControlID="dataValue" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataValue" Text='<%# Bind("Value") %>'></asp:TextBox>
                    <%-- Disabled for now as Value is not required.  --%>
                    <asp:RequiredFieldValidator Enabled="false"
                        ID="ReqVal_dataValue" runat="server" Display="Dynamic" ControlToValidate="dataValue"
                        ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator ID="RangeVal_dataValue"
                            runat="server" Display="Dynamic" ControlToValidate="dataValue" ErrorMessage="Invalid value"
                            MaximumValue="2147483647" MinimumValue="-2147483648" Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataRetailLdApplicable" runat="server" Text="Retail Ld Applicable:"
                        AssociatedControlID="dataRetailLdApplicable" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataRetailLdApplicable" SelectedValue='<%# Bind("RetailLdApplicable") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWholesaleLdApplicable" runat="server" Text="Wholesale Ld Applicable:"
                        AssociatedControlID="dataWholesaleLdApplicable" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataWholesaleLdApplicable" SelectedValue='<%# Bind("WholesaleLdApplicable") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataBillable" runat="server" Text="Billable:" AssociatedControlID="dataBillable" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataBillable" SelectedValue='<%# Bind("Billable") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
