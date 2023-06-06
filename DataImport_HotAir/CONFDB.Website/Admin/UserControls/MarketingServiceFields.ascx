<%@ Control Language="C#" ClassName="MarketingServiceFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler:" AssociatedControlID="dataWholesalerId" />
                </td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource"
                        DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>'
                        AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <%--<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetAll" />--%>
                    <data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
                        <Parameters>
                            <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
                        </Parameters>
                    </data:WholesalerDataSource>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataName" runat="server" Text="Name:" AssociatedControlID="dataName" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="dataName" Text='<%# Bind("Name") %>' MaxLength="100"></asp:TextBox><asp:RequiredFieldValidator
                        ID="ReqVal_dataName" runat="server" Display="Dynamic" ControlToValidate="dataName"
                        ErrorMessage="Required"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
