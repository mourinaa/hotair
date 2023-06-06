<%@ Control Language="C#" ClassName="Customer_FeatureFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataCustomerId" runat="server" Text="Customer Id:" AssociatedControlID="dataCustomerId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataCustomerId" DataSourceID="CustomerIdCustomerDataSource" DataTextField="PriCustomerNumber" DataValueField="Id" SelectedValue='<%# Bind("CustomerId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:CustomerDataSource ID="CustomerIdCustomerDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureId" runat="server" Text="Feature Id:" AssociatedControlID="dataFeatureId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFeatureId" DataSourceID="FeatureIdFeatureDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FeatureId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:FeatureDataSource ID="FeatureIdFeatureDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureOptionId" runat="server" Text="Feature Option Id:" AssociatedControlID="dataFeatureOptionId" /></td>
        <td>
					<data:EntityDropDownList runat="server" ID="dataFeatureOptionId" DataSourceID="FeatureOptionIdFeatureOptionDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FeatureOptionId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:FeatureOptionDataSource ID="FeatureOptionIdFeatureOptionDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataEnabled" runat="server" Text="Enabled:" AssociatedControlID="dataEnabled" /></td>
        <td>
					<asp:RadioButtonList runat="server" ID="dataEnabled" SelectedValue='<%# Bind("Enabled") %>' RepeatDirection="Horizontal"><asp:ListItem Value="True" Text="Yes" Selected="True"></asp:ListItem><asp:ListItem Value="False" Text="No"></asp:ListItem></asp:RadioButtonList>
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureOptionValue" runat="server" Text="Feature Option Value:" AssociatedControlID="dataFeatureOptionValue" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataFeatureOptionValue" Text='<%# Bind("FeatureOptionValue") %>' MaxLength="100"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


