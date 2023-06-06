<%@ Control Language="C#" ClassName="SalesPersonFields" %>
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
                    <asp:Label ID="lbldataFullName" runat="server" Text="Full Name:" AssociatedControlID="dataFullName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataFullName" Text='<%# Bind("FullName") %>' MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ReqVal_dataFullName" runat="server" Display="Dynamic"
                        ControlToValidate="dataFullName" ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEmailAddress" runat="server" Text="Email Address:" AssociatedControlID="dataEmailAddress" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataEmailAddress" Text='<%# Bind("EmailAddress") %>'
                        MaxLength="100">
                    </asp:TextBox><asp:RequiredFieldValidator ID="ReqVal_dataEmailAddress" runat="server"
                        Display="Dynamic" ControlToValidate="dataEmailAddress" ErrorMessage="Required"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="Regularexpressionvalidator2" runat="server" CssClass="ErrorMessage"
                        Display="Dynamic" ControlToValidate="dataEmailAddress" ErrorMessage="Email address is not valid."
                        ValidationExpression="^(?:[a-zA-Z0-9_'^&/+-])+(?:\.(?:[a-zA-Z0-9_'^&/+-])+)*@(?:(?:\[?(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?))\.){3}(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\]?)|(?:[a-zA-Z0-9-]+\.)+(?:[a-zA-Z]){2,}\.?)$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataExternalAgent" runat="server" Text="External Agent:" AssociatedControlID="dataExternalAgent" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataExternalAgent" SelectedValue='<%# Bind("ExternalAgent") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" />
                </td>
                <td>
                    <asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>'
                        RepeatDirection="Horizontal">
                        <asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No"></asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <%--			<tr>
        <td class="literal"><asp:Label ID="lbldataSalesManagerId" runat="server" Text="Sales Manager Id:" AssociatedControlID="dataSalesManagerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataSalesManagerId" DataSourceID="SalesManagerIdSalesPersonDataSource" DataTextField="FullName" DataValueField="Id" SelectedValue='<%# Bind("SalesManagerId") %>' AppendNullItem="true" Required="false" NullItemText="< Please Choose ...>" />
					<data:SalesPersonDataSource ID="SalesManagerIdSalesPersonDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>--%>
        </table>
    </ItemTemplate>
</asp:FormView>
