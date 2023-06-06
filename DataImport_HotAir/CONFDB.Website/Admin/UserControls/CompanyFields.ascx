<%@ Control Language="C#" ClassName="CompanyFields" %>
<asp:FormView ID="FormView1" runat="server">
    <ItemTemplate>
        <table border="0" cellpadding="3" cellspacing="1">
            <tr>
                <td class="literal">
                    <%--<asp:Label ID="lbldataWholesalerId" runat="server" Text="Wholesaler" AssociatedControlID="dataWholesalerId" />--%>
                </td>
                <td>
                    <data:EntityDropDownList Visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
					    <Parameters>
					        <data:SqlParameter DefaultValue="<%$ AppSettings:WholesalerID %>" Name="Id" Type="string">
					        </data:SqlParameter>
					    </Parameters>
					</data:WholesalerDataSource>
                </td>
            </tr>
            <tr>
                <td class="literal">
                    <asp:Label ID="lbldataDescription" runat="server" Text="Company Name:" AssociatedControlID="dataDescription" /></td>
                <td>
                    <asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>'
                        MaxLength="50" Width="300px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="dataDescription"></asp:RequiredFieldValidator>
                </td>
            </tr>
			
        </table>
    </ItemTemplate>
</asp:FormView>
