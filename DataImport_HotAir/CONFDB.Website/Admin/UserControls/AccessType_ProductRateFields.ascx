<%@ Control Language="C#" ClassName="AccessType_ProductRateFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataAccessTypeId" runat="server" Text="Access Type:" AssociatedControlID="dataAccessTypeId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataAccessTypeId" DataSourceID="AccessTypeIdAccessTypeDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("AccessTypeId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:AccessTypeDataSource ID="AccessTypeIdAccessTypeDataSource" runat="server" SelectMethod="GetAll" />
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataProductRateId" runat="server" Text="Product Rate:" AssociatedControlID="dataProductRateId" /></td>
                <td>
                    <data:EntityDropDownList runat="server" ID="dataProductRateId" DataSourceID="ProductRateIdProductRateDataSource"
                        DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("ProductRateId") %>'
                        AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
                    <data:ProductRateDataSource ID="ProductRateIdProductRateDataSource" runat="server"
                        SelectMethod="GetAll" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:FormView>
