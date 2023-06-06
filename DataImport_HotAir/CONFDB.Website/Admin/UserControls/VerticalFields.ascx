<%@ Control Language="C#" ClassName="VerticalFields" %>

<asp:FormView ID="FormView1" runat="server">
	<ItemTemplate>
		<table border="0" cellpadding="3" cellspacing="1">
			<tr>
        <td class="literal"><asp:Label ID="lbldataWholesalerId" Visible="False" runat="server" Text="Wholesaler Id:" AssociatedControlID="dataWholesalerId" /></td>
        <td>
					<data:EntityDropDownList Visible="false" runat="server" ID="dataWholesalerId" DataSourceID="WholesalerIdWholesalerDataSource" DataTextField="CompanyName" DataValueField="Id" SelectedValue='<%# Bind("WholesalerId") %>' AppendNullItem="false" Required="true" NullItemText="< Please Choose ...>" ErrorText="Required" />
					<data:WholesalerDataSource ID="WholesalerIdWholesalerDataSource" runat="server" SelectMethod="GetById">
					    <Parameters>
					        <asp:Parameter DefaultValue="<%$ AppSettings: WholesalerID %>" Name="Id" Type="String" />
					    </Parameters>
					</data:WholesalerDataSource>
					
				</td>
			</tr>
			<tr>
        <td class="literal"><asp:Label ID="lbldataDescription" runat="server" Text="Description:" AssociatedControlID="dataDescription" /></td>
        <td>
					<asp:TextBox runat="server" ID="dataDescription" Text='<%# Bind("Description") %>' MaxLength="50"></asp:TextBox>
				</td>
			</tr>
			
		</table>

	</ItemTemplate>
</asp:FormView>


