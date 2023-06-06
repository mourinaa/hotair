<%@ Control Language="C#" ClassName="Wholesaler_Product_FeatureFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesaler_ProductId" runat="server" Text="Wholesaler Product:" AssociatedControlID="dataWholesaler_ProductId" /></td>
        <td>
					<data:EntityDropDownList ReadOnly="<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>" runat="server" ID="dataWholesaler_ProductId" DataSourceID="Wholesaler_ProductIdWholesaler_ProductDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("Wholesaler_ProductId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:Wholesaler_ProductDataSource ID="Wholesaler_ProductIdWholesaler_ProductDataSource" runat="server" SelectMethod="GetAll"  />
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataFeatureId" runat="server" Text="Feature:" AssociatedControlID="dataFeatureId" /></td>
        <td>
					<data:EntityDropDownList ReadOnly="<%# (FormView1.DefaultMode == FormViewMode.Insert) ? false : true %>" runat="server" ID="dataFeatureId" DataSourceID="FeatureIdFeatureDataSource" DataTextField="Name" DataValueField="Id" SelectedValue='<%# Bind("FeatureId") %>' AppendNullItem="true" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
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


