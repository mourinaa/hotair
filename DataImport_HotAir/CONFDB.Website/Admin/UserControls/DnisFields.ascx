<%@ Control Language="C#" ClassName="DnisFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler" AssociatedControlID="dataWholesalerId" />--%>
                </td>
                <td>
                    <data:EntityDropDownList Visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource"
                        DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                        <Parameters>
                            <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                        </Parameters>
                    </data:WholesalerDataSource>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAccessTypeId" runat="server" Text="Access Type" AssociatedControlID="dataAccessTypeId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataAccessTypeId" DataSourceID="AccessTypeIdAccessTypeDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AccessTypeId") %>'
                        AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
                    <data:AccessTypeDataSource ID="AccessTypeIdAccessTypeDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDnisTypeId" runat="server" Text="Dnis Type" AssociatedControlID="dataDnisTypeId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataDnisTypeId" DataSourceID="DnisTypeIdDnisTypeDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("DnisTypeId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:DnisTypeDataSource ID="DnisTypeIdDnisTypeDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDnisNumber" runat="server" Text="Dnis Number:" AssociatedControlID="dataDnisNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDnisNumber" Text='<%# Bind("DnisNumber") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDialNumber" runat="server" Text="Dial Number:" AssociatedControlID="dataDialNumber" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDialNumber" Text='<%# Bind("DialNumber") %>'
                        MaxLength="50"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        MaxLength="100"></asp:TextBox>
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
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDisplayOrder" runat="server" Text="Display Order:" AssociatedControlID="dataDisplayOrder" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDisplayOrder" Text='<%# Bind("DisplayOrder") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataDisplayOrder" runat="server" Enabled="false"
                        Display="Dynamic" ControlToValidate="dataDisplayOrder" ErrorMessage="Required"></asp:RequiredFieldValidator><asp:RangeValidator
                            ID="RangeVal_dataDisplayOrder" runat="server" Display="Dynamic" ControlToValidate="dataDisplayOrder"
                            ErrorMessage="Invalid value" MaximumValue="2147483647" MinimumValue="-2147483648"
                            Type="Integer"></asp:RangeValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDefaultOption" runat="server" Text="Default Option:" AssociatedControlID="dataDefaultOption" /></td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataDefaultOption" SelectedValue='<%# Bind("DefaultOption") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No" Selected="True"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataCallFlowId" runat="server" Text="Call Flow" AssociatedControlID="dataCallFlowId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataCallFlowId" DataSourceID="CallFlowIdCallFlowDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("CallFlowId") %>'
                        AppendNullItem="false" Required="false" NullItemText="< Please Choose ...>" />
                    <data:CallFlowDataSource ID="CallFlowIdCallFlowDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataPromptSetId" runat="server" Text="Prompt Set" AssociatedControlID="dataPromptSetId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataPromptSetId" DataSourceID="PromptSetIdPromptSetDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("PromptSetId") %>'
                        AppendNullItem="false" Required="false" NullItemText="< Please Choose ...>" />
                    <data:PromptSetDataSource ID="PromptSetIdPromptSetDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
